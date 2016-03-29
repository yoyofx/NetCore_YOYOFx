using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Linq.Expressions;
using System.Text.RegularExpressions;
using MaxZhang.EasyEntities.Persistence.Mapping;
using MaxZhang.EasyEntities.Persistence.Provider.SQLServer;

namespace MaxZhang.EasyEntities.Persistence
{

    public class OpAction
    {
        public string Operand { set; get; }
        public string Operator { set; get; }
        public string OpValue { set; get; }
        public Type OpType { set; get; }
    }

    public static class QueryObjectExtension
    {
        /// <summary>
        /// 选择返回列，用于返回指定名称属性集合数据源
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <param name="query"></param>
        /// <param name="newObject"></param>
        /// <returns>查询构造器，一般使用Select语句后应该执行查询</returns>
        public static SelectQuery<TModel> Select<TModel>(this SelectQuery<TModel> query, Expression<Func<TModel, object>> newObject)
        {

            var fields = TranslateExtendtion.TranslateObject(newObject, query.Provider)
                .Split(',')
                .Select(f => GetMetaFieldName<TModel>(query.TableIndex, f)).ToList();

            query.SqlBuilder.ClearFields();
            var keys = DbMetaDataManager.GetKeys(typeof(TModel)).Select(k => GetMetaFieldName<TModel>(query.TableIndex, k));

            var keyAndFields = keys.ToList();

            keyAndFields.AddRange(fields);

            keyAndFields.ForEach(f => query.SqlBuilder.AddField(f));
            return query;
        }
        /// <summary>
        /// 条件查询
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <param name="query"></param>
        /// <param name="qc">条件对象</param>
        /// <returns>查询构造器，后面可接其它查询构造器方法</returns>
        public static SelectQuery<TModel> Where<TModel>(this SelectQuery<TModel> query, QueryConditional<TModel> qc)
        {
            Regex regex = new Regex(@"[a-z|A-Z]+\w*\.");
            string sql = regex.Replace(qc.ToString(), @"T1.");
            query.WhereCreater.Append(" AND ")
                             .Append(sql);


            return query;
        }

        /// <summary>
        /// 返回分页数据
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <param name="query"></param>
        /// <param name="pageIndex">第几页</param>
        /// <param name="pageSize">共几页</param>
        /// <returns>延时执行查询，在调用时</returns>
        public static IEnumerable<TModel> GetPager<TModel>(this SelectQuery<TModel> query, int pageIndex, int pageSize)
        {
            query.SqlBuilder.Clear();
            query.SqlBuilder.IsFunction = true;
            var tableName = DbMetaDataManager.GetTableName(typeof(TModel));
            string where = query.WhereCreater.ToString().Replace("Where 1=1  AND", "");
            Regex regex = new Regex(@"[a-z|A-Z]+\w*\.");
            where = regex.Replace(where, @"");

            var key = DbMetaDataManager.GetKeys(typeof(TModel))[0];
            query.SqlBuilder.FuncSQL = string.Format(@"EXEC sp_getdatapage {0}, {1}, '[{2}]', '{3}', '{4}'", pageIndex, pageSize, tableName, where, key);
            return query.ToLazyList();
        }

        /// <summary>
        /// 条件查询
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <param name="query"></param>
        /// <param name="whereExpression">条件表达式</param>
        /// <returns>查询构造器，后面可接其它查询构造器方法</returns>
        public static SelectQuery<TModel> Where<TModel>(this SelectQuery<TModel> query, Expression<Func<TModel, bool>> whereExpression)
        {
            return And(query, whereExpression);
        }

        /// <summary>
        /// 查询方法，条件查询And操作
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <param name="query"></param>
        /// <param name="whereExpression">条件表达式</param>
        /// <returns>查询构造器，后面可接其它查询构造器方法</returns>
        public static SelectQuery<TModel> And<TModel>(this SelectQuery<TModel> query, Expression<Func<TModel, bool>> whereExpression)
        {
            string whereSQL = TranslateExtendtion.TranslateConditional(whereExpression, query.Provider);
            Regex regex = new Regex(@"[a-z|A-Z]+\w*\.");
            whereSQL = regex.Replace(whereSQL, @"T1.");
            query.WhereCreater.Append(" AND ")
                             .Append(whereSQL);
            return query;
        }



        /// <summary>
        ///  查询方法，条件查询Or操作
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <param name="query"></param>
        /// <param name="whereExpression">条件表达式</param>
        /// <returns>查询构造器，后面可接其它查询构造器方法</returns>
        public static SelectQuery<TModel> Or<TModel>(this SelectQuery<TModel> query, Expression<Func<TModel, bool>> whereExpression)
        {
            string whereSQL = TranslateExtendtion.TranslateConditional(whereExpression, query.Provider);
            Regex regex = new Regex(@"[a-z|A-Z]+\w*\.");
            whereSQL = regex.Replace(whereSQL, @"T1.");
            query.WhereCreater.Append(" OR ")
                             .Append(whereSQL);
            return query;
        }

        /// <summary>
        ///  查询方法，设定查询返回的行数
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <param name="query"></param>
        /// <param name="topNum">行数</param>
        /// <returns>查询构造器，后面可接其它查询构造器方法</returns>
        public static SelectQuery<TModel> Top<TModel>(this SelectQuery<TModel> query, int topNum)
        {
            query.SqlBuilder.AddTop(topNum);
            return query;
        }

        /// <summary>
        ///  查询方法，对查询列进行汇总操作
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <param name="query"></param>
        /// <param name="propertyExpression">列名表达式</param>
        /// <returns>查询构造器，后面可接其它查询构造器方法</returns>
        public static SelectQuery<TModel> Sum<TModel>(this SelectQuery<TModel> query, Expression<Func<TModel, object>> propertyExpression)
        {
            string property = TranslateExtendtion.TranslateObject(propertyExpression, query.Provider);
            Regex regex = new Regex(@"[a-z|A-Z]+\w*\.");
            property = regex.Replace(property, @"");

            query.SqlBuilder.AddSum(query.TableIndex, property);
            return query;
        }
        /// <summary>
        ///  查询方法，对查询列进行求平均值操作
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <param name="query"></param>
        /// <param name="propertyExpression">列名表达式</param>
        /// <returns>查询构造器，后面可接其它查询构造器方法</returns>
        public static SelectQuery<TModel> Avg<TModel>(this SelectQuery<TModel> query, Expression<Func<TModel, object>> propertyExpression)
        {
            string property = TranslateExtendtion.TranslateObject(propertyExpression, query.Provider);
            Regex regex = new Regex(@"[a-z|A-Z]+\w*\.");
            property = regex.Replace(property, @"");

            query.SqlBuilder.AddAvg(query.TableIndex, property);
            return query;
        }
        /// <summary>
        ///  查询方法，对查询列进行最大值操作
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <param name="query"></param>
        /// <param name="propertyExpression">列名表达式</param>
        /// <returns></returns>
        public static SelectQuery<TModel> Max<TModel>(this SelectQuery<TModel> query, Expression<Func<TModel, object>> propertyExpression)
        {
            string property = TranslateExtendtion.TranslateObject(propertyExpression, query.Provider);
            Regex regex = new Regex(@"[a-z|A-Z]+\w*\.");
            property = regex.Replace(property, @"");

            query.SqlBuilder.AddMax(query.TableIndex, property);
            return query;
        }
        /// <summary>
        ///  查询方法，对查询列进行最小值操作
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <param name="query"></param>
        /// <param name="propertyExpression">列名表达式</param>
        /// <returns>查询构造器，后面可接其它查询构造器方法</returns>
        public static SelectQuery<TModel> Min<TModel>(this SelectQuery<TModel> query, Expression<Func<TModel, object>> propertyExpression)
        {
            string property = TranslateExtendtion.TranslateObject(propertyExpression, query.Provider);
            Regex regex = new Regex(@"[a-z|A-Z]+\w*\.");
            property = regex.Replace(property, @"");
            query.SqlBuilder.AddMin(query.TableIndex, property);
            return query;
        }
        /// <summary>
        ///  查询方法，查询进行计数操作
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <param name="query"></param>
        /// <param name="propertyExpression">列名表达式</param>
        /// <returns>行数，查询构造器，后面可接其它查询构造器方法</returns>
        public static SelectQuery<TModel> Count<TModel>(this SelectQuery<TModel> query, Expression<Func<TModel, object>> propertyExpression)
        {
            string property = TranslateExtendtion.TranslateObject(propertyExpression, query.Provider);
            Regex regex = new Regex(@"[a-z|A-Z]+\w*\.");
            property = regex.Replace(property, @"");
            query.SqlBuilder.AddCount(query.TableIndex, property);
            return query;
        }
        /// <summary>
        ///  查询方法，对查询的列进行排序操作
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <param name="query"></param>
        /// <param name="propertyExpression">列名表达式</param>
        /// <param name="isAsc">升序Or降序</param>
        /// <returns>查询构造器，后面可接其它查询构造器方法</returns>
        public static SelectQuery<TModel> OrderBy<TModel>(this SelectQuery<TModel> query, Expression<Func<TModel, object>> propertyExpression, bool isAsc)
        {
            string property = TranslateExtendtion.TranslateObject(propertyExpression, query.Provider);
            Regex regex = new Regex(@"[a-z|A-Z]+\w*\.");
            property = regex.Replace(property, @"");
            query.SqlBuilder.AddOrderBy(query.TableIndex, property, isAsc);
            return query;
        }
        /// <summary>
        ///  查询方法，对查询的列进行分组操作
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <param name="query"></param>
        /// <param name="propertyExpression">列名表达式</param>
        /// <returns>查询构造器，后面可接其它查询构造器方法</returns>
        public static SelectQuery<TModel> GroupBy<TModel>(this SelectQuery<TModel> query, Expression<Func<TModel, object>> propertyExpression)
        {
            string property = TranslateExtendtion.TranslateObject(propertyExpression, query.Provider);
            Regex regex = new Regex(@"[a-z|A-Z]+\w*\.");
            property = regex.Replace(property, @"");
            query.SqlBuilder.AddGroupBy(query.TableIndex, property);
            return query;
        }

        /// <summary>
        /// 执行,立即返回查询中的第一行实体数据，如果没有查询到则返回为空
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <param name="query"></param>
        /// <param name="whereExpression">条件表达式</param>
        /// <returns>实体对象</returns>
        public static TModel First<TModel>(this SelectQuery<TModel> query, Expression<Func<TModel, bool>> whereExpression)
        {
            TModel firstItem = default(TModel);
            SelectQuery<TModel> queryObject = query;
            if (whereExpression != null)
                queryObject = And(query, whereExpression);
            using (IDataReader IReader = queryObject.Provider.QueryData(new Command(queryObject.ToString())))
            {
                if (IReader.Read())
                {
                    //firstItem = DynamicDataRecordBuilder<TModel>.CreateBuilder(IReader).Build(IReader);
                    firstItem = IReader.ToEntity<TModel>();
                }
            }

            //UpdateTableCable.Set(typeof(TModel), firstItem);

            return firstItem;
        }

        /// <summary>
        /// 执行,立即返回查询中的第一行实体数据，如果没有查询到则返回为空
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <param name="query"></param>
        /// <returns></returns>
        public static TModel First<TModel>(this SelectQuery<TModel> query)
        {
            return First(query, null);
        }

        #region 解释工具


        public static string GetMetaFieldName<T>(int tabIdx, string propertyName)
        {
            string fieldName = string.Empty;
            var field = DbMetaDataManager.GetFieldName(typeof(T), propertyName);

            if (field != null)
            {
                fieldName = string.Format("T{0}.{1}", tabIdx, field);
            }
            return fieldName;
        }

        #endregion
    }
}
