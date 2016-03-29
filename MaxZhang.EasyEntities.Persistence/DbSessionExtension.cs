using MaxZhang.EasyEntities.Persistence.Provider;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.OracleClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace MaxZhang.EasyEntities.Persistence
{
    public static class DbSessionExtension
    {
        /// <summary>
        /// 创建用于查询单表的条件对象
        /// </summary>
        /// <returns></returns>
        public static QueryConditional CreateConditional<TModel>(this DbSession session, Expression<Func<TModel, bool>> expr)
        {
            return new QueryConditional<TModel>(expr, session.Provider);
        }

        /// <summary>
        /// 创建用于查询多表的条件对象
        /// </summary>
        /// <returns></returns>
        public static QueryConditional CreateConditional<TModel1, TModel2>(this DbSession session, Expression<Func<TModel1, TModel2, bool>> expr)
        {
            return new QueryConditional<TModel1, TModel2>(expr, session.Provider);
        }

        /// <summary>
        /// 创建用于查询多表的条件对象
        /// </summary>
        /// <returns></returns>
        public static QueryConditional CreateConditional<TModel1, TModel2, TModel3>(this DbSession session, Expression<Func<TModel1, TModel2, TModel3, bool>> expr)
        {
            return new QueryConditional<TModel1, TModel2, TModel3>(expr, session.Provider);
        }

        /// <summary>
        /// 创建用于查询多表的条件对象
        /// </summary>
        /// <returns></returns>
        public static QueryConditional CreateConditional<TModel1, TModel2, TModel3, TModel4>(this DbSession session, Expression<Func<TModel1, TModel2, TModel3, TModel4, bool>> expr)
        {
            return new QueryConditional<TModel1, TModel2, TModel3, TModel4>(expr, session.Provider);
        }

        /// <summary>
        /// 创建用于查询多表的条件对象
        /// </summary>
        /// <returns></returns>
        public static QueryConditional CreateConditional<TModel1, TModel2, TModel3, TModel4, TModel5>(this DbSession session, Expression<Func<TModel1, TModel2, TModel3, TModel4, TModel5, bool>> expr)
        {
            return new QueryConditional<TModel1, TModel2, TModel3, TModel4,TModel5>(expr, session.Provider);
        }


        /// <summary>
        /// 执行存储过程，返回SqlDataReader ( 注意：调用该方法后，一定要对SqlDataReader进行Close )
        /// </summary>
        /// <param name="storedProcName">存储过程名</param>
        /// <param name="parameters">存储过程参数</param>
        /// <returns>SqlDataReader</returns>
        public static DataSet RunStoredProcedure(this DbSession session, string storedProcName, IDataParameter[] parameters)
        {
            DataSet ds = new DataSet();
            IDbConnection connection = session.Provider.DbConnection;
            IDbCommand command = StoredProcCommandBuilder.BuildQueryCommand(connection, storedProcName, parameters);
            command.CommandType = CommandType.StoredProcedure;
            try
            {
                string assemblyName = connection.GetType().Assembly.FullName;
                string typeName = connection.GetType().FullName.Replace("Connection", "DataAdapter"); // You may be more conservative than this
                DbDataAdapter adapter = (DbDataAdapter)Activator.CreateInstance(assemblyName, typeName).Unwrap();
                adapter.SelectCommand = (DbCommand)command;
                adapter.Fill(ds); 
            }
            catch (System.Exception ex)
            {
                connection.Close();
            }
            finally
            {
                //command.Dispose();
                connection.Close();
            }

            return ds;

        }


    }
}
