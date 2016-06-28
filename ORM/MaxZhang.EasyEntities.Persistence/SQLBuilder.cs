using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MaxZhang.EasyEntities.Persistence
{
    public class SQLItem
    {
        public SQLItem(string n, string v)
        {
            Name = n;
            Value = v;
        }
        public string Name { set; get; }
        public string Value { set; get; }

    }

    public class SQLBuilder
    {
        public SQLBuilder()
        {
            IsFunction = false;
        }


        private List<SQLItem> items = new List<SQLItem>();
        public void AddTop(int topNum)
        {
            if (!items.Any(it => it.Name == "Top"))
            {
                items.Add(new SQLItem("Top", string.Format("Top({0})", topNum)));
            }
            else
            {
                throw new Exception("不能添加多个TOP语句");
            }

        }

        


        public void AddField(string name)
        {
            if (!items.Any(it => it.Name == "GroupField"))
                items.Add(new SQLItem("Field", name));
            else
                throw new Exception("在有聚合函数的语句中不允许添加字段");
        }

        public void ClearFields()
        {
            items.RemoveAll(it => it.Name == "Field");
        }

        public void Clear()
        {
            items.Clear();
        }

        private void AddGroupField(string name)
        {

            items.RemoveAll(it => it.Name == "Field");
            //添加聚合函数后清空所有正常字段|
            items.Add(new SQLItem("GroupField", name));

        }



        public void AddMax(int tabidx, string name)
        {
            AddGroupField(string.Format("Max(T{0}.{1})", tabidx, name));
        }

        public void AddMin(int tabidx, string name)
        {
            AddGroupField(string.Format("Min(T{0}.{1})", tabidx, name));
        }

        public void AddCount(int tabidx, string name)
        {
            AddGroupField(string.Format("Count(T{0}.{1})", tabidx, name));
        }
        public void AddAvg(int tabidx, string name)
        {
            AddGroupField(string.Format("Avg(T{0}.{1})", tabidx, name));
        }
        public void AddSum(int tabidx, string name)
        {
            AddGroupField(string.Format("Sum(T{0}.{1})", tabidx, name));
        }


        public void AddGroupBy(int tabidx, string name)
        {
            if (items.Any(it => it.Name == "OrderBy"))
                throw new Exception("在包含OrderBy语句中不允许使用GroupBy");
            string item = string.Format("T{0}.{1}", tabidx, name);
            items.Add(new SQLItem("GroupBy", name));
        }

        public void AddOrderBy(int tabindex, string name, bool isAsc)
        {
            if (items.Any(it => it.Name == "GroupField"))
                throw new Exception("在包含聚合函数的语句中不允许使用OrderBy");
            string order = " Asc ";
            if (!isAsc)
                order = " Desc ";
            string item = string.Format("T{0}.{1} {2}", tabindex, name, order);
            items.Add(new SQLItem("OrderBy", item));
        }

        public void AddFromTable(string name, int index)
        {
            if (items.Any(it => it.Name == "GroupField"))
                throw new Exception("语句中不允许包含多个Table");
            items.Add(new SQLItem("Table", string.Format("From {0} T{1}", name, index)));
        }

        private string getFields(string name)
        {
            StringBuilder strFields = new StringBuilder();
            var list = items.Where(it => it.Name == name);
            if (list != null)
            {
                var itemList = list.ToList();
                for (int i = 0; i < itemList.Count; i++)
                {
                    strFields.Append(itemList[i].Value);
                    if (i != itemList.Count - 1)
                        strFields.Append(",");
                }
            }
            return strFields.ToString();
        }

        public bool IsFunction { set; get; }

        public string FuncSQL { set; get; }


        public string Build(string where)
        {
            var sqlBuilder = new StringBuilder();
            if (!IsFunction)
            {
                sqlBuilder.Append("Select")
                    .Append(getFields("Top")).Append(" ");

                var strFields = getFields("Field");
                if (strFields != "")
                {
                    sqlBuilder.Append(strFields).Append(" ");
                }

                var strGroupFields = getFields("GroupField");
                if (strGroupFields != "")
                {
                    sqlBuilder.Append(strGroupFields).Append(" ");
                }

                sqlBuilder.Append(getFields("Table")).Append(" ")
                    .Append(where).Append(" ");
                var strGroups = getFields("GroupBy");
                if (strGroups != "")
                {
                    sqlBuilder.Append("Group By ").Append(strGroups).Append(" ");
                }
                var strOrders = getFields("OrderBy");
                if (strOrders != "")
                {
                    sqlBuilder.Append("Order By ").Append(strOrders).Append(" ");
                }
            }
            else
            {
                sqlBuilder.Append(FuncSQL);
            }
            return sqlBuilder.ToString();

        }
    }
}
