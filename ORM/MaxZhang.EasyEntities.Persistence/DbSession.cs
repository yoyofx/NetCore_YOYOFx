using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;
using System.Xml.Linq;
using MaxZhang.EasyEntities.Persistence.Linq;
using MaxZhang.EasyEntities.Persistence.Mapping;
using System.Linq.Expressions;
using System.ComponentModel.Design;
using MaxZhang.EasyEntities.Persistence.Provider;
using MaxZhang.EasyEntities.Persistence.Provider.SQLServer;
using MaxZhang.EasyEntities.Persistence.SqlMap;

namespace MaxZhang.EasyEntities.Persistence
{
    /// <summary>
    /// 数据访问对象，每个Session打开一个数据连接
    /// </summary>
    [DebuggerDisplay("SQL = {Log}")]
    public class DbSession : IDisposable
    {
        /// <summary>
        /// 数据提供者
        /// </summary>
        public IDataProvider Provider { get; set; }
        /// <summary>
        /// 延时SQL语句集合
        /// </summary>
        public List<Command> Commands { get; private set; }

        /// <summary>
        /// 延时执行SQL语句的数量
        /// </summary>
        public int CommandCount
        {
            get
            {
                if (Commands == null)
                {
                    return 0;
                }
                return Commands.Count;
            }
        }

        public bool HasCommand
        {
            get { return CommandCount > 0; }
        }

        private volatile static DbSession _default = null;
        private static readonly object lockObject = new object();
        /// <summary>
        /// 默认的数据访问对象
        /// </summary>
        public static DbSession Default
        {
            get
            {
                if (_default == null)
                {
                    lock (lockObject)
                    {
                        if (_default == null)
                            _default = new DbSession();
                    }
                }

                return _default;
            }
        }

        public DbSession()
            : this(ProviderFactory.GetProvider())
        {
        }

        public DbSession(IDataProvider provider)
        {
            if (provider == null)
            {
                throw new ArgumentNullException("provider");
            }
            Provider = provider;
          
            Commands = new List<Command>();


        }

       /// <summary>
       /// 执行一条SQL语句
       /// </summary>
       /// <param name="command">SQL命令对象</param>
       /// <example>session.Execute(new Command("select * from a where a1='001' ",null))</example>
       public void Execute(Command command)
       {
           Provider.Execute(command);
       }
        /// <summary>
       /// 执行一条SQL语句返回第一行第一列的值
        /// </summary>
       /// <param name="command">SQL命令对象</param>
       /// <returns>返回第一行第一列的值</returns>
        public object ScalarQuery(Command command)
        {
           return Provider.QueryScalar(command);
        }

        /// <summary>
        /// 执行一条SQL语句返回查询结果
        /// </summary>
        /// <param name="command">SQL命令对象</param>
        /// <returns>IDataReader</returns>
        public IDataReader ReaderQuery(Command command)
        {
            return Provider.QueryData(command);
        }


        /// <summary>
        /// 执行一条SQL语句返回查询结果
        /// </summary>
        /// <param name="command">SQL命令对象</param>
        /// <returns>DataSet</returns>
        public DataSet DataSetQuery(Command command)
        {
            return Provider.Query(command);
        }

        /// <summary>
        /// 更新DataSet，如果DataSet中有行添加、删除或数据更新则按每条数据执行相应的SQL语句。
        /// 必须对已用Query对象查询出来的DataSet或者在Command中指定TableName。
        /// </summary>
        /// <param name="ds"></param>
        public void UpdateDataSet<T>(DataSet ds,QueryConditional<T> whereObject=null) where T:DbObject
        {
            var table = ds.Tables[0];
            string tableName = string.Empty;
            if (whereObject != null)
                tableName = DbMetaDataManager.GetTableName(typeof(T));
            else
                tableName = table.TableName;

            if(string.IsNullOrEmpty(tableName))
                throw new InvalidOperationException("表名不能为空！");
            string whereSQL = null;
            if( whereObject!=null)
                whereSQL = whereObject.ToString();
            Provider.UpdateDataSet(ds,whereSQL);
        }

        /// <summary>
        /// 创建查询对象
        /// </summary>
        /// <returns>Query</returns>
        public SelectQuery<TModel> CreateQuery<TModel>()
        {
            object model = default(TModel);

            if (!_modelTypeCable.TryGetValue(typeof(TModel), out model))
            {
                model = Activator.CreateInstance(typeof(TModel));
                _modelTypeCable.TryAdd(typeof(TModel), model);
                DbMetaDataManager.GetMetaDatas(typeof(TModel));
            }

            return new SelectQuery<TModel>(Provider);
        }

  
        /// <summary>
        /// 创建Linq查询对象
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <returns></returns>
        public LinqQuery<TModel> CreateLinq<TModel>()
        {
            object model = default(TModel);

            if (!_modelTypeCable.TryGetValue(typeof(TModel), out model))
            {
                model = Activator.CreateInstance(typeof(TModel));
                _modelTypeCable.TryAdd(typeof(TModel),model);
                DbMetaDataManager.GetMetaDatas(typeof(TModel));
            }
          
            
            return new LinqQuery<TModel>(Provider);
        }

      


        public static readonly ConcurrentDictionary<Type, object> _modelTypeCable = new ConcurrentDictionary<Type, object>();

        /// <summary>
        /// 立即执行插入语句
        /// </summary>
        /// <typeparam name="TModel">模型名称</typeparam>
        /// <param name="objExp">插入对象表达式，表达要插入的列信息</param>
        /// <example> session.Insert(u => new AdminUser1 {ID = "5", NameA = "maxzhang"}).Where(p => p.Age > 5).Go;</example>
        public void Insert<TModel>(Expression<Func<TModel,object>> objExp) where TModel : DbObject
        {
            var tableName = DbMetaDataManager.GetTableName(typeof(TModel));
            FieldsFormater format = new FieldsFormater(Provider);
            format.Visit(objExp);
            string fieldNames =  string.Join(",", format.Parameters.Keys);
            string paramterNames = string.Join(",", format.Parameters.Values.Select(p => p.Name));
            string template = string.Format("INSERT INTO {0}({1}) VALUES({2})", tableName, fieldNames, paramterNames);
            var ps = format.Parameters.Values.Where(p => p.IsMethodType == false).ToList();
            var command = new Command(template,ps);   
            Provider.Execute(command);
        }

     

        /// <summary>
        /// 立即执行更新语句
        /// </summary>
        /// <typeparam name="TModel">模型名称</typeparam>
        /// <param name="objExp">更新对象表达式，表示要更新的列信息</param>
        /// <returns>将返回一个操作接口，此接口会有一个Where方法和Go方法，Where表示要添加条件，Go则表示立即执行语句。</returns>
        /// <example> session.Update(u => new AdminUser1 {ID = "5", NameA = "maxzhang"}).Where(p => p.Age > 5).Go</example>
        public IOperatorWhere<TModel> Update<TModel>(Expression<Func<TModel, object>> objExp) where TModel : DbObject
        {
            var tableName = DbMetaDataManager.GetTableName(typeof(TModel));
            FieldsFormater format = new FieldsFormater(Provider);
            format.Visit(objExp);
            string paramterNameAndValues = string.Join(",", format.Parameters.Select(kv => kv.Key + "=" + kv.Value.Name));
           
            string template = string.Format("Update {0} SET {1} Where 1=1", tableName, paramterNameAndValues);
            var ps = format.Parameters.Values.Where(p => p.IsMethodType == false).ToList();
           
            return new OperatorWhereObject<TModel>(Provider, template, ps);
        }
        /// <summary>
        /// 立即执行删除记录语句
        /// </summary>
        /// <typeparam name="TModel">模型名称</typeparam>
        /// <returns>将返回一个操作接口，此接口会有一个Where方法和Go方法，Where表示要添加条件，Go则表示立即执行语句。</returns>
        ///<example>session.Delete().Where(u => u.ID == "5");</example>
        public IOperatorWhere<TModel> Delete<TModel>() where TModel : DbObject
        {
            var tableName = DbMetaDataManager.GetTableName(typeof(TModel));
            string template = string.Format("DELETE From {0} Where 1=1", tableName);
            return new OperatorWhereObject<TModel>(Provider, template,null);
        }

       /// <summary>
        /// 添加实体对象到数据库，延时操作
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <param name="entity">对象</param>
        public void InsertTransaction<T>(T entity) where T : DbObject
        {
            AddCommand<T>(TextType.Insert, entity);
        }

        /// <summary>
        /// 更新实体对象到数据库，延时操作
        /// 
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <param name="entity">对象</param>
        public void UpdateTransaction<T>(T entity) where T : DbObject
        {
            AddCommand<T>(TextType.Update, entity);
        }

        /// <summary>
        /// 移除实体对象到数据库，延时操作
        /// 通常表示对象在数据库中的某种状态
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <param name="entity">对象</param>
        public void RemoveTransaction<T>(T entity) where T : DbObject
        {
            AddCommand<T>(TextType.Remove, entity);
        }


        /// <summary>
        /// 从数据库删除实体对象，延时操作
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <param name="entity">对象</param>
        public void DeleteTransaction<T>(T entity) where T : DbObject
        {
            AddCommand<T>(TextType.Delete, entity);
        }
        /// <summary>
        /// 批量添加，延时操作
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entities"></param>
        public void InsertAllTransaction<T>(List<T> entities) where T : DbObject
        {
            foreach (T entity in entities)
            {
                InsertTransaction<T>(entity);
            }
        }
        /// <summary>
        /// 批量更新，延时操作
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entities"></param>
        public void UpdateAllTransaction<T>(List<T> entities) where T : DbObject
        {
            foreach (T entity in entities)
            {
                UpdateTransaction<T>(entity);
            }
        }

        /// <summary>
        /// 批量移除，延时操作
        /// </summary>
        public void RemoveAllTransaction<T>(List<T> entities) where T : DbObject
        {
            foreach (T entity in entities)
            {
                RemoveTransaction<T>(entity);
            }
        }


        /// <summary>
        /// 批量删除，延时操作
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entities"></param>
        public void DeleteAllTransaction<T>(List<T> entities) where T : DbObject
        {
            foreach (T entity in entities)
            {
                DeleteTransaction<T>(entity);
            }
        }

        /// <summary>
        /// 提交并执行所有操作
        /// </summary>
        public void SubmitChanges()
        {
            if (CommandCount > 1)
            {
                Provider.Execute(Commands);
            }
            else if (CommandCount > 0)
            {
                Provider.Execute(Commands[0]);
            }
            if (Commands != null)
            {
                Commands.Clear();
            }
        }

        public void Dispose()
        {
            _modelTypeCable.Clear();
           
            if (Commands != null)
            {
                Commands.Clear();
            }
            _default = null;
            Provider.Dispose();
        }

        public override string ToString()
        {
            if (HasCommand)
            {
                StringBuilder sb = new StringBuilder();
                foreach (Command command in Commands)
                {
                    sb.AppendLine(command.ToString());
                }
                return sb.ToString();
            }
            return String.Empty;
        }

        public string Log { get { return Provider.Log; }}


        private void AddCommand<T>(TextType textType, T entity) where T:DbObject
        {
            Command command = null;
         
            switch (textType)
            {
                case TextType.Insert:
                    command = TableTemplateMethod.GetInstertCommand<T>(entity ,Provider.ParamPrefix);
                    break;
                case TextType.Remove:
                    command = TableTemplateMethod.GetRemoveCommand(entity, Provider.ParamPrefix);
                    break;
                case TextType.Update:
                    command = TableTemplateMethod.GetUpdateCommand<T>(entity, Provider.ParamPrefix);
                    break;
                case TextType.Delete:
                    command = TableTemplateMethod.GetDeleteCommand<T>(entity, Provider.ParamPrefix);
                    break;
            }
            if (command != null)
            {
                if (Commands == null)
                {
                    Commands = new List<Command>();
                }
                Commands.Add(command);
            }
        }

        /// <summary>
        /// 得到SQL-Map命令对象
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public SqlMapCommand GetCommandInfo(string name)
        {
            SqlMapCommand commandInfo =null;
            if (sqlMaps.TryGetValue(name, out commandInfo))
            {
                commandInfo.DataProvider = this.Provider;
                return commandInfo;
            }
            else
            {
                throw new NotSupportedException("没有对应的SQL命令函数!");
            }
        }




        public static void AddMap(string filePath)
        {
            StreamReader sr = new StreamReader(filePath);
            string xml = sr.ReadToEnd();
            sr.Close();
            var doc = XDocument.Parse(xml);
            var root = doc.Element("Root");
            var sqlMapList= root.Elements().ToList();

            foreach (var sm in sqlMapList)
            {
                var item = new SqlMapCommand();
                item.ReturnType = sm.Attribute("Type").Value;
                item.Name = sm.Attribute("Name").Value;
                item.Memo = sm.Attribute("Memo").Value;
                item.SQL = sm.Value;
                item.SQLType = root.Attribute("Type").Value;
                SetParameters(item);
                try
                {
                    sqlMaps.Add(item.Name, item);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            
        }

        private static void SetParameters(SqlMapCommand command)
        {
            
            Regex regex = new Regex(@"#(\w+):(\w+)[,]?(out|input)?#");
            var ms =  regex.Matches(command.SQL);
            foreach (Match m in ms)
            {
                if (m.Success)   // parameter of word
                {
                    SqlMapParameter p = new SqlMapParameter();
                    p.Name =  m.Groups[1].Value;
                    p.Type = Type.GetType("System." + m.Groups[2].Value);
                    p.Direction = m.Groups[3].Value == "out"? ParameterDirection.Output
                                             : ParameterDirection.Input;
                             
                    command.Parameters.Add(p);
                }
            }
          
            
        }


        public static Dictionary<string, SqlMapCommand> sqlMaps = new Dictionary<string, SqlMapCommand>();

        private enum TextType
        {
            Insert,
            Remove,
            Update,
            Delete
        }
    }
}