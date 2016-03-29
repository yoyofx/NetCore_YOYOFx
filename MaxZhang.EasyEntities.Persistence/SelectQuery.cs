using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using ExtendPropertyLib;
using MaxZhang.EasyEntities.Persistence.Mapping;
using MaxZhang.EasyEntities.Persistence.Provider;
using System.Diagnostics;

namespace MaxZhang.EasyEntities.Persistence
{
    /// <summary>
    /// 查询构造器
    /// </summary>
    /// <typeparam name="TModel"></typeparam>
    [System.Diagnostics.DebuggerDisplay("SQL:{ToString()}",Target=typeof(string))]
    public class SelectQuery<TModel>:IDisposable
    {
        
        internal Type ModelType { set; get; }
        internal IDataProvider Provider { get; set; }
        internal Command Command { get; set; }
        internal StringBuilder WhereCreater { set; get; }
        internal SQLBuilder SqlBuilder { set; get; }
        internal int TableIndex { set; get; }
        
        #region 构造器
            public SelectQuery()
                : this(ProviderFactory.GetProvider())
            {
            }

            public SelectQuery(IDataProvider provider)
            {
                if (provider == null)
                {
                    throw new ArgumentNullException("provider");
                }
                Init(provider);
                //MetaType metaType = MetaManager.GetMetaType();

              
                var tableName = DbMetaDataManager.GetTableName(ModelType);
                var metaDataList = DbMetaDataManager.GetMetaDatas(ModelType);

                SqlBuilder.AddFromTable(tableName, TableIndex);
                foreach (var parameter in metaDataList)
                {
                    SqlBuilder.AddField(string.Format("T{0}.{1}",TableIndex,parameter.FieldName));
                } 
            }
        

            private void Init(IDataProvider provider)
            {
                TableIndex = 1;
                Provider = provider;
                SqlBuilder = new SQLBuilder();
                WhereCreater = new StringBuilder();
                ModelType = typeof(TModel);
                WhereCreater.Append(" Where 1=1 ");
            }
        #endregion

        /// <summary>
        /// 延时加载数据到实体类型列表中，只有在调用或使用它时才出发其加载
        /// </summary>
        /// <returns>延时型实体列表</returns>
        public IEnumerable<TModel> ToLazyList()
        {
           
            using (IDataReader reader = Provider.QueryData(new Command(this.ToString())))
            {
                while (reader.Read())
                {
                    TModel item ;
                    item = reader.ToEntity<TModel>(); //DynamicDataRecordBuilder<TModel>.CreateBuilder(reader).Build(reader);
                    yield return item;
                }
            }
           
        }
        /// <summary>
        /// 立即返回实体列表数据
        /// </summary>
        /// <returns>TModel实体列表数据</returns>
        public List<TModel> ToList()
        {
            return this.ToLazyList().ToList();
        }

        /// <summary>
        /// 立即返回数据DataSet
        /// </summary>
        /// <returns>数据DataSet</returns>
        public DataSet ToDataSet()
        {
            var tableName = DbMetaDataManager.GetTableName(ModelType);
            return Provider.Query(new Command(this.ToString()){TableName = tableName});
        }

        /// <summary>
        /// 立即返回第一行第一列的值的T类型
        /// </summary>
        /// <typeparam name="T">返回类型</typeparam>
        /// <returns>回第一行第一列的值</returns>
        public T ToSingle<T>() 
        {
            object result = Provider.QueryScalar(new Command(this.ToString()));
            if(result is DBNull || result ==null)
                return default(T);
   
            return (T) result;
        }

        /// <summary>
        /// 立即返回第一行第一列的值的Int类型
        /// </summary>
        /// <typeparam name="T">Int类型</typeparam>
        /// <returns>回第一行第一列的值</returns>
        public int ToInt()
        {
            object result = Provider.QueryScalar(new Command(this.ToString()));
            if (result is DBNull || result == null)
                return 0;
            return Convert.ToInt32(result);
        }

        /// <summary>
        /// 当前要被执行的SQL语句
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return SqlBuilder.Build(WhereCreater.ToString());
        }

        public void Dispose()
        {
            this.ModelType = null;
            this.Provider.Dispose();
            this.Command = null;
            this.WhereCreater = null;
        }  
    }      
}         
