using System;
using System.Data;
using System.Xml;
using System.Linq;
using ExtendPropertyLib;
using MaxZhang.EasyEntities.Persistence;
using MaxZhang.EasyEntities.Persistence.Provider;
using System.Collections.Generic;
using System.IO;
using System.Configuration;

namespace YGC
{
	class MainClass
	{
		public static void Main (string[] args)
		{
				using (var session = DbSession.Default) {
						session.Provider.DbConnection.Open ();
						var schemaTables = GetDatabaseSchema (session,"Tables");
						GenerateCodeBuilder builder = new GenerateCodeBuilder ("com.my.orm");
						builder.BuildNamespaceStart ();
						foreach (DataRow dtrow in schemaTables.Rows) {
							string TableName = dtrow ["TABLE_NAME"].ToString ();
							var schemaColumns = GetDatabaseSchema (session, "Columns", new string[] { null, null, TableName, null });
							var tableSchema = GetTableSchema (session,TableName);
							builder.BuildClass (TableName, tableSchema, schemaColumns);
							break;
						}

						builder.BuildNamespaceEnd();
						Console.WriteLine (builder.ToString());
				}

				
			Console.WriteLine (Environment.CurrentDirectory);

				Console.WriteLine ("The End!");
		}

		private static DataTable GetTableSchema(DbSession session,string TableName)
		{
			var cmd = new Command( string.Format("select * from {0} where 1=2",TableName));
			return session.Provider.FillSchema (TableName, cmd);
		}

		private static DataTable GetDatabaseSchema(DbSession session,string schema,string[] data = null)
		{
			var connection = session.Provider.DbConnection;
			if(connection.State == ConnectionState.Closed)
				connection.Open ();

			return connection.GetSchema (schema);
		}


	}
}
