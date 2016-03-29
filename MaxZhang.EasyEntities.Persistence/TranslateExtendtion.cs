using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
using MaxZhang.EasyEntities.Persistence.Provider;
using MaxZhang.EasyEntities.Persistence.Provider.SQLServer;

namespace MaxZhang.EasyEntities.Persistence
{
    /// <summary>
    /// 表达式转换扩展类
    /// </summary>
    public static class TranslateExtendtion
    {
        /// <summary>
        /// 解析整个表达式，转换为SQL语句
        /// </summary>
        /// <param name="expr"></param>
        /// <returns></returns>
        public static string TranslateConditional(Expression expr,IDataProvider dp)
        {
            var exprVisitor = new SqlTranslateFormater();
            exprVisitor.Provider = dp;
            string cmd = exprVisitor.Translate(expr);
            return cmd;
        }
        /// <summary>
        /// 解析型如“a=>a.id”的表达式，既 f(x':TModel) = x'.y':object
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <param name="expr"></param>
        /// <returns></returns>
        internal static string TranslateObject<TModel>(Expression<Func<TModel, object>> expr, IDataProvider dp)
        {
            var exprVisitor = new SqlTranslateFormater();
            exprVisitor.Provider = dp;
            string cmd = exprVisitor.Translate(expr);
            return cmd;
        }

    }
}
