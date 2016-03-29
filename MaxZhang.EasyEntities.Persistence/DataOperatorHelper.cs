using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using MaxZhang.EasyEntities.Persistence.Mapping;
using System.ComponentModel;

namespace MaxZhang.EasyEntities.Persistence
{
    public static class DataOperatorHelper
    {
        public static bool IsNullableType(Type theType)
        {
            return (theType.IsGenericType && theType.
              GetGenericTypeDefinition().Equals
              (typeof(Nullable<>)));
        }

        public static bool IsBooleanType(Type theType)
        {
            return theType == typeof(Nullable<bool>) || (theType == typeof(bool));
        }



        /// <summary>
        /// IDataReader to model object for the 'T'.
        /// 泛型方法:将一个实现IDataReader接口的对象的所有属性通过反射，
        /// 把属性Copy到有相同字段的实体对象中.
        /// </summary>
        /// <param name="T">实体类名(Model object name)</param>
        /// <param name="reader">IDataReader接口实例对象(Object is type of IDataReader)</param>
        /// <returns>Model object for the 'T'.</returns>
        public static T ToEntity<T>(this IDataReader reader)
        {
            
            PropertyInfo[] propertys = null;
            T entity = Activator.CreateInstance<T>();
            propertys = new PropertyInfo[reader.FieldCount];
            for (int i = 0; i < reader.FieldCount; i++)
            {
               
                 string dbName = reader.GetName(i);
                 string propertyName = DbMetaDataManager.GetPropertyName(typeof(T), dbName);
                 if (string.IsNullOrEmpty(propertyName))
                     continue;
                 propertys[i] = typeof(T).GetProperty(propertyName);
                 if (propertys[i] != null && !reader.IsDBNull(i))
                 {
                     try
                     {
                         object val = reader[i];
                         if (!IsNullableType(propertys[i].PropertyType) )
                             val = Convert.ChangeType(val, propertys[i].PropertyType);

                         if (IsBooleanType(propertys[i].PropertyType))
                         {
                             val = Convert.ToBoolean(val);
                         }
                         
                         propertys[i].SetValue(entity, val, null);
                     }
                     catch (Exception exxxx)
                     {
                     }
                 }
                
            
            }

            return entity;
        }

        /// <summary>
        /// IDataReader to model object for the 'a.
        /// 泛型方法:将一个实现IDataReader接口的对象的所有属性
        /// 把属性Copy到有相同字段的匿名实体对象中.
        /// </summary>
        /// <param name="T">实体类名(Model object name)</param>
        /// <param name="reader">IDataReader接口实例对象(Object is type of IDataReader)</param>
        /// <returns>Model object for the 'a.</returns>
        public static T ToAEntity<T>(this IDataReader reader)
        {
            List<object> paramters = new List<object>();
            var t = typeof(T);
            var ps = t.GetProperties();

            foreach (PropertyInfo p in ps)
            {

                object val = reader[p.Name];

                if (!(val is DBNull))
                {
                    if (!IsNullableType(p.PropertyType))
                        val = Convert.ChangeType(val, p.PropertyType);

                    if (IsBooleanType(p.PropertyType))
                    {
                        val = Convert.ToBoolean(val);
                    }

                    paramters.Add(val);
                }


            }
           
          

            return (T)Activator.CreateInstance(typeof(T), paramters.ToArray()); ;
        }

    }
}