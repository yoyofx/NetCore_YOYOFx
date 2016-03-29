using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Text.RegularExpressions;
using MaxZhang.EasyEntities.Persistence.Mapping;
using MaxZhang.EasyEntities.Persistence.Provider;

namespace MaxZhang.EasyEntities.Persistence
{
    public class OperatorWhereObject<TModel> : IOperatorWhere<TModel> where TModel:DbObject
    {
        public OperatorWhereObject(IDataProvider p,string sql,List<Parameter> ps )
        {
            Provider = p;
            Parameters = ps;
            SQL = sql;
        }

        private string SQL = string.Empty;
        private List<Parameter> Parameters { set; get; } 
        private IDataProvider Provider {set; get; }
        /// <summary>
        /// 执行表达式
        /// </summary>
        public void Go()
        {
            var command = new Command(SQL, Parameters);
            Provider.Execute(command);
        }



        public IOperatorWhere<TModel> Where(Expression<Func<TModel, bool>> whereExp)
        {
            string whereSQL = TranslateExtendtion.TranslateConditional(whereExp,Provider);
            Regex regex = new Regex(@"\w+\.");
            whereSQL = regex.Replace(whereSQL, @"");
            SQL += string.Format(" And {0}", whereSQL);
            return this;
        }
    }
}
