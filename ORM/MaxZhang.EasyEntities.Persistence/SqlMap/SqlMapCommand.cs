using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using MaxZhang.EasyEntities.Persistence.Provider;

namespace MaxZhang.EasyEntities.Persistence.SqlMap
{
    public class SqlMapCommand
    {
        public SqlMapCommand()
        {
            Parameters = new List<SqlMapParameter>();
        }
        public string SQLType { set; get; }
        public string Name { set; get; }
        public string Memo { set; get; }
        public string ReturnType { set; get; }
        public IDataProvider DataProvider{set;get;}


        public List<SqlMapParameter> Parameters { set; get; }
        public string SQL { set; get; }
        public void SetParameterValue(string name,object value)
        {
            if (!Parameters.Any(p => p.Name == name))
            {
                Parameters.Add(new SqlMapParameter() { Name = name, Type = value.GetType(), Value = value });
            }
            else
            {
                var parameter = Parameters.First(p => p.Name == name);
                parameter.Type = value.GetType();
                parameter.Value = value;

            }
                
        }

        public IDataReader Query(params object[] values)
        {
            if (values.Length < this.Parameters.Count)
                throw new NotSupportedException("执行参数数小于实际参数数量！");

            string sql = this.SQL;
            Regex regex = new Regex(@"#(\w+):(\w+)[,]?(out|input)?#");
            var ms = regex.Matches(sql);
            foreach (Match m in ms)
            {
                sql = sql.Replace(m.Groups[0].Value, DataProvider.ParamPrefix + m.Groups[1].Value);
            }
            var command = new Command(
                    sql,
                    this.Parameters.Select( p=>
                            new Parameter(p.Name,p.Value)).ToList());

            for (int i=0;i<values.Length;i++)
            {
                command.Parameters[i].Value = values[i];
            }

            return DataProvider.QueryData(command);
        }



        public DataSet Query()
        {
            string sql = this.SQL;
            Regex regex = new Regex(@"#(\w+):(\w+)[,]?(out|input)?#");
            var ms = regex.Matches(sql);
            foreach (Match m in ms)
            {
                sql = sql.Replace(m.Groups[0].Value, "@" + m.Groups[1].Value);
            }
            var command = new Command(
                    sql,
                    this.Parameters.Select(p =>
                            new Parameter(p.Name, p.Value)).ToList());

            return DataProvider.Query(command);
        }


        /// <summary>
        /// 查询
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="values"></param>
        /// <returns></returns>
        public List<T> Query<T>(params object[] values)
        {
            List<T> list = new List<T>();
            using (IDataReader iReader = Query(values))
            {
                while (iReader.Read())
                {
                    T tm = default(T);
                    tm = iReader.ToEntity<T>();
                    list.Add(tm);
                }
            }
            return list;
        }

        public DataSet QueryData(params object[] values)
        {
            DataSet ds = new DataSet();
            ds.Load(Query(values), LoadOption.OverwriteChanges, "");
            return ds;
        }

    }
}
