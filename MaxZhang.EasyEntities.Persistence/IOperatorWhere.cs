using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using MaxZhang.EasyEntities.Persistence.Mapping;

namespace MaxZhang.EasyEntities.Persistence
{
    public interface IOperatorWhere<TModel> where TModel : DbObject
    {
        /// <summary>
        /// 添加条件语句
        /// </summary>
        /// <param name="whereExp"></param>
        /// <returns></returns>
        IOperatorWhere<TModel> Where(Expression<Func<TModel, bool>> whereExp);
        /// <summary>
        /// 执行表达式
        /// </summary>
        void Go();
    }
}
