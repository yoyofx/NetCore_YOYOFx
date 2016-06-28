using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
using MaxZhang.EasyEntities.Persistence.Mapping;
using MaxZhang.EasyEntities.Persistence.Provider;

namespace MaxZhang.EasyEntities.Persistence
{
    /// <summary>
    /// 查询条件对象
    /// </summary>
    public abstract class QueryConditional
    {

        public IDataProvider DataProvider { set; get; }

        /// <summary>
        /// 将所有用到的物理模型类型对象加载到缓存中。
        /// </summary>
        /// <param name="dbtypes"></param>
        protected void LoadObjects(Type[] dbtypes)
        {
            foreach (var type in dbtypes)
            {
                object model = null;
                if (!DbSession._modelTypeCable.TryGetValue(type, out model))
                {
                    model = Activator.CreateInstance(type);
                    DbSession._modelTypeCable.TryAdd(type, model);
                    DbMetaDataManager.GetMetaDatas(type);
                }
            }
        }

        /// <summary>
        /// Linq查询中的用户接口
        /// </summary>
        /// <returns></returns>
        public bool Eq()
        {
            return true;
        }

        protected QueryConditional(Type[] dbtypes, Expression expr, IDataProvider dataProvider)
        {
            LoadObjects(dbtypes);
            DataProvider = dataProvider;
            string conditional = TranslateExtendtion.TranslateConditional(expr, DataProvider);
            this.strConditional = new StringBuilder(conditional);
        }


        private QueryConditional AndOr(Expression expr, string andor)
        {
            string conditional = TranslateExtendtion.TranslateConditional(expr, DataProvider);
            this.strConditional
                .Append(" ")
                .Append(andor)
                .Append(" ")
                .Append(conditional);
            return this;
        }

        public virtual QueryConditional And(Expression expr)
        {
            return AndOr(expr, "AND");
        }

        public virtual QueryConditional Or(Expression expr)
        {
            return AndOr(expr, "OR");
        }


        private StringBuilder strConditional;

        public override string ToString()
        {
            return this.strConditional.ToString();
        }

    }
    /// <summary>
    /// 查询条件对象
    /// </summary>
    public class QueryConditional<TModel>:QueryConditional
    {


        public QueryConditional(Expression<Func<TModel, bool>> expr, IDataProvider dataProvider):base(new Type[]{typeof(TModel)},expr,  dataProvider)
        {

        }

        public QueryConditional<TModel> And(Expression<Func<TModel, bool>> expr)
        {

            return (QueryConditional<TModel>)base.And(expr);
        }

        public QueryConditional<TModel> Or(Expression<Func<TModel, bool>> expr)
        {
            return (QueryConditional<TModel>)base.Or(expr);
        }

    }
    /// <summary>
    /// 查询条件对象
    /// </summary>
    public class QueryConditional<TModel1,TModel2> : QueryConditional
    {


        public QueryConditional(Expression<Func<TModel1, TModel2, bool>> expr, IDataProvider dataProvider)
            : base(new Type[] { typeof(TModel1),typeof(TModel2) }, expr,  dataProvider)
        {

        }

        public QueryConditional<TModel1, TModel2> And(Expression<Func<TModel1, TModel2, bool>> expr)
        {
            base.And(expr);
            return this;
        }

        public QueryConditional<TModel1, TModel2> Or(Expression<Func<TModel1, TModel2, bool>> expr)
        {
            base.Or(expr);
            return this;
        }

    }
    /// <summary>
    /// 查询条件对象
    /// </summary>
    public class QueryConditional<TModel1, TModel2, TModel3> : QueryConditional
    {


        public QueryConditional(Expression<Func<TModel1, TModel2, TModel3, bool>> expr, IDataProvider dataProvider)
            : base(new Type[] { typeof(TModel1), typeof(TModel2),typeof(TModel3) }, expr,  dataProvider)
        {

        }

        public QueryConditional<TModel1, TModel2, TModel3> And(Expression<Func<TModel1, TModel2, TModel3, bool>> expr)
        {
            base.And(expr);
            return this;
        }

        public QueryConditional<TModel1, TModel2, TModel3> Or(Expression<Func<TModel1, TModel2, TModel3, bool>> expr)
        {
            base.Or(expr);
            return this;
        }

    }
    /// <summary>
    /// 查询条件对象
    /// </summary>
    public class QueryConditional<TModel1, TModel2, TModel3, TModel4> : QueryConditional
    {


        public QueryConditional(Expression<Func<TModel1, TModel2, TModel3, TModel4, bool>> expr, IDataProvider dataProvider)
            : base(new Type[] { typeof(TModel1), typeof(TModel2), typeof(TModel3), typeof(TModel4) }, expr ,  dataProvider)
        {

        }

        public QueryConditional<TModel1, TModel2, TModel3, TModel4> And(Expression<Func<TModel1, TModel2, TModel3, TModel4, bool>> expr)
        {
            base.And(expr);
            return this;
        }

        public QueryConditional<TModel1, TModel2, TModel3, TModel4> Or(Expression<Func<TModel1, TModel2, TModel3, TModel4, bool>> expr)
        {
            base.Or(expr);
            return this;
        }

    }
    /// <summary>
    /// 查询条件对象
    /// </summary>
    public class QueryConditional<TModel1, TModel2, TModel3, TModel4, TModel5> : QueryConditional
    {


        public QueryConditional(Expression<Func<TModel1, TModel2, TModel3, TModel4, TModel5, bool>> expr, IDataProvider dataProvider)
            : base(new Type[] { typeof(TModel1), typeof(TModel2), typeof(TModel3), typeof(TModel4), typeof(TModel5) }, expr,  dataProvider)
        {

        }

        public QueryConditional<TModel1, TModel2, TModel3, TModel4, TModel5> And(Expression<Func<TModel1, TModel2, TModel3, TModel4, TModel5, bool>> expr)
        {
            base.And(expr);
            return this;
        }

        public QueryConditional<TModel1, TModel2, TModel3, TModel4, TModel5> Or(Expression<Func<TModel1, TModel2, TModel3, TModel4, TModel5, bool>> expr)
        {
            base.Or(expr);
            return this;
        }

    }
}
