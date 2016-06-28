using System;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading;
using System.Globalization;

namespace YGC
{
	public class GenerateCodeBuilder
	{
		private StringBuilder generateCodeBuilder = new StringBuilder();
		private string _nameSpace;
		public GenerateCodeBuilder(string nameSpace)
		{
			this._nameSpace = nameSpace;
		}
			



		public void BuildNamespaceEnd()
		{
			generateCodeBuilder.AppendLine("}");
		}

		public void BuildNamespaceStart()
		{
			generateCodeBuilder.AppendLine ("using System;");
			generateCodeBuilder.AppendLine ("using ExtendPropertyLib;");
			generateCodeBuilder.AppendLine("using System;");
			generateCodeBuilder.AppendLine("using MaxZhang.EasyEntities.Persistence;");
			generateCodeBuilder.AppendLine("using MaxZhang.EasyEntities.Persistence.Mapping;");
			generateCodeBuilder.AppendLine("using MaxZhang.EasyEntities.Persistence.Provider;");
			generateCodeBuilder.Append ("namespace").Append(" ").AppendLine(_nameSpace);
			generateCodeBuilder.AppendLine ("{");
		}

		public void BuildClass(string tableName,DataTable tableSchema,DataTable columnsSchema)
		{
			generateCodeBuilder.Append ("\tpublic partial class").Append(" ").Append(tableName).AppendLine(" : DbObject");
			generateCodeBuilder.AppendLine ("\t{");
			//ctor
			generateCodeBuilder.Append ("\t\tstatic ").Append(tableName).AppendLine("() {");
			generateCodeBuilder.AppendFormat("\t\t\tTableNameProperty.AddOwner(typeof({0}),\"{0}\");",tableName).AppendLine();

			generateCodeBuilder.AppendFormat ("\t\t\tKeysProperty.AddOwner(typeof({0}),new string[]", tableName).Append ("{")
				.Append (String.Join (",", tableSchema.PrimaryKey.Select (p => string.Format("\"{0}\"" ,p.ColumnName) ))).Append ("});").AppendLine();;

			//end stor
			generateCodeBuilder.AppendLine ("\t\t} ");

			//property
			for (int i=0; i<tableSchema.Columns.Count ; i++) {
				DataColumn column = tableSchema.Columns[i];
				string COMMENT = columnsSchema.Rows [i]["COLUMN_COMMENT"].ToString();
				bool isPrimaryKey = tableSchema.PrimaryKey.Contains (column);
				BuildProperty (tableName,column, COMMENT , isPrimaryKey);
			}

			//end class
			generateCodeBuilder.AppendLine ("\t}").AppendLine();
		}


		private void BuildProperty(string tableName, DataColumn column,string comment ,bool isKey)
		{
			string strPropertyType = column.AllowDBNull && column.DataType.IsValueType ? 
				string.Format("Nullable<{0}>",column.DataType.Name) : column.DataType.Name;

			string metadata = string.Format (" FieldName = \"{0}\", IsKey = {1}, IDentity = {2}", column.ColumnName, isKey ? "true" : "false", column.AutoIncrement ? "true" : "false");
			StringBuilder sb = new StringBuilder ();
			sb.Append ("{").Append (metadata).Append ("});");
			generateCodeBuilder.AppendFormat ("\t\tpublic static ExtendProperty {0}Property = ExtendProperty.RegisterProperty(\"{1}\", typeof({2}), typeof({3}),\n\t\t\tnew DbMetaData() ",
				tableName + column.ColumnName, column.ColumnName, strPropertyType, tableName).Append(sb).AppendLine();

			generateCodeBuilder.AppendLine("\t\t///<summary>");
			generateCodeBuilder.Append ("\t\t///").AppendLine (comment.Replace(Environment.NewLine,"\t\t///"));
			generateCodeBuilder.AppendLine ("\t\t///</summary>");
			TextInfo tInfo = Thread.CurrentThread.CurrentCulture.TextInfo;
			generateCodeBuilder.Append ("\t\tpublic ").Append (strPropertyType).Append (" ").Append ( tInfo.ToTitleCase(column.ColumnName)).AppendLine();
			generateCodeBuilder.AppendLine ("\t\t{");
			generateCodeBuilder.Append ("\t\t\tset { this.SetValue(").Append(tableName).Append(column.ColumnName).Append("Property, value); }").AppendLine();
			generateCodeBuilder.Append ("\t\t\t").Append ("get { return (").Append (strPropertyType).Append (") this.GetValue(").Append (tableName).Append (column.ColumnName).Append ("Property); }").AppendLine ();
			generateCodeBuilder.AppendLine ("\t\t}").AppendLine ();
		}


		public override string ToString ()
		{
			return generateCodeBuilder.ToString ();
		}
	}
}

