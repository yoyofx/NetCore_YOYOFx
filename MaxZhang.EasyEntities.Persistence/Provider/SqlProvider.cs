using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace MaxZhang.EasyEntities.Persistence.Provider
{
    public class SqlProvider : IDataProvider
    {
        private string connString;
        private SqlConnection conn;

        public SqlProvider() { }

        public SqlProvider(string connString)
        {
            this.connString = connString;
            conn = new SqlConnection(connString);
        }

        public SqlConnection Connection
        {
            get
            {
                if (conn == null)
                {
                    conn = new SqlConnection(connString);
                }
                return conn;
            }
        }

        public DbConnection DbConnection
        {
            get { return Connection; }
        }

        public string DateTimeFlagString
        {
            get { return "'{0}'"; }
        }

        public string Database
        {
            get { return "SQL Server"; }
        }

        public string ParamPrefix
        {
            get { return "@"; }
        }

        public string ConnString
        {
            get { return connString; }
            set { connString = value; }
        }

        /// <summary>
        /// 平台函数名callback
        /// </summary>
        /// <param name="methodName"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public string GetFunctionNameCallback(string methodName, params object[] parameters)
        {
            string funcName = null;
            switch(methodName)
            {
                case "getdate":
                    funcName = "GETDATE()";
                    break;
            }

            return funcName;

        }


        public void Execute(Command command)
        {
            OpenConnection();
            using (SqlTransaction trans = Connection.BeginTransaction())
            {
                using (SqlCommand cmd = Connection.CreateCommand())
                {
                    PrepareCommand(cmd, trans, command);
                    try
                    {
                        cmd.ExecuteNonQuery();
                        trans.Commit();
                    }
                    catch (SqlException e)
                    {
                        trans.Rollback();
                        cmd.Dispose();
                        throw new Exception(e.Message);
                    }
                }
            }
        }

        public void Execute(List<Command> commands)
        {
            OpenConnection();
            using (SqlTransaction trans = Connection.BeginTransaction())
            {
                SqlCommand cmd = Connection.CreateCommand();
                try
                {
                    foreach (Command command in commands)
                    {
                        PrepareCommand(cmd, trans, command);
                        cmd.ExecuteNonQuery();
                    }
                    trans.Commit();
                }
                catch (SqlException e)
                {
                    trans.Rollback();
                    cmd.Dispose();
                    throw new Exception(e.Message);
                }
            }
        }

        public object QueryScalar(Command command)
        {
            using (SqlCommand cmd = Connection.CreateCommand())
            {
                PrepareCommand(cmd, null, command);
                return cmd.ExecuteScalar();
            }
        }

        public IDataReader QueryData(Command command)
        {
            using (SqlCommand cmd = Connection.CreateCommand())
            {
                PrepareCommand(cmd, null, command);
                return cmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
        }

        public DataSet Query(Command command)
        {
            using (SqlCommand cmd = Connection.CreateCommand())
            {
                PrepareCommand(cmd, null, command);
                DataSet ds=new DataSet();
                SqlDataAdapter da=new SqlDataAdapter(cmd);
                if (!string.IsNullOrEmpty(command.TableName))
                    da.Fill(ds, command.TableName);
                else
                {
                    da.Fill(ds);
                }
                return ds;
            }
        }


        #region 存储过程


        /// <summary>
        /// 执行存储过程，返回SqlDataReader ( 注意：调用该方法后，一定要对SqlDataReader进行Close )
        /// </summary>
        /// <param name="storedProcName">存储过程名</param>
        /// <param name="parameters">存储过程参数</param>
        /// <returns>SqlDataReader</returns>
        public int RunProcedureRef(string storedProcName, IDataParameter[] parameters)
        {
            SqlConnection connection = Connection;
            OpenConnection();
            SqlCommand command = (SqlCommand)StoredProcCommandBuilder.BuildQueryCommand(connection, storedProcName, parameters);
            try
            {
                return command.ExecuteNonQuery();
            }
            catch (System.Exception ex)
            {
                connection.Close();
            }
            finally
            {
                command.Dispose();
            }

            return 0;

        }

        /// <summary>
        /// 执行存储过程，返回SqlDataReader ( 注意：调用该方法后，一定要对SqlDataReader进行Close )
        /// </summary>
        /// <param name="storedProcName">存储过程名</param>
        /// <param name="parameters">存储过程参数</param>
        /// <returns>SqlDataReader</returns>
        public  SqlDataReader RunProcedure(string storedProcName, IDataParameter[] parameters)
        {
            SqlConnection connection = Connection;
            SqlDataReader returnReader = null;
            OpenConnection();
            SqlCommand command = (SqlCommand)StoredProcCommandBuilder.BuildQueryCommand(connection, storedProcName, parameters);
            command.CommandType = CommandType.StoredProcedure;
            try
            {
                returnReader = command.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (System.Exception ex)
            {
                command.Dispose();
                connection.Close();
            }

            return returnReader;

        }
        
        #endregion

        public void Dispose()
        {
            if (Connection != null)
            {
                if (Connection.State != ConnectionState.Closed)
                {
                    Connection.Close();
                }
                Connection.Dispose();
            }
        }

        private void OpenConnection()
        {
            if (Connection.State != ConnectionState.Open)
            {
                Connection.Open();
            }
        }

        private void PrepareCommand(SqlCommand cmd, SqlTransaction trans, Command command)
        {
            if (trans != null)
            {
                cmd.Transaction = trans;
            }
            cmd.CommandText = command.Text;
            if (command.HasParameter)
            {
                cmd.Parameters.Clear();
                foreach (Parameter param in command.Parameters)
                {
                    cmd.Parameters.Add(new SqlParameter(param.Name, param.Value));
                }
            }
            OpenConnection();
        }


        #region Build(Command)
        /// <summary>
        /// 创建command、SqlParameter对象
        /// </summary>
        /// <param name="cmd"></param>
        /// <param name="conn"></param>
        /// <param name="trans"></param>
        /// <param name="cmdText"></param>
        /// <param name="cmdParms"></param>
        private  void PrepareCommand(SqlCommand cmd, SqlConnection conn, SqlTransaction trans, string cmdText, SqlParameter[] cmdParms)
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();
            cmd.Connection = conn;
            cmd.CommandText = cmdText;
            if (trans != null)
                cmd.Transaction = trans;
            cmd.CommandType = CommandType.Text;//cmdType;
            if (cmdParms != null)
            {
                foreach (SqlParameter parameter in cmdParms)
                {
                    if ((parameter.Direction == ParameterDirection.InputOutput || parameter.Direction == ParameterDirection.Input) &&
                        (parameter.Value == null))
                    {
                        parameter.Value = DBNull.Value;
                    }
                    cmd.Parameters.Add(parameter);
                }
            }
        }

    
        #endregion

        public string Log
        {
            set;
            get;
        }

        /// <summary>
        /// 更新DataSet，如果DataSet中有行添加、删除或数据更新则按每条数据执行相应的SQL语句。
        /// 必须对已用Query对象查询出来的DataSet或者在Command中指定TableName。
        /// </summary>
        /// <param name="ds"></param>
        public void UpdateDataSet(DataSet ds,string where=null)
        {
            var table = ds.Tables[0];
            this.BulkTable(table,table.TableName,where);

        }

        /// <summary>
        /// 批量操作表
        /// </summary>
        /// <param name="cmdType"></param>
        /// <param name="dt"></param>
        /// <param name="strTblName">数据库表名</param>
        /// <param name="where">除主键外的条件</param>
        /// <returns></returns>
        private int BulkTable(DataTable dt, string strTblName, string where=null)
        {
            int affect = 0;

                StringBuilder cmdFields = new StringBuilder();
                foreach (DataColumn column in dt.Columns)
                {
                    cmdFields.Append(column.ColumnName + ",");
                }
                if (cmdFields.Length > 0)
                {
                    cmdFields = cmdFields.Remove(cmdFields.Length - 1, 1);
                }
                using (SqlCommand myCommand = new SqlCommand(string.Format("select top 0 {0} from {1}", cmdFields, strTblName), conn))
                {
                    try
                    {
                        SqlDataAdapter myAdapter = new SqlDataAdapter();
                        myAdapter.SelectCommand = myCommand;
                        SqlCommandBuilder myCommandBuilder = new SqlCommandBuilder
                        {
                            DataAdapter = myAdapter,
                            SetAllValues = true,
                            ConflictOption = ConflictOption.OverwriteChanges,
                        };
                        myCommandBuilder.RefreshSchema();
                       
                     
                        myAdapter.InsertCommand = myCommandBuilder.GetInsertCommand(true);
                        myAdapter.InsertCommand.Connection = conn;
                        myAdapter.UpdateCommand = myCommandBuilder.GetUpdateCommand(true);
                        myAdapter.DeleteCommand = myCommandBuilder.GetDeleteCommand(true);

                        if (!string.IsNullOrEmpty(where))
                        {
                            myAdapter.UpdateCommand.CommandText = myAdapter.UpdateCommand.CommandText.Replace("WHERE", "WHERE " + where + " and ");
                        }

                        var dd = dt.GetChanges(DataRowState.Added);
                        affect = myAdapter.Update(dt);
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    finally
                    {
                        
                    }
                }
            
            return affect;
        }

		public DataTable FillSchema(string tableName,Command command){
			using (SqlCommand cmd = Connection.CreateCommand())
			{
				PrepareCommand(cmd, null, command);
				DataSet ds=new DataSet();
				SqlDataAdapter da=new SqlDataAdapter(cmd);
				da.FillSchema(ds,SchemaType.Mapped,tableName);
				return ds.Tables[0];
			}
		}

      
    }
}