//using System;
//using System.Collections.Generic;
//using System.Data;
//using System.Data.Common;
//using System.Linq;
//using System.Text;
//using System.Data.SQLite;

//namespace MaxZhang.EasyEntities.Persistence.Provider
//{
//    public class SQLiteProvider:IDataProvider
//    {
//        private string connString;
//        private SQLiteConnection conn;
//        public SQLiteProvider() { }

//        public SQLiteProvider(string connString)
//        {
//            this.connString = connString;
//            conn = new SQLiteConnection(connString);
//        }

//        public SQLiteConnection Connection
//        {
//            get
//            {
//                if (conn == null)
//                {
//                    conn = new SQLiteConnection(connString);
//                }
//                return conn;
//            }
//        }

//        public DbConnection DbConnection
//        {
//            get { return Connection; }
//        }

//        public string Database
//        {
//            get { return "SQLite"; }
//        }

//        public string ParamPrefix
//        {
//            get { return "@"; }
//        }

//        public string ConnString
//        {
//            get { return connString; }
//            set { connString = value; }
//        }


//        public void Execute(Command command)
//        {
//            using (SQLiteCommand cmd = Connection.CreateCommand())
//            {
//                PrepareCommand(cmd, null, command);
//                cmd.ExecuteNonQuery();
//            }
//        }

//        public void Execute(List<Command> commands)
//        {
//            OpenConnection();
//            using (SQLiteTransaction trans = Connection.BeginTransaction())
//            {
//                SQLiteCommand cmd = Connection.CreateCommand();
//                try
//                {
//                    foreach (Command command in commands)
//                    {
//                        PrepareCommand(cmd, trans, command);
//                        cmd.ExecuteNonQuery();
//                    }
//                    trans.Commit();
//                }
//                catch (SQLiteException e)
//                {
//                    trans.Rollback();
//                    cmd.Dispose();
//                    throw new Exception(e.Message);
//                }
//            }
//        }

//        public object QueryScalar(Command command)
//        {
//            using (SQLiteCommand cmd = Connection.CreateCommand())
//            {
//                PrepareCommand(cmd, null, command);
//                return cmd.ExecuteScalar();
//            }
//        }

//        public IDataReader QueryData(Command command)
//        {
//            using (SQLiteCommand cmd = Connection.CreateCommand())
//            {
//                PrepareCommand(cmd, null, command);
//                SQLiteDataReader reader=null;
//                reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
//                return reader;
//            }
//        }

//        public DataSet Query(Command command)
//        {
//            using (SQLiteCommand cmd = Connection.CreateCommand())
//            {
//                PrepareCommand(cmd, null, command);
//                DataSet ds = new DataSet();
//                SQLiteDataAdapter da = new SQLiteDataAdapter(cmd);
//                da.Fill(ds);
//                return ds;
//            }
//        } 


//        private void OpenConnection()
//        {
//            if (Connection.State != ConnectionState.Open)
//            {
//                Connection.Open();
//            }
//        }

//        private void PrepareCommand(SQLiteCommand cmd, SQLiteTransaction trans, Command command)
//        {
//            if (trans != null)
//            {
//                cmd.Transaction = trans;
//            }
//            cmd.CommandText = command.Text;
//            if (command.HasParameter)
//            {
//                cmd.Parameters.Clear();
//                foreach (Parameter param in command.Parameters)
//                {
//                    cmd.Parameters.Add(new SQLiteParameter(param.Name, param.Value));
//                }
//            }
//            OpenConnection();
//        }


//        public void Dispose()
//        {
//            if (Connection != null)
//            {
//                if (Connection.State != ConnectionState.Closed)
//                {
//                    Connection.Close();
//                }
//                Connection.Dispose();
//            }
            
//        }
//    }
//}
