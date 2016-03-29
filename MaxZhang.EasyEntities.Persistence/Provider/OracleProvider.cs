using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OracleClient;

namespace MaxZhang.EasyEntities.Persistence.Provider
{
    public class OracleProvider : IDataProvider
    {
        private string connString;
        private OracleConnection conn;

        public OracleProvider() { }

        public OracleProvider(string connString)
        {
            this.connString = connString;
            conn = new OracleConnection(connString);
        }

        public OracleConnection Connection
        {
            get
            {
                if (conn == null)
                {
                    conn = new OracleConnection(connString);
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
            get { return "to_date('{0}','yyyy-mm-ddhh24:mi:ss')"; }
        }

        public string Database
        {
            get { return "Oracle"; }
        }

        public string ParamPrefix
        {
            get { return ":"; }
        }

        public string ConnString
        {
            get { return connString; }
            set { connString = value; }
        }

        public string GetFunctionNameCallback(string methodName, params object[] parameters)
        {
            string funcName = null;
            switch (methodName)
            {
                case "getdate":
                    funcName = "SYSDATE";
                    break;
            }

            return funcName;
        }


        public void Execute(Command command)
        {
            using (OracleCommand cmd = Connection.CreateCommand())
            {
                PrepareCommand(cmd, null, command);
                cmd.ExecuteNonQuery();
            }
        }

        public void Execute(List<Command> commands)
        {
            OpenConnection();
            using (OracleTransaction trans = Connection.BeginTransaction())
            {
                OracleCommand cmd = Connection.CreateCommand();
                try
                {
                    foreach (Command command in commands)
                    {
                        PrepareCommand(cmd, trans, command);
                        cmd.ExecuteNonQuery();
                    }
                    trans.Commit();
                }
                catch (OracleException e)
                {
                    trans.Rollback();
                    cmd.Dispose();
                    throw new Exception(e.Message);
                }
            }
        }

        public object QueryScalar(Command command)
        {
            using (OracleCommand cmd = Connection.CreateCommand())
            {
                PrepareCommand(cmd, null, command);
                return cmd.ExecuteScalar();
            }
        }

        public IDataReader QueryData(Command command)
        {
            using (OracleCommand cmd = Connection.CreateCommand())
            {
                PrepareCommand(cmd, null, command);
                return cmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
        }

        public DataSet Query(Command command)
        {
            using (OracleCommand cmd = Connection.CreateCommand())
            {
                PrepareCommand(cmd, null, command);
                DataSet ds=new DataSet();
                OracleDataAdapter da=new OracleDataAdapter(cmd);
                da.Fill(ds);
                return ds;
            }
        }

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

        private void PrepareCommand(OracleCommand cmd, OracleTransaction trans, Command command)
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
                    cmd.Parameters.Add(new OracleParameter(param.Name, param.Value));
                }
            }
            OpenConnection();
        }

      


        public string Log
        {
            set;
            get;
        }


        public void UpdateDataSet(DataSet ds, string where = null)
        {
            throw new NotImplementedException();
        }

		public DataTable FillSchema(string tableName,Command command){
			throw new NotImplementedException();
		}



        
    }
}