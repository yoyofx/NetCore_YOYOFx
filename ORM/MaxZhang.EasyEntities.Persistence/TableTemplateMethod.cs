using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ExtendPropertyLib;
using MaxZhang.EasyEntities.Persistence.Mapping;

namespace MaxZhang.EasyEntities.Persistence
{
    /// <summary>
    /// 增删改，模板生成类
    /// </summary>
    public class TableTemplateMethod
    {
        /// <summary>
        /// 插入操作
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <param name="entity"></param>
        /// <param name="paramPrefix"></param>
        /// <returns></returns>
        static public Command GetInstertCommand<TModel>(TModel entity,string paramPrefix) where TModel:DbObject
        {
            var tableName = GetTableName(typeof (TModel));
            var fields = GetFields(typeof (TModel));
            var paramters = GetParamNames(typeof (TModel), paramPrefix);

            string template = string.Format("INSERT INTO {0}({1}) VALUES({2})", tableName, fields, paramters);

            var ps = GetParams(entity, paramPrefix);

            return new Command(template,ps);
        }
        /// <summary>
        /// 删除操作
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <param name="entity"></param>
        /// <param name="paramPrefix"></param>
        /// <returns></returns>
        static public Command GetDeleteCommand<TModel>(TModel entity, string paramPrefix) where TModel : DbObject
        {
            var tableName = GetTableName(typeof(TModel));
            var keys = GetKeysParamNames(typeof (TModel),paramPrefix);
          
            string template = string.Format("DELETE From {0} Where {1}", tableName, keys);

            var ps = GetKeysParams(entity, paramPrefix);

            return new Command(template, ps);
        }

        static public Command GetUpdateCommand<TModel>(TModel entity,string paramPrefix) where TModel : DbObject
        {
            var tableName = GetTableName(typeof(TModel));
            var keys = GetKeysParamNames(typeof(TModel), paramPrefix);

            var paramterNameAndValues = GetParamNameAndValues(typeof(TModel), paramPrefix);

            string template = string.Format("Update {0} SET {1} Where {2}", tableName, paramterNameAndValues, keys);

            var pkeys = GetKeysParams(entity, paramPrefix);
            var ps = GetParams(entity, paramPrefix);
            foreach (var key in pkeys)
            {
                if(!ps.Any(p=>p.Name == key.Name))
                    ps.Add(key);
            }
           
            return new Command(template, ps);
        }

        public static Command GetRemoveCommand<TModel>(TModel entity, string paramPrefix) where TModel : DbObject
        {
            var tableName = GetTableName(typeof(TModel));
            var keys = GetKeysParamNames(typeof(TModel), paramPrefix);
            var removeFieldName = GetRemoveAbleFieldName(typeof(TModel));

            string template = string.Format("Update {0} SET {1} Where {2}", tableName, removeFieldName + "=1" , keys);

            var ps = GetKeysParams(entity, paramPrefix);

            return new Command(template, ps);

        }


        /// <summary>
        /// 得到模型对象中可移除属性，列名
        /// </summary>
        static private string GetRemoveAbleFieldName(Type tmodel)
        {
            var fs = DbMetaDataManager.GetMetaDatas(tmodel)
                                       .Where(md => md.RemoveAble);

            var fmd = fs.FirstOrDefault();

            if (fmd == null)
                throw new InvalidOperationException("不能在没有可移除类型的对象上进行些操作！");

            return fmd.FieldName;


        }


        /// <summary>
        ///  得到除自增列以外所有列的列名
        /// </summary>
        static private string GetFields(Type tmodel)
        {
            var fs = DbMetaDataManager.GetMetaDatas(tmodel)
                                        .Where(md => !md.IDentity);

            var fields = String.Join(",",
                   fs.Select(f => f.FieldName)
                );

            return fields;
        }
        /// <summary>
        /// 得到除自增列以外所有列的参数
        /// </summary>
        static private List<Parameter> GetParams<TModel>(TModel entity,string paramPrefix) where TModel:DbObject
        {
            var extendPropertys = ExtendProperty.GetPropertys(typeof(TModel));
            var pds = extendPropertys
                .Where(ep => ep.MetaData!=null && ep.MetaData.GetType() == typeof(DbMetaData) &&  !((DbMetaData)ep.MetaData).IDentity)
                .Select( ep => new Parameter(paramPrefix + ((DbMetaData) ep.MetaData).FieldName,
                              FormatValue(entity.GetValue(ep)),
                              ((DbMetaData) ep.MetaData).Type)).ToList();
            return pds;
        }
        /// <summary>
        /// 得到主键参数
        /// </summary>
        static private List<Parameter> GetKeysParams<TModel>(TModel entity, string paramPrefix) where TModel : DbObject
        {
            var extendPropertys = ExtendProperty.GetPropertys(typeof(TModel));
            var pds = extendPropertys
                .Where(ep => ep.MetaData != null && ep.MetaData.GetType() == typeof(DbMetaData) && ((DbMetaData)ep.MetaData).IsKey)
                .Select(ep => new Parameter(paramPrefix + ((DbMetaData)ep.MetaData).FieldName,
                              FormatValue(entity.GetValue(ep)),
                              ((DbMetaData)ep.MetaData).Type)).ToList();
            return pds;
        }

        /// <summary>
        /// 得到除自增列外的所有列名
        /// </summary>
        static private string GetParamNames(Type tmodel, string paramPrefix)
        {
            var fs = DbMetaDataManager.GetMetaDatas(tmodel)
                                       .Where(md => !md.IDentity);
            var values = String.Join(",",
                    fs.Select(f => paramPrefix + f.FieldName)
                 );
            return values;
        }

        /// <summary>
        /// 得到除主键和自增列外的列名与值
        /// </summary>
        static private string GetParamNameAndValues(Type tmodel, string paramPrefix)
        {
            var fs = DbMetaDataManager.GetMetaDatas(tmodel)
                                       .Where(md => !md.IDentity && !md.IsKey);
            var values = String.Join(",",
                    fs.Select(f =>f.FieldName + "=" + paramPrefix + f.FieldName)
                 );
            return values;
        }

        /// <summary>
        /// 得到主键的列名和参数名
        /// </summary>
        static private string GetKeysParamNames(Type tmodel, string paramPrefix)
        {
            var keys =  DbMetaDataManager.GetKeys(tmodel);
            var values = String.Join(" And ",
                  keys.Select(f => f + "=" + paramPrefix + f)
               );
            return values;
        }

         /// <summary>
         /// 得到表名
         /// </summary>
        static private string GetTableName(Type tmodel)
        {
            var tableName = DbMetaDataManager.GetTableName(tmodel);
            return tableName;
        }

        private static object FormatValue(object value)
        {
            if (value == null)
            {
                return DBNull.Value;
            }
            if (String.IsNullOrEmpty(value.ToString()))
            {
                return DBNull.Value;
            }
            if (value is DateTime)
                return value;


            if (value is Boolean)
            {
                return (bool)value ? 1 : 0;
            }

            return value.ToString().Trim();
        }
      
    }
}
