using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using ExtendPropertyLib;

namespace MaxZhang.EasyEntities.Persistence.Mapping
{
    /// <summary>
    /// 数据库元数据管理类
    /// </summary>
    public static class DbMetaDataManager
    {
        public static object LockObject = new object();


        /// <summary>
        /// 设置表模型缓存
        /// </summary>
        /// <param name="dboType"></param>
        private static void SetTableModelCable(Type dboType)
        {
            object model = null;
            //表模型缓存
            if (!DbSession._modelTypeCable.TryGetValue(dboType, out model))
            {
                model = Activator.CreateInstance(dboType);
                DbSession._modelTypeCable.TryAdd(dboType, model);
            }
        }

        private static ConcurrentDictionary<string, List<DbMetaData>> tableCableMetaDatas = new ConcurrentDictionary<string, List<DbMetaData>>();
        /// <summary>
        /// 获取物理模型类型对应表所有列的元数据
        /// </summary>
        /// <param name="dboType"></param>
        /// <returns></returns>
        public static List<DbMetaData> GetMetaDatas(Type dboType)
        {
            lock (LockObject)
            {
                SetTableModelCable(dboType);

                var tableName = GetTableName(dboType);
                List<DbMetaData> mds = null;
                //元数据缓存
                if (!tableCableMetaDatas.TryGetValue(tableName, out mds))
                {
                    var reader = new DbMetaDataReader(dboType);
                    mds = reader.GetMetaData();
                    tableCableMetaDatas.TryAdd(tableName, mds);
                }
                return mds;
            }

        }
        /// <summary>
        /// 获取物理模型类型的表名
        /// </summary>
        /// <param name="dboType"></param>
        /// <returns></returns>
        public static string GetTableName(Type dboType)
        {
            lock (LockObject)
            {
                SetTableModelCable(dboType);
                var ep = ExtendProperty.GetProperty(dboType, "TableName");
                var tableName = ep.DefaultValue.ToString();
                return tableName;
            }
        }
        /// <summary>
        /// 获取物理模型类型的列名
        /// </summary>
        /// <param name="dboType"></param>
        /// <param name="fieldName"></param>
        /// <returns></returns>
        public static string GetFieldName(Type dboType, string fieldName)
        {
            lock (LockObject)
            {
                SetTableModelCable(dboType);
                var md = GetMetaData(dboType, fieldName) as DbMetaData;
                return md.FieldName;
            }
        }

        /// <summary>
        /// 得到字段对应的类型属性名
        /// </summary>
        /// <param name="dboType"></param>
        /// <param name="fieldName"></param>
        /// <returns></returns>
        public static string GetPropertyName(Type dboType, string fieldName)
        {
            lock (LockObject)
            {
                SetTableModelCable(dboType);
                string result = null;
                var ps = ExtendProperty.GetPropertys(dboType);
                var exp = ps.FirstOrDefault(ep => (ep.MetaData as DbMetaData) != null ? (ep.MetaData as DbMetaData).FieldName == fieldName : false);
                if (exp != null)
                    result = exp.PropertyName;

                return result;
            }
        }


        /// <summary>
        /// 获取物理模型类型的主键数组
        /// </summary>
        /// <param name="dboType"></param>
        /// <returns></returns>
        public static string[] GetKeys(Type dboType)
        {
            lock (LockObject)
            {
                SetTableModelCable(dboType);
                var ep = ExtendProperty.GetProperty(dboType, "Keys");
                var keys = ep.DefaultValue as string[];
                return keys;
            }
        }
        /// <summary>
        /// 获取物理模型类型的所有数据库列名数组
        /// </summary>
        /// <param name="dboType"></param>
        /// <returns></returns>
        public static string[] GetColumns(Type dboType)
        {
            lock (LockObject)
            {
                SetTableModelCable(dboType);
                var md = GetMetaData(dboType, "Columns");
                return (string[])md.Tag;
            }
        }

        /// <summary>
        /// 获取物理模型中对应属性的元数据信息，既属性对应的数据库中的表列信息。
        /// </summary>
        /// <param name="dboType"></param>
        /// <param name="propertyName">属性名</param>
        /// <returns></returns>
        public static MetaData GetMetaData(Type dboType, string propertyName)
        {
            lock (LockObject)
            {
                SetTableModelCable(dboType);
                var ep = ExtendProperty.GetProperty(dboType, propertyName);
                return ep.MetaData;
            }
        }

    }

    /// <summary>
    /// 物理模型元数据读取类
    /// </summary>
    public class DbMetaDataReader
    {
        private List<DbMetaData> mds = null;

        public DbMetaDataReader(Type type)
        {
            var extendPropertys = ExtendProperty.GetPropertys(type);
            mds = extendPropertys
                .Where(ep => ep.MetaData != null && ep.MetaData.GetType() == typeof(DbMetaData))
                .Select(ep => ep.MetaData as DbMetaData).ToList();
        }
        /// <summary>
        /// 得到对应模型类型的元数据信息
        /// </summary>
        /// <returns></returns>
        public List<DbMetaData> GetMetaData()
        {
            return mds;
        }

    }
}
