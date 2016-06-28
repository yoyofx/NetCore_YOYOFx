using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using MaxZhang.EasyEntities.Persistence.Mapping;

namespace MaxZhang.EasyEntities.Persistence.Provider.SQLServer
{
    public class FieldsFormater : ExpressionVisitor
    {
        public string ParamPrefix {private set; get; }

        public IDataProvider DataProvider {private set; get; }

        public FieldsFormater(IDataProvider dataProvider)
        {
            this.DataProvider = dataProvider;
            ParamPrefix = dataProvider.ParamPrefix;
        }

        Dictionary<string , Parameter> parameters = new Dictionary<string, Parameter>(); 

        protected  Expression VisitConstant(ConstantExpression node,string fieldName)
        {
            if (parameters.Keys.Any(k => k == fieldName))
                parameters[fieldName].Value = node.Value;
            else
            {
                parameters.Add(fieldName, new Parameter(ParamPrefix + fieldName, node.Value));
            }
            return base.VisitConstant(node);
        }

        protected  Expression MyVisitMember(MemberExpression node, string fieldName)
        {
            LambdaExpression lambda = Expression.Lambda(node);
            var fn = lambda.Compile();
            VisitConstant(Expression.Constant(fn.DynamicInvoke(null), node.Type), fieldName);
            return base.VisitMember(node);
        }


        protected override MemberAssignment VisitMemberAssignment(MemberAssignment node)
        {
            string propertyName = node.Member.Name;
            string fieldName = DbMetaDataManager.GetFieldName(node.Member.DeclaringType, propertyName);

            if (node.Expression.NodeType == ExpressionType.Call)
            {

                VisitMethodCall((MethodCallExpression)node.Expression,fieldName);
            }
            else if (node.Expression.NodeType == ExpressionType.Convert)
            {
                var ue = node.Expression as UnaryExpression;
                var call = ue.Operand as MethodCallExpression;

                if (call != null)
                    this.VisitMethodCall(call, fieldName);
                else
                    this.MyVisitMember(ue.Operand as MemberExpression,fieldName);
            }
            else
            {
                parameters.Add(fieldName, new Parameter(ParamPrefix + fieldName, null));
                var constant = node.Expression as ConstantExpression;
                if (constant != null)
                    VisitConstant(constant, fieldName);
                else
                {
                    LambdaExpression lambda = Expression.Lambda(node.Expression);
                    var fn = lambda.Compile();
                    VisitConstant(Expression.Constant(fn.DynamicInvoke(null), node.Expression.Type), fieldName);
                }
            }
            return node;
        }


        protected  Expression VisitMethodCall(MethodCallExpression node,string fieldName)
        {
            string sqlMethodName = node.Method.Name.ToLower();
            string callName = DataProvider.GetFunctionNameCallback(sqlMethodName, null);
            if (!string.IsNullOrEmpty(callName))
            {
                parameters.Add(fieldName, new Parameter(callName, callName) { IsMethodType = true });
            }
            else
                throw new NotSupportedException(string.Format("{0}数据库中不支持函数{1}",DataProvider.Database,sqlMethodName));

            return base.VisitMethodCall(node);
        }

        
        public Dictionary<string , Parameter> Parameters
        {
            get { return parameters; }
        }


    }
}
