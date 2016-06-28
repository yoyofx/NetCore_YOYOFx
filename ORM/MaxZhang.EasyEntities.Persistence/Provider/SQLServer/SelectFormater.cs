using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using MaxZhang.EasyEntities.Persistence.Mapping;
using System.Collections.Concurrent;

namespace MaxZhang.EasyEntities.Persistence.Provider.SQLServer
{
    /// <summary>
    /// 解析SQL语句中Select语句部分的Expression表达式树
    /// </summary>
    public class SelectFormater:ExpressionVisitor
    {
        protected StringBuilder sb = new StringBuilder();

        public SelectFormater(ConcurrentDictionary<Type, string> ass)
        {
            this.Ass = ass;
        }

        private ConcurrentDictionary<Type, string> Ass;

        protected override Expression VisitMember(MemberExpression node)
        {
            var fieldName = DbMetaDataManager.GetFieldName(node.Member.DeclaringType, node.Member.Name);
            string tn = string.Empty;
            if (Ass.TryGetValue(node.Member.DeclaringType, out tn))
            {
                sb.Append(tn);
                sb.Append(".");
            }
            sb.Append(fieldName);
            return node;
        }

        protected override Expression VisitNew(NewExpression node)
        {

            for (int i = 0; i < node.Members.Count; i++)
            {
                this.Visit(node.Arguments[i]);
                this.sb.Append(" AS ");
                this.sb.Append(node.Members[i].Name);
                if (i != node.Members.Count - 1)
                    this.sb.Append(", ");
            }
            return node;
        }

        public override string ToString()
        {
            return this.sb.ToString();
        }
    }
}