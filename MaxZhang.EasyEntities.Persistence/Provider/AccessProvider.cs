using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OleDb;

namespace MaxZhang.EasyEntities.Persistence.Provider
{
	public class AccessProvider : IDataProvider
	{
		private string connString;
		private OleDbConnection conn;

		public AccessProvider() { }

		public AccessProvider(string connString)
		{
			this.connString = connString;
			conn = new OleDbConnection(connString);
		}

		public OleDbConnection Connection
		{
			get
			{
				if (conn == null)
				{
					conn = new OleDbConnection(connString);
				}
				return conn;
			}
		}

        public DbConnection DbConnection
        {
            get { return Connection; }
        }

		public string Database
		{
			get { return "Access"; }
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

		public void Execute(Command command)
		{
			using (OleDbCommand cmd = Connection.CreateCommand())
			{
				PrepareCommand(cmd, null, command);
				cmd.ExecuteNonQuery();
			}
		}

		public void Execute(List<Command> commands)
		{
			OpenConnection();
			using (OleDbTransaction trans = Connection.BeginTransaction())
			{
				OleDbCommand cmd = Connection.CreateCommand();
				try
				{
					foreach (Command command in commands)
					{
						PrepareCommand(cmd, trans, command);
						cmd.ExecuteNonQuery();
					}
					trans.Commit();
				}
				catch (OleDbException e)
				{
					trans.Rollback();
					cmd.Dispose();
					throw new Exception(e.Message);
				}
			}
		}

		public object QueryScalar(Command command)
		{
			using (OleDbCommand cmd = Connection.CreateCommand())
			{
				PrepareCommand(cmd, null, command);
				return cmd.ExecuteScalar();
			}
		}

		public IDataReader QueryData(Command command)
		{
			using (OleDbCommand cmd = Connection.CreateCommand())
			{
				PrepareCommand(cmd, null, command);
				return cmd.ExecuteReader(CommandBehavior.CloseConnection);
			}
		}

	    public DataSet Query(Command command)
	    {
            using (OleDbCommand cmd = Connection.CreateCommand())
            {
                PrepareCommand(cmd, null, command);
                DataSet ds=new DataSet();
                OleDbDataAdapter da=new OleDbDataAdapter(cmd);
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

		private void PrepareCommand(OleDbCommand cmd, OleDbTransaction trans, Command command)
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
					cmd.Parameters.Add(new OleDbParameter(param.Name, param.Value));
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


        public string DateTimeFlagString
        {
            get { return "#{0}#"; }
        }





        public string GetFunctionNameCallback(string methodName, params object[] parameters)
        {
            string funcName = null;
            switch (methodName)
            {
                case "getdate":
                    funcName = "DATE()";
                    break;
            }

            return funcName;
        }

		public DataTable FillSchema(string tableName,Command command){
			throw new NotImplementedException();
		}
    }
}
