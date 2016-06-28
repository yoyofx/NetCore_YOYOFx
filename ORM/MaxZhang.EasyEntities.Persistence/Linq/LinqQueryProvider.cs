using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using MaxZhang.EasyEntities.Persistence.Provider;
using MaxZhang.EasyEntities.Persistence.Provider.SQLServer;

namespace MaxZhang.EasyEntities.Persistence.Linq
{
    /// <summary>
    /// Linq提供器，用于提供Linq表达式所需要的数据源
    /// 并提供执行表达式入口，解析生成查询提供数据源所需要的条件
    /// </summary>
    public class LinqQueryProvider : IQueryProvider
    {
        public LinqQueryProvider(IDataProvider dataProvider)
        {
            DataProvider = dataProvider;
        }

        public IDataProvider DataProvider{set;get;}

        /// <summary>
        /// 创建查询
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public IQueryable CreateQuery(Expression expression)
        {
            Type elementType = TypeSystem.GetElementType(expression.Type);
            try
            {
                return (IQueryable)Activator.CreateInstance(
                    typeof(LinqQuery<>).MakeGenericType(elementType),
                    new object[] { this, expression });
            }
            catch
            {
                throw new Exception();
            }
        }

        public IQueryable<TResult> CreateQuery<TResult>(Expression expression)
        {
            return new LinqQuery<TResult>(this, expression);
        }

     
        /// <summary>
        /// 执行入口，解析表达式并生成执行SQL语句，返回SQL数据源数据
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public object Execute(Expression expression)
        {
        
            var t = new SqlTranslateFormater();
            t.Provider = DataProvider;
            string sql = t.Translate(expression);
            DataProvider.Log = sql;
            var reader = DataProvider.QueryData(new Command(sql));
            Type elementType = TypeSystem.GetElementType(expression.Type);

            return Activator.CreateInstance(
                typeof(ObjectReader<>).MakeGenericType(elementType),
                BindingFlags.Instance | BindingFlags.NonPublic, null,
                new object[] { reader },
                null);

        }
        /// <summary>
        /// 执行入口，解析表达式并生成执行SQL语句，返回SQL数据源一行数据,如first操作符
        /// </summary>
        public TResult Execute<TResult>(Expression expression)
        {
            var reader = ((ObjectReader<TResult>) this.Execute(expression)).GetEnumerator();
            reader.MoveNext();
            return (TResult) reader.Current;
        }
    }


    internal static class TypeSystem
    {
        internal static Type GetElementType(Type seqType)
        {
            Type ienum = FindIEnumerable(seqType);
            if (ienum == null) return seqType;
            return ienum.GetGenericArguments()[0];
        }

        private static Type FindIEnumerable(Type seqType)
        {
            if (seqType == null || seqType == typeof(string))
                return null;

            if (seqType.IsArray)
                return typeof(IEnumerable<>).MakeGenericType(seqType.GetElementType());

            if (seqType.IsGenericType)
            {
                foreach (Type arg in seqType.GetGenericArguments())
                {
                    Type ienum = typeof(IEnumerable<>).MakeGenericType(arg);
                    if (ienum.IsAssignableFrom(seqType))
                    {
                        return ienum;
                    }
                }
            }

            Type[] ifaces = seqType.GetInterfaces();
            if (ifaces != null && ifaces.Length > 0)
            {
                foreach (Type iface in ifaces)
                {
                    Type ienum = FindIEnumerable(iface);
                    if (ienum != null) return ienum;
                }
            }

            if (seqType.BaseType != null && seqType.BaseType != typeof(object))
            {
                return FindIEnumerable(seqType.BaseType);
            }

            return null;
        }
    }

}
