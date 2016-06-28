using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using MaxZhang.EasyEntities.Persistence.Provider;

namespace MaxZhang.EasyEntities.Persistence.Linq
{
    /// <summary>
    /// Linq查询对象，Linq表达式都作用于这个对象
    /// </summary>
    /// <typeparam name="TData"></typeparam>
    public class LinqQuery<TData>: IQueryable<TData>, IQueryable, 
        IEnumerable<TData>, IEnumerable, IOrderedQueryable<TData>, IOrderedQueryable {
    
        public LinqQuery(IDataProvider dataProvider)
            : this()
        {
            DataProvider = dataProvider;
            Provider = new LinqQueryProvider(dataProvider);
        }


        public LinqQuery()
        {
            Expression = Expression.Constant(this);
        }

        public LinqQuery(LinqQueryProvider provider,
            Expression expression)
        {
            if (provider == null)
            {
                throw new ArgumentNullException("provider");
            }

            if (expression == null)
            {
                throw new ArgumentNullException("expression");
            }

            if (!typeof(IQueryable<TData>).IsAssignableFrom(expression.Type))
            {
                throw new ArgumentOutOfRangeException("expression");
            }

            Provider = provider;
            Expression = expression;
        }
        /// <summary>
        /// 数据库提供器
        /// </summary>
        public IDataProvider DataProvider { get; private set; }
        /// <summary>
        /// Linq提供器，用于Linq的数据源
        /// </summary>
        public IQueryProvider Provider { get; private set; }
        /// <summary>
        /// 要执行的表达式
        /// </summary>
        public Expression Expression { get; private set; }

        public Type ElementType
        {
            get { return typeof(TData); }
        }

        /// <summary>
        /// 访问Linq读取器，返回数据
        /// </summary>
        /// <returns></returns>
        public IEnumerator<TData> GetEnumerator()
        {
            return ((Provider.Execute(Expression)) as ObjectReader<TData>).GetEnumerator();
        }
        /// <summary>
        /// 访问Linq读取器，返回数据
        /// </summary>
        /// <returns></returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((Provider.Execute(Expression)) as ObjectReader<TData>).GetEnumerator();
        }

        /// <summary>
        /// 调试信息
        /// </summary>
        public string SqlDebug
        {
            get
            {
                return DataProvider.Log;
            }
        }

    }

}
