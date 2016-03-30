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
			Console.WriteLine ("Start Generate Code ......");
			string Namespace = ConfigurationManager.AppSettings ["Namespace"].ToString ();
			using (var session = DbSession.Default)
			{
				var schemaTables = GetDatabaseSchema (session,"Tables");
				GenerateCodeBuilder builder = new GenerateCodeBuilder (Namespace);
				builder.BuildNamespaceStart ();
				int index = 1;
				foreach (DataRow dtrow in schemaTables.Rows) {
					string TableName = dtrow ["TABLE_NAME"].ToString ();
					var schemaColumns = GetDatabaseSchema (session, "Columns", new string[] { null, null, TableName, null });
					var tableSchema = GetTableSchema (session,TableName);
					builder.BuildClass (TableName, tableSchema, schemaColumns);
					Console.WriteLine (string.Format ("Table:{0} Complated; {1}/{2}",TableName,index++,schemaTables.Rows.Count) );

				}
				builder.BuildNamespaceEnd();

				File.WriteAllText (Path.Combine (Environment.CurrentDirectory, "Database.cs"), builder.ToString());

				Console.WriteLine ("ALL DONE!");
			}

			Console.WriteLine (Environment.CurrentDirectory);
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
