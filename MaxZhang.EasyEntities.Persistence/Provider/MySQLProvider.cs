using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Data;
using MaxZhang.EasyEntities.Persistence.Provider;
using MySql.Data.MySqlClient;

namespace MaxZhang.EasyEntities.Persistence.Provider
{
	public class MySQLProvider : IDataProvider
	{
		private string connString;
		private MySqlConnection conn;

		public MySQLProvider() { }

		public MySQLProvider(string connString)
		{
			this.connString = connString;
			conn = new MySqlConnection(connString);
		}

		public MySqlConnection Connection
		{
			get
			{
				if (conn == null)
				{
					conn = new MySqlConnection(connString);
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
			get { return "MySQL"; }
		}

		public string ParamPrefix
		{
			get { return "?"; }
		}

		public string ConnString
		{
			get { return connString; }
			set { connString = value; }
		}


		public void Execute(Command command)
		{
			using (MySqlCommand cmd = Connection.CreateCommand())
			{
				PrepareCommand(cmd, null, command);
				cmd.ExecuteNonQuery();
			}
		}

		public void Execute(List<Command> commands)
		{
			OpenConnection();
			using (MySqlTransaction trans = Connection.BeginTransaction())
			{
				MySqlCommand cmd = Connection.CreateCommand();
				try
				{
					foreach (Command command in commands)
					{
						PrepareCommand(cmd, trans, command);
						cmd.ExecuteNonQuery();
					}
					trans.Commit();
				}
				catch (MySqlException e)
				{
					trans.Rollback();
					cmd.Dispose();
					throw new Exception(e.Message);
				}
			}
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


		public object QueryScalar(Command command)
		{
			using (MySqlCommand cmd = Connection.CreateCommand())
			{
				PrepareCommand(cmd, null, command);
				return cmd.ExecuteScalar();
			}
		}

		public IDataReader QueryData(Command command)
		{
			using (MySqlCommand cmd = Connection.CreateCommand())
			{
				PrepareCommand(cmd, null, command);
				return cmd.ExecuteReader(CommandBehavior.CloseConnection);
			}
		}

		public DataSet Query(Command command)
		{
			using (MySqlCommand cmd = Connection.CreateCommand())
			{
				PrepareCommand(cmd, null, command);
				DataSet ds=new DataSet();
				MySqlDataAdapter da=new MySqlDataAdapter(cmd);
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

		private void PrepareCommand(MySqlCommand cmd, MySqlTransaction trans, Command command)
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
					cmd.Parameters.Add(new MySqlParameter(param.Name, param.Value));
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


		public DataTable FillSchema(string tableName,Command command)
		{
			using (MySqlCommand cmd = Connection.CreateCommand())
			{
				PrepareCommand(cmd, null, command);
				DataSet ds=new DataSet();
				MySqlDataAdapter da=new MySqlDataAdapter(cmd);
				da.FillSchema(ds,SchemaType.Mapped,tableName);
				return ds.Tables[0];
			}
		}



	}
}







