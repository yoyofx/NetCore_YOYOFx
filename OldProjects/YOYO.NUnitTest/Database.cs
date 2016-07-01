using System;
using ExtendPropertyLib;
using System;
using MaxZhang.EasyEntities.Persistence;
using MaxZhang.EasyEntities.Persistence.Mapping;
using MaxZhang.EasyEntities.Persistence.Provider;
namespace paipaiyuan.fx.db
{
	public partial class ppy_action : DbObject
	{
		static ppy_action() {
			TableNameProperty.AddOwner(typeof(ppy_action),"ppy_action");
			KeysProperty.AddOwner(typeof(ppy_action),new string[]{"id"});
		} 
		public static ExtendProperty ppy_actionidProperty = ExtendProperty.RegisterProperty("id", typeof(UInt32), typeof(ppy_action),
			new DbMetaData() { FieldName = "id", IsKey = true, IDentity = false});
		///<summary>
		///主键
		///</summary>
		public UInt32 Id
		{
			set { this.SetValue(ppy_actionidProperty, value); }
			get { return (UInt32) this.GetValue(ppy_actionidProperty); }
		}

		public static ExtendProperty ppy_actionnameProperty = ExtendProperty.RegisterProperty("name", typeof(String), typeof(ppy_action),
			new DbMetaData() { FieldName = "name", IsKey = false, IDentity = false});
		///<summary>
		///行为唯一标识
		///</summary>
		public String Name
		{
			set { this.SetValue(ppy_actionnameProperty, value); }
			get { return (String) this.GetValue(ppy_actionnameProperty); }
		}

		public static ExtendProperty ppy_actiontitleProperty = ExtendProperty.RegisterProperty("title", typeof(String), typeof(ppy_action),
			new DbMetaData() { FieldName = "title", IsKey = false, IDentity = false});
		///<summary>
		///行为说明
		///</summary>
		public String Title
		{
			set { this.SetValue(ppy_actiontitleProperty, value); }
			get { return (String) this.GetValue(ppy_actiontitleProperty); }
		}

		public static ExtendProperty ppy_actionremarkProperty = ExtendProperty.RegisterProperty("remark", typeof(String), typeof(ppy_action),
			new DbMetaData() { FieldName = "remark", IsKey = false, IDentity = false});
		///<summary>
		///行为描述
		///</summary>
		public String Remark
		{
			set { this.SetValue(ppy_actionremarkProperty, value); }
			get { return (String) this.GetValue(ppy_actionremarkProperty); }
		}

		public static ExtendProperty ppy_actionruleProperty = ExtendProperty.RegisterProperty("rule", typeof(String), typeof(ppy_action),
			new DbMetaData() { FieldName = "rule", IsKey = false, IDentity = false});
		///<summary>
		///行为规则
		///</summary>
		public String Rule
		{
			set { this.SetValue(ppy_actionruleProperty, value); }
			get { return (String) this.GetValue(ppy_actionruleProperty); }
		}

		public static ExtendProperty ppy_actionlogProperty = ExtendProperty.RegisterProperty("log", typeof(String), typeof(ppy_action),
			new DbMetaData() { FieldName = "log", IsKey = false, IDentity = false});
		///<summary>
		///日志规则
		///</summary>
		public String Log
		{
			set { this.SetValue(ppy_actionlogProperty, value); }
			get { return (String) this.GetValue(ppy_actionlogProperty); }
		}

		public static ExtendProperty ppy_actiontypeProperty = ExtendProperty.RegisterProperty("type", typeof(Byte), typeof(ppy_action),
			new DbMetaData() { FieldName = "type", IsKey = false, IDentity = false});
		///<summary>
		///类型
		///</summary>
		public Byte Type
		{
			set { this.SetValue(ppy_actiontypeProperty, value); }
			get { return (Byte) this.GetValue(ppy_actiontypeProperty); }
		}

		public static ExtendProperty ppy_actionstatusProperty = ExtendProperty.RegisterProperty("status", typeof(SByte), typeof(ppy_action),
			new DbMetaData() { FieldName = "status", IsKey = false, IDentity = false});
		///<summary>
		///状态
		///</summary>
		public SByte Status
		{
			set { this.SetValue(ppy_actionstatusProperty, value); }
			get { return (SByte) this.GetValue(ppy_actionstatusProperty); }
		}

		public static ExtendProperty ppy_actionupdate_timeProperty = ExtendProperty.RegisterProperty("update_time", typeof(UInt32), typeof(ppy_action),
			new DbMetaData() { FieldName = "update_time", IsKey = false, IDentity = false});
		///<summary>
		///修改时间
		///</summary>
		public UInt32 Update_Time
		{
			set { this.SetValue(ppy_actionupdate_timeProperty, value); }
			get { return (UInt32) this.GetValue(ppy_actionupdate_timeProperty); }
		}

	}

	public partial class ppy_action_log : DbObject
	{
		static ppy_action_log() {
			TableNameProperty.AddOwner(typeof(ppy_action_log),"ppy_action_log");
			KeysProperty.AddOwner(typeof(ppy_action_log),new string[]{});
		} 
		public static ExtendProperty ppy_action_logidProperty = ExtendProperty.RegisterProperty("id", typeof(UInt32), typeof(ppy_action_log),
			new DbMetaData() { FieldName = "id", IsKey = false, IDentity = false});
		///<summary>
		///主键
		///</summary>
		public UInt32 Id
		{
			set { this.SetValue(ppy_action_logidProperty, value); }
			get { return (UInt32) this.GetValue(ppy_action_logidProperty); }
		}

		public static ExtendProperty ppy_action_logaction_idProperty = ExtendProperty.RegisterProperty("action_id", typeof(UInt32), typeof(ppy_action_log),
			new DbMetaData() { FieldName = "action_id", IsKey = false, IDentity = false});
		///<summary>
		///行为唯一标识
		///</summary>
		public UInt32 Action_Id
		{
			set { this.SetValue(ppy_action_logaction_idProperty, value); }
			get { return (UInt32) this.GetValue(ppy_action_logaction_idProperty); }
		}

		public static ExtendProperty ppy_action_loguser_idProperty = ExtendProperty.RegisterProperty("user_id", typeof(UInt32), typeof(ppy_action_log),
			new DbMetaData() { FieldName = "user_id", IsKey = false, IDentity = false});
		///<summary>
		///行为说明
		///</summary>
		public UInt32 User_Id
		{
			set { this.SetValue(ppy_action_loguser_idProperty, value); }
			get { return (UInt32) this.GetValue(ppy_action_loguser_idProperty); }
		}

		public static ExtendProperty ppy_action_logaction_ipProperty = ExtendProperty.RegisterProperty("action_ip", typeof(Int64), typeof(ppy_action_log),
			new DbMetaData() { FieldName = "action_ip", IsKey = false, IDentity = false});
		///<summary>
		///行为描述
		///</summary>
		public Int64 Action_Ip
		{
			set { this.SetValue(ppy_action_logaction_ipProperty, value); }
			get { return (Int64) this.GetValue(ppy_action_logaction_ipProperty); }
		}

		public static ExtendProperty ppy_action_logmodelProperty = ExtendProperty.RegisterProperty("model", typeof(String), typeof(ppy_action_log),
			new DbMetaData() { FieldName = "model", IsKey = false, IDentity = false});
		///<summary>
		///行为规则
		///</summary>
		public String Model
		{
			set { this.SetValue(ppy_action_logmodelProperty, value); }
			get { return (String) this.GetValue(ppy_action_logmodelProperty); }
		}

		public static ExtendProperty ppy_action_logrecord_idProperty = ExtendProperty.RegisterProperty("record_id", typeof(UInt32), typeof(ppy_action_log),
			new DbMetaData() { FieldName = "record_id", IsKey = false, IDentity = false});
		///<summary>
		///日志规则
		///</summary>
		public UInt32 Record_Id
		{
			set { this.SetValue(ppy_action_logrecord_idProperty, value); }
			get { return (UInt32) this.GetValue(ppy_action_logrecord_idProperty); }
		}

		public static ExtendProperty ppy_action_logremarkProperty = ExtendProperty.RegisterProperty("remark", typeof(String), typeof(ppy_action_log),
			new DbMetaData() { FieldName = "remark", IsKey = false, IDentity = false});
		///<summary>
		///类型
		///</summary>
		public String Remark
		{
			set { this.SetValue(ppy_action_logremarkProperty, value); }
			get { return (String) this.GetValue(ppy_action_logremarkProperty); }
		}

		public static ExtendProperty ppy_action_logstatusProperty = ExtendProperty.RegisterProperty("status", typeof(SByte), typeof(ppy_action_log),
			new DbMetaData() { FieldName = "status", IsKey = false, IDentity = false});
		///<summary>
		///状态
		///</summary>
		public SByte Status
		{
			set { this.SetValue(ppy_action_logstatusProperty, value); }
			get { return (SByte) this.GetValue(ppy_action_logstatusProperty); }
		}

		public static ExtendProperty ppy_action_logcreate_timeProperty = ExtendProperty.RegisterProperty("create_time", typeof(UInt32), typeof(ppy_action_log),
			new DbMetaData() { FieldName = "create_time", IsKey = false, IDentity = false});
		///<summary>
		///修改时间
		///</summary>
		public UInt32 Create_Time
		{
			set { this.SetValue(ppy_action_logcreate_timeProperty, value); }
			get { return (UInt32) this.GetValue(ppy_action_logcreate_timeProperty); }
		}

	}

	public partial class ppy_activityfiles : DbObject
	{
		static ppy_activityfiles() {
			TableNameProperty.AddOwner(typeof(ppy_activityfiles),"ppy_activityfiles");
			KeysProperty.AddOwner(typeof(ppy_activityfiles),new string[]{"CODE"});
		} 
		public static ExtendProperty ppy_activityfilesCODEProperty = ExtendProperty.RegisterProperty("CODE", typeof(Int64), typeof(ppy_activityfiles),
			new DbMetaData() { FieldName = "CODE", IsKey = true, IDentity = true});
		///<summary>
		///主键
		///</summary>
		public Int64 CODE
		{
			set { this.SetValue(ppy_activityfilesCODEProperty, value); }
			get { return (Int64) this.GetValue(ppy_activityfilesCODEProperty); }
		}

		public static ExtendProperty ppy_activityfilesACTIVITYCODEProperty = ExtendProperty.RegisterProperty("ACTIVITYCODE", typeof(Nullable<Int64>), typeof(ppy_activityfiles),
			new DbMetaData() { FieldName = "ACTIVITYCODE", IsKey = false, IDentity = false});
		///<summary>
		///行为唯一标识
		///</summary>
		public Nullable<Int64> ACTIVITYCODE
		{
			set { this.SetValue(ppy_activityfilesACTIVITYCODEProperty, value); }
			get { return (Nullable<Int64>) this.GetValue(ppy_activityfilesACTIVITYCODEProperty); }
		}

		public static ExtendProperty ppy_activityfilesDEALERCODEProperty = ExtendProperty.RegisterProperty("DEALERCODE", typeof(Nullable<Int32>), typeof(ppy_activityfiles),
			new DbMetaData() { FieldName = "DEALERCODE", IsKey = false, IDentity = false});
		///<summary>
		///行为说明
		///</summary>
		public Nullable<Int32> DEALERCODE
		{
			set { this.SetValue(ppy_activityfilesDEALERCODEProperty, value); }
			get { return (Nullable<Int32>) this.GetValue(ppy_activityfilesDEALERCODEProperty); }
		}

		public static ExtendProperty ppy_activityfilesCREATEDATEProperty = ExtendProperty.RegisterProperty("CREATEDATE", typeof(Nullable<DateTime>), typeof(ppy_activityfiles),
			new DbMetaData() { FieldName = "CREATEDATE", IsKey = false, IDentity = false});
		///<summary>
		///行为描述
		///</summary>
		public Nullable<DateTime> CREATEDATE
		{
			set { this.SetValue(ppy_activityfilesCREATEDATEProperty, value); }
			get { return (Nullable<DateTime>) this.GetValue(ppy_activityfilesCREATEDATEProperty); }
		}

		public static ExtendProperty ppy_activityfilesFILEPATHProperty = ExtendProperty.RegisterProperty("FILEPATH", typeof(String), typeof(ppy_activityfiles),
			new DbMetaData() { FieldName = "FILEPATH", IsKey = false, IDentity = false});
		///<summary>
		///行为规则
		///</summary>
		public String FILEPATH
		{
			set { this.SetValue(ppy_activityfilesFILEPATHProperty, value); }
			get { return (String) this.GetValue(ppy_activityfilesFILEPATHProperty); }
		}

		public static ExtendProperty ppy_activityfilesFILETYPEProperty = ExtendProperty.RegisterProperty("FILETYPE", typeof(Nullable<SByte>), typeof(ppy_activityfiles),
			new DbMetaData() { FieldName = "FILETYPE", IsKey = false, IDentity = false});
		///<summary>
		///日志规则
		///</summary>
		public Nullable<SByte> FILETYPE
		{
			set { this.SetValue(ppy_activityfilesFILETYPEProperty, value); }
			get { return (Nullable<SByte>) this.GetValue(ppy_activityfilesFILETYPEProperty); }
		}

	}

	public partial class ppy_activityinfo : DbObject
	{
		static ppy_activityinfo() {
			TableNameProperty.AddOwner(typeof(ppy_activityinfo),"ppy_activityinfo");
			KeysProperty.AddOwner(typeof(ppy_activityinfo),new string[]{"CODE"});
		} 
		public static ExtendProperty ppy_activityinfoCODEProperty = ExtendProperty.RegisterProperty("CODE", typeof(Int64), typeof(ppy_activityinfo),
			new DbMetaData() { FieldName = "CODE", IsKey = true, IDentity = true});
		///<summary>
		///主键
		///</summary>
		public Int64 CODE
		{
			set { this.SetValue(ppy_activityinfoCODEProperty, value); }
			get { return (Int64) this.GetValue(ppy_activityinfoCODEProperty); }
		}

		public static ExtendProperty ppy_activityinfoNAMEProperty = ExtendProperty.RegisterProperty("NAME", typeof(String), typeof(ppy_activityinfo),
			new DbMetaData() { FieldName = "NAME", IsKey = false, IDentity = false});
		///<summary>
		///行为唯一标识
		///</summary>
		public String NAME
		{
			set { this.SetValue(ppy_activityinfoNAMEProperty, value); }
			get { return (String) this.GetValue(ppy_activityinfoNAMEProperty); }
		}

		public static ExtendProperty ppy_activityinfoADDRESSProperty = ExtendProperty.RegisterProperty("ADDRESS", typeof(String), typeof(ppy_activityinfo),
			new DbMetaData() { FieldName = "ADDRESS", IsKey = false, IDentity = false});
		///<summary>
		///行为说明
		///</summary>
		public String ADDRESS
		{
			set { this.SetValue(ppy_activityinfoADDRESSProperty, value); }
			get { return (String) this.GetValue(ppy_activityinfoADDRESSProperty); }
		}

		public static ExtendProperty ppy_activityinfoREGIONProperty = ExtendProperty.RegisterProperty("REGION", typeof(Nullable<Int16>), typeof(ppy_activityinfo),
			new DbMetaData() { FieldName = "REGION", IsKey = false, IDentity = false});
		///<summary>
		///行为描述
		///</summary>
		public Nullable<Int16> REGION
		{
			set { this.SetValue(ppy_activityinfoREGIONProperty, value); }
			get { return (Nullable<Int16>) this.GetValue(ppy_activityinfoREGIONProperty); }
		}

		public static ExtendProperty ppy_activityinfoCONTENTProperty = ExtendProperty.RegisterProperty("CONTENT", typeof(String), typeof(ppy_activityinfo),
			new DbMetaData() { FieldName = "CONTENT", IsKey = false, IDentity = false});
		///<summary>
		///行为规则
		///</summary>
		public String CONTENT
		{
			set { this.SetValue(ppy_activityinfoCONTENTProperty, value); }
			get { return (String) this.GetValue(ppy_activityinfoCONTENTProperty); }
		}

		public static ExtendProperty ppy_activityinfoBEGINTIMEProperty = ExtendProperty.RegisterProperty("BEGINTIME", typeof(Nullable<DateTime>), typeof(ppy_activityinfo),
			new DbMetaData() { FieldName = "BEGINTIME", IsKey = false, IDentity = false});
		///<summary>
		///日志规则
		///</summary>
		public Nullable<DateTime> BEGINTIME
		{
			set { this.SetValue(ppy_activityinfoBEGINTIMEProperty, value); }
			get { return (Nullable<DateTime>) this.GetValue(ppy_activityinfoBEGINTIMEProperty); }
		}

		public static ExtendProperty ppy_activityinfoENDTIMEProperty = ExtendProperty.RegisterProperty("ENDTIME", typeof(Nullable<DateTime>), typeof(ppy_activityinfo),
			new DbMetaData() { FieldName = "ENDTIME", IsKey = false, IDentity = false});
		///<summary>
		///类型
		///</summary>
		public Nullable<DateTime> ENDTIME
		{
			set { this.SetValue(ppy_activityinfoENDTIMEProperty, value); }
			get { return (Nullable<DateTime>) this.GetValue(ppy_activityinfoENDTIMEProperty); }
		}

		public static ExtendProperty ppy_activityinfoAPROCEDUREProperty = ExtendProperty.RegisterProperty("APROCEDURE", typeof(String), typeof(ppy_activityinfo),
			new DbMetaData() { FieldName = "APROCEDURE", IsKey = false, IDentity = false});
		///<summary>
		///状态
		///</summary>
		public String APROCEDURE
		{
			set { this.SetValue(ppy_activityinfoAPROCEDUREProperty, value); }
			get { return (String) this.GetValue(ppy_activityinfoAPROCEDUREProperty); }
		}

		public static ExtendProperty ppy_activityinfoORGNAMEProperty = ExtendProperty.RegisterProperty("ORGNAME", typeof(String), typeof(ppy_activityinfo),
			new DbMetaData() { FieldName = "ORGNAME", IsKey = false, IDentity = false});
		///<summary>
		///修改时间
		///</summary>
		public String ORGNAME
		{
			set { this.SetValue(ppy_activityinfoORGNAMEProperty, value); }
			get { return (String) this.GetValue(ppy_activityinfoORGNAMEProperty); }
		}

		public static ExtendProperty ppy_activityinfoORGPHONEProperty = ExtendProperty.RegisterProperty("ORGPHONE", typeof(String), typeof(ppy_activityinfo),
			new DbMetaData() { FieldName = "ORGPHONE", IsKey = false, IDentity = false});
		///<summary>
		///主键
		///</summary>
		public String ORGPHONE
		{
			set { this.SetValue(ppy_activityinfoORGPHONEProperty, value); }
			get { return (String) this.GetValue(ppy_activityinfoORGPHONEProperty); }
		}

		public static ExtendProperty ppy_activityinfoORGIDCARDProperty = ExtendProperty.RegisterProperty("ORGIDCARD", typeof(String), typeof(ppy_activityinfo),
			new DbMetaData() { FieldName = "ORGIDCARD", IsKey = false, IDentity = false});
		///<summary>
		///行为id
		///</summary>
		public String ORGIDCARD
		{
			set { this.SetValue(ppy_activityinfoORGIDCARDProperty, value); }
			get { return (String) this.GetValue(ppy_activityinfoORGIDCARDProperty); }
		}

		public static ExtendProperty ppy_activityinfoORGNATUREProperty = ExtendProperty.RegisterProperty("ORGNATURE", typeof(Nullable<Boolean>), typeof(ppy_activityinfo),
			new DbMetaData() { FieldName = "ORGNATURE", IsKey = false, IDentity = false});
		///<summary>
		///执行用户id
		///</summary>
		public Nullable<Boolean> ORGNATURE
		{
			set { this.SetValue(ppy_activityinfoORGNATUREProperty, value); }
			get { return (Nullable<Boolean>) this.GetValue(ppy_activityinfoORGNATUREProperty); }
		}

		public static ExtendProperty ppy_activityinfoLONGITUDEProperty = ExtendProperty.RegisterProperty("LONGITUDE", typeof(String), typeof(ppy_activityinfo),
			new DbMetaData() { FieldName = "LONGITUDE", IsKey = false, IDentity = false});
		///<summary>
		///执行行为者ip
		///</summary>
		public String LONGITUDE
		{
			set { this.SetValue(ppy_activityinfoLONGITUDEProperty, value); }
			get { return (String) this.GetValue(ppy_activityinfoLONGITUDEProperty); }
		}

		public static ExtendProperty ppy_activityinfoLATITUDEProperty = ExtendProperty.RegisterProperty("LATITUDE", typeof(String), typeof(ppy_activityinfo),
			new DbMetaData() { FieldName = "LATITUDE", IsKey = false, IDentity = false});
		///<summary>
		///触发行为的表
		///</summary>
		public String LATITUDE
		{
			set { this.SetValue(ppy_activityinfoLATITUDEProperty, value); }
			get { return (String) this.GetValue(ppy_activityinfoLATITUDEProperty); }
		}

		public static ExtendProperty ppy_activityinfoTOTALPAYMENTProperty = ExtendProperty.RegisterProperty("TOTALPAYMENT", typeof(Nullable<Decimal>), typeof(ppy_activityinfo),
			new DbMetaData() { FieldName = "TOTALPAYMENT", IsKey = false, IDentity = false});
		///<summary>
		///触发行为的数据id
		///</summary>
		public Nullable<Decimal> TOTALPAYMENT
		{
			set { this.SetValue(ppy_activityinfoTOTALPAYMENTProperty, value); }
			get { return (Nullable<Decimal>) this.GetValue(ppy_activityinfoTOTALPAYMENTProperty); }
		}

		public static ExtendProperty ppy_activityinfoCAUTIONMONEYProperty = ExtendProperty.RegisterProperty("CAUTIONMONEY", typeof(Nullable<Decimal>), typeof(ppy_activityinfo),
			new DbMetaData() { FieldName = "CAUTIONMONEY", IsKey = false, IDentity = false});
		///<summary>
		///日志备注
		///</summary>
		public Nullable<Decimal> CAUTIONMONEY
		{
			set { this.SetValue(ppy_activityinfoCAUTIONMONEYProperty, value); }
			get { return (Nullable<Decimal>) this.GetValue(ppy_activityinfoCAUTIONMONEYProperty); }
		}

		public static ExtendProperty ppy_activityinfoBUDGETCAPProperty = ExtendProperty.RegisterProperty("BUDGETCAP", typeof(Nullable<Decimal>), typeof(ppy_activityinfo),
			new DbMetaData() { FieldName = "BUDGETCAP", IsKey = false, IDentity = false});
		///<summary>
		///状态
		///</summary>
		public Nullable<Decimal> BUDGETCAP
		{
			set { this.SetValue(ppy_activityinfoBUDGETCAPProperty, value); }
			get { return (Nullable<Decimal>) this.GetValue(ppy_activityinfoBUDGETCAPProperty); }
		}

		public static ExtendProperty ppy_activityinfoPROVIDEDRESSProperty = ExtendProperty.RegisterProperty("PROVIDEDRESS", typeof(Nullable<Boolean>), typeof(ppy_activityinfo),
			new DbMetaData() { FieldName = "PROVIDEDRESS", IsKey = false, IDentity = false});
		///<summary>
		///执行行为的时间
		///</summary>
		public Nullable<Boolean> PROVIDEDRESS
		{
			set { this.SetValue(ppy_activityinfoPROVIDEDRESSProperty, value); }
			get { return (Nullable<Boolean>) this.GetValue(ppy_activityinfoPROVIDEDRESSProperty); }
		}

		public static ExtendProperty ppy_activityinfoPROVIDEROOMBOARDProperty = ExtendProperty.RegisterProperty("PROVIDEROOMBOARD", typeof(Nullable<Boolean>), typeof(ppy_activityinfo),
			new DbMetaData() { FieldName = "PROVIDEROOMBOARD", IsKey = false, IDentity = false});
		///<summary>
		///文件编号
		///</summary>
		public Nullable<Boolean> PROVIDEROOMBOARD
		{
			set { this.SetValue(ppy_activityinfoPROVIDEROOMBOARDProperty, value); }
			get { return (Nullable<Boolean>) this.GetValue(ppy_activityinfoPROVIDEROOMBOARDProperty); }
		}

		public static ExtendProperty ppy_activityinfoSHUTTLEProperty = ExtendProperty.RegisterProperty("SHUTTLE", typeof(Nullable<Boolean>), typeof(ppy_activityinfo),
			new DbMetaData() { FieldName = "SHUTTLE", IsKey = false, IDentity = false});
		///<summary>
		///活动编号
		///</summary>
		public Nullable<Boolean> SHUTTLE
		{
			set { this.SetValue(ppy_activityinfoSHUTTLEProperty, value); }
			get { return (Nullable<Boolean>) this.GetValue(ppy_activityinfoSHUTTLEProperty); }
		}

		public static ExtendProperty ppy_activityinfoADDDETAILSProperty = ExtendProperty.RegisterProperty("ADDDETAILS", typeof(String), typeof(ppy_activityinfo),
			new DbMetaData() { FieldName = "ADDDETAILS", IsKey = false, IDentity = false});
		///<summary>
		///经销商编号
		///</summary>
		public String ADDDETAILS
		{
			set { this.SetValue(ppy_activityinfoADDDETAILSProperty, value); }
			get { return (String) this.GetValue(ppy_activityinfoADDDETAILSProperty); }
		}

		public static ExtendProperty ppy_activityinfoSTATEProperty = ExtendProperty.RegisterProperty("STATE", typeof(Nullable<Int16>), typeof(ppy_activityinfo),
			new DbMetaData() { FieldName = "STATE", IsKey = false, IDentity = false});
		///<summary>
		///上传时间
		///</summary>
		public Nullable<Int16> STATE
		{
			set { this.SetValue(ppy_activityinfoSTATEProperty, value); }
			get { return (Nullable<Int16>) this.GetValue(ppy_activityinfoSTATEProperty); }
		}

		public static ExtendProperty ppy_activityinfoREMARKProperty = ExtendProperty.RegisterProperty("REMARK", typeof(String), typeof(ppy_activityinfo),
			new DbMetaData() { FieldName = "REMARK", IsKey = false, IDentity = false});
		///<summary>
		///文件路径
		///</summary>
		public String REMARK
		{
			set { this.SetValue(ppy_activityinfoREMARKProperty, value); }
			get { return (String) this.GetValue(ppy_activityinfoREMARKProperty); }
		}

		public static ExtendProperty ppy_activityinfoDEALERCODEProperty = ExtendProperty.RegisterProperty("DEALERCODE", typeof(Nullable<Int32>), typeof(ppy_activityinfo),
			new DbMetaData() { FieldName = "DEALERCODE", IsKey = false, IDentity = false});
		///<summary>
		///文件类型		///            1内容扫描件		///            2流程扫描件		///            3举办方相关证明		///            4其它
		///</summary>
		public Nullable<Int32> DEALERCODE
		{
			set { this.SetValue(ppy_activityinfoDEALERCODEProperty, value); }
			get { return (Nullable<Int32>) this.GetValue(ppy_activityinfoDEALERCODEProperty); }
		}

		public static ExtendProperty ppy_activityinfoSTARTCOUNTProperty = ExtendProperty.RegisterProperty("STARTCOUNT", typeof(Nullable<Int16>), typeof(ppy_activityinfo),
			new DbMetaData() { FieldName = "STARTCOUNT", IsKey = false, IDentity = false});
		///<summary>
		///编号
		///</summary>
		public Nullable<Int16> STARTCOUNT
		{
			set { this.SetValue(ppy_activityinfoSTARTCOUNTProperty, value); }
			get { return (Nullable<Int16>) this.GetValue(ppy_activityinfoSTARTCOUNTProperty); }
		}

		public static ExtendProperty ppy_activityinfoORDERTYPEProperty = ExtendProperty.RegisterProperty("ORDERTYPE", typeof(Nullable<Int16>), typeof(ppy_activityinfo),
			new DbMetaData() { FieldName = "ORDERTYPE", IsKey = false, IDentity = false});
		///<summary>
		///活动名称
		///</summary>
		public Nullable<Int16> ORDERTYPE
		{
			set { this.SetValue(ppy_activityinfoORDERTYPEProperty, value); }
			get { return (Nullable<Int16>) this.GetValue(ppy_activityinfoORDERTYPEProperty); }
		}

	}

	public partial class ppy_addons : DbObject
	{
		static ppy_addons() {
			TableNameProperty.AddOwner(typeof(ppy_addons),"ppy_addons");
			KeysProperty.AddOwner(typeof(ppy_addons),new string[]{"id"});
		} 
		public static ExtendProperty ppy_addonsidProperty = ExtendProperty.RegisterProperty("id", typeof(UInt32), typeof(ppy_addons),
			new DbMetaData() { FieldName = "id", IsKey = true, IDentity = false});
		///<summary>
		///主键
		///</summary>
		public UInt32 Id
		{
			set { this.SetValue(ppy_addonsidProperty, value); }
			get { return (UInt32) this.GetValue(ppy_addonsidProperty); }
		}

		public static ExtendProperty ppy_addonsnameProperty = ExtendProperty.RegisterProperty("name", typeof(String), typeof(ppy_addons),
			new DbMetaData() { FieldName = "name", IsKey = false, IDentity = false});
		///<summary>
		///行为唯一标识
		///</summary>
		public String Name
		{
			set { this.SetValue(ppy_addonsnameProperty, value); }
			get { return (String) this.GetValue(ppy_addonsnameProperty); }
		}

		public static ExtendProperty ppy_addonstitleProperty = ExtendProperty.RegisterProperty("title", typeof(String), typeof(ppy_addons),
			new DbMetaData() { FieldName = "title", IsKey = false, IDentity = false});
		///<summary>
		///行为说明
		///</summary>
		public String Title
		{
			set { this.SetValue(ppy_addonstitleProperty, value); }
			get { return (String) this.GetValue(ppy_addonstitleProperty); }
		}

		public static ExtendProperty ppy_addonsdescriptionProperty = ExtendProperty.RegisterProperty("description", typeof(String), typeof(ppy_addons),
			new DbMetaData() { FieldName = "description", IsKey = false, IDentity = false});
		///<summary>
		///行为描述
		///</summary>
		public String Description
		{
			set { this.SetValue(ppy_addonsdescriptionProperty, value); }
			get { return (String) this.GetValue(ppy_addonsdescriptionProperty); }
		}

		public static ExtendProperty ppy_addonsstatusProperty = ExtendProperty.RegisterProperty("status", typeof(Boolean), typeof(ppy_addons),
			new DbMetaData() { FieldName = "status", IsKey = false, IDentity = false});
		///<summary>
		///行为规则
		///</summary>
		public Boolean Status
		{
			set { this.SetValue(ppy_addonsstatusProperty, value); }
			get { return (Boolean) this.GetValue(ppy_addonsstatusProperty); }
		}

		public static ExtendProperty ppy_addonsconfigProperty = ExtendProperty.RegisterProperty("config", typeof(String), typeof(ppy_addons),
			new DbMetaData() { FieldName = "config", IsKey = false, IDentity = false});
		///<summary>
		///日志规则
		///</summary>
		public String Config
		{
			set { this.SetValue(ppy_addonsconfigProperty, value); }
			get { return (String) this.GetValue(ppy_addonsconfigProperty); }
		}

		public static ExtendProperty ppy_addonsauthorProperty = ExtendProperty.RegisterProperty("author", typeof(String), typeof(ppy_addons),
			new DbMetaData() { FieldName = "author", IsKey = false, IDentity = false});
		///<summary>
		///类型
		///</summary>
		public String Author
		{
			set { this.SetValue(ppy_addonsauthorProperty, value); }
			get { return (String) this.GetValue(ppy_addonsauthorProperty); }
		}

		public static ExtendProperty ppy_addonsversionProperty = ExtendProperty.RegisterProperty("version", typeof(String), typeof(ppy_addons),
			new DbMetaData() { FieldName = "version", IsKey = false, IDentity = false});
		///<summary>
		///状态
		///</summary>
		public String Version
		{
			set { this.SetValue(ppy_addonsversionProperty, value); }
			get { return (String) this.GetValue(ppy_addonsversionProperty); }
		}

		public static ExtendProperty ppy_addonscreate_timeProperty = ExtendProperty.RegisterProperty("create_time", typeof(UInt32), typeof(ppy_addons),
			new DbMetaData() { FieldName = "create_time", IsKey = false, IDentity = false});
		///<summary>
		///修改时间
		///</summary>
		public UInt32 Create_Time
		{
			set { this.SetValue(ppy_addonscreate_timeProperty, value); }
			get { return (UInt32) this.GetValue(ppy_addonscreate_timeProperty); }
		}

		public static ExtendProperty ppy_addonshas_adminlistProperty = ExtendProperty.RegisterProperty("has_adminlist", typeof(Byte), typeof(ppy_addons),
			new DbMetaData() { FieldName = "has_adminlist", IsKey = false, IDentity = false});
		///<summary>
		///主键
		///</summary>
		public Byte Has_Adminlist
		{
			set { this.SetValue(ppy_addonshas_adminlistProperty, value); }
			get { return (Byte) this.GetValue(ppy_addonshas_adminlistProperty); }
		}

	}

	public partial class ppy_agreementinfo : DbObject
	{
		static ppy_agreementinfo() {
			TableNameProperty.AddOwner(typeof(ppy_agreementinfo),"ppy_agreementinfo");
			KeysProperty.AddOwner(typeof(ppy_agreementinfo),new string[]{"CODE"});
		} 
		public static ExtendProperty ppy_agreementinfoCODEProperty = ExtendProperty.RegisterProperty("CODE", typeof(Int64), typeof(ppy_agreementinfo),
			new DbMetaData() { FieldName = "CODE", IsKey = true, IDentity = false});
		///<summary>
		///主键
		///</summary>
		public Int64 CODE
		{
			set { this.SetValue(ppy_agreementinfoCODEProperty, value); }
			get { return (Int64) this.GetValue(ppy_agreementinfoCODEProperty); }
		}

		public static ExtendProperty ppy_agreementinfoCONTENTProperty = ExtendProperty.RegisterProperty("CONTENT", typeof(String), typeof(ppy_agreementinfo),
			new DbMetaData() { FieldName = "CONTENT", IsKey = false, IDentity = false});
		///<summary>
		///行为唯一标识
		///</summary>
		public String CONTENT
		{
			set { this.SetValue(ppy_agreementinfoCONTENTProperty, value); }
			get { return (String) this.GetValue(ppy_agreementinfoCONTENTProperty); }
		}

		public static ExtendProperty ppy_agreementinfoSESProperty = ExtendProperty.RegisterProperty("SES", typeof(String), typeof(ppy_agreementinfo),
			new DbMetaData() { FieldName = "SES", IsKey = false, IDentity = false});
		///<summary>
		///行为说明
		///</summary>
		public String SES
		{
			set { this.SetValue(ppy_agreementinfoSESProperty, value); }
			get { return (String) this.GetValue(ppy_agreementinfoSESProperty); }
		}

		public static ExtendProperty ppy_agreementinfoDESProperty = ExtendProperty.RegisterProperty("DES", typeof(String), typeof(ppy_agreementinfo),
			new DbMetaData() { FieldName = "DES", IsKey = false, IDentity = false});
		///<summary>
		///行为描述
		///</summary>
		public String DES
		{
			set { this.SetValue(ppy_agreementinfoDESProperty, value); }
			get { return (String) this.GetValue(ppy_agreementinfoDESProperty); }
		}

		public static ExtendProperty ppy_agreementinfoACTIVITYCODEProperty = ExtendProperty.RegisterProperty("ACTIVITYCODE", typeof(Int64), typeof(ppy_agreementinfo),
			new DbMetaData() { FieldName = "ACTIVITYCODE", IsKey = false, IDentity = false});
		///<summary>
		///行为规则
		///</summary>
		public Int64 ACTIVITYCODE
		{
			set { this.SetValue(ppy_agreementinfoACTIVITYCODEProperty, value); }
			get { return (Int64) this.GetValue(ppy_agreementinfoACTIVITYCODEProperty); }
		}

		public static ExtendProperty ppy_agreementinfoSTARTCODEProperty = ExtendProperty.RegisterProperty("STARTCODE", typeof(Int32), typeof(ppy_agreementinfo),
			new DbMetaData() { FieldName = "STARTCODE", IsKey = false, IDentity = false});
		///<summary>
		///日志规则
		///</summary>
		public Int32 STARTCODE
		{
			set { this.SetValue(ppy_agreementinfoSTARTCODEProperty, value); }
			get { return (Int32) this.GetValue(ppy_agreementinfoSTARTCODEProperty); }
		}

	}

	public partial class ppy_areas : DbObject
	{
		static ppy_areas() {
			TableNameProperty.AddOwner(typeof(ppy_areas),"ppy_areas");
			KeysProperty.AddOwner(typeof(ppy_areas),new string[]{"area_id"});
		} 
		public static ExtendProperty ppy_areasarea_idProperty = ExtendProperty.RegisterProperty("area_id", typeof(UInt16), typeof(ppy_areas),
			new DbMetaData() { FieldName = "area_id", IsKey = true, IDentity = false});
		///<summary>
		///主键
		///</summary>
		public UInt16 Area_Id
		{
			set { this.SetValue(ppy_areasarea_idProperty, value); }
			get { return (UInt16) this.GetValue(ppy_areasarea_idProperty); }
		}

		public static ExtendProperty ppy_areasparent_idProperty = ExtendProperty.RegisterProperty("parent_id", typeof(UInt16), typeof(ppy_areas),
			new DbMetaData() { FieldName = "parent_id", IsKey = false, IDentity = false});
		///<summary>
		///行为唯一标识
		///</summary>
		public UInt16 Parent_Id
		{
			set { this.SetValue(ppy_areasparent_idProperty, value); }
			get { return (UInt16) this.GetValue(ppy_areasparent_idProperty); }
		}

		public static ExtendProperty ppy_areasarea_nameProperty = ExtendProperty.RegisterProperty("area_name", typeof(String), typeof(ppy_areas),
			new DbMetaData() { FieldName = "area_name", IsKey = false, IDentity = false});
		///<summary>
		///行为说明
		///</summary>
		public String Area_Name
		{
			set { this.SetValue(ppy_areasarea_nameProperty, value); }
			get { return (String) this.GetValue(ppy_areasarea_nameProperty); }
		}

		public static ExtendProperty ppy_areasarea_typeProperty = ExtendProperty.RegisterProperty("area_type", typeof(Boolean), typeof(ppy_areas),
			new DbMetaData() { FieldName = "area_type", IsKey = false, IDentity = false});
		///<summary>
		///行为描述
		///</summary>
		public Boolean Area_Type
		{
			set { this.SetValue(ppy_areasarea_typeProperty, value); }
			get { return (Boolean) this.GetValue(ppy_areasarea_typeProperty); }
		}

	}

	public partial class ppy_assembly : DbObject
	{
		static ppy_assembly() {
			TableNameProperty.AddOwner(typeof(ppy_assembly),"ppy_assembly");
			KeysProperty.AddOwner(typeof(ppy_assembly),new string[]{"Id"});
		} 
		public static ExtendProperty ppy_assemblyIdProperty = ExtendProperty.RegisterProperty("Id", typeof(Int32), typeof(ppy_assembly),
			new DbMetaData() { FieldName = "Id", IsKey = true, IDentity = true});
		///<summary>
		///主键
		///</summary>
		public Int32 Id
		{
			set { this.SetValue(ppy_assemblyIdProperty, value); }
			get { return (Int32) this.GetValue(ppy_assemblyIdProperty); }
		}

		public static ExtendProperty ppy_assemblyOrderIdProperty = ExtendProperty.RegisterProperty("OrderId", typeof(Int32), typeof(ppy_assembly),
			new DbMetaData() { FieldName = "OrderId", IsKey = false, IDentity = false});
		///<summary>
		///行为唯一标识
		///</summary>
		public Int32 Orderid
		{
			set { this.SetValue(ppy_assemblyOrderIdProperty, value); }
			get { return (Int32) this.GetValue(ppy_assemblyOrderIdProperty); }
		}

		public static ExtendProperty ppy_assemblyInfoProperty = ExtendProperty.RegisterProperty("Info", typeof(String), typeof(ppy_assembly),
			new DbMetaData() { FieldName = "Info", IsKey = false, IDentity = false});
		///<summary>
		///行为说明
		///</summary>
		public String Info
		{
			set { this.SetValue(ppy_assemblyInfoProperty, value); }
			get { return (String) this.GetValue(ppy_assemblyInfoProperty); }
		}

		public static ExtendProperty ppy_assemblyOperatingTimeProperty = ExtendProperty.RegisterProperty("OperatingTime", typeof(Int32), typeof(ppy_assembly),
			new DbMetaData() { FieldName = "OperatingTime", IsKey = false, IDentity = false});
		///<summary>
		///行为描述
		///</summary>
		public Int32 Operatingtime
		{
			set { this.SetValue(ppy_assemblyOperatingTimeProperty, value); }
			get { return (Int32) this.GetValue(ppy_assemblyOperatingTimeProperty); }
		}

		public static ExtendProperty ppy_assemblyOperatingUidProperty = ExtendProperty.RegisterProperty("OperatingUid", typeof(Int32), typeof(ppy_assembly),
			new DbMetaData() { FieldName = "OperatingUid", IsKey = false, IDentity = false});
		///<summary>
		///行为规则
		///</summary>
		public Int32 Operatinguid
		{
			set { this.SetValue(ppy_assemblyOperatingUidProperty, value); }
			get { return (Int32) this.GetValue(ppy_assemblyOperatingUidProperty); }
		}

		public static ExtendProperty ppy_assemblyStateTypeProperty = ExtendProperty.RegisterProperty("StateType", typeof(SByte), typeof(ppy_assembly),
			new DbMetaData() { FieldName = "StateType", IsKey = false, IDentity = false});
		///<summary>
		///日志规则
		///</summary>
		public SByte Statetype
		{
			set { this.SetValue(ppy_assemblyStateTypeProperty, value); }
			get { return (SByte) this.GetValue(ppy_assemblyStateTypeProperty); }
		}

		public static ExtendProperty ppy_assemblyStateIdProperty = ExtendProperty.RegisterProperty("StateId", typeof(SByte), typeof(ppy_assembly),
			new DbMetaData() { FieldName = "StateId", IsKey = false, IDentity = false});
		///<summary>
		///类型
		///</summary>
		public SByte Stateid
		{
			set { this.SetValue(ppy_assemblyStateIdProperty, value); }
			get { return (SByte) this.GetValue(ppy_assemblyStateIdProperty); }
		}

	}

	public partial class ppy_attachment : DbObject
	{
		static ppy_attachment() {
			TableNameProperty.AddOwner(typeof(ppy_attachment),"ppy_attachment");
			KeysProperty.AddOwner(typeof(ppy_attachment),new string[]{"id"});
		} 
		public static ExtendProperty ppy_attachmentidProperty = ExtendProperty.RegisterProperty("id", typeof(UInt32), typeof(ppy_attachment),
			new DbMetaData() { FieldName = "id", IsKey = true, IDentity = false});
		///<summary>
		///主键
		///</summary>
		public UInt32 Id
		{
			set { this.SetValue(ppy_attachmentidProperty, value); }
			get { return (UInt32) this.GetValue(ppy_attachmentidProperty); }
		}

		public static ExtendProperty ppy_attachmentuidProperty = ExtendProperty.RegisterProperty("uid", typeof(UInt32), typeof(ppy_attachment),
			new DbMetaData() { FieldName = "uid", IsKey = false, IDentity = false});
		///<summary>
		///行为唯一标识
		///</summary>
		public UInt32 Uid
		{
			set { this.SetValue(ppy_attachmentuidProperty, value); }
			get { return (UInt32) this.GetValue(ppy_attachmentuidProperty); }
		}

		public static ExtendProperty ppy_attachmenttitleProperty = ExtendProperty.RegisterProperty("title", typeof(String), typeof(ppy_attachment),
			new DbMetaData() { FieldName = "title", IsKey = false, IDentity = false});
		///<summary>
		///行为说明
		///</summary>
		public String Title
		{
			set { this.SetValue(ppy_attachmenttitleProperty, value); }
			get { return (String) this.GetValue(ppy_attachmenttitleProperty); }
		}

		public static ExtendProperty ppy_attachmenttypeProperty = ExtendProperty.RegisterProperty("type", typeof(Byte), typeof(ppy_attachment),
			new DbMetaData() { FieldName = "type", IsKey = false, IDentity = false});
		///<summary>
		///行为描述
		///</summary>
		public Byte Type
		{
			set { this.SetValue(ppy_attachmenttypeProperty, value); }
			get { return (Byte) this.GetValue(ppy_attachmenttypeProperty); }
		}

		public static ExtendProperty ppy_attachmentsourceProperty = ExtendProperty.RegisterProperty("source", typeof(UInt32), typeof(ppy_attachment),
			new DbMetaData() { FieldName = "source", IsKey = false, IDentity = false});
		///<summary>
		///行为规则
		///</summary>
		public UInt32 Source
		{
			set { this.SetValue(ppy_attachmentsourceProperty, value); }
			get { return (UInt32) this.GetValue(ppy_attachmentsourceProperty); }
		}

		public static ExtendProperty ppy_attachmentrecord_idProperty = ExtendProperty.RegisterProperty("record_id", typeof(UInt32), typeof(ppy_attachment),
			new DbMetaData() { FieldName = "record_id", IsKey = false, IDentity = false});
		///<summary>
		///日志规则
		///</summary>
		public UInt32 Record_Id
		{
			set { this.SetValue(ppy_attachmentrecord_idProperty, value); }
			get { return (UInt32) this.GetValue(ppy_attachmentrecord_idProperty); }
		}

		public static ExtendProperty ppy_attachmentdownloadProperty = ExtendProperty.RegisterProperty("download", typeof(UInt32), typeof(ppy_attachment),
			new DbMetaData() { FieldName = "download", IsKey = false, IDentity = false});
		///<summary>
		///类型
		///</summary>
		public UInt32 Download
		{
			set { this.SetValue(ppy_attachmentdownloadProperty, value); }
			get { return (UInt32) this.GetValue(ppy_attachmentdownloadProperty); }
		}

		public static ExtendProperty ppy_attachmentsizeProperty = ExtendProperty.RegisterProperty("size", typeof(UInt64), typeof(ppy_attachment),
			new DbMetaData() { FieldName = "size", IsKey = false, IDentity = false});
		///<summary>
		///状态
		///</summary>
		public UInt64 Size
		{
			set { this.SetValue(ppy_attachmentsizeProperty, value); }
			get { return (UInt64) this.GetValue(ppy_attachmentsizeProperty); }
		}

		public static ExtendProperty ppy_attachmentdirProperty = ExtendProperty.RegisterProperty("dir", typeof(UInt32), typeof(ppy_attachment),
			new DbMetaData() { FieldName = "dir", IsKey = false, IDentity = false});
		///<summary>
		///修改时间
		///</summary>
		public UInt32 Dir
		{
			set { this.SetValue(ppy_attachmentdirProperty, value); }
			get { return (UInt32) this.GetValue(ppy_attachmentdirProperty); }
		}

		public static ExtendProperty ppy_attachmentsortProperty = ExtendProperty.RegisterProperty("sort", typeof(UInt32), typeof(ppy_attachment),
			new DbMetaData() { FieldName = "sort", IsKey = false, IDentity = false});
		///<summary>
		///主键
		///</summary>
		public UInt32 Sort
		{
			set { this.SetValue(ppy_attachmentsortProperty, value); }
			get { return (UInt32) this.GetValue(ppy_attachmentsortProperty); }
		}

		public static ExtendProperty ppy_attachmentcreate_timeProperty = ExtendProperty.RegisterProperty("create_time", typeof(UInt32), typeof(ppy_attachment),
			new DbMetaData() { FieldName = "create_time", IsKey = false, IDentity = false});
		///<summary>
		///行为id
		///</summary>
		public UInt32 Create_Time
		{
			set { this.SetValue(ppy_attachmentcreate_timeProperty, value); }
			get { return (UInt32) this.GetValue(ppy_attachmentcreate_timeProperty); }
		}

		public static ExtendProperty ppy_attachmentupdate_timeProperty = ExtendProperty.RegisterProperty("update_time", typeof(UInt32), typeof(ppy_attachment),
			new DbMetaData() { FieldName = "update_time", IsKey = false, IDentity = false});
		///<summary>
		///执行用户id
		///</summary>
		public UInt32 Update_Time
		{
			set { this.SetValue(ppy_attachmentupdate_timeProperty, value); }
			get { return (UInt32) this.GetValue(ppy_attachmentupdate_timeProperty); }
		}

		public static ExtendProperty ppy_attachmentstatusProperty = ExtendProperty.RegisterProperty("status", typeof(Boolean), typeof(ppy_attachment),
			new DbMetaData() { FieldName = "status", IsKey = false, IDentity = false});
		///<summary>
		///执行行为者ip
		///</summary>
		public Boolean Status
		{
			set { this.SetValue(ppy_attachmentstatusProperty, value); }
			get { return (Boolean) this.GetValue(ppy_attachmentstatusProperty); }
		}

	}

	public partial class ppy_attribute : DbObject
	{
		static ppy_attribute() {
			TableNameProperty.AddOwner(typeof(ppy_attribute),"ppy_attribute");
			KeysProperty.AddOwner(typeof(ppy_attribute),new string[]{"id"});
		} 
		public static ExtendProperty ppy_attributeidProperty = ExtendProperty.RegisterProperty("id", typeof(UInt32), typeof(ppy_attribute),
			new DbMetaData() { FieldName = "id", IsKey = true, IDentity = false});
		///<summary>
		///主键
		///</summary>
		public UInt32 Id
		{
			set { this.SetValue(ppy_attributeidProperty, value); }
			get { return (UInt32) this.GetValue(ppy_attributeidProperty); }
		}

		public static ExtendProperty ppy_attributenameProperty = ExtendProperty.RegisterProperty("name", typeof(String), typeof(ppy_attribute),
			new DbMetaData() { FieldName = "name", IsKey = false, IDentity = false});
		///<summary>
		///行为唯一标识
		///</summary>
		public String Name
		{
			set { this.SetValue(ppy_attributenameProperty, value); }
			get { return (String) this.GetValue(ppy_attributenameProperty); }
		}

		public static ExtendProperty ppy_attributetitleProperty = ExtendProperty.RegisterProperty("title", typeof(String), typeof(ppy_attribute),
			new DbMetaData() { FieldName = "title", IsKey = false, IDentity = false});
		///<summary>
		///行为说明
		///</summary>
		public String Title
		{
			set { this.SetValue(ppy_attributetitleProperty, value); }
			get { return (String) this.GetValue(ppy_attributetitleProperty); }
		}

		public static ExtendProperty ppy_attributefieldProperty = ExtendProperty.RegisterProperty("field", typeof(String), typeof(ppy_attribute),
			new DbMetaData() { FieldName = "field", IsKey = false, IDentity = false});
		///<summary>
		///行为描述
		///</summary>
		public String Field
		{
			set { this.SetValue(ppy_attributefieldProperty, value); }
			get { return (String) this.GetValue(ppy_attributefieldProperty); }
		}

		public static ExtendProperty ppy_attributetypeProperty = ExtendProperty.RegisterProperty("type", typeof(String), typeof(ppy_attribute),
			new DbMetaData() { FieldName = "type", IsKey = false, IDentity = false});
		///<summary>
		///行为规则
		///</summary>
		public String Type
		{
			set { this.SetValue(ppy_attributetypeProperty, value); }
			get { return (String) this.GetValue(ppy_attributetypeProperty); }
		}

		public static ExtendProperty ppy_attributevalueProperty = ExtendProperty.RegisterProperty("value", typeof(String), typeof(ppy_attribute),
			new DbMetaData() { FieldName = "value", IsKey = false, IDentity = false});
		///<summary>
		///日志规则
		///</summary>
		public String Value
		{
			set { this.SetValue(ppy_attributevalueProperty, value); }
			get { return (String) this.GetValue(ppy_attributevalueProperty); }
		}

		public static ExtendProperty ppy_attributeremarkProperty = ExtendProperty.RegisterProperty("remark", typeof(String), typeof(ppy_attribute),
			new DbMetaData() { FieldName = "remark", IsKey = false, IDentity = false});
		///<summary>
		///类型
		///</summary>
		public String Remark
		{
			set { this.SetValue(ppy_attributeremarkProperty, value); }
			get { return (String) this.GetValue(ppy_attributeremarkProperty); }
		}

		public static ExtendProperty ppy_attributeis_showProperty = ExtendProperty.RegisterProperty("is_show", typeof(Byte), typeof(ppy_attribute),
			new DbMetaData() { FieldName = "is_show", IsKey = false, IDentity = false});
		///<summary>
		///状态
		///</summary>
		public Byte Is_Show
		{
			set { this.SetValue(ppy_attributeis_showProperty, value); }
			get { return (Byte) this.GetValue(ppy_attributeis_showProperty); }
		}

		public static ExtendProperty ppy_attributeextraProperty = ExtendProperty.RegisterProperty("extra", typeof(String), typeof(ppy_attribute),
			new DbMetaData() { FieldName = "extra", IsKey = false, IDentity = false});
		///<summary>
		///修改时间
		///</summary>
		public String Extra
		{
			set { this.SetValue(ppy_attributeextraProperty, value); }
			get { return (String) this.GetValue(ppy_attributeextraProperty); }
		}

		public static ExtendProperty ppy_attributemodel_idProperty = ExtendProperty.RegisterProperty("model_id", typeof(UInt32), typeof(ppy_attribute),
			new DbMetaData() { FieldName = "model_id", IsKey = false, IDentity = false});
		///<summary>
		///主键
		///</summary>
		public UInt32 Model_Id
		{
			set { this.SetValue(ppy_attributemodel_idProperty, value); }
			get { return (UInt32) this.GetValue(ppy_attributemodel_idProperty); }
		}

		public static ExtendProperty ppy_attributeis_mustProperty = ExtendProperty.RegisterProperty("is_must", typeof(Byte), typeof(ppy_attribute),
			new DbMetaData() { FieldName = "is_must", IsKey = false, IDentity = false});
		///<summary>
		///行为id
		///</summary>
		public Byte Is_Must
		{
			set { this.SetValue(ppy_attributeis_mustProperty, value); }
			get { return (Byte) this.GetValue(ppy_attributeis_mustProperty); }
		}

		public static ExtendProperty ppy_attributestatusProperty = ExtendProperty.RegisterProperty("status", typeof(SByte), typeof(ppy_attribute),
			new DbMetaData() { FieldName = "status", IsKey = false, IDentity = false});
		///<summary>
		///执行用户id
		///</summary>
		public SByte Status
		{
			set { this.SetValue(ppy_attributestatusProperty, value); }
			get { return (SByte) this.GetValue(ppy_attributestatusProperty); }
		}

		public static ExtendProperty ppy_attributeupdate_timeProperty = ExtendProperty.RegisterProperty("update_time", typeof(UInt32), typeof(ppy_attribute),
			new DbMetaData() { FieldName = "update_time", IsKey = false, IDentity = false});
		///<summary>
		///执行行为者ip
		///</summary>
		public UInt32 Update_Time
		{
			set { this.SetValue(ppy_attributeupdate_timeProperty, value); }
			get { return (UInt32) this.GetValue(ppy_attributeupdate_timeProperty); }
		}

		public static ExtendProperty ppy_attributecreate_timeProperty = ExtendProperty.RegisterProperty("create_time", typeof(UInt32), typeof(ppy_attribute),
			new DbMetaData() { FieldName = "create_time", IsKey = false, IDentity = false});
		///<summary>
		///触发行为的表
		///</summary>
		public UInt32 Create_Time
		{
			set { this.SetValue(ppy_attributecreate_timeProperty, value); }
			get { return (UInt32) this.GetValue(ppy_attributecreate_timeProperty); }
		}

		public static ExtendProperty ppy_attributevalidate_ruleProperty = ExtendProperty.RegisterProperty("validate_rule", typeof(String), typeof(ppy_attribute),
			new DbMetaData() { FieldName = "validate_rule", IsKey = false, IDentity = false});
		///<summary>
		///触发行为的数据id
		///</summary>
		public String Validate_Rule
		{
			set { this.SetValue(ppy_attributevalidate_ruleProperty, value); }
			get { return (String) this.GetValue(ppy_attributevalidate_ruleProperty); }
		}

		public static ExtendProperty ppy_attributevalidate_timeProperty = ExtendProperty.RegisterProperty("validate_time", typeof(Byte), typeof(ppy_attribute),
			new DbMetaData() { FieldName = "validate_time", IsKey = false, IDentity = false});
		///<summary>
		///日志备注
		///</summary>
		public Byte Validate_Time
		{
			set { this.SetValue(ppy_attributevalidate_timeProperty, value); }
			get { return (Byte) this.GetValue(ppy_attributevalidate_timeProperty); }
		}

		public static ExtendProperty ppy_attributeerror_infoProperty = ExtendProperty.RegisterProperty("error_info", typeof(String), typeof(ppy_attribute),
			new DbMetaData() { FieldName = "error_info", IsKey = false, IDentity = false});
		///<summary>
		///状态
		///</summary>
		public String Error_Info
		{
			set { this.SetValue(ppy_attributeerror_infoProperty, value); }
			get { return (String) this.GetValue(ppy_attributeerror_infoProperty); }
		}

		public static ExtendProperty ppy_attributevalidate_typeProperty = ExtendProperty.RegisterProperty("validate_type", typeof(String), typeof(ppy_attribute),
			new DbMetaData() { FieldName = "validate_type", IsKey = false, IDentity = false});
		///<summary>
		///执行行为的时间
		///</summary>
		public String Validate_Type
		{
			set { this.SetValue(ppy_attributevalidate_typeProperty, value); }
			get { return (String) this.GetValue(ppy_attributevalidate_typeProperty); }
		}

		public static ExtendProperty ppy_attributeauto_ruleProperty = ExtendProperty.RegisterProperty("auto_rule", typeof(String), typeof(ppy_attribute),
			new DbMetaData() { FieldName = "auto_rule", IsKey = false, IDentity = false});
		///<summary>
		///文件编号
		///</summary>
		public String Auto_Rule
		{
			set { this.SetValue(ppy_attributeauto_ruleProperty, value); }
			get { return (String) this.GetValue(ppy_attributeauto_ruleProperty); }
		}

		public static ExtendProperty ppy_attributeauto_timeProperty = ExtendProperty.RegisterProperty("auto_time", typeof(Byte), typeof(ppy_attribute),
			new DbMetaData() { FieldName = "auto_time", IsKey = false, IDentity = false});
		///<summary>
		///活动编号
		///</summary>
		public Byte Auto_Time
		{
			set { this.SetValue(ppy_attributeauto_timeProperty, value); }
			get { return (Byte) this.GetValue(ppy_attributeauto_timeProperty); }
		}

		public static ExtendProperty ppy_attributeauto_typeProperty = ExtendProperty.RegisterProperty("auto_type", typeof(String), typeof(ppy_attribute),
			new DbMetaData() { FieldName = "auto_type", IsKey = false, IDentity = false});
		///<summary>
		///经销商编号
		///</summary>
		public String Auto_Type
		{
			set { this.SetValue(ppy_attributeauto_typeProperty, value); }
			get { return (String) this.GetValue(ppy_attributeauto_typeProperty); }
		}

	}

	public partial class ppy_auth_extend : DbObject
	{
		static ppy_auth_extend() {
			TableNameProperty.AddOwner(typeof(ppy_auth_extend),"ppy_auth_extend");
			KeysProperty.AddOwner(typeof(ppy_auth_extend),new string[]{"group_id","extend_id","type"});
		} 
		public static ExtendProperty ppy_auth_extendgroup_idProperty = ExtendProperty.RegisterProperty("group_id", typeof(UInt32), typeof(ppy_auth_extend),
			new DbMetaData() { FieldName = "group_id", IsKey = true, IDentity = false});
		///<summary>
		///主键
		///</summary>
		public UInt32 Group_Id
		{
			set { this.SetValue(ppy_auth_extendgroup_idProperty, value); }
			get { return (UInt32) this.GetValue(ppy_auth_extendgroup_idProperty); }
		}

		public static ExtendProperty ppy_auth_extendextend_idProperty = ExtendProperty.RegisterProperty("extend_id", typeof(UInt32), typeof(ppy_auth_extend),
			new DbMetaData() { FieldName = "extend_id", IsKey = true, IDentity = false});
		///<summary>
		///行为唯一标识
		///</summary>
		public UInt32 Extend_Id
		{
			set { this.SetValue(ppy_auth_extendextend_idProperty, value); }
			get { return (UInt32) this.GetValue(ppy_auth_extendextend_idProperty); }
		}

		public static ExtendProperty ppy_auth_extendtypeProperty = ExtendProperty.RegisterProperty("type", typeof(Byte), typeof(ppy_auth_extend),
			new DbMetaData() { FieldName = "type", IsKey = true, IDentity = false});
		///<summary>
		///行为说明
		///</summary>
		public Byte Type
		{
			set { this.SetValue(ppy_auth_extendtypeProperty, value); }
			get { return (Byte) this.GetValue(ppy_auth_extendtypeProperty); }
		}

	}

	public partial class ppy_auth_group : DbObject
	{
		static ppy_auth_group() {
			TableNameProperty.AddOwner(typeof(ppy_auth_group),"ppy_auth_group");
			KeysProperty.AddOwner(typeof(ppy_auth_group),new string[]{"id"});
		} 
		public static ExtendProperty ppy_auth_groupidProperty = ExtendProperty.RegisterProperty("id", typeof(UInt32), typeof(ppy_auth_group),
			new DbMetaData() { FieldName = "id", IsKey = true, IDentity = false});
		///<summary>
		///主键
		///</summary>
		public UInt32 Id
		{
			set { this.SetValue(ppy_auth_groupidProperty, value); }
			get { return (UInt32) this.GetValue(ppy_auth_groupidProperty); }
		}

		public static ExtendProperty ppy_auth_groupmoduleProperty = ExtendProperty.RegisterProperty("module", typeof(String), typeof(ppy_auth_group),
			new DbMetaData() { FieldName = "module", IsKey = false, IDentity = false});
		///<summary>
		///行为唯一标识
		///</summary>
		public String Module
		{
			set { this.SetValue(ppy_auth_groupmoduleProperty, value); }
			get { return (String) this.GetValue(ppy_auth_groupmoduleProperty); }
		}

		public static ExtendProperty ppy_auth_grouptypeProperty = ExtendProperty.RegisterProperty("type", typeof(SByte), typeof(ppy_auth_group),
			new DbMetaData() { FieldName = "type", IsKey = false, IDentity = false});
		///<summary>
		///行为说明
		///</summary>
		public SByte Type
		{
			set { this.SetValue(ppy_auth_grouptypeProperty, value); }
			get { return (SByte) this.GetValue(ppy_auth_grouptypeProperty); }
		}

		public static ExtendProperty ppy_auth_grouptitleProperty = ExtendProperty.RegisterProperty("title", typeof(String), typeof(ppy_auth_group),
			new DbMetaData() { FieldName = "title", IsKey = false, IDentity = false});
		///<summary>
		///行为描述
		///</summary>
		public String Title
		{
			set { this.SetValue(ppy_auth_grouptitleProperty, value); }
			get { return (String) this.GetValue(ppy_auth_grouptitleProperty); }
		}

		public static ExtendProperty ppy_auth_groupdescriptionProperty = ExtendProperty.RegisterProperty("description", typeof(String), typeof(ppy_auth_group),
			new DbMetaData() { FieldName = "description", IsKey = false, IDentity = false});
		///<summary>
		///行为规则
		///</summary>
		public String Description
		{
			set { this.SetValue(ppy_auth_groupdescriptionProperty, value); }
			get { return (String) this.GetValue(ppy_auth_groupdescriptionProperty); }
		}

		public static ExtendProperty ppy_auth_groupstatusProperty = ExtendProperty.RegisterProperty("status", typeof(Boolean), typeof(ppy_auth_group),
			new DbMetaData() { FieldName = "status", IsKey = false, IDentity = false});
		///<summary>
		///日志规则
		///</summary>
		public Boolean Status
		{
			set { this.SetValue(ppy_auth_groupstatusProperty, value); }
			get { return (Boolean) this.GetValue(ppy_auth_groupstatusProperty); }
		}

		public static ExtendProperty ppy_auth_grouprulesProperty = ExtendProperty.RegisterProperty("rules", typeof(String), typeof(ppy_auth_group),
			new DbMetaData() { FieldName = "rules", IsKey = false, IDentity = false});
		///<summary>
		///类型
		///</summary>
		public String Rules
		{
			set { this.SetValue(ppy_auth_grouprulesProperty, value); }
			get { return (String) this.GetValue(ppy_auth_grouprulesProperty); }
		}

	}

	public partial class ppy_auth_group_access : DbObject
	{
		static ppy_auth_group_access() {
			TableNameProperty.AddOwner(typeof(ppy_auth_group_access),"ppy_auth_group_access");
			KeysProperty.AddOwner(typeof(ppy_auth_group_access),new string[]{"uid","group_id"});
		} 
		public static ExtendProperty ppy_auth_group_accessuidProperty = ExtendProperty.RegisterProperty("uid", typeof(UInt32), typeof(ppy_auth_group_access),
			new DbMetaData() { FieldName = "uid", IsKey = true, IDentity = false});
		///<summary>
		///主键
		///</summary>
		public UInt32 Uid
		{
			set { this.SetValue(ppy_auth_group_accessuidProperty, value); }
			get { return (UInt32) this.GetValue(ppy_auth_group_accessuidProperty); }
		}

		public static ExtendProperty ppy_auth_group_accessgroup_idProperty = ExtendProperty.RegisterProperty("group_id", typeof(UInt32), typeof(ppy_auth_group_access),
			new DbMetaData() { FieldName = "group_id", IsKey = true, IDentity = false});
		///<summary>
		///行为唯一标识
		///</summary>
		public UInt32 Group_Id
		{
			set { this.SetValue(ppy_auth_group_accessgroup_idProperty, value); }
			get { return (UInt32) this.GetValue(ppy_auth_group_accessgroup_idProperty); }
		}

	}

	public partial class ppy_auth_rule : DbObject
	{
		static ppy_auth_rule() {
			TableNameProperty.AddOwner(typeof(ppy_auth_rule),"ppy_auth_rule");
			KeysProperty.AddOwner(typeof(ppy_auth_rule),new string[]{"id"});
		} 
		public static ExtendProperty ppy_auth_ruleidProperty = ExtendProperty.RegisterProperty("id", typeof(UInt32), typeof(ppy_auth_rule),
			new DbMetaData() { FieldName = "id", IsKey = true, IDentity = false});
		///<summary>
		///主键
		///</summary>
		public UInt32 Id
		{
			set { this.SetValue(ppy_auth_ruleidProperty, value); }
			get { return (UInt32) this.GetValue(ppy_auth_ruleidProperty); }
		}

		public static ExtendProperty ppy_auth_rulemoduleProperty = ExtendProperty.RegisterProperty("module", typeof(String), typeof(ppy_auth_rule),
			new DbMetaData() { FieldName = "module", IsKey = false, IDentity = false});
		///<summary>
		///行为唯一标识
		///</summary>
		public String Module
		{
			set { this.SetValue(ppy_auth_rulemoduleProperty, value); }
			get { return (String) this.GetValue(ppy_auth_rulemoduleProperty); }
		}

		public static ExtendProperty ppy_auth_ruletypeProperty = ExtendProperty.RegisterProperty("type", typeof(SByte), typeof(ppy_auth_rule),
			new DbMetaData() { FieldName = "type", IsKey = false, IDentity = false});
		///<summary>
		///行为说明
		///</summary>
		public SByte Type
		{
			set { this.SetValue(ppy_auth_ruletypeProperty, value); }
			get { return (SByte) this.GetValue(ppy_auth_ruletypeProperty); }
		}

		public static ExtendProperty ppy_auth_rulenameProperty = ExtendProperty.RegisterProperty("name", typeof(String), typeof(ppy_auth_rule),
			new DbMetaData() { FieldName = "name", IsKey = false, IDentity = false});
		///<summary>
		///行为描述
		///</summary>
		public String Name
		{
			set { this.SetValue(ppy_auth_rulenameProperty, value); }
			get { return (String) this.GetValue(ppy_auth_rulenameProperty); }
		}

		public static ExtendProperty ppy_auth_ruletitleProperty = ExtendProperty.RegisterProperty("title", typeof(String), typeof(ppy_auth_rule),
			new DbMetaData() { FieldName = "title", IsKey = false, IDentity = false});
		///<summary>
		///行为规则
		///</summary>
		public String Title
		{
			set { this.SetValue(ppy_auth_ruletitleProperty, value); }
			get { return (String) this.GetValue(ppy_auth_ruletitleProperty); }
		}

		public static ExtendProperty ppy_auth_rulestatusProperty = ExtendProperty.RegisterProperty("status", typeof(Boolean), typeof(ppy_auth_rule),
			new DbMetaData() { FieldName = "status", IsKey = false, IDentity = false});
		///<summary>
		///日志规则
		///</summary>
		public Boolean Status
		{
			set { this.SetValue(ppy_auth_rulestatusProperty, value); }
			get { return (Boolean) this.GetValue(ppy_auth_rulestatusProperty); }
		}

		public static ExtendProperty ppy_auth_ruleconditionProperty = ExtendProperty.RegisterProperty("condition", typeof(String), typeof(ppy_auth_rule),
			new DbMetaData() { FieldName = "condition", IsKey = false, IDentity = false});
		///<summary>
		///类型
		///</summary>
		public String Condition
		{
			set { this.SetValue(ppy_auth_ruleconditionProperty, value); }
			get { return (String) this.GetValue(ppy_auth_ruleconditionProperty); }
		}

	}

	public partial class ppy_bank : DbObject
	{
		static ppy_bank() {
			TableNameProperty.AddOwner(typeof(ppy_bank),"ppy_bank");
			KeysProperty.AddOwner(typeof(ppy_bank),new string[]{"id"});
		} 
		public static ExtendProperty ppy_bankidProperty = ExtendProperty.RegisterProperty("id", typeof(Int32), typeof(ppy_bank),
			new DbMetaData() { FieldName = "id", IsKey = true, IDentity = true});
		///<summary>
		///主键
		///</summary>
		public Int32 Id
		{
			set { this.SetValue(ppy_bankidProperty, value); }
			get { return (Int32) this.GetValue(ppy_bankidProperty); }
		}

		public static ExtendProperty ppy_banknameProperty = ExtendProperty.RegisterProperty("name", typeof(String), typeof(ppy_bank),
			new DbMetaData() { FieldName = "name", IsKey = false, IDentity = false});
		///<summary>
		///行为唯一标识
		///</summary>
		public String Name
		{
			set { this.SetValue(ppy_banknameProperty, value); }
			get { return (String) this.GetValue(ppy_banknameProperty); }
		}

		public static ExtendProperty ppy_bankinfoProperty = ExtendProperty.RegisterProperty("info", typeof(String), typeof(ppy_bank),
			new DbMetaData() { FieldName = "info", IsKey = false, IDentity = false});
		///<summary>
		///行为说明
		///</summary>
		public String Info
		{
			set { this.SetValue(ppy_bankinfoProperty, value); }
			get { return (String) this.GetValue(ppy_bankinfoProperty); }
		}

		public static ExtendProperty ppy_bankstateProperty = ExtendProperty.RegisterProperty("state", typeof(SByte), typeof(ppy_bank),
			new DbMetaData() { FieldName = "state", IsKey = false, IDentity = false});
		///<summary>
		///行为描述
		///</summary>
		public SByte State
		{
			set { this.SetValue(ppy_bankstateProperty, value); }
			get { return (SByte) this.GetValue(ppy_bankstateProperty); }
		}

	}

	public partial class ppy_category : DbObject
	{
		static ppy_category() {
			TableNameProperty.AddOwner(typeof(ppy_category),"ppy_category");
			KeysProperty.AddOwner(typeof(ppy_category),new string[]{"id"});
		} 
		public static ExtendProperty ppy_categoryidProperty = ExtendProperty.RegisterProperty("id", typeof(UInt32), typeof(ppy_category),
			new DbMetaData() { FieldName = "id", IsKey = true, IDentity = false});
		///<summary>
		///主键
		///</summary>
		public UInt32 Id
		{
			set { this.SetValue(ppy_categoryidProperty, value); }
			get { return (UInt32) this.GetValue(ppy_categoryidProperty); }
		}

		public static ExtendProperty ppy_categorynameProperty = ExtendProperty.RegisterProperty("name", typeof(String), typeof(ppy_category),
			new DbMetaData() { FieldName = "name", IsKey = false, IDentity = false});
		///<summary>
		///行为唯一标识
		///</summary>
		public String Name
		{
			set { this.SetValue(ppy_categorynameProperty, value); }
			get { return (String) this.GetValue(ppy_categorynameProperty); }
		}

		public static ExtendProperty ppy_categorytitleProperty = ExtendProperty.RegisterProperty("title", typeof(String), typeof(ppy_category),
			new DbMetaData() { FieldName = "title", IsKey = false, IDentity = false});
		///<summary>
		///行为说明
		///</summary>
		public String Title
		{
			set { this.SetValue(ppy_categorytitleProperty, value); }
			get { return (String) this.GetValue(ppy_categorytitleProperty); }
		}

		public static ExtendProperty ppy_categorypidProperty = ExtendProperty.RegisterProperty("pid", typeof(UInt32), typeof(ppy_category),
			new DbMetaData() { FieldName = "pid", IsKey = false, IDentity = false});
		///<summary>
		///行为描述
		///</summary>
		public UInt32 Pid
		{
			set { this.SetValue(ppy_categorypidProperty, value); }
			get { return (UInt32) this.GetValue(ppy_categorypidProperty); }
		}

		public static ExtendProperty ppy_categorysortProperty = ExtendProperty.RegisterProperty("sort", typeof(UInt32), typeof(ppy_category),
			new DbMetaData() { FieldName = "sort", IsKey = false, IDentity = false});
		///<summary>
		///行为规则
		///</summary>
		public UInt32 Sort
		{
			set { this.SetValue(ppy_categorysortProperty, value); }
			get { return (UInt32) this.GetValue(ppy_categorysortProperty); }
		}

		public static ExtendProperty ppy_categorylist_rowProperty = ExtendProperty.RegisterProperty("list_row", typeof(Byte), typeof(ppy_category),
			new DbMetaData() { FieldName = "list_row", IsKey = false, IDentity = false});
		///<summary>
		///日志规则
		///</summary>
		public Byte List_Row
		{
			set { this.SetValue(ppy_categorylist_rowProperty, value); }
			get { return (Byte) this.GetValue(ppy_categorylist_rowProperty); }
		}

		public static ExtendProperty ppy_categorymeta_titleProperty = ExtendProperty.RegisterProperty("meta_title", typeof(String), typeof(ppy_category),
			new DbMetaData() { FieldName = "meta_title", IsKey = false, IDentity = false});
		///<summary>
		///类型
		///</summary>
		public String Meta_Title
		{
			set { this.SetValue(ppy_categorymeta_titleProperty, value); }
			get { return (String) this.GetValue(ppy_categorymeta_titleProperty); }
		}

		public static ExtendProperty ppy_categorykeywordsProperty = ExtendProperty.RegisterProperty("keywords", typeof(String), typeof(ppy_category),
			new DbMetaData() { FieldName = "keywords", IsKey = false, IDentity = false});
		///<summary>
		///状态
		///</summary>
		public String Keywords
		{
			set { this.SetValue(ppy_categorykeywordsProperty, value); }
			get { return (String) this.GetValue(ppy_categorykeywordsProperty); }
		}

		public static ExtendProperty ppy_categorydescriptionProperty = ExtendProperty.RegisterProperty("description", typeof(String), typeof(ppy_category),
			new DbMetaData() { FieldName = "description", IsKey = false, IDentity = false});
		///<summary>
		///修改时间
		///</summary>
		public String Description
		{
			set { this.SetValue(ppy_categorydescriptionProperty, value); }
			get { return (String) this.GetValue(ppy_categorydescriptionProperty); }
		}

		public static ExtendProperty ppy_categorytemplate_indexProperty = ExtendProperty.RegisterProperty("template_index", typeof(String), typeof(ppy_category),
			new DbMetaData() { FieldName = "template_index", IsKey = false, IDentity = false});
		///<summary>
		///主键
		///</summary>
		public String Template_Index
		{
			set { this.SetValue(ppy_categorytemplate_indexProperty, value); }
			get { return (String) this.GetValue(ppy_categorytemplate_indexProperty); }
		}

		public static ExtendProperty ppy_categorytemplate_listsProperty = ExtendProperty.RegisterProperty("template_lists", typeof(String), typeof(ppy_category),
			new DbMetaData() { FieldName = "template_lists", IsKey = false, IDentity = false});
		///<summary>
		///行为id
		///</summary>
		public String Template_Lists
		{
			set { this.SetValue(ppy_categorytemplate_listsProperty, value); }
			get { return (String) this.GetValue(ppy_categorytemplate_listsProperty); }
		}

		public static ExtendProperty ppy_categorytemplate_detailProperty = ExtendProperty.RegisterProperty("template_detail", typeof(String), typeof(ppy_category),
			new DbMetaData() { FieldName = "template_detail", IsKey = false, IDentity = false});
		///<summary>
		///执行用户id
		///</summary>
		public String Template_Detail
		{
			set { this.SetValue(ppy_categorytemplate_detailProperty, value); }
			get { return (String) this.GetValue(ppy_categorytemplate_detailProperty); }
		}

		public static ExtendProperty ppy_categorytemplate_editProperty = ExtendProperty.RegisterProperty("template_edit", typeof(String), typeof(ppy_category),
			new DbMetaData() { FieldName = "template_edit", IsKey = false, IDentity = false});
		///<summary>
		///执行行为者ip
		///</summary>
		public String Template_Edit
		{
			set { this.SetValue(ppy_categorytemplate_editProperty, value); }
			get { return (String) this.GetValue(ppy_categorytemplate_editProperty); }
		}

		public static ExtendProperty ppy_categorymodelProperty = ExtendProperty.RegisterProperty("model", typeof(String), typeof(ppy_category),
			new DbMetaData() { FieldName = "model", IsKey = false, IDentity = false});
		///<summary>
		///触发行为的表
		///</summary>
		public String Model
		{
			set { this.SetValue(ppy_categorymodelProperty, value); }
			get { return (String) this.GetValue(ppy_categorymodelProperty); }
		}

		public static ExtendProperty ppy_categorymodel_subProperty = ExtendProperty.RegisterProperty("model_sub", typeof(String), typeof(ppy_category),
			new DbMetaData() { FieldName = "model_sub", IsKey = false, IDentity = false});
		///<summary>
		///触发行为的数据id
		///</summary>
		public String Model_Sub
		{
			set { this.SetValue(ppy_categorymodel_subProperty, value); }
			get { return (String) this.GetValue(ppy_categorymodel_subProperty); }
		}

		public static ExtendProperty ppy_categorytypeProperty = ExtendProperty.RegisterProperty("type", typeof(String), typeof(ppy_category),
			new DbMetaData() { FieldName = "type", IsKey = false, IDentity = false});
		///<summary>
		///日志备注
		///</summary>
		public String Type
		{
			set { this.SetValue(ppy_categorytypeProperty, value); }
			get { return (String) this.GetValue(ppy_categorytypeProperty); }
		}

		public static ExtendProperty ppy_categorylink_idProperty = ExtendProperty.RegisterProperty("link_id", typeof(UInt32), typeof(ppy_category),
			new DbMetaData() { FieldName = "link_id", IsKey = false, IDentity = false});
		///<summary>
		///状态
		///</summary>
		public UInt32 Link_Id
		{
			set { this.SetValue(ppy_categorylink_idProperty, value); }
			get { return (UInt32) this.GetValue(ppy_categorylink_idProperty); }
		}

		public static ExtendProperty ppy_categoryallow_publishProperty = ExtendProperty.RegisterProperty("allow_publish", typeof(Byte), typeof(ppy_category),
			new DbMetaData() { FieldName = "allow_publish", IsKey = false, IDentity = false});
		///<summary>
		///执行行为的时间
		///</summary>
		public Byte Allow_Publish
		{
			set { this.SetValue(ppy_categoryallow_publishProperty, value); }
			get { return (Byte) this.GetValue(ppy_categoryallow_publishProperty); }
		}

		public static ExtendProperty ppy_categorydisplayProperty = ExtendProperty.RegisterProperty("display", typeof(Byte), typeof(ppy_category),
			new DbMetaData() { FieldName = "display", IsKey = false, IDentity = false});
		///<summary>
		///文件编号
		///</summary>
		public Byte Display
		{
			set { this.SetValue(ppy_categorydisplayProperty, value); }
			get { return (Byte) this.GetValue(ppy_categorydisplayProperty); }
		}

		public static ExtendProperty ppy_categoryreplyProperty = ExtendProperty.RegisterProperty("reply", typeof(Byte), typeof(ppy_category),
			new DbMetaData() { FieldName = "reply", IsKey = false, IDentity = false});
		///<summary>
		///活动编号
		///</summary>
		public Byte Reply
		{
			set { this.SetValue(ppy_categoryreplyProperty, value); }
			get { return (Byte) this.GetValue(ppy_categoryreplyProperty); }
		}

		public static ExtendProperty ppy_categorycheckProperty = ExtendProperty.RegisterProperty("check", typeof(Byte), typeof(ppy_category),
			new DbMetaData() { FieldName = "check", IsKey = false, IDentity = false});
		///<summary>
		///经销商编号
		///</summary>
		public Byte Check
		{
			set { this.SetValue(ppy_categorycheckProperty, value); }
			get { return (Byte) this.GetValue(ppy_categorycheckProperty); }
		}

		public static ExtendProperty ppy_categoryreply_modelProperty = ExtendProperty.RegisterProperty("reply_model", typeof(String), typeof(ppy_category),
			new DbMetaData() { FieldName = "reply_model", IsKey = false, IDentity = false});
		///<summary>
		///上传时间
		///</summary>
		public String Reply_Model
		{
			set { this.SetValue(ppy_categoryreply_modelProperty, value); }
			get { return (String) this.GetValue(ppy_categoryreply_modelProperty); }
		}

		public static ExtendProperty ppy_categoryextendProperty = ExtendProperty.RegisterProperty("extend", typeof(String), typeof(ppy_category),
			new DbMetaData() { FieldName = "extend", IsKey = false, IDentity = false});
		///<summary>
		///文件路径
		///</summary>
		public String Extend
		{
			set { this.SetValue(ppy_categoryextendProperty, value); }
			get { return (String) this.GetValue(ppy_categoryextendProperty); }
		}

		public static ExtendProperty ppy_categorycreate_timeProperty = ExtendProperty.RegisterProperty("create_time", typeof(UInt32), typeof(ppy_category),
			new DbMetaData() { FieldName = "create_time", IsKey = false, IDentity = false});
		///<summary>
		///文件类型		///            1内容扫描件		///            2流程扫描件		///            3举办方相关证明		///            4其它
		///</summary>
		public UInt32 Create_Time
		{
			set { this.SetValue(ppy_categorycreate_timeProperty, value); }
			get { return (UInt32) this.GetValue(ppy_categorycreate_timeProperty); }
		}

		public static ExtendProperty ppy_categoryupdate_timeProperty = ExtendProperty.RegisterProperty("update_time", typeof(UInt32), typeof(ppy_category),
			new DbMetaData() { FieldName = "update_time", IsKey = false, IDentity = false});
		///<summary>
		///编号
		///</summary>
		public UInt32 Update_Time
		{
			set { this.SetValue(ppy_categoryupdate_timeProperty, value); }
			get { return (UInt32) this.GetValue(ppy_categoryupdate_timeProperty); }
		}

		public static ExtendProperty ppy_categorystatusProperty = ExtendProperty.RegisterProperty("status", typeof(SByte), typeof(ppy_category),
			new DbMetaData() { FieldName = "status", IsKey = false, IDentity = false});
		///<summary>
		///活动名称
		///</summary>
		public SByte Status
		{
			set { this.SetValue(ppy_categorystatusProperty, value); }
			get { return (SByte) this.GetValue(ppy_categorystatusProperty); }
		}

		public static ExtendProperty ppy_categoryiconProperty = ExtendProperty.RegisterProperty("icon", typeof(UInt32), typeof(ppy_category),
			new DbMetaData() { FieldName = "icon", IsKey = false, IDentity = false});
		///<summary>
		///活动地点
		///</summary>
		public UInt32 Icon
		{
			set { this.SetValue(ppy_categoryiconProperty, value); }
			get { return (UInt32) this.GetValue(ppy_categoryiconProperty); }
		}

		public static ExtendProperty ppy_categorygroupsProperty = ExtendProperty.RegisterProperty("groups", typeof(String), typeof(ppy_category),
			new DbMetaData() { FieldName = "groups", IsKey = false, IDentity = false});
		///<summary>
		///活动区域(保存区县信息)
		///</summary>
		public String Groups
		{
			set { this.SetValue(ppy_categorygroupsProperty, value); }
			get { return (String) this.GetValue(ppy_categorygroupsProperty); }
		}

	}

	public partial class ppy_channel : DbObject
	{
		static ppy_channel() {
			TableNameProperty.AddOwner(typeof(ppy_channel),"ppy_channel");
			KeysProperty.AddOwner(typeof(ppy_channel),new string[]{"id"});
		} 
		public static ExtendProperty ppy_channelidProperty = ExtendProperty.RegisterProperty("id", typeof(UInt32), typeof(ppy_channel),
			new DbMetaData() { FieldName = "id", IsKey = true, IDentity = false});
		///<summary>
		///主键
		///</summary>
		public UInt32 Id
		{
			set { this.SetValue(ppy_channelidProperty, value); }
			get { return (UInt32) this.GetValue(ppy_channelidProperty); }
		}

		public static ExtendProperty ppy_channelpidProperty = ExtendProperty.RegisterProperty("pid", typeof(UInt32), typeof(ppy_channel),
			new DbMetaData() { FieldName = "pid", IsKey = false, IDentity = false});
		///<summary>
		///行为唯一标识
		///</summary>
		public UInt32 Pid
		{
			set { this.SetValue(ppy_channelpidProperty, value); }
			get { return (UInt32) this.GetValue(ppy_channelpidProperty); }
		}

		public static ExtendProperty ppy_channeltitleProperty = ExtendProperty.RegisterProperty("title", typeof(String), typeof(ppy_channel),
			new DbMetaData() { FieldName = "title", IsKey = false, IDentity = false});
		///<summary>
		///行为说明
		///</summary>
		public String Title
		{
			set { this.SetValue(ppy_channeltitleProperty, value); }
			get { return (String) this.GetValue(ppy_channeltitleProperty); }
		}

		public static ExtendProperty ppy_channelurlProperty = ExtendProperty.RegisterProperty("url", typeof(String), typeof(ppy_channel),
			new DbMetaData() { FieldName = "url", IsKey = false, IDentity = false});
		///<summary>
		///行为描述
		///</summary>
		public String Url
		{
			set { this.SetValue(ppy_channelurlProperty, value); }
			get { return (String) this.GetValue(ppy_channelurlProperty); }
		}

		public static ExtendProperty ppy_channelsortProperty = ExtendProperty.RegisterProperty("sort", typeof(UInt32), typeof(ppy_channel),
			new DbMetaData() { FieldName = "sort", IsKey = false, IDentity = false});
		///<summary>
		///行为规则
		///</summary>
		public UInt32 Sort
		{
			set { this.SetValue(ppy_channelsortProperty, value); }
			get { return (UInt32) this.GetValue(ppy_channelsortProperty); }
		}

		public static ExtendProperty ppy_channelcreate_timeProperty = ExtendProperty.RegisterProperty("create_time", typeof(UInt32), typeof(ppy_channel),
			new DbMetaData() { FieldName = "create_time", IsKey = false, IDentity = false});
		///<summary>
		///日志规则
		///</summary>
		public UInt32 Create_Time
		{
			set { this.SetValue(ppy_channelcreate_timeProperty, value); }
			get { return (UInt32) this.GetValue(ppy_channelcreate_timeProperty); }
		}

		public static ExtendProperty ppy_channelupdate_timeProperty = ExtendProperty.RegisterProperty("update_time", typeof(UInt32), typeof(ppy_channel),
			new DbMetaData() { FieldName = "update_time", IsKey = false, IDentity = false});
		///<summary>
		///类型
		///</summary>
		public UInt32 Update_Time
		{
			set { this.SetValue(ppy_channelupdate_timeProperty, value); }
			get { return (UInt32) this.GetValue(ppy_channelupdate_timeProperty); }
		}

		public static ExtendProperty ppy_channelstatusProperty = ExtendProperty.RegisterProperty("status", typeof(SByte), typeof(ppy_channel),
			new DbMetaData() { FieldName = "status", IsKey = false, IDentity = false});
		///<summary>
		///状态
		///</summary>
		public SByte Status
		{
			set { this.SetValue(ppy_channelstatusProperty, value); }
			get { return (SByte) this.GetValue(ppy_channelstatusProperty); }
		}

		public static ExtendProperty ppy_channeltargetProperty = ExtendProperty.RegisterProperty("target", typeof(Byte), typeof(ppy_channel),
			new DbMetaData() { FieldName = "target", IsKey = false, IDentity = false});
		///<summary>
		///修改时间
		///</summary>
		public Byte Target
		{
			set { this.SetValue(ppy_channeltargetProperty, value); }
			get { return (Byte) this.GetValue(ppy_channeltargetProperty); }
		}

	}

	public partial class ppy_config : DbObject
	{
		static ppy_config() {
			TableNameProperty.AddOwner(typeof(ppy_config),"ppy_config");
			KeysProperty.AddOwner(typeof(ppy_config),new string[]{"id"});
		} 
		public static ExtendProperty ppy_configidProperty = ExtendProperty.RegisterProperty("id", typeof(UInt32), typeof(ppy_config),
			new DbMetaData() { FieldName = "id", IsKey = true, IDentity = false});
		///<summary>
		///主键
		///</summary>
		public UInt32 Id
		{
			set { this.SetValue(ppy_configidProperty, value); }
			get { return (UInt32) this.GetValue(ppy_configidProperty); }
		}

		public static ExtendProperty ppy_confignameProperty = ExtendProperty.RegisterProperty("name", typeof(String), typeof(ppy_config),
			new DbMetaData() { FieldName = "name", IsKey = false, IDentity = false});
		///<summary>
		///行为唯一标识
		///</summary>
		public String Name
		{
			set { this.SetValue(ppy_confignameProperty, value); }
			get { return (String) this.GetValue(ppy_confignameProperty); }
		}

		public static ExtendProperty ppy_configtypeProperty = ExtendProperty.RegisterProperty("type", typeof(Byte), typeof(ppy_config),
			new DbMetaData() { FieldName = "type", IsKey = false, IDentity = false});
		///<summary>
		///行为说明
		///</summary>
		public Byte Type
		{
			set { this.SetValue(ppy_configtypeProperty, value); }
			get { return (Byte) this.GetValue(ppy_configtypeProperty); }
		}

		public static ExtendProperty ppy_configtitleProperty = ExtendProperty.RegisterProperty("title", typeof(String), typeof(ppy_config),
			new DbMetaData() { FieldName = "title", IsKey = false, IDentity = false});
		///<summary>
		///行为描述
		///</summary>
		public String Title
		{
			set { this.SetValue(ppy_configtitleProperty, value); }
			get { return (String) this.GetValue(ppy_configtitleProperty); }
		}

		public static ExtendProperty ppy_configgroupProperty = ExtendProperty.RegisterProperty("group", typeof(Byte), typeof(ppy_config),
			new DbMetaData() { FieldName = "group", IsKey = false, IDentity = false});
		///<summary>
		///行为规则
		///</summary>
		public Byte Group
		{
			set { this.SetValue(ppy_configgroupProperty, value); }
			get { return (Byte) this.GetValue(ppy_configgroupProperty); }
		}

		public static ExtendProperty ppy_configextraProperty = ExtendProperty.RegisterProperty("extra", typeof(String), typeof(ppy_config),
			new DbMetaData() { FieldName = "extra", IsKey = false, IDentity = false});
		///<summary>
		///日志规则
		///</summary>
		public String Extra
		{
			set { this.SetValue(ppy_configextraProperty, value); }
			get { return (String) this.GetValue(ppy_configextraProperty); }
		}

		public static ExtendProperty ppy_configremarkProperty = ExtendProperty.RegisterProperty("remark", typeof(String), typeof(ppy_config),
			new DbMetaData() { FieldName = "remark", IsKey = false, IDentity = false});
		///<summary>
		///类型
		///</summary>
		public String Remark
		{
			set { this.SetValue(ppy_configremarkProperty, value); }
			get { return (String) this.GetValue(ppy_configremarkProperty); }
		}

		public static ExtendProperty ppy_configcreate_timeProperty = ExtendProperty.RegisterProperty("create_time", typeof(UInt32), typeof(ppy_config),
			new DbMetaData() { FieldName = "create_time", IsKey = false, IDentity = false});
		///<summary>
		///状态
		///</summary>
		public UInt32 Create_Time
		{
			set { this.SetValue(ppy_configcreate_timeProperty, value); }
			get { return (UInt32) this.GetValue(ppy_configcreate_timeProperty); }
		}

		public static ExtendProperty ppy_configupdate_timeProperty = ExtendProperty.RegisterProperty("update_time", typeof(UInt32), typeof(ppy_config),
			new DbMetaData() { FieldName = "update_time", IsKey = false, IDentity = false});
		///<summary>
		///修改时间
		///</summary>
		public UInt32 Update_Time
		{
			set { this.SetValue(ppy_configupdate_timeProperty, value); }
			get { return (UInt32) this.GetValue(ppy_configupdate_timeProperty); }
		}

		public static ExtendProperty ppy_configstatusProperty = ExtendProperty.RegisterProperty("status", typeof(SByte), typeof(ppy_config),
			new DbMetaData() { FieldName = "status", IsKey = false, IDentity = false});
		///<summary>
		///主键
		///</summary>
		public SByte Status
		{
			set { this.SetValue(ppy_configstatusProperty, value); }
			get { return (SByte) this.GetValue(ppy_configstatusProperty); }
		}

		public static ExtendProperty ppy_configvalueProperty = ExtendProperty.RegisterProperty("value", typeof(String), typeof(ppy_config),
			new DbMetaData() { FieldName = "value", IsKey = false, IDentity = false});
		///<summary>
		///行为id
		///</summary>
		public String Value
		{
			set { this.SetValue(ppy_configvalueProperty, value); }
			get { return (String) this.GetValue(ppy_configvalueProperty); }
		}

		public static ExtendProperty ppy_configsortProperty = ExtendProperty.RegisterProperty("sort", typeof(UInt16), typeof(ppy_config),
			new DbMetaData() { FieldName = "sort", IsKey = false, IDentity = false});
		///<summary>
		///执行用户id
		///</summary>
		public UInt16 Sort
		{
			set { this.SetValue(ppy_configsortProperty, value); }
			get { return (UInt16) this.GetValue(ppy_configsortProperty); }
		}

	}

	public partial class ppy_control_log : DbObject
	{
		static ppy_control_log() {
			TableNameProperty.AddOwner(typeof(ppy_control_log),"ppy_control_log");
			KeysProperty.AddOwner(typeof(ppy_control_log),new string[]{"id"});
		} 
		public static ExtendProperty ppy_control_logidProperty = ExtendProperty.RegisterProperty("id", typeof(Int32), typeof(ppy_control_log),
			new DbMetaData() { FieldName = "id", IsKey = true, IDentity = true});
		///<summary>
		///主键
		///</summary>
		public Int32 Id
		{
			set { this.SetValue(ppy_control_logidProperty, value); }
			get { return (Int32) this.GetValue(ppy_control_logidProperty); }
		}

		public static ExtendProperty ppy_control_logcontentProperty = ExtendProperty.RegisterProperty("content", typeof(String), typeof(ppy_control_log),
			new DbMetaData() { FieldName = "content", IsKey = false, IDentity = false});
		///<summary>
		///行为唯一标识
		///</summary>
		public String Content
		{
			set { this.SetValue(ppy_control_logcontentProperty, value); }
			get { return (String) this.GetValue(ppy_control_logcontentProperty); }
		}

		public static ExtendProperty ppy_control_logcreate_timeProperty = ExtendProperty.RegisterProperty("create_time", typeof(Int32), typeof(ppy_control_log),
			new DbMetaData() { FieldName = "create_time", IsKey = false, IDentity = false});
		///<summary>
		///行为说明
		///</summary>
		public Int32 Create_Time
		{
			set { this.SetValue(ppy_control_logcreate_timeProperty, value); }
			get { return (Int32) this.GetValue(ppy_control_logcreate_timeProperty); }
		}

		public static ExtendProperty ppy_control_loguidProperty = ExtendProperty.RegisterProperty("uid", typeof(Int32), typeof(ppy_control_log),
			new DbMetaData() { FieldName = "uid", IsKey = false, IDentity = false});
		///<summary>
		///行为描述
		///</summary>
		public Int32 Uid
		{
			set { this.SetValue(ppy_control_loguidProperty, value); }
			get { return (Int32) this.GetValue(ppy_control_loguidProperty); }
		}

	}

	public partial class ppy_data_collect : DbObject
	{
		static ppy_data_collect() {
			TableNameProperty.AddOwner(typeof(ppy_data_collect),"ppy_data_collect");
			KeysProperty.AddOwner(typeof(ppy_data_collect),new string[]{"id"});
		} 
		public static ExtendProperty ppy_data_collectidProperty = ExtendProperty.RegisterProperty("id", typeof(Int32), typeof(ppy_data_collect),
			new DbMetaData() { FieldName = "id", IsKey = true, IDentity = true});
		///<summary>
		///主键
		///</summary>
		public Int32 Id
		{
			set { this.SetValue(ppy_data_collectidProperty, value); }
			get { return (Int32) this.GetValue(ppy_data_collectidProperty); }
		}

		public static ExtendProperty ppy_data_collectuidProperty = ExtendProperty.RegisterProperty("uid", typeof(Int32), typeof(ppy_data_collect),
			new DbMetaData() { FieldName = "uid", IsKey = false, IDentity = false});
		///<summary>
		///行为唯一标识
		///</summary>
		public Int32 Uid
		{
			set { this.SetValue(ppy_data_collectuidProperty, value); }
			get { return (Int32) this.GetValue(ppy_data_collectuidProperty); }
		}

		public static ExtendProperty ppy_data_collectrole_idProperty = ExtendProperty.RegisterProperty("role_id", typeof(Int32), typeof(ppy_data_collect),
			new DbMetaData() { FieldName = "role_id", IsKey = false, IDentity = false});
		///<summary>
		///行为说明
		///</summary>
		public Int32 Role_Id
		{
			set { this.SetValue(ppy_data_collectrole_idProperty, value); }
			get { return (Int32) this.GetValue(ppy_data_collectrole_idProperty); }
		}

		public static ExtendProperty ppy_data_collectmonth_timeProperty = ExtendProperty.RegisterProperty("month_time", typeof(Int32), typeof(ppy_data_collect),
			new DbMetaData() { FieldName = "month_time", IsKey = false, IDentity = false});
		///<summary>
		///行为描述
		///</summary>
		public Int32 Month_Time
		{
			set { this.SetValue(ppy_data_collectmonth_timeProperty, value); }
			get { return (Int32) this.GetValue(ppy_data_collectmonth_timeProperty); }
		}

		public static ExtendProperty ppy_data_collectorder_numProperty = ExtendProperty.RegisterProperty("order_num", typeof(Int32), typeof(ppy_data_collect),
			new DbMetaData() { FieldName = "order_num", IsKey = false, IDentity = false});
		///<summary>
		///行为规则
		///</summary>
		public Int32 Order_Num
		{
			set { this.SetValue(ppy_data_collectorder_numProperty, value); }
			get { return (Int32) this.GetValue(ppy_data_collectorder_numProperty); }
		}

		public static ExtendProperty ppy_data_collecttime_totalProperty = ExtendProperty.RegisterProperty("time_total", typeof(Int32), typeof(ppy_data_collect),
			new DbMetaData() { FieldName = "time_total", IsKey = false, IDentity = false});
		///<summary>
		///日志规则
		///</summary>
		public Int32 Time_Total
		{
			set { this.SetValue(ppy_data_collecttime_totalProperty, value); }
			get { return (Int32) this.GetValue(ppy_data_collecttime_totalProperty); }
		}

		public static ExtendProperty ppy_data_collectorder_moneyProperty = ExtendProperty.RegisterProperty("order_money", typeof(Decimal), typeof(ppy_data_collect),
			new DbMetaData() { FieldName = "order_money", IsKey = false, IDentity = false});
		///<summary>
		///类型
		///</summary>
		public Decimal Order_Money
		{
			set { this.SetValue(ppy_data_collectorder_moneyProperty, value); }
			get { return (Decimal) this.GetValue(ppy_data_collectorder_moneyProperty); }
		}

		public static ExtendProperty ppy_data_collectretail_priceProperty = ExtendProperty.RegisterProperty("retail_price", typeof(Decimal), typeof(ppy_data_collect),
			new DbMetaData() { FieldName = "retail_price", IsKey = false, IDentity = false});
		///<summary>
		///状态
		///</summary>
		public Decimal Retail_Price
		{
			set { this.SetValue(ppy_data_collectretail_priceProperty, value); }
			get { return (Decimal) this.GetValue(ppy_data_collectretail_priceProperty); }
		}

	}

	public partial class ppy_document : DbObject
	{
		static ppy_document() {
			TableNameProperty.AddOwner(typeof(ppy_document),"ppy_document");
			KeysProperty.AddOwner(typeof(ppy_document),new string[]{"id"});
		} 
		public static ExtendProperty ppy_documentidProperty = ExtendProperty.RegisterProperty("id", typeof(UInt32), typeof(ppy_document),
			new DbMetaData() { FieldName = "id", IsKey = true, IDentity = false});
		///<summary>
		///主键
		///</summary>
		public UInt32 Id
		{
			set { this.SetValue(ppy_documentidProperty, value); }
			get { return (UInt32) this.GetValue(ppy_documentidProperty); }
		}

		public static ExtendProperty ppy_documentuidProperty = ExtendProperty.RegisterProperty("uid", typeof(UInt32), typeof(ppy_document),
			new DbMetaData() { FieldName = "uid", IsKey = false, IDentity = false});
		///<summary>
		///行为唯一标识
		///</summary>
		public UInt32 Uid
		{
			set { this.SetValue(ppy_documentuidProperty, value); }
			get { return (UInt32) this.GetValue(ppy_documentuidProperty); }
		}

		public static ExtendProperty ppy_documentnameProperty = ExtendProperty.RegisterProperty("name", typeof(String), typeof(ppy_document),
			new DbMetaData() { FieldName = "name", IsKey = false, IDentity = false});
		///<summary>
		///行为说明
		///</summary>
		public String Name
		{
			set { this.SetValue(ppy_documentnameProperty, value); }
			get { return (String) this.GetValue(ppy_documentnameProperty); }
		}

		public static ExtendProperty ppy_documenttitleProperty = ExtendProperty.RegisterProperty("title", typeof(String), typeof(ppy_document),
			new DbMetaData() { FieldName = "title", IsKey = false, IDentity = false});
		///<summary>
		///行为描述
		///</summary>
		public String Title
		{
			set { this.SetValue(ppy_documenttitleProperty, value); }
			get { return (String) this.GetValue(ppy_documenttitleProperty); }
		}

		public static ExtendProperty ppy_documentcategory_idProperty = ExtendProperty.RegisterProperty("category_id", typeof(UInt32), typeof(ppy_document),
			new DbMetaData() { FieldName = "category_id", IsKey = false, IDentity = false});
		///<summary>
		///行为规则
		///</summary>
		public UInt32 Category_Id
		{
			set { this.SetValue(ppy_documentcategory_idProperty, value); }
			get { return (UInt32) this.GetValue(ppy_documentcategory_idProperty); }
		}

		public static ExtendProperty ppy_documentgroup_idProperty = ExtendProperty.RegisterProperty("group_id", typeof(UInt16), typeof(ppy_document),
			new DbMetaData() { FieldName = "group_id", IsKey = false, IDentity = false});
		///<summary>
		///日志规则
		///</summary>
		public UInt16 Group_Id
		{
			set { this.SetValue(ppy_documentgroup_idProperty, value); }
			get { return (UInt16) this.GetValue(ppy_documentgroup_idProperty); }
		}

		public static ExtendProperty ppy_documentdescriptionProperty = ExtendProperty.RegisterProperty("description", typeof(String), typeof(ppy_document),
			new DbMetaData() { FieldName = "description", IsKey = false, IDentity = false});
		///<summary>
		///类型
		///</summary>
		public String Description
		{
			set { this.SetValue(ppy_documentdescriptionProperty, value); }
			get { return (String) this.GetValue(ppy_documentdescriptionProperty); }
		}

		public static ExtendProperty ppy_documentrootProperty = ExtendProperty.RegisterProperty("root", typeof(UInt32), typeof(ppy_document),
			new DbMetaData() { FieldName = "root", IsKey = false, IDentity = false});
		///<summary>
		///状态
		///</summary>
		public UInt32 Root
		{
			set { this.SetValue(ppy_documentrootProperty, value); }
			get { return (UInt32) this.GetValue(ppy_documentrootProperty); }
		}

		public static ExtendProperty ppy_documentpidProperty = ExtendProperty.RegisterProperty("pid", typeof(UInt32), typeof(ppy_document),
			new DbMetaData() { FieldName = "pid", IsKey = false, IDentity = false});
		///<summary>
		///修改时间
		///</summary>
		public UInt32 Pid
		{
			set { this.SetValue(ppy_documentpidProperty, value); }
			get { return (UInt32) this.GetValue(ppy_documentpidProperty); }
		}

		public static ExtendProperty ppy_documentmodel_idProperty = ExtendProperty.RegisterProperty("model_id", typeof(Byte), typeof(ppy_document),
			new DbMetaData() { FieldName = "model_id", IsKey = false, IDentity = false});
		///<summary>
		///主键
		///</summary>
		public Byte Model_Id
		{
			set { this.SetValue(ppy_documentmodel_idProperty, value); }
			get { return (Byte) this.GetValue(ppy_documentmodel_idProperty); }
		}

		public static ExtendProperty ppy_documenttypeProperty = ExtendProperty.RegisterProperty("type", typeof(Byte), typeof(ppy_document),
			new DbMetaData() { FieldName = "type", IsKey = false, IDentity = false});
		///<summary>
		///行为id
		///</summary>
		public Byte Type
		{
			set { this.SetValue(ppy_documenttypeProperty, value); }
			get { return (Byte) this.GetValue(ppy_documenttypeProperty); }
		}

		public static ExtendProperty ppy_documentpositionProperty = ExtendProperty.RegisterProperty("position", typeof(UInt16), typeof(ppy_document),
			new DbMetaData() { FieldName = "position", IsKey = false, IDentity = false});
		///<summary>
		///执行用户id
		///</summary>
		public UInt16 Position
		{
			set { this.SetValue(ppy_documentpositionProperty, value); }
			get { return (UInt16) this.GetValue(ppy_documentpositionProperty); }
		}

		public static ExtendProperty ppy_documentlink_idProperty = ExtendProperty.RegisterProperty("link_id", typeof(UInt32), typeof(ppy_document),
			new DbMetaData() { FieldName = "link_id", IsKey = false, IDentity = false});
		///<summary>
		///执行行为者ip
		///</summary>
		public UInt32 Link_Id
		{
			set { this.SetValue(ppy_documentlink_idProperty, value); }
			get { return (UInt32) this.GetValue(ppy_documentlink_idProperty); }
		}

		public static ExtendProperty ppy_documentcover_idProperty = ExtendProperty.RegisterProperty("cover_id", typeof(UInt32), typeof(ppy_document),
			new DbMetaData() { FieldName = "cover_id", IsKey = false, IDentity = false});
		///<summary>
		///触发行为的表
		///</summary>
		public UInt32 Cover_Id
		{
			set { this.SetValue(ppy_documentcover_idProperty, value); }
			get { return (UInt32) this.GetValue(ppy_documentcover_idProperty); }
		}

		public static ExtendProperty ppy_documentdisplayProperty = ExtendProperty.RegisterProperty("display", typeof(Byte), typeof(ppy_document),
			new DbMetaData() { FieldName = "display", IsKey = false, IDentity = false});
		///<summary>
		///触发行为的数据id
		///</summary>
		public Byte Display
		{
			set { this.SetValue(ppy_documentdisplayProperty, value); }
			get { return (Byte) this.GetValue(ppy_documentdisplayProperty); }
		}

		public static ExtendProperty ppy_documentdeadlineProperty = ExtendProperty.RegisterProperty("deadline", typeof(UInt32), typeof(ppy_document),
			new DbMetaData() { FieldName = "deadline", IsKey = false, IDentity = false});
		///<summary>
		///日志备注
		///</summary>
		public UInt32 Deadline
		{
			set { this.SetValue(ppy_documentdeadlineProperty, value); }
			get { return (UInt32) this.GetValue(ppy_documentdeadlineProperty); }
		}

		public static ExtendProperty ppy_documentattachProperty = ExtendProperty.RegisterProperty("attach", typeof(Byte), typeof(ppy_document),
			new DbMetaData() { FieldName = "attach", IsKey = false, IDentity = false});
		///<summary>
		///状态
		///</summary>
		public Byte Attach
		{
			set { this.SetValue(ppy_documentattachProperty, value); }
			get { return (Byte) this.GetValue(ppy_documentattachProperty); }
		}

		public static ExtendProperty ppy_documentviewProperty = ExtendProperty.RegisterProperty("view", typeof(UInt32), typeof(ppy_document),
			new DbMetaData() { FieldName = "view", IsKey = false, IDentity = false});
		///<summary>
		///执行行为的时间
		///</summary>
		public UInt32 View
		{
			set { this.SetValue(ppy_documentviewProperty, value); }
			get { return (UInt32) this.GetValue(ppy_documentviewProperty); }
		}

		public static ExtendProperty ppy_documentcommentProperty = ExtendProperty.RegisterProperty("comment", typeof(UInt32), typeof(ppy_document),
			new DbMetaData() { FieldName = "comment", IsKey = false, IDentity = false});
		///<summary>
		///文件编号
		///</summary>
		public UInt32 Comment
		{
			set { this.SetValue(ppy_documentcommentProperty, value); }
			get { return (UInt32) this.GetValue(ppy_documentcommentProperty); }
		}

		public static ExtendProperty ppy_documentextendProperty = ExtendProperty.RegisterProperty("extend", typeof(UInt32), typeof(ppy_document),
			new DbMetaData() { FieldName = "extend", IsKey = false, IDentity = false});
		///<summary>
		///活动编号
		///</summary>
		public UInt32 Extend
		{
			set { this.SetValue(ppy_documentextendProperty, value); }
			get { return (UInt32) this.GetValue(ppy_documentextendProperty); }
		}

		public static ExtendProperty ppy_documentlevelProperty = ExtendProperty.RegisterProperty("level", typeof(Int32), typeof(ppy_document),
			new DbMetaData() { FieldName = "level", IsKey = false, IDentity = false});
		///<summary>
		///经销商编号
		///</summary>
		public Int32 Level
		{
			set { this.SetValue(ppy_documentlevelProperty, value); }
			get { return (Int32) this.GetValue(ppy_documentlevelProperty); }
		}

		public static ExtendProperty ppy_documentcreate_timeProperty = ExtendProperty.RegisterProperty("create_time", typeof(UInt32), typeof(ppy_document),
			new DbMetaData() { FieldName = "create_time", IsKey = false, IDentity = false});
		///<summary>
		///上传时间
		///</summary>
		public UInt32 Create_Time
		{
			set { this.SetValue(ppy_documentcreate_timeProperty, value); }
			get { return (UInt32) this.GetValue(ppy_documentcreate_timeProperty); }
		}

		public static ExtendProperty ppy_documentupdate_timeProperty = ExtendProperty.RegisterProperty("update_time", typeof(UInt32), typeof(ppy_document),
			new DbMetaData() { FieldName = "update_time", IsKey = false, IDentity = false});
		///<summary>
		///文件路径
		///</summary>
		public UInt32 Update_Time
		{
			set { this.SetValue(ppy_documentupdate_timeProperty, value); }
			get { return (UInt32) this.GetValue(ppy_documentupdate_timeProperty); }
		}

		public static ExtendProperty ppy_documentstatusProperty = ExtendProperty.RegisterProperty("status", typeof(SByte), typeof(ppy_document),
			new DbMetaData() { FieldName = "status", IsKey = false, IDentity = false});
		///<summary>
		///文件类型		///            1内容扫描件		///            2流程扫描件		///            3举办方相关证明		///            4其它
		///</summary>
		public SByte Status
		{
			set { this.SetValue(ppy_documentstatusProperty, value); }
			get { return (SByte) this.GetValue(ppy_documentstatusProperty); }
		}

		public static ExtendProperty ppy_documentrole_idProperty = ExtendProperty.RegisterProperty("role_id", typeof(Int32), typeof(ppy_document),
			new DbMetaData() { FieldName = "role_id", IsKey = false, IDentity = false});
		///<summary>
		///编号
		///</summary>
		public Int32 Role_Id
		{
			set { this.SetValue(ppy_documentrole_idProperty, value); }
			get { return (Int32) this.GetValue(ppy_documentrole_idProperty); }
		}

	}

	public partial class ppy_document_article : DbObject
	{
		static ppy_document_article() {
			TableNameProperty.AddOwner(typeof(ppy_document_article),"ppy_document_article");
			KeysProperty.AddOwner(typeof(ppy_document_article),new string[]{"id"});
		} 
		public static ExtendProperty ppy_document_articleidProperty = ExtendProperty.RegisterProperty("id", typeof(UInt32), typeof(ppy_document_article),
			new DbMetaData() { FieldName = "id", IsKey = true, IDentity = false});
		///<summary>
		///主键
		///</summary>
		public UInt32 Id
		{
			set { this.SetValue(ppy_document_articleidProperty, value); }
			get { return (UInt32) this.GetValue(ppy_document_articleidProperty); }
		}

		public static ExtendProperty ppy_document_articleparseProperty = ExtendProperty.RegisterProperty("parse", typeof(Byte), typeof(ppy_document_article),
			new DbMetaData() { FieldName = "parse", IsKey = false, IDentity = false});
		///<summary>
		///行为唯一标识
		///</summary>
		public Byte Parse
		{
			set { this.SetValue(ppy_document_articleparseProperty, value); }
			get { return (Byte) this.GetValue(ppy_document_articleparseProperty); }
		}

		public static ExtendProperty ppy_document_articlecontentProperty = ExtendProperty.RegisterProperty("content", typeof(String), typeof(ppy_document_article),
			new DbMetaData() { FieldName = "content", IsKey = false, IDentity = false});
		///<summary>
		///行为说明
		///</summary>
		public String Content
		{
			set { this.SetValue(ppy_document_articlecontentProperty, value); }
			get { return (String) this.GetValue(ppy_document_articlecontentProperty); }
		}

		public static ExtendProperty ppy_document_articletemplateProperty = ExtendProperty.RegisterProperty("template", typeof(String), typeof(ppy_document_article),
			new DbMetaData() { FieldName = "template", IsKey = false, IDentity = false});
		///<summary>
		///行为描述
		///</summary>
		public String Template
		{
			set { this.SetValue(ppy_document_articletemplateProperty, value); }
			get { return (String) this.GetValue(ppy_document_articletemplateProperty); }
		}

		public static ExtendProperty ppy_document_articlebookmarkProperty = ExtendProperty.RegisterProperty("bookmark", typeof(UInt32), typeof(ppy_document_article),
			new DbMetaData() { FieldName = "bookmark", IsKey = false, IDentity = false});
		///<summary>
		///行为规则
		///</summary>
		public UInt32 Bookmark
		{
			set { this.SetValue(ppy_document_articlebookmarkProperty, value); }
			get { return (UInt32) this.GetValue(ppy_document_articlebookmarkProperty); }
		}

		public static ExtendProperty ppy_document_articlerole_idProperty = ExtendProperty.RegisterProperty("role_id", typeof(UInt32), typeof(ppy_document_article),
			new DbMetaData() { FieldName = "role_id", IsKey = false, IDentity = false});
		///<summary>
		///日志规则
		///</summary>
		public UInt32 Role_Id
		{
			set { this.SetValue(ppy_document_articlerole_idProperty, value); }
			get { return (UInt32) this.GetValue(ppy_document_articlerole_idProperty); }
		}

	}

	public partial class ppy_document_download : DbObject
	{
		static ppy_document_download() {
			TableNameProperty.AddOwner(typeof(ppy_document_download),"ppy_document_download");
			KeysProperty.AddOwner(typeof(ppy_document_download),new string[]{"id"});
		} 
		public static ExtendProperty ppy_document_downloadidProperty = ExtendProperty.RegisterProperty("id", typeof(UInt32), typeof(ppy_document_download),
			new DbMetaData() { FieldName = "id", IsKey = true, IDentity = false});
		///<summary>
		///主键
		///</summary>
		public UInt32 Id
		{
			set { this.SetValue(ppy_document_downloadidProperty, value); }
			get { return (UInt32) this.GetValue(ppy_document_downloadidProperty); }
		}

		public static ExtendProperty ppy_document_downloadparseProperty = ExtendProperty.RegisterProperty("parse", typeof(Byte), typeof(ppy_document_download),
			new DbMetaData() { FieldName = "parse", IsKey = false, IDentity = false});
		///<summary>
		///行为唯一标识
		///</summary>
		public Byte Parse
		{
			set { this.SetValue(ppy_document_downloadparseProperty, value); }
			get { return (Byte) this.GetValue(ppy_document_downloadparseProperty); }
		}

		public static ExtendProperty ppy_document_downloadcontentProperty = ExtendProperty.RegisterProperty("content", typeof(String), typeof(ppy_document_download),
			new DbMetaData() { FieldName = "content", IsKey = false, IDentity = false});
		///<summary>
		///行为说明
		///</summary>
		public String Content
		{
			set { this.SetValue(ppy_document_downloadcontentProperty, value); }
			get { return (String) this.GetValue(ppy_document_downloadcontentProperty); }
		}

		public static ExtendProperty ppy_document_downloadtemplateProperty = ExtendProperty.RegisterProperty("template", typeof(String), typeof(ppy_document_download),
			new DbMetaData() { FieldName = "template", IsKey = false, IDentity = false});
		///<summary>
		///行为描述
		///</summary>
		public String Template
		{
			set { this.SetValue(ppy_document_downloadtemplateProperty, value); }
			get { return (String) this.GetValue(ppy_document_downloadtemplateProperty); }
		}

		public static ExtendProperty ppy_document_downloadfile_idProperty = ExtendProperty.RegisterProperty("file_id", typeof(UInt32), typeof(ppy_document_download),
			new DbMetaData() { FieldName = "file_id", IsKey = false, IDentity = false});
		///<summary>
		///行为规则
		///</summary>
		public UInt32 File_Id
		{
			set { this.SetValue(ppy_document_downloadfile_idProperty, value); }
			get { return (UInt32) this.GetValue(ppy_document_downloadfile_idProperty); }
		}

		public static ExtendProperty ppy_document_downloaddownloadProperty = ExtendProperty.RegisterProperty("download", typeof(UInt32), typeof(ppy_document_download),
			new DbMetaData() { FieldName = "download", IsKey = false, IDentity = false});
		///<summary>
		///日志规则
		///</summary>
		public UInt32 Download
		{
			set { this.SetValue(ppy_document_downloaddownloadProperty, value); }
			get { return (UInt32) this.GetValue(ppy_document_downloaddownloadProperty); }
		}

		public static ExtendProperty ppy_document_downloadsizeProperty = ExtendProperty.RegisterProperty("size", typeof(UInt64), typeof(ppy_document_download),
			new DbMetaData() { FieldName = "size", IsKey = false, IDentity = false});
		///<summary>
		///类型
		///</summary>
		public UInt64 Size
		{
			set { this.SetValue(ppy_document_downloadsizeProperty, value); }
			get { return (UInt64) this.GetValue(ppy_document_downloadsizeProperty); }
		}

	}

	public partial class ppy_file : DbObject
	{
		static ppy_file() {
			TableNameProperty.AddOwner(typeof(ppy_file),"ppy_file");
			KeysProperty.AddOwner(typeof(ppy_file),new string[]{"id"});
		} 
		public static ExtendProperty ppy_fileidProperty = ExtendProperty.RegisterProperty("id", typeof(UInt32), typeof(ppy_file),
			new DbMetaData() { FieldName = "id", IsKey = true, IDentity = false});
		///<summary>
		///主键
		///</summary>
		public UInt32 Id
		{
			set { this.SetValue(ppy_fileidProperty, value); }
			get { return (UInt32) this.GetValue(ppy_fileidProperty); }
		}

		public static ExtendProperty ppy_filenameProperty = ExtendProperty.RegisterProperty("name", typeof(String), typeof(ppy_file),
			new DbMetaData() { FieldName = "name", IsKey = false, IDentity = false});
		///<summary>
		///行为唯一标识
		///</summary>
		public String Name
		{
			set { this.SetValue(ppy_filenameProperty, value); }
			get { return (String) this.GetValue(ppy_filenameProperty); }
		}

		public static ExtendProperty ppy_filesavenameProperty = ExtendProperty.RegisterProperty("savename", typeof(String), typeof(ppy_file),
			new DbMetaData() { FieldName = "savename", IsKey = false, IDentity = false});
		///<summary>
		///行为说明
		///</summary>
		public String Savename
		{
			set { this.SetValue(ppy_filesavenameProperty, value); }
			get { return (String) this.GetValue(ppy_filesavenameProperty); }
		}

		public static ExtendProperty ppy_filesavepathProperty = ExtendProperty.RegisterProperty("savepath", typeof(String), typeof(ppy_file),
			new DbMetaData() { FieldName = "savepath", IsKey = false, IDentity = false});
		///<summary>
		///行为描述
		///</summary>
		public String Savepath
		{
			set { this.SetValue(ppy_filesavepathProperty, value); }
			get { return (String) this.GetValue(ppy_filesavepathProperty); }
		}

		public static ExtendProperty ppy_fileextProperty = ExtendProperty.RegisterProperty("ext", typeof(String), typeof(ppy_file),
			new DbMetaData() { FieldName = "ext", IsKey = false, IDentity = false});
		///<summary>
		///行为规则
		///</summary>
		public String Ext
		{
			set { this.SetValue(ppy_fileextProperty, value); }
			get { return (String) this.GetValue(ppy_fileextProperty); }
		}

		public static ExtendProperty ppy_filemimeProperty = ExtendProperty.RegisterProperty("mime", typeof(String), typeof(ppy_file),
			new DbMetaData() { FieldName = "mime", IsKey = false, IDentity = false});
		///<summary>
		///日志规则
		///</summary>
		public String Mime
		{
			set { this.SetValue(ppy_filemimeProperty, value); }
			get { return (String) this.GetValue(ppy_filemimeProperty); }
		}

		public static ExtendProperty ppy_filesizeProperty = ExtendProperty.RegisterProperty("size", typeof(UInt32), typeof(ppy_file),
			new DbMetaData() { FieldName = "size", IsKey = false, IDentity = false});
		///<summary>
		///类型
		///</summary>
		public UInt32 Size
		{
			set { this.SetValue(ppy_filesizeProperty, value); }
			get { return (UInt32) this.GetValue(ppy_filesizeProperty); }
		}

		public static ExtendProperty ppy_filemd5Property = ExtendProperty.RegisterProperty("md5", typeof(String), typeof(ppy_file),
			new DbMetaData() { FieldName = "md5", IsKey = false, IDentity = false});
		///<summary>
		///状态
		///</summary>
		public String Md5
		{
			set { this.SetValue(ppy_filemd5Property, value); }
			get { return (String) this.GetValue(ppy_filemd5Property); }
		}

		public static ExtendProperty ppy_filesha1Property = ExtendProperty.RegisterProperty("sha1", typeof(String), typeof(ppy_file),
			new DbMetaData() { FieldName = "sha1", IsKey = false, IDentity = false});
		///<summary>
		///修改时间
		///</summary>
		public String Sha1
		{
			set { this.SetValue(ppy_filesha1Property, value); }
			get { return (String) this.GetValue(ppy_filesha1Property); }
		}

		public static ExtendProperty ppy_filelocationProperty = ExtendProperty.RegisterProperty("location", typeof(Byte), typeof(ppy_file),
			new DbMetaData() { FieldName = "location", IsKey = false, IDentity = false});
		///<summary>
		///主键
		///</summary>
		public Byte Location
		{
			set { this.SetValue(ppy_filelocationProperty, value); }
			get { return (Byte) this.GetValue(ppy_filelocationProperty); }
		}

		public static ExtendProperty ppy_fileurlProperty = ExtendProperty.RegisterProperty("url", typeof(String), typeof(ppy_file),
			new DbMetaData() { FieldName = "url", IsKey = false, IDentity = false});
		///<summary>
		///行为id
		///</summary>
		public String Url
		{
			set { this.SetValue(ppy_fileurlProperty, value); }
			get { return (String) this.GetValue(ppy_fileurlProperty); }
		}

		public static ExtendProperty ppy_filecreate_timeProperty = ExtendProperty.RegisterProperty("create_time", typeof(UInt32), typeof(ppy_file),
			new DbMetaData() { FieldName = "create_time", IsKey = false, IDentity = false});
		///<summary>
		///执行用户id
		///</summary>
		public UInt32 Create_Time
		{
			set { this.SetValue(ppy_filecreate_timeProperty, value); }
			get { return (UInt32) this.GetValue(ppy_filecreate_timeProperty); }
		}

	}

	public partial class ppy_format : DbObject
	{
		static ppy_format() {
			TableNameProperty.AddOwner(typeof(ppy_format),"ppy_format");
			KeysProperty.AddOwner(typeof(ppy_format),new string[]{"Id"});
		} 
		public static ExtendProperty ppy_formatIdProperty = ExtendProperty.RegisterProperty("Id", typeof(Int32), typeof(ppy_format),
			new DbMetaData() { FieldName = "Id", IsKey = true, IDentity = true});
		///<summary>
		///主键
		///</summary>
		public Int32 Id
		{
			set { this.SetValue(ppy_formatIdProperty, value); }
			get { return (Int32) this.GetValue(ppy_formatIdProperty); }
		}

		public static ExtendProperty ppy_formatNameProperty = ExtendProperty.RegisterProperty("Name", typeof(String), typeof(ppy_format),
			new DbMetaData() { FieldName = "Name", IsKey = false, IDentity = false});
		///<summary>
		///行为唯一标识
		///</summary>
		public String Name
		{
			set { this.SetValue(ppy_formatNameProperty, value); }
			get { return (String) this.GetValue(ppy_formatNameProperty); }
		}

		public static ExtendProperty ppy_formatTimeValProperty = ExtendProperty.RegisterProperty("TimeVal", typeof(Int32), typeof(ppy_format),
			new DbMetaData() { FieldName = "TimeVal", IsKey = false, IDentity = false});
		///<summary>
		///行为说明
		///</summary>
		public Int32 Timeval
		{
			set { this.SetValue(ppy_formatTimeValProperty, value); }
			get { return (Int32) this.GetValue(ppy_formatTimeValProperty); }
		}

		public static ExtendProperty ppy_formatMinStrProperty = ExtendProperty.RegisterProperty("MinStr", typeof(Int32), typeof(ppy_format),
			new DbMetaData() { FieldName = "MinStr", IsKey = false, IDentity = false});
		///<summary>
		///行为描述
		///</summary>
		public Int32 Minstr
		{
			set { this.SetValue(ppy_formatMinStrProperty, value); }
			get { return (Int32) this.GetValue(ppy_formatMinStrProperty); }
		}

		public static ExtendProperty ppy_formatMaxStrProperty = ExtendProperty.RegisterProperty("MaxStr", typeof(Int32), typeof(ppy_format),
			new DbMetaData() { FieldName = "MaxStr", IsKey = false, IDentity = false});
		///<summary>
		///行为规则
		///</summary>
		public Int32 Maxstr
		{
			set { this.SetValue(ppy_formatMaxStrProperty, value); }
			get { return (Int32) this.GetValue(ppy_formatMaxStrProperty); }
		}

		public static ExtendProperty ppy_formatExampleProperty = ExtendProperty.RegisterProperty("Example", typeof(String), typeof(ppy_format),
			new DbMetaData() { FieldName = "Example", IsKey = false, IDentity = false});
		///<summary>
		///日志规则
		///</summary>
		public String Example
		{
			set { this.SetValue(ppy_formatExampleProperty, value); }
			get { return (String) this.GetValue(ppy_formatExampleProperty); }
		}

	}

	public partial class ppy_hooks : DbObject
	{
		static ppy_hooks() {
			TableNameProperty.AddOwner(typeof(ppy_hooks),"ppy_hooks");
			KeysProperty.AddOwner(typeof(ppy_hooks),new string[]{"id"});
		} 
		public static ExtendProperty ppy_hooksidProperty = ExtendProperty.RegisterProperty("id", typeof(UInt32), typeof(ppy_hooks),
			new DbMetaData() { FieldName = "id", IsKey = true, IDentity = false});
		///<summary>
		///主键
		///</summary>
		public UInt32 Id
		{
			set { this.SetValue(ppy_hooksidProperty, value); }
			get { return (UInt32) this.GetValue(ppy_hooksidProperty); }
		}

		public static ExtendProperty ppy_hooksnameProperty = ExtendProperty.RegisterProperty("name", typeof(String), typeof(ppy_hooks),
			new DbMetaData() { FieldName = "name", IsKey = false, IDentity = false});
		///<summary>
		///行为唯一标识
		///</summary>
		public String Name
		{
			set { this.SetValue(ppy_hooksnameProperty, value); }
			get { return (String) this.GetValue(ppy_hooksnameProperty); }
		}

		public static ExtendProperty ppy_hooksdescriptionProperty = ExtendProperty.RegisterProperty("description", typeof(String), typeof(ppy_hooks),
			new DbMetaData() { FieldName = "description", IsKey = false, IDentity = false});
		///<summary>
		///行为说明
		///</summary>
		public String Description
		{
			set { this.SetValue(ppy_hooksdescriptionProperty, value); }
			get { return (String) this.GetValue(ppy_hooksdescriptionProperty); }
		}

		public static ExtendProperty ppy_hookstypeProperty = ExtendProperty.RegisterProperty("type", typeof(Byte), typeof(ppy_hooks),
			new DbMetaData() { FieldName = "type", IsKey = false, IDentity = false});
		///<summary>
		///行为描述
		///</summary>
		public Byte Type
		{
			set { this.SetValue(ppy_hookstypeProperty, value); }
			get { return (Byte) this.GetValue(ppy_hookstypeProperty); }
		}

		public static ExtendProperty ppy_hooksupdate_timeProperty = ExtendProperty.RegisterProperty("update_time", typeof(UInt32), typeof(ppy_hooks),
			new DbMetaData() { FieldName = "update_time", IsKey = false, IDentity = false});
		///<summary>
		///行为规则
		///</summary>
		public UInt32 Update_Time
		{
			set { this.SetValue(ppy_hooksupdate_timeProperty, value); }
			get { return (UInt32) this.GetValue(ppy_hooksupdate_timeProperty); }
		}

		public static ExtendProperty ppy_hooksaddonsProperty = ExtendProperty.RegisterProperty("addons", typeof(String), typeof(ppy_hooks),
			new DbMetaData() { FieldName = "addons", IsKey = false, IDentity = false});
		///<summary>
		///日志规则
		///</summary>
		public String Addons
		{
			set { this.SetValue(ppy_hooksaddonsProperty, value); }
			get { return (String) this.GetValue(ppy_hooksaddonsProperty); }
		}

		public static ExtendProperty ppy_hooksstatusProperty = ExtendProperty.RegisterProperty("status", typeof(Byte), typeof(ppy_hooks),
			new DbMetaData() { FieldName = "status", IsKey = false, IDentity = false});
		///<summary>
		///类型
		///</summary>
		public Byte Status
		{
			set { this.SetValue(ppy_hooksstatusProperty, value); }
			get { return (Byte) this.GetValue(ppy_hooksstatusProperty); }
		}

	}

	public partial class ppy_lines : DbObject
	{
		static ppy_lines() {
			TableNameProperty.AddOwner(typeof(ppy_lines),"ppy_lines");
			KeysProperty.AddOwner(typeof(ppy_lines),new string[]{"id"});
		} 
		public static ExtendProperty ppy_linesidProperty = ExtendProperty.RegisterProperty("id", typeof(UInt32), typeof(ppy_lines),
			new DbMetaData() { FieldName = "id", IsKey = true, IDentity = false});
		///<summary>
		///主键
		///</summary>
		public UInt32 Id
		{
			set { this.SetValue(ppy_linesidProperty, value); }
			get { return (UInt32) this.GetValue(ppy_linesidProperty); }
		}

		public static ExtendProperty ppy_linesinfoProperty = ExtendProperty.RegisterProperty("info", typeof(String), typeof(ppy_lines),
			new DbMetaData() { FieldName = "info", IsKey = false, IDentity = false});
		///<summary>
		///行为唯一标识
		///</summary>
		public String Info
		{
			set { this.SetValue(ppy_linesinfoProperty, value); }
			get { return (String) this.GetValue(ppy_linesinfoProperty); }
		}

		public static ExtendProperty ppy_linestypeProperty = ExtendProperty.RegisterProperty("type", typeof(Int32), typeof(ppy_lines),
			new DbMetaData() { FieldName = "type", IsKey = false, IDentity = false});
		///<summary>
		///行为说明
		///</summary>
		public Int32 Type
		{
			set { this.SetValue(ppy_linestypeProperty, value); }
			get { return (Int32) this.GetValue(ppy_linestypeProperty); }
		}

	}

	public partial class ppy_member : DbObject
	{
		static ppy_member() {
			TableNameProperty.AddOwner(typeof(ppy_member),"ppy_member");
			KeysProperty.AddOwner(typeof(ppy_member),new string[]{"uid"});
		} 
		public static ExtendProperty ppy_memberuidProperty = ExtendProperty.RegisterProperty("uid", typeof(UInt32), typeof(ppy_member),
			new DbMetaData() { FieldName = "uid", IsKey = true, IDentity = false});
		///<summary>
		///主键
		///</summary>
		public UInt32 Uid
		{
			set { this.SetValue(ppy_memberuidProperty, value); }
			get { return (UInt32) this.GetValue(ppy_memberuidProperty); }
		}

		public static ExtendProperty ppy_membernicknameProperty = ExtendProperty.RegisterProperty("nickname", typeof(String), typeof(ppy_member),
			new DbMetaData() { FieldName = "nickname", IsKey = false, IDentity = false});
		///<summary>
		///行为唯一标识
		///</summary>
		public String Nickname
		{
			set { this.SetValue(ppy_membernicknameProperty, value); }
			get { return (String) this.GetValue(ppy_membernicknameProperty); }
		}

		public static ExtendProperty ppy_membersexProperty = ExtendProperty.RegisterProperty("sex", typeof(Byte), typeof(ppy_member),
			new DbMetaData() { FieldName = "sex", IsKey = false, IDentity = false});
		///<summary>
		///行为说明
		///</summary>
		public Byte Sex
		{
			set { this.SetValue(ppy_membersexProperty, value); }
			get { return (Byte) this.GetValue(ppy_membersexProperty); }
		}

		public static ExtendProperty ppy_memberbirthdayProperty = ExtendProperty.RegisterProperty("birthday", typeof(DateTime), typeof(ppy_member),
			new DbMetaData() { FieldName = "birthday", IsKey = false, IDentity = false});
		///<summary>
		///行为描述
		///</summary>
		public DateTime Birthday
		{
			set { this.SetValue(ppy_memberbirthdayProperty, value); }
			get { return (DateTime) this.GetValue(ppy_memberbirthdayProperty); }
		}

		public static ExtendProperty ppy_membertaxProperty = ExtendProperty.RegisterProperty("tax", typeof(String), typeof(ppy_member),
			new DbMetaData() { FieldName = "tax", IsKey = false, IDentity = false});
		///<summary>
		///行为规则
		///</summary>
		public String Tax
		{
			set { this.SetValue(ppy_membertaxProperty, value); }
			get { return (String) this.GetValue(ppy_membertaxProperty); }
		}

		public static ExtendProperty ppy_memberscoreProperty = ExtendProperty.RegisterProperty("score", typeof(Int32), typeof(ppy_member),
			new DbMetaData() { FieldName = "score", IsKey = false, IDentity = false});
		///<summary>
		///日志规则
		///</summary>
		public Int32 Score
		{
			set { this.SetValue(ppy_memberscoreProperty, value); }
			get { return (Int32) this.GetValue(ppy_memberscoreProperty); }
		}

		public static ExtendProperty ppy_memberloginProperty = ExtendProperty.RegisterProperty("login", typeof(UInt32), typeof(ppy_member),
			new DbMetaData() { FieldName = "login", IsKey = false, IDentity = false});
		///<summary>
		///类型
		///</summary>
		public UInt32 Login
		{
			set { this.SetValue(ppy_memberloginProperty, value); }
			get { return (UInt32) this.GetValue(ppy_memberloginProperty); }
		}

		public static ExtendProperty ppy_memberreg_ipProperty = ExtendProperty.RegisterProperty("reg_ip", typeof(Int64), typeof(ppy_member),
			new DbMetaData() { FieldName = "reg_ip", IsKey = false, IDentity = false});
		///<summary>
		///状态
		///</summary>
		public Int64 Reg_Ip
		{
			set { this.SetValue(ppy_memberreg_ipProperty, value); }
			get { return (Int64) this.GetValue(ppy_memberreg_ipProperty); }
		}

		public static ExtendProperty ppy_memberreg_timeProperty = ExtendProperty.RegisterProperty("reg_time", typeof(UInt32), typeof(ppy_member),
			new DbMetaData() { FieldName = "reg_time", IsKey = false, IDentity = false});
		///<summary>
		///修改时间
		///</summary>
		public UInt32 Reg_Time
		{
			set { this.SetValue(ppy_memberreg_timeProperty, value); }
			get { return (UInt32) this.GetValue(ppy_memberreg_timeProperty); }
		}

		public static ExtendProperty ppy_memberlast_login_ipProperty = ExtendProperty.RegisterProperty("last_login_ip", typeof(Int64), typeof(ppy_member),
			new DbMetaData() { FieldName = "last_login_ip", IsKey = false, IDentity = false});
		///<summary>
		///主键
		///</summary>
		public Int64 Last_Login_Ip
		{
			set { this.SetValue(ppy_memberlast_login_ipProperty, value); }
			get { return (Int64) this.GetValue(ppy_memberlast_login_ipProperty); }
		}

		public static ExtendProperty ppy_memberlast_login_timeProperty = ExtendProperty.RegisterProperty("last_login_time", typeof(UInt32), typeof(ppy_member),
			new DbMetaData() { FieldName = "last_login_time", IsKey = false, IDentity = false});
		///<summary>
		///行为id
		///</summary>
		public UInt32 Last_Login_Time
		{
			set { this.SetValue(ppy_memberlast_login_timeProperty, value); }
			get { return (UInt32) this.GetValue(ppy_memberlast_login_timeProperty); }
		}

		public static ExtendProperty ppy_memberstatusProperty = ExtendProperty.RegisterProperty("status", typeof(SByte), typeof(ppy_member),
			new DbMetaData() { FieldName = "status", IsKey = false, IDentity = false});
		///<summary>
		///执行用户id
		///</summary>
		public SByte Status
		{
			set { this.SetValue(ppy_memberstatusProperty, value); }
			get { return (SByte) this.GetValue(ppy_memberstatusProperty); }
		}

		public static ExtendProperty ppy_memberaddressProperty = ExtendProperty.RegisterProperty("address", typeof(String), typeof(ppy_member),
			new DbMetaData() { FieldName = "address", IsKey = false, IDentity = false});
		///<summary>
		///执行行为者ip
		///</summary>
		public String Address
		{
			set { this.SetValue(ppy_memberaddressProperty, value); }
			get { return (String) this.GetValue(ppy_memberaddressProperty); }
		}

		public static ExtendProperty ppy_memberprovince_idProperty = ExtendProperty.RegisterProperty("province_id", typeof(Nullable<Int32>), typeof(ppy_member),
			new DbMetaData() { FieldName = "province_id", IsKey = false, IDentity = false});
		///<summary>
		///触发行为的表
		///</summary>
		public Nullable<Int32> Province_Id
		{
			set { this.SetValue(ppy_memberprovince_idProperty, value); }
			get { return (Nullable<Int32>) this.GetValue(ppy_memberprovince_idProperty); }
		}

		public static ExtendProperty ppy_membercity_idProperty = ExtendProperty.RegisterProperty("city_id", typeof(Nullable<Int32>), typeof(ppy_member),
			new DbMetaData() { FieldName = "city_id", IsKey = false, IDentity = false});
		///<summary>
		///触发行为的数据id
		///</summary>
		public Nullable<Int32> City_Id
		{
			set { this.SetValue(ppy_membercity_idProperty, value); }
			get { return (Nullable<Int32>) this.GetValue(ppy_membercity_idProperty); }
		}

		public static ExtendProperty ppy_memberdistrict_idProperty = ExtendProperty.RegisterProperty("district_id", typeof(Nullable<Int32>), typeof(ppy_member),
			new DbMetaData() { FieldName = "district_id", IsKey = false, IDentity = false});
		///<summary>
		///日志备注
		///</summary>
		public Nullable<Int32> District_Id
		{
			set { this.SetValue(ppy_memberdistrict_idProperty, value); }
			get { return (Nullable<Int32>) this.GetValue(ppy_memberdistrict_idProperty); }
		}

		public static ExtendProperty ppy_memberidcardProperty = ExtendProperty.RegisterProperty("idcard", typeof(String), typeof(ppy_member),
			new DbMetaData() { FieldName = "idcard", IsKey = false, IDentity = false});
		///<summary>
		///状态
		///</summary>
		public String Idcard
		{
			set { this.SetValue(ppy_memberidcardProperty, value); }
			get { return (String) this.GetValue(ppy_memberidcardProperty); }
		}

		public static ExtendProperty ppy_memberparent_uidProperty = ExtendProperty.RegisterProperty("parent_uid", typeof(Int32), typeof(ppy_member),
			new DbMetaData() { FieldName = "parent_uid", IsKey = false, IDentity = false});
		///<summary>
		///执行行为的时间
		///</summary>
		public Int32 Parent_Uid
		{
			set { this.SetValue(ppy_memberparent_uidProperty, value); }
			get { return (Int32) this.GetValue(ppy_memberparent_uidProperty); }
		}

		public static ExtendProperty ppy_memberbankcityProperty = ExtendProperty.RegisterProperty("bankcity", typeof(Nullable<Int32>), typeof(ppy_member),
			new DbMetaData() { FieldName = "bankcity", IsKey = false, IDentity = false});
		///<summary>
		///文件编号
		///</summary>
		public Nullable<Int32> Bankcity
		{
			set { this.SetValue(ppy_memberbankcityProperty, value); }
			get { return (Nullable<Int32>) this.GetValue(ppy_memberbankcityProperty); }
		}

		public static ExtendProperty ppy_memberbankprovProperty = ExtendProperty.RegisterProperty("bankprov", typeof(Nullable<Int32>), typeof(ppy_member),
			new DbMetaData() { FieldName = "bankprov", IsKey = false, IDentity = false});
		///<summary>
		///活动编号
		///</summary>
		public Nullable<Int32> Bankprov
		{
			set { this.SetValue(ppy_memberbankprovProperty, value); }
			get { return (Nullable<Int32>) this.GetValue(ppy_memberbankprovProperty); }
		}

		public static ExtendProperty ppy_memberopenbankProperty = ExtendProperty.RegisterProperty("openbank", typeof(Nullable<Int32>), typeof(ppy_member),
			new DbMetaData() { FieldName = "openbank", IsKey = false, IDentity = false});
		///<summary>
		///经销商编号
		///</summary>
		public Nullable<Int32> Openbank
		{
			set { this.SetValue(ppy_memberopenbankProperty, value); }
			get { return (Nullable<Int32>) this.GetValue(ppy_memberopenbankProperty); }
		}

		public static ExtendProperty ppy_memberbank_idProperty = ExtendProperty.RegisterProperty("bank_id", typeof(String), typeof(ppy_member),
			new DbMetaData() { FieldName = "bank_id", IsKey = false, IDentity = false});
		///<summary>
		///上传时间
		///</summary>
		public String Bank_Id
		{
			set { this.SetValue(ppy_memberbank_idProperty, value); }
			get { return (String) this.GetValue(ppy_memberbank_idProperty); }
		}

		public static ExtendProperty ppy_membersalesProperty = ExtendProperty.RegisterProperty("sales", typeof(Nullable<Int32>), typeof(ppy_member),
			new DbMetaData() { FieldName = "sales", IsKey = false, IDentity = false});
		///<summary>
		///文件路径
		///</summary>
		public Nullable<Int32> Sales
		{
			set { this.SetValue(ppy_membersalesProperty, value); }
			get { return (Nullable<Int32>) this.GetValue(ppy_membersalesProperty); }
		}

		public static ExtendProperty ppy_memberlasttimeProperty = ExtendProperty.RegisterProperty("lasttime", typeof(Nullable<Int32>), typeof(ppy_member),
			new DbMetaData() { FieldName = "lasttime", IsKey = false, IDentity = false});
		///<summary>
		///文件类型		///            1内容扫描件		///            2流程扫描件		///            3举办方相关证明		///            4其它
		///</summary>
		public Nullable<Int32> Lasttime
		{
			set { this.SetValue(ppy_memberlasttimeProperty, value); }
			get { return (Nullable<Int32>) this.GetValue(ppy_memberlasttimeProperty); }
		}

		public static ExtendProperty ppy_memberstartimeProperty = ExtendProperty.RegisterProperty("startime", typeof(Int32), typeof(ppy_member),
			new DbMetaData() { FieldName = "startime", IsKey = false, IDentity = false});
		///<summary>
		///编号
		///</summary>
		public Int32 Startime
		{
			set { this.SetValue(ppy_memberstartimeProperty, value); }
			get { return (Int32) this.GetValue(ppy_memberstartimeProperty); }
		}

		public static ExtendProperty ppy_memberendtimeProperty = ExtendProperty.RegisterProperty("endtime", typeof(Int32), typeof(ppy_member),
			new DbMetaData() { FieldName = "endtime", IsKey = false, IDentity = false});
		///<summary>
		///活动名称
		///</summary>
		public Int32 Endtime
		{
			set { this.SetValue(ppy_memberendtimeProperty, value); }
			get { return (Int32) this.GetValue(ppy_memberendtimeProperty); }
		}

		public static ExtendProperty ppy_memberimgProperty = ExtendProperty.RegisterProperty("img", typeof(String), typeof(ppy_member),
			new DbMetaData() { FieldName = "img", IsKey = false, IDentity = false});
		///<summary>
		///活动地点
		///</summary>
		public String Img
		{
			set { this.SetValue(ppy_memberimgProperty, value); }
			get { return (String) this.GetValue(ppy_memberimgProperty); }
		}

		public static ExtendProperty ppy_memberimg2Property = ExtendProperty.RegisterProperty("img2", typeof(String), typeof(ppy_member),
			new DbMetaData() { FieldName = "img2", IsKey = false, IDentity = false});
		///<summary>
		///活动区域(保存区县信息)
		///</summary>
		public String Img2
		{
			set { this.SetValue(ppy_memberimg2Property, value); }
			get { return (String) this.GetValue(ppy_memberimg2Property); }
		}

		public static ExtendProperty ppy_membernameProperty = ExtendProperty.RegisterProperty("name", typeof(String), typeof(ppy_member),
			new DbMetaData() { FieldName = "name", IsKey = false, IDentity = false});
		///<summary>
		///活动内容
		///</summary>
		public String Name
		{
			set { this.SetValue(ppy_membernameProperty, value); }
			get { return (String) this.GetValue(ppy_membernameProperty); }
		}

		public static ExtendProperty ppy_membercardnameProperty = ExtendProperty.RegisterProperty("cardname", typeof(String), typeof(ppy_member),
			new DbMetaData() { FieldName = "cardname", IsKey = false, IDentity = false});
		///<summary>
		///开始时间
		///</summary>
		public String Cardname
		{
			set { this.SetValue(ppy_membercardnameProperty, value); }
			get { return (String) this.GetValue(ppy_membercardnameProperty); }
		}

		public static ExtendProperty ppy_memberstar_zoneProperty = ExtendProperty.RegisterProperty("star_zone", typeof(Int32), typeof(ppy_member),
			new DbMetaData() { FieldName = "star_zone", IsKey = false, IDentity = false});
		///<summary>
		///结束时间
		///</summary>
		public Int32 Star_Zone
		{
			set { this.SetValue(ppy_memberstar_zoneProperty, value); }
			get { return (Int32) this.GetValue(ppy_memberstar_zoneProperty); }
		}

		public static ExtendProperty ppy_memberconstructProperty = ExtendProperty.RegisterProperty("construct", typeof(String), typeof(ppy_member),
			new DbMetaData() { FieldName = "construct", IsKey = false, IDentity = false});
		///<summary>
		///活动流程
		///</summary>
		public String Construct
		{
			set { this.SetValue(ppy_memberconstructProperty, value); }
			get { return (String) this.GetValue(ppy_memberconstructProperty); }
		}

		public static ExtendProperty ppy_membersub_bankProperty = ExtendProperty.RegisterProperty("sub_bank", typeof(String), typeof(ppy_member),
			new DbMetaData() { FieldName = "sub_bank", IsKey = false, IDentity = false});
		///<summary>
		///举办方名称
		///</summary>
		public String Sub_Bank
		{
			set { this.SetValue(ppy_membersub_bankProperty, value); }
			get { return (String) this.GetValue(ppy_membersub_bankProperty); }
		}

		public static ExtendProperty ppy_memberisdqProperty = ExtendProperty.RegisterProperty("isdq", typeof(Int64), typeof(ppy_member),
			new DbMetaData() { FieldName = "isdq", IsKey = false, IDentity = false});
		///<summary>
		///举办方电话
		///</summary>
		public Int64 Isdq
		{
			set { this.SetValue(ppy_memberisdqProperty, value); }
			get { return (Int64) this.GetValue(ppy_memberisdqProperty); }
		}

	}

	public partial class ppy_menu : DbObject
	{
		static ppy_menu() {
			TableNameProperty.AddOwner(typeof(ppy_menu),"ppy_menu");
			KeysProperty.AddOwner(typeof(ppy_menu),new string[]{"id"});
		} 
		public static ExtendProperty ppy_menuidProperty = ExtendProperty.RegisterProperty("id", typeof(UInt32), typeof(ppy_menu),
			new DbMetaData() { FieldName = "id", IsKey = true, IDentity = false});
		///<summary>
		///主键
		///</summary>
		public UInt32 Id
		{
			set { this.SetValue(ppy_menuidProperty, value); }
			get { return (UInt32) this.GetValue(ppy_menuidProperty); }
		}

		public static ExtendProperty ppy_menutitleProperty = ExtendProperty.RegisterProperty("title", typeof(String), typeof(ppy_menu),
			new DbMetaData() { FieldName = "title", IsKey = false, IDentity = false});
		///<summary>
		///行为唯一标识
		///</summary>
		public String Title
		{
			set { this.SetValue(ppy_menutitleProperty, value); }
			get { return (String) this.GetValue(ppy_menutitleProperty); }
		}

		public static ExtendProperty ppy_menupidProperty = ExtendProperty.RegisterProperty("pid", typeof(UInt32), typeof(ppy_menu),
			new DbMetaData() { FieldName = "pid", IsKey = false, IDentity = false});
		///<summary>
		///行为说明
		///</summary>
		public UInt32 Pid
		{
			set { this.SetValue(ppy_menupidProperty, value); }
			get { return (UInt32) this.GetValue(ppy_menupidProperty); }
		}

		public static ExtendProperty ppy_menusortProperty = ExtendProperty.RegisterProperty("sort", typeof(UInt32), typeof(ppy_menu),
			new DbMetaData() { FieldName = "sort", IsKey = false, IDentity = false});
		///<summary>
		///行为描述
		///</summary>
		public UInt32 Sort
		{
			set { this.SetValue(ppy_menusortProperty, value); }
			get { return (UInt32) this.GetValue(ppy_menusortProperty); }
		}

		public static ExtendProperty ppy_menuurlProperty = ExtendProperty.RegisterProperty("url", typeof(String), typeof(ppy_menu),
			new DbMetaData() { FieldName = "url", IsKey = false, IDentity = false});
		///<summary>
		///行为规则
		///</summary>
		public String Url
		{
			set { this.SetValue(ppy_menuurlProperty, value); }
			get { return (String) this.GetValue(ppy_menuurlProperty); }
		}

		public static ExtendProperty ppy_menuhideProperty = ExtendProperty.RegisterProperty("hide", typeof(Byte), typeof(ppy_menu),
			new DbMetaData() { FieldName = "hide", IsKey = false, IDentity = false});
		///<summary>
		///日志规则
		///</summary>
		public Byte Hide
		{
			set { this.SetValue(ppy_menuhideProperty, value); }
			get { return (Byte) this.GetValue(ppy_menuhideProperty); }
		}

		public static ExtendProperty ppy_menutipProperty = ExtendProperty.RegisterProperty("tip", typeof(String), typeof(ppy_menu),
			new DbMetaData() { FieldName = "tip", IsKey = false, IDentity = false});
		///<summary>
		///类型
		///</summary>
		public String Tip
		{
			set { this.SetValue(ppy_menutipProperty, value); }
			get { return (String) this.GetValue(ppy_menutipProperty); }
		}

		public static ExtendProperty ppy_menugroupProperty = ExtendProperty.RegisterProperty("group", typeof(String), typeof(ppy_menu),
			new DbMetaData() { FieldName = "group", IsKey = false, IDentity = false});
		///<summary>
		///状态
		///</summary>
		public String Group
		{
			set { this.SetValue(ppy_menugroupProperty, value); }
			get { return (String) this.GetValue(ppy_menugroupProperty); }
		}

		public static ExtendProperty ppy_menuis_devProperty = ExtendProperty.RegisterProperty("is_dev", typeof(Byte), typeof(ppy_menu),
			new DbMetaData() { FieldName = "is_dev", IsKey = false, IDentity = false});
		///<summary>
		///修改时间
		///</summary>
		public Byte Is_Dev
		{
			set { this.SetValue(ppy_menuis_devProperty, value); }
			get { return (Byte) this.GetValue(ppy_menuis_devProperty); }
		}

		public static ExtendProperty ppy_menustatusProperty = ExtendProperty.RegisterProperty("status", typeof(Boolean), typeof(ppy_menu),
			new DbMetaData() { FieldName = "status", IsKey = false, IDentity = false});
		///<summary>
		///主键
		///</summary>
		public Boolean Status
		{
			set { this.SetValue(ppy_menustatusProperty, value); }
			get { return (Boolean) this.GetValue(ppy_menustatusProperty); }
		}

		public static ExtendProperty ppy_menutypeProperty = ExtendProperty.RegisterProperty("type", typeof(SByte), typeof(ppy_menu),
			new DbMetaData() { FieldName = "type", IsKey = false, IDentity = false});
		///<summary>
		///行为id
		///</summary>
		public SByte Type
		{
			set { this.SetValue(ppy_menutypeProperty, value); }
			get { return (SByte) this.GetValue(ppy_menutypeProperty); }
		}

	}

	public partial class ppy_model : DbObject
	{
		static ppy_model() {
			TableNameProperty.AddOwner(typeof(ppy_model),"ppy_model");
			KeysProperty.AddOwner(typeof(ppy_model),new string[]{"id"});
		} 
		public static ExtendProperty ppy_modelidProperty = ExtendProperty.RegisterProperty("id", typeof(UInt32), typeof(ppy_model),
			new DbMetaData() { FieldName = "id", IsKey = true, IDentity = false});
		///<summary>
		///主键
		///</summary>
		public UInt32 Id
		{
			set { this.SetValue(ppy_modelidProperty, value); }
			get { return (UInt32) this.GetValue(ppy_modelidProperty); }
		}

		public static ExtendProperty ppy_modelnameProperty = ExtendProperty.RegisterProperty("name", typeof(String), typeof(ppy_model),
			new DbMetaData() { FieldName = "name", IsKey = false, IDentity = false});
		///<summary>
		///行为唯一标识
		///</summary>
		public String Name
		{
			set { this.SetValue(ppy_modelnameProperty, value); }
			get { return (String) this.GetValue(ppy_modelnameProperty); }
		}

		public static ExtendProperty ppy_modeltitleProperty = ExtendProperty.RegisterProperty("title", typeof(String), typeof(ppy_model),
			new DbMetaData() { FieldName = "title", IsKey = false, IDentity = false});
		///<summary>
		///行为说明
		///</summary>
		public String Title
		{
			set { this.SetValue(ppy_modeltitleProperty, value); }
			get { return (String) this.GetValue(ppy_modeltitleProperty); }
		}

		public static ExtendProperty ppy_modelextendProperty = ExtendProperty.RegisterProperty("extend", typeof(UInt32), typeof(ppy_model),
			new DbMetaData() { FieldName = "extend", IsKey = false, IDentity = false});
		///<summary>
		///行为描述
		///</summary>
		public UInt32 Extend
		{
			set { this.SetValue(ppy_modelextendProperty, value); }
			get { return (UInt32) this.GetValue(ppy_modelextendProperty); }
		}

		public static ExtendProperty ppy_modelrelationProperty = ExtendProperty.RegisterProperty("relation", typeof(String), typeof(ppy_model),
			new DbMetaData() { FieldName = "relation", IsKey = false, IDentity = false});
		///<summary>
		///行为规则
		///</summary>
		public String Relation
		{
			set { this.SetValue(ppy_modelrelationProperty, value); }
			get { return (String) this.GetValue(ppy_modelrelationProperty); }
		}

		public static ExtendProperty ppy_modelneed_pkProperty = ExtendProperty.RegisterProperty("need_pk", typeof(Byte), typeof(ppy_model),
			new DbMetaData() { FieldName = "need_pk", IsKey = false, IDentity = false});
		///<summary>
		///日志规则
		///</summary>
		public Byte Need_Pk
		{
			set { this.SetValue(ppy_modelneed_pkProperty, value); }
			get { return (Byte) this.GetValue(ppy_modelneed_pkProperty); }
		}

		public static ExtendProperty ppy_modelfield_sortProperty = ExtendProperty.RegisterProperty("field_sort", typeof(String), typeof(ppy_model),
			new DbMetaData() { FieldName = "field_sort", IsKey = false, IDentity = false});
		///<summary>
		///类型
		///</summary>
		public String Field_Sort
		{
			set { this.SetValue(ppy_modelfield_sortProperty, value); }
			get { return (String) this.GetValue(ppy_modelfield_sortProperty); }
		}

		public static ExtendProperty ppy_modelfield_groupProperty = ExtendProperty.RegisterProperty("field_group", typeof(String), typeof(ppy_model),
			new DbMetaData() { FieldName = "field_group", IsKey = false, IDentity = false});
		///<summary>
		///状态
		///</summary>
		public String Field_Group
		{
			set { this.SetValue(ppy_modelfield_groupProperty, value); }
			get { return (String) this.GetValue(ppy_modelfield_groupProperty); }
		}

		public static ExtendProperty ppy_modelattribute_listProperty = ExtendProperty.RegisterProperty("attribute_list", typeof(String), typeof(ppy_model),
			new DbMetaData() { FieldName = "attribute_list", IsKey = false, IDentity = false});
		///<summary>
		///修改时间
		///</summary>
		public String Attribute_List
		{
			set { this.SetValue(ppy_modelattribute_listProperty, value); }
			get { return (String) this.GetValue(ppy_modelattribute_listProperty); }
		}

		public static ExtendProperty ppy_modelattribute_aliasProperty = ExtendProperty.RegisterProperty("attribute_alias", typeof(String), typeof(ppy_model),
			new DbMetaData() { FieldName = "attribute_alias", IsKey = false, IDentity = false});
		///<summary>
		///主键
		///</summary>
		public String Attribute_Alias
		{
			set { this.SetValue(ppy_modelattribute_aliasProperty, value); }
			get { return (String) this.GetValue(ppy_modelattribute_aliasProperty); }
		}

		public static ExtendProperty ppy_modeltemplate_listProperty = ExtendProperty.RegisterProperty("template_list", typeof(String), typeof(ppy_model),
			new DbMetaData() { FieldName = "template_list", IsKey = false, IDentity = false});
		///<summary>
		///行为id
		///</summary>
		public String Template_List
		{
			set { this.SetValue(ppy_modeltemplate_listProperty, value); }
			get { return (String) this.GetValue(ppy_modeltemplate_listProperty); }
		}

		public static ExtendProperty ppy_modeltemplate_addProperty = ExtendProperty.RegisterProperty("template_add", typeof(String), typeof(ppy_model),
			new DbMetaData() { FieldName = "template_add", IsKey = false, IDentity = false});
		///<summary>
		///执行用户id
		///</summary>
		public String Template_Add
		{
			set { this.SetValue(ppy_modeltemplate_addProperty, value); }
			get { return (String) this.GetValue(ppy_modeltemplate_addProperty); }
		}

		public static ExtendProperty ppy_modeltemplate_editProperty = ExtendProperty.RegisterProperty("template_edit", typeof(String), typeof(ppy_model),
			new DbMetaData() { FieldName = "template_edit", IsKey = false, IDentity = false});
		///<summary>
		///执行行为者ip
		///</summary>
		public String Template_Edit
		{
			set { this.SetValue(ppy_modeltemplate_editProperty, value); }
			get { return (String) this.GetValue(ppy_modeltemplate_editProperty); }
		}

		public static ExtendProperty ppy_modellist_gridProperty = ExtendProperty.RegisterProperty("list_grid", typeof(String), typeof(ppy_model),
			new DbMetaData() { FieldName = "list_grid", IsKey = false, IDentity = false});
		///<summary>
		///触发行为的表
		///</summary>
		public String List_Grid
		{
			set { this.SetValue(ppy_modellist_gridProperty, value); }
			get { return (String) this.GetValue(ppy_modellist_gridProperty); }
		}

		public static ExtendProperty ppy_modellist_rowProperty = ExtendProperty.RegisterProperty("list_row", typeof(UInt16), typeof(ppy_model),
			new DbMetaData() { FieldName = "list_row", IsKey = false, IDentity = false});
		///<summary>
		///触发行为的数据id
		///</summary>
		public UInt16 List_Row
		{
			set { this.SetValue(ppy_modellist_rowProperty, value); }
			get { return (UInt16) this.GetValue(ppy_modellist_rowProperty); }
		}

		public static ExtendProperty ppy_modelsearch_keyProperty = ExtendProperty.RegisterProperty("search_key", typeof(String), typeof(ppy_model),
			new DbMetaData() { FieldName = "search_key", IsKey = false, IDentity = false});
		///<summary>
		///日志备注
		///</summary>
		public String Search_Key
		{
			set { this.SetValue(ppy_modelsearch_keyProperty, value); }
			get { return (String) this.GetValue(ppy_modelsearch_keyProperty); }
		}

		public static ExtendProperty ppy_modelsearch_listProperty = ExtendProperty.RegisterProperty("search_list", typeof(String), typeof(ppy_model),
			new DbMetaData() { FieldName = "search_list", IsKey = false, IDentity = false});
		///<summary>
		///状态
		///</summary>
		public String Search_List
		{
			set { this.SetValue(ppy_modelsearch_listProperty, value); }
			get { return (String) this.GetValue(ppy_modelsearch_listProperty); }
		}

		public static ExtendProperty ppy_modelcreate_timeProperty = ExtendProperty.RegisterProperty("create_time", typeof(UInt32), typeof(ppy_model),
			new DbMetaData() { FieldName = "create_time", IsKey = false, IDentity = false});
		///<summary>
		///执行行为的时间
		///</summary>
		public UInt32 Create_Time
		{
			set { this.SetValue(ppy_modelcreate_timeProperty, value); }
			get { return (UInt32) this.GetValue(ppy_modelcreate_timeProperty); }
		}

		public static ExtendProperty ppy_modelupdate_timeProperty = ExtendProperty.RegisterProperty("update_time", typeof(UInt32), typeof(ppy_model),
			new DbMetaData() { FieldName = "update_time", IsKey = false, IDentity = false});
		///<summary>
		///文件编号
		///</summary>
		public UInt32 Update_Time
		{
			set { this.SetValue(ppy_modelupdate_timeProperty, value); }
			get { return (UInt32) this.GetValue(ppy_modelupdate_timeProperty); }
		}

		public static ExtendProperty ppy_modelstatusProperty = ExtendProperty.RegisterProperty("status", typeof(Byte), typeof(ppy_model),
			new DbMetaData() { FieldName = "status", IsKey = false, IDentity = false});
		///<summary>
		///活动编号
		///</summary>
		public Byte Status
		{
			set { this.SetValue(ppy_modelstatusProperty, value); }
			get { return (Byte) this.GetValue(ppy_modelstatusProperty); }
		}

		public static ExtendProperty ppy_modelengine_typeProperty = ExtendProperty.RegisterProperty("engine_type", typeof(String), typeof(ppy_model),
			new DbMetaData() { FieldName = "engine_type", IsKey = false, IDentity = false});
		///<summary>
		///经销商编号
		///</summary>
		public String Engine_Type
		{
			set { this.SetValue(ppy_modelengine_typeProperty, value); }
			get { return (String) this.GetValue(ppy_modelengine_typeProperty); }
		}

	}

	public partial class ppy_order : DbObject
	{
		static ppy_order() {
			TableNameProperty.AddOwner(typeof(ppy_order),"ppy_order");
			KeysProperty.AddOwner(typeof(ppy_order),new string[]{"id"});
		} 
		public static ExtendProperty ppy_orderidProperty = ExtendProperty.RegisterProperty("id", typeof(Int32), typeof(ppy_order),
			new DbMetaData() { FieldName = "id", IsKey = true, IDentity = true});
		///<summary>
		///主键
		///</summary>
		public Int32 Id
		{
			set { this.SetValue(ppy_orderidProperty, value); }
			get { return (Int32) this.GetValue(ppy_orderidProperty); }
		}

		public static ExtendProperty ppy_orderOrderIdProperty = ExtendProperty.RegisterProperty("OrderId", typeof(String), typeof(ppy_order),
			new DbMetaData() { FieldName = "OrderId", IsKey = false, IDentity = false});
		///<summary>
		///行为唯一标识
		///</summary>
		public String Orderid
		{
			set { this.SetValue(ppy_orderOrderIdProperty, value); }
			get { return (String) this.GetValue(ppy_orderOrderIdProperty); }
		}

		public static ExtendProperty ppy_orderStarIDProperty = ExtendProperty.RegisterProperty("StarID", typeof(Int32), typeof(ppy_order),
			new DbMetaData() { FieldName = "StarID", IsKey = false, IDentity = false});
		///<summary>
		///行为说明
		///</summary>
		public Int32 Starid
		{
			set { this.SetValue(ppy_orderStarIDProperty, value); }
			get { return (Int32) this.GetValue(ppy_orderStarIDProperty); }
		}

		public static ExtendProperty ppy_orderFormatIDProperty = ExtendProperty.RegisterProperty("FormatID", typeof(Int32), typeof(ppy_order),
			new DbMetaData() { FieldName = "FormatID", IsKey = false, IDentity = false});
		///<summary>
		///行为描述
		///</summary>
		public Int32 Formatid
		{
			set { this.SetValue(ppy_orderFormatIDProperty, value); }
			get { return (Int32) this.GetValue(ppy_orderFormatIDProperty); }
		}

		public static ExtendProperty ppy_orderRetailPriceProperty = ExtendProperty.RegisterProperty("RetailPrice", typeof(Decimal), typeof(ppy_order),
			new DbMetaData() { FieldName = "RetailPrice", IsKey = false, IDentity = false});
		///<summary>
		///行为规则
		///</summary>
		public Decimal Retailprice
		{
			set { this.SetValue(ppy_orderRetailPriceProperty, value); }
			get { return (Decimal) this.GetValue(ppy_orderRetailPriceProperty); }
		}

		public static ExtendProperty ppy_orderChannelPriceProperty = ExtendProperty.RegisterProperty("ChannelPrice", typeof(Decimal), typeof(ppy_order),
			new DbMetaData() { FieldName = "ChannelPrice", IsKey = false, IDentity = false});
		///<summary>
		///日志规则
		///</summary>
		public Decimal Channelprice
		{
			set { this.SetValue(ppy_orderChannelPriceProperty, value); }
			get { return (Decimal) this.GetValue(ppy_orderChannelPriceProperty); }
		}

		public static ExtendProperty ppy_orderStarPriceProperty = ExtendProperty.RegisterProperty("StarPrice", typeof(Decimal), typeof(ppy_order),
			new DbMetaData() { FieldName = "StarPrice", IsKey = false, IDentity = false});
		///<summary>
		///类型
		///</summary>
		public Decimal Starprice
		{
			set { this.SetValue(ppy_orderStarPriceProperty, value); }
			get { return (Decimal) this.GetValue(ppy_orderStarPriceProperty); }
		}

		public static ExtendProperty ppy_orderStarStateProperty = ExtendProperty.RegisterProperty("StarState", typeof(SByte), typeof(ppy_order),
			new DbMetaData() { FieldName = "StarState", IsKey = false, IDentity = false});
		///<summary>
		///状态
		///</summary>
		public SByte Starstate
		{
			set { this.SetValue(ppy_orderStarStateProperty, value); }
			get { return (SByte) this.GetValue(ppy_orderStarStateProperty); }
		}

		public static ExtendProperty ppy_orderManageStateProperty = ExtendProperty.RegisterProperty("ManageState", typeof(SByte), typeof(ppy_order),
			new DbMetaData() { FieldName = "ManageState", IsKey = false, IDentity = false});
		///<summary>
		///修改时间
		///</summary>
		public SByte Managestate
		{
			set { this.SetValue(ppy_orderManageStateProperty, value); }
			get { return (SByte) this.GetValue(ppy_orderManageStateProperty); }
		}

		public static ExtendProperty ppy_orderChannelStateProperty = ExtendProperty.RegisterProperty("ChannelState", typeof(SByte), typeof(ppy_order),
			new DbMetaData() { FieldName = "ChannelState", IsKey = false, IDentity = false});
		///<summary>
		///主键
		///</summary>
		public SByte Channelstate
		{
			set { this.SetValue(ppy_orderChannelStateProperty, value); }
			get { return (SByte) this.GetValue(ppy_orderChannelStateProperty); }
		}

		public static ExtendProperty ppy_orderLastTimeProperty = ExtendProperty.RegisterProperty("LastTime", typeof(Int32), typeof(ppy_order),
			new DbMetaData() { FieldName = "LastTime", IsKey = false, IDentity = false});
		///<summary>
		///行为id
		///</summary>
		public Int32 Lasttime
		{
			set { this.SetValue(ppy_orderLastTimeProperty, value); }
			get { return (Int32) this.GetValue(ppy_orderLastTimeProperty); }
		}

		public static ExtendProperty ppy_orderVideoIdProperty = ExtendProperty.RegisterProperty("VideoId", typeof(Int32), typeof(ppy_order),
			new DbMetaData() { FieldName = "VideoId", IsKey = false, IDentity = false});
		///<summary>
		///执行用户id
		///</summary>
		public Int32 Videoid
		{
			set { this.SetValue(ppy_orderVideoIdProperty, value); }
			get { return (Int32) this.GetValue(ppy_orderVideoIdProperty); }
		}

		public static ExtendProperty ppy_orderNameProperty = ExtendProperty.RegisterProperty("Name", typeof(String), typeof(ppy_order),
			new DbMetaData() { FieldName = "Name", IsKey = false, IDentity = false});
		///<summary>
		///执行行为者ip
		///</summary>
		public String Name
		{
			set { this.SetValue(ppy_orderNameProperty, value); }
			get { return (String) this.GetValue(ppy_orderNameProperty); }
		}

		public static ExtendProperty ppy_orderPhoneProperty = ExtendProperty.RegisterProperty("Phone", typeof(String), typeof(ppy_order),
			new DbMetaData() { FieldName = "Phone", IsKey = false, IDentity = false});
		///<summary>
		///触发行为的表
		///</summary>
		public String Phone
		{
			set { this.SetValue(ppy_orderPhoneProperty, value); }
			get { return (String) this.GetValue(ppy_orderPhoneProperty); }
		}

		public static ExtendProperty ppy_orderLinesProperty = ExtendProperty.RegisterProperty("Lines", typeof(String), typeof(ppy_order),
			new DbMetaData() { FieldName = "Lines", IsKey = false, IDentity = false});
		///<summary>
		///触发行为的数据id
		///</summary>
		public String Lines
		{
			set { this.SetValue(ppy_orderLinesProperty, value); }
			get { return (String) this.GetValue(ppy_orderLinesProperty); }
		}

		public static ExtendProperty ppy_orderMessageProperty = ExtendProperty.RegisterProperty("Message", typeof(String), typeof(ppy_order),
			new DbMetaData() { FieldName = "Message", IsKey = false, IDentity = false});
		///<summary>
		///日志备注
		///</summary>
		public String Message
		{
			set { this.SetValue(ppy_orderMessageProperty, value); }
			get { return (String) this.GetValue(ppy_orderMessageProperty); }
		}

		public static ExtendProperty ppy_orderOrderTimeProperty = ExtendProperty.RegisterProperty("OrderTime", typeof(Int32), typeof(ppy_order),
			new DbMetaData() { FieldName = "OrderTime", IsKey = false, IDentity = false});
		///<summary>
		///状态
		///</summary>
		public Int32 Ordertime
		{
			set { this.SetValue(ppy_orderOrderTimeProperty, value); }
			get { return (Int32) this.GetValue(ppy_orderOrderTimeProperty); }
		}

		public static ExtendProperty ppy_orderStateTypeProperty = ExtendProperty.RegisterProperty("StateType", typeof(SByte), typeof(ppy_order),
			new DbMetaData() { FieldName = "StateType", IsKey = false, IDentity = false});
		///<summary>
		///执行行为的时间
		///</summary>
		public SByte Statetype
		{
			set { this.SetValue(ppy_orderStateTypeProperty, value); }
			get { return (SByte) this.GetValue(ppy_orderStateTypeProperty); }
		}

		public static ExtendProperty ppy_orderMainUidProperty = ExtendProperty.RegisterProperty("MainUid", typeof(Int32), typeof(ppy_order),
			new DbMetaData() { FieldName = "MainUid", IsKey = false, IDentity = false});
		///<summary>
		///文件编号
		///</summary>
		public Int32 Mainuid
		{
			set { this.SetValue(ppy_orderMainUidProperty, value); }
			get { return (Int32) this.GetValue(ppy_orderMainUidProperty); }
		}

		public static ExtendProperty ppy_orderUidProperty = ExtendProperty.RegisterProperty("Uid", typeof(Int32), typeof(ppy_order),
			new DbMetaData() { FieldName = "Uid", IsKey = false, IDentity = false});
		///<summary>
		///活动编号
		///</summary>
		public Int32 Uid
		{
			set { this.SetValue(ppy_orderUidProperty, value); }
			get { return (Int32) this.GetValue(ppy_orderUidProperty); }
		}

		public static ExtendProperty ppy_orderIsInvoiceProperty = ExtendProperty.RegisterProperty("IsInvoice", typeof(SByte), typeof(ppy_order),
			new DbMetaData() { FieldName = "IsInvoice", IsKey = false, IDentity = false});
		///<summary>
		///经销商编号
		///</summary>
		public SByte Isinvoice
		{
			set { this.SetValue(ppy_orderIsInvoiceProperty, value); }
			get { return (SByte) this.GetValue(ppy_orderIsInvoiceProperty); }
		}

		public static ExtendProperty ppy_orderCompleteDateProperty = ExtendProperty.RegisterProperty("CompleteDate", typeof(Int32), typeof(ppy_order),
			new DbMetaData() { FieldName = "CompleteDate", IsKey = false, IDentity = false});
		///<summary>
		///上传时间
		///</summary>
		public Int32 Completedate
		{
			set { this.SetValue(ppy_orderCompleteDateProperty, value); }
			get { return (Int32) this.GetValue(ppy_orderCompleteDateProperty); }
		}

		public static ExtendProperty ppy_orderReturntimeProperty = ExtendProperty.RegisterProperty("Returntime", typeof(Int32), typeof(ppy_order),
			new DbMetaData() { FieldName = "Returntime", IsKey = false, IDentity = false});
		///<summary>
		///文件路径
		///</summary>
		public Int32 Returntime
		{
			set { this.SetValue(ppy_orderReturntimeProperty, value); }
			get { return (Int32) this.GetValue(ppy_orderReturntimeProperty); }
		}

		public static ExtendProperty ppy_orderPayTypeProperty = ExtendProperty.RegisterProperty("PayType", typeof(Int32), typeof(ppy_order),
			new DbMetaData() { FieldName = "PayType", IsKey = false, IDentity = false});
		///<summary>
		///文件类型		///            1内容扫描件		///            2流程扫描件		///            3举办方相关证明		///            4其它
		///</summary>
		public Int32 Paytype
		{
			set { this.SetValue(ppy_orderPayTypeProperty, value); }
			get { return (Int32) this.GetValue(ppy_orderPayTypeProperty); }
		}

	}

	public partial class ppy_payment : DbObject
	{
		static ppy_payment() {
			TableNameProperty.AddOwner(typeof(ppy_payment),"ppy_payment");
			KeysProperty.AddOwner(typeof(ppy_payment),new string[]{"id"});
		} 
		public static ExtendProperty ppy_paymentidProperty = ExtendProperty.RegisterProperty("id", typeof(Int32), typeof(ppy_payment),
			new DbMetaData() { FieldName = "id", IsKey = true, IDentity = true});
		///<summary>
		///主键
		///</summary>
		public Int32 Id
		{
			set { this.SetValue(ppy_paymentidProperty, value); }
			get { return (Int32) this.GetValue(ppy_paymentidProperty); }
		}

		public static ExtendProperty ppy_paymentnameProperty = ExtendProperty.RegisterProperty("name", typeof(String), typeof(ppy_payment),
			new DbMetaData() { FieldName = "name", IsKey = false, IDentity = false});
		///<summary>
		///行为唯一标识
		///</summary>
		public String Name
		{
			set { this.SetValue(ppy_paymentnameProperty, value); }
			get { return (String) this.GetValue(ppy_paymentnameProperty); }
		}

		public static ExtendProperty ppy_paymentinfoProperty = ExtendProperty.RegisterProperty("info", typeof(String), typeof(ppy_payment),
			new DbMetaData() { FieldName = "info", IsKey = false, IDentity = false});
		///<summary>
		///行为说明
		///</summary>
		public String Info
		{
			set { this.SetValue(ppy_paymentinfoProperty, value); }
			get { return (String) this.GetValue(ppy_paymentinfoProperty); }
		}

		public static ExtendProperty ppy_paymentnumProperty = ExtendProperty.RegisterProperty("num", typeof(Int32), typeof(ppy_payment),
			new DbMetaData() { FieldName = "num", IsKey = false, IDentity = false});
		///<summary>
		///行为描述
		///</summary>
		public Int32 Num
		{
			set { this.SetValue(ppy_paymentnumProperty, value); }
			get { return (Int32) this.GetValue(ppy_paymentnumProperty); }
		}

		public static ExtendProperty ppy_paymentrateProperty = ExtendProperty.RegisterProperty("rate", typeof(Int32), typeof(ppy_payment),
			new DbMetaData() { FieldName = "rate", IsKey = false, IDentity = false});
		///<summary>
		///行为规则
		///</summary>
		public Int32 Rate
		{
			set { this.SetValue(ppy_paymentrateProperty, value); }
			get { return (Int32) this.GetValue(ppy_paymentrateProperty); }
		}

		public static ExtendProperty ppy_paymentstateProperty = ExtendProperty.RegisterProperty("state", typeof(SByte), typeof(ppy_payment),
			new DbMetaData() { FieldName = "state", IsKey = false, IDentity = false});
		///<summary>
		///日志规则
		///</summary>
		public SByte State
		{
			set { this.SetValue(ppy_paymentstateProperty, value); }
			get { return (SByte) this.GetValue(ppy_paymentstateProperty); }
		}

	}

	public partial class ppy_picture : DbObject
	{
		static ppy_picture() {
			TableNameProperty.AddOwner(typeof(ppy_picture),"ppy_picture");
			KeysProperty.AddOwner(typeof(ppy_picture),new string[]{"id"});
		} 
		public static ExtendProperty ppy_pictureidProperty = ExtendProperty.RegisterProperty("id", typeof(UInt32), typeof(ppy_picture),
			new DbMetaData() { FieldName = "id", IsKey = true, IDentity = false});
		///<summary>
		///主键
		///</summary>
		public UInt32 Id
		{
			set { this.SetValue(ppy_pictureidProperty, value); }
			get { return (UInt32) this.GetValue(ppy_pictureidProperty); }
		}

		public static ExtendProperty ppy_picturepathProperty = ExtendProperty.RegisterProperty("path", typeof(String), typeof(ppy_picture),
			new DbMetaData() { FieldName = "path", IsKey = false, IDentity = false});
		///<summary>
		///行为唯一标识
		///</summary>
		public String Path
		{
			set { this.SetValue(ppy_picturepathProperty, value); }
			get { return (String) this.GetValue(ppy_picturepathProperty); }
		}

		public static ExtendProperty ppy_pictureurlProperty = ExtendProperty.RegisterProperty("url", typeof(String), typeof(ppy_picture),
			new DbMetaData() { FieldName = "url", IsKey = false, IDentity = false});
		///<summary>
		///行为说明
		///</summary>
		public String Url
		{
			set { this.SetValue(ppy_pictureurlProperty, value); }
			get { return (String) this.GetValue(ppy_pictureurlProperty); }
		}

		public static ExtendProperty ppy_picturemd5Property = ExtendProperty.RegisterProperty("md5", typeof(String), typeof(ppy_picture),
			new DbMetaData() { FieldName = "md5", IsKey = false, IDentity = false});
		///<summary>
		///行为描述
		///</summary>
		public String Md5
		{
			set { this.SetValue(ppy_picturemd5Property, value); }
			get { return (String) this.GetValue(ppy_picturemd5Property); }
		}

		public static ExtendProperty ppy_picturesha1Property = ExtendProperty.RegisterProperty("sha1", typeof(String), typeof(ppy_picture),
			new DbMetaData() { FieldName = "sha1", IsKey = false, IDentity = false});
		///<summary>
		///行为规则
		///</summary>
		public String Sha1
		{
			set { this.SetValue(ppy_picturesha1Property, value); }
			get { return (String) this.GetValue(ppy_picturesha1Property); }
		}

		public static ExtendProperty ppy_picturestatusProperty = ExtendProperty.RegisterProperty("status", typeof(SByte), typeof(ppy_picture),
			new DbMetaData() { FieldName = "status", IsKey = false, IDentity = false});
		///<summary>
		///日志规则
		///</summary>
		public SByte Status
		{
			set { this.SetValue(ppy_picturestatusProperty, value); }
			get { return (SByte) this.GetValue(ppy_picturestatusProperty); }
		}

		public static ExtendProperty ppy_picturecreate_timeProperty = ExtendProperty.RegisterProperty("create_time", typeof(UInt32), typeof(ppy_picture),
			new DbMetaData() { FieldName = "create_time", IsKey = false, IDentity = false});
		///<summary>
		///类型
		///</summary>
		public UInt32 Create_Time
		{
			set { this.SetValue(ppy_picturecreate_timeProperty, value); }
			get { return (UInt32) this.GetValue(ppy_picturecreate_timeProperty); }
		}

	}

	public partial class ppy_premiumlog : DbObject
	{
		static ppy_premiumlog() {
			TableNameProperty.AddOwner(typeof(ppy_premiumlog),"ppy_premiumlog");
			KeysProperty.AddOwner(typeof(ppy_premiumlog),new string[]{"CODE"});
		} 
		public static ExtendProperty ppy_premiumlogCODEProperty = ExtendProperty.RegisterProperty("CODE", typeof(Int64), typeof(ppy_premiumlog),
			new DbMetaData() { FieldName = "CODE", IsKey = true, IDentity = false});
		///<summary>
		///主键
		///</summary>
		public Int64 CODE
		{
			set { this.SetValue(ppy_premiumlogCODEProperty, value); }
			get { return (Int64) this.GetValue(ppy_premiumlogCODEProperty); }
		}

		public static ExtendProperty ppy_premiumlogACTIVITYCODEProperty = ExtendProperty.RegisterProperty("ACTIVITYCODE", typeof(Int64), typeof(ppy_premiumlog),
			new DbMetaData() { FieldName = "ACTIVITYCODE", IsKey = false, IDentity = false});
		///<summary>
		///行为唯一标识
		///</summary>
		public Int64 ACTIVITYCODE
		{
			set { this.SetValue(ppy_premiumlogACTIVITYCODEProperty, value); }
			get { return (Int64) this.GetValue(ppy_premiumlogACTIVITYCODEProperty); }
		}

		public static ExtendProperty ppy_premiumlogSTARTCODEProperty = ExtendProperty.RegisterProperty("STARTCODE", typeof(Int32), typeof(ppy_premiumlog),
			new DbMetaData() { FieldName = "STARTCODE", IsKey = false, IDentity = false});
		///<summary>
		///行为说明
		///</summary>
		public Int32 STARTCODE
		{
			set { this.SetValue(ppy_premiumlogSTARTCODEProperty, value); }
			get { return (Int32) this.GetValue(ppy_premiumlogSTARTCODEProperty); }
		}

		public static ExtendProperty ppy_premiumlogPREMIUMPRICEProperty = ExtendProperty.RegisterProperty("PREMIUMPRICE", typeof(Nullable<Decimal>), typeof(ppy_premiumlog),
			new DbMetaData() { FieldName = "PREMIUMPRICE", IsKey = false, IDentity = false});
		///<summary>
		///行为描述
		///</summary>
		public Nullable<Decimal> PREMIUMPRICE
		{
			set { this.SetValue(ppy_premiumlogPREMIUMPRICEProperty, value); }
			get { return (Nullable<Decimal>) this.GetValue(ppy_premiumlogPREMIUMPRICEProperty); }
		}

		public static ExtendProperty ppy_premiumlogCREATETIMEProperty = ExtendProperty.RegisterProperty("CREATETIME", typeof(Nullable<DateTime>), typeof(ppy_premiumlog),
			new DbMetaData() { FieldName = "CREATETIME", IsKey = false, IDentity = false});
		///<summary>
		///行为规则
		///</summary>
		public Nullable<DateTime> CREATETIME
		{
			set { this.SetValue(ppy_premiumlogCREATETIMEProperty, value); }
			get { return (Nullable<DateTime>) this.GetValue(ppy_premiumlogCREATETIMEProperty); }
		}

	}

	public partial class ppy_re_activity_start : DbObject
	{
		static ppy_re_activity_start() {
			TableNameProperty.AddOwner(typeof(ppy_re_activity_start),"ppy_re_activity_start");
			KeysProperty.AddOwner(typeof(ppy_re_activity_start),new string[]{"CODE","ACTIVITYCODE","STARTCODE"});
		} 
		public static ExtendProperty ppy_re_activity_startCODEProperty = ExtendProperty.RegisterProperty("CODE", typeof(Int32), typeof(ppy_re_activity_start),
			new DbMetaData() { FieldName = "CODE", IsKey = true, IDentity = true});
		///<summary>
		///主键
		///</summary>
		public Int32 CODE
		{
			set { this.SetValue(ppy_re_activity_startCODEProperty, value); }
			get { return (Int32) this.GetValue(ppy_re_activity_startCODEProperty); }
		}

		public static ExtendProperty ppy_re_activity_startACTIVITYCODEProperty = ExtendProperty.RegisterProperty("ACTIVITYCODE", typeof(Int64), typeof(ppy_re_activity_start),
			new DbMetaData() { FieldName = "ACTIVITYCODE", IsKey = true, IDentity = false});
		///<summary>
		///行为唯一标识
		///</summary>
		public Int64 ACTIVITYCODE
		{
			set { this.SetValue(ppy_re_activity_startACTIVITYCODEProperty, value); }
			get { return (Int64) this.GetValue(ppy_re_activity_startACTIVITYCODEProperty); }
		}

		public static ExtendProperty ppy_re_activity_startSTARTCODEProperty = ExtendProperty.RegisterProperty("STARTCODE", typeof(Int32), typeof(ppy_re_activity_start),
			new DbMetaData() { FieldName = "STARTCODE", IsKey = true, IDentity = false});
		///<summary>
		///行为说明
		///</summary>
		public Int32 STARTCODE
		{
			set { this.SetValue(ppy_re_activity_startSTARTCODEProperty, value); }
			get { return (Int32) this.GetValue(ppy_re_activity_startSTARTCODEProperty); }
		}

		public static ExtendProperty ppy_re_activity_startSTARTPRICEProperty = ExtendProperty.RegisterProperty("STARTPRICE", typeof(Nullable<Decimal>), typeof(ppy_re_activity_start),
			new DbMetaData() { FieldName = "STARTPRICE", IsKey = false, IDentity = false});
		///<summary>
		///行为描述
		///</summary>
		public Nullable<Decimal> STARTPRICE
		{
			set { this.SetValue(ppy_re_activity_startSTARTPRICEProperty, value); }
			get { return (Nullable<Decimal>) this.GetValue(ppy_re_activity_startSTARTPRICEProperty); }
		}

		public static ExtendProperty ppy_re_activity_startBILLINGMETHODProperty = ExtendProperty.RegisterProperty("BILLINGMETHOD", typeof(Nullable<SByte>), typeof(ppy_re_activity_start),
			new DbMetaData() { FieldName = "BILLINGMETHOD", IsKey = false, IDentity = false});
		///<summary>
		///行为规则
		///</summary>
		public Nullable<SByte> BILLINGMETHOD
		{
			set { this.SetValue(ppy_re_activity_startBILLINGMETHODProperty, value); }
			get { return (Nullable<SByte>) this.GetValue(ppy_re_activity_startBILLINGMETHODProperty); }
		}

		public static ExtendProperty ppy_re_activity_startTIMECOUNTProperty = ExtendProperty.RegisterProperty("TIMECOUNT", typeof(Nullable<SByte>), typeof(ppy_re_activity_start),
			new DbMetaData() { FieldName = "TIMECOUNT", IsKey = false, IDentity = false});
		///<summary>
		///日志规则
		///</summary>
		public Nullable<SByte> TIMECOUNT
		{
			set { this.SetValue(ppy_re_activity_startTIMECOUNTProperty, value); }
			get { return (Nullable<SByte>) this.GetValue(ppy_re_activity_startTIMECOUNTProperty); }
		}

		public static ExtendProperty ppy_re_activity_startREJECTCOUNTProperty = ExtendProperty.RegisterProperty("REJECTCOUNT", typeof(Nullable<SByte>), typeof(ppy_re_activity_start),
			new DbMetaData() { FieldName = "REJECTCOUNT", IsKey = false, IDentity = false});
		///<summary>
		///类型
		///</summary>
		public Nullable<SByte> REJECTCOUNT
		{
			set { this.SetValue(ppy_re_activity_startREJECTCOUNTProperty, value); }
			get { return (Nullable<SByte>) this.GetValue(ppy_re_activity_startREJECTCOUNTProperty); }
		}

		public static ExtendProperty ppy_re_activity_startPREMIUMCOUNTProperty = ExtendProperty.RegisterProperty("PREMIUMCOUNT", typeof(Nullable<SByte>), typeof(ppy_re_activity_start),
			new DbMetaData() { FieldName = "PREMIUMCOUNT", IsKey = false, IDentity = false});
		///<summary>
		///状态
		///</summary>
		public Nullable<SByte> PREMIUMCOUNT
		{
			set { this.SetValue(ppy_re_activity_startPREMIUMCOUNTProperty, value); }
			get { return (Nullable<SByte>) this.GetValue(ppy_re_activity_startPREMIUMCOUNTProperty); }
		}

		public static ExtendProperty ppy_re_activity_startISCONSENTProperty = ExtendProperty.RegisterProperty("ISCONSENT", typeof(Nullable<Boolean>), typeof(ppy_re_activity_start),
			new DbMetaData() { FieldName = "ISCONSENT", IsKey = false, IDentity = false});
		///<summary>
		///修改时间
		///</summary>
		public Nullable<Boolean> ISCONSENT
		{
			set { this.SetValue(ppy_re_activity_startISCONSENTProperty, value); }
			get { return (Nullable<Boolean>) this.GetValue(ppy_re_activity_startISCONSENTProperty); }
		}

		public static ExtendProperty ppy_re_activity_startACTIVATIONSTATEProperty = ExtendProperty.RegisterProperty("ACTIVATIONSTATE", typeof(Nullable<Boolean>), typeof(ppy_re_activity_start),
			new DbMetaData() { FieldName = "ACTIVATIONSTATE", IsKey = false, IDentity = false});
		///<summary>
		///主键
		///</summary>
		public Nullable<Boolean> ACTIVATIONSTATE
		{
			set { this.SetValue(ppy_re_activity_startACTIVATIONSTATEProperty, value); }
			get { return (Nullable<Boolean>) this.GetValue(ppy_re_activity_startACTIVATIONSTATEProperty); }
		}

	}

	public partial class ppy_register_customer : DbObject
	{
		static ppy_register_customer() {
			TableNameProperty.AddOwner(typeof(ppy_register_customer),"ppy_register_customer");
			KeysProperty.AddOwner(typeof(ppy_register_customer),new string[]{"id"});
		} 
		public static ExtendProperty ppy_register_customeridProperty = ExtendProperty.RegisterProperty("id", typeof(Int32), typeof(ppy_register_customer),
			new DbMetaData() { FieldName = "id", IsKey = true, IDentity = true});
		///<summary>
		///主键
		///</summary>
		public Int32 Id
		{
			set { this.SetValue(ppy_register_customeridProperty, value); }
			get { return (Int32) this.GetValue(ppy_register_customeridProperty); }
		}

		public static ExtendProperty ppy_register_customernameProperty = ExtendProperty.RegisterProperty("name", typeof(String), typeof(ppy_register_customer),
			new DbMetaData() { FieldName = "name", IsKey = false, IDentity = false});
		///<summary>
		///行为唯一标识
		///</summary>
		public String Name
		{
			set { this.SetValue(ppy_register_customernameProperty, value); }
			get { return (String) this.GetValue(ppy_register_customernameProperty); }
		}

		public static ExtendProperty ppy_register_customernicknameProperty = ExtendProperty.RegisterProperty("nickname", typeof(String), typeof(ppy_register_customer),
			new DbMetaData() { FieldName = "nickname", IsKey = false, IDentity = false});
		///<summary>
		///行为说明
		///</summary>
		public String Nickname
		{
			set { this.SetValue(ppy_register_customernicknameProperty, value); }
			get { return (String) this.GetValue(ppy_register_customernicknameProperty); }
		}

		public static ExtendProperty ppy_register_customerphoneProperty = ExtendProperty.RegisterProperty("phone", typeof(String), typeof(ppy_register_customer),
			new DbMetaData() { FieldName = "phone", IsKey = false, IDentity = false});
		///<summary>
		///行为描述
		///</summary>
		public String Phone
		{
			set { this.SetValue(ppy_register_customerphoneProperty, value); }
			get { return (String) this.GetValue(ppy_register_customerphoneProperty); }
		}

		public static ExtendProperty ppy_register_customertypeProperty = ExtendProperty.RegisterProperty("type", typeof(SByte), typeof(ppy_register_customer),
			new DbMetaData() { FieldName = "type", IsKey = false, IDentity = false});
		///<summary>
		///行为规则
		///</summary>
		public SByte Type
		{
			set { this.SetValue(ppy_register_customertypeProperty, value); }
			get { return (SByte) this.GetValue(ppy_register_customertypeProperty); }
		}

		public static ExtendProperty ppy_register_customerstatusProperty = ExtendProperty.RegisterProperty("status", typeof(SByte), typeof(ppy_register_customer),
			new DbMetaData() { FieldName = "status", IsKey = false, IDentity = false});
		///<summary>
		///日志规则
		///</summary>
		public SByte Status
		{
			set { this.SetValue(ppy_register_customerstatusProperty, value); }
			get { return (SByte) this.GetValue(ppy_register_customerstatusProperty); }
		}

		public static ExtendProperty ppy_register_customerremarkProperty = ExtendProperty.RegisterProperty("remark", typeof(String), typeof(ppy_register_customer),
			new DbMetaData() { FieldName = "remark", IsKey = false, IDentity = false});
		///<summary>
		///类型
		///</summary>
		public String Remark
		{
			set { this.SetValue(ppy_register_customerremarkProperty, value); }
			get { return (String) this.GetValue(ppy_register_customerremarkProperty); }
		}

		public static ExtendProperty ppy_register_customertimeProperty = ExtendProperty.RegisterProperty("time", typeof(Int32), typeof(ppy_register_customer),
			new DbMetaData() { FieldName = "time", IsKey = false, IDentity = false});
		///<summary>
		///状态
		///</summary>
		public Int32 Time
		{
			set { this.SetValue(ppy_register_customertimeProperty, value); }
			get { return (Int32) this.GetValue(ppy_register_customertimeProperty); }
		}

		public static ExtendProperty ppy_register_customermessageProperty = ExtendProperty.RegisterProperty("message", typeof(String), typeof(ppy_register_customer),
			new DbMetaData() { FieldName = "message", IsKey = false, IDentity = false});
		///<summary>
		///修改时间
		///</summary>
		public String Message
		{
			set { this.SetValue(ppy_register_customermessageProperty, value); }
			get { return (String) this.GetValue(ppy_register_customermessageProperty); }
		}

	}

	public partial class ppy_register_ucenter_member : DbObject
	{
		static ppy_register_ucenter_member() {
			TableNameProperty.AddOwner(typeof(ppy_register_ucenter_member),"ppy_register_ucenter_member");
			KeysProperty.AddOwner(typeof(ppy_register_ucenter_member),new string[]{"id"});
		} 
		public static ExtendProperty ppy_register_ucenter_memberidProperty = ExtendProperty.RegisterProperty("id", typeof(UInt32), typeof(ppy_register_ucenter_member),
			new DbMetaData() { FieldName = "id", IsKey = true, IDentity = false});
		///<summary>
		///主键
		///</summary>
		public UInt32 Id
		{
			set { this.SetValue(ppy_register_ucenter_memberidProperty, value); }
			get { return (UInt32) this.GetValue(ppy_register_ucenter_memberidProperty); }
		}

		public static ExtendProperty ppy_register_ucenter_memberusernameProperty = ExtendProperty.RegisterProperty("username", typeof(String), typeof(ppy_register_ucenter_member),
			new DbMetaData() { FieldName = "username", IsKey = false, IDentity = false});
		///<summary>
		///行为唯一标识
		///</summary>
		public String Username
		{
			set { this.SetValue(ppy_register_ucenter_memberusernameProperty, value); }
			get { return (String) this.GetValue(ppy_register_ucenter_memberusernameProperty); }
		}

		public static ExtendProperty ppy_register_ucenter_memberpasswordProperty = ExtendProperty.RegisterProperty("password", typeof(String), typeof(ppy_register_ucenter_member),
			new DbMetaData() { FieldName = "password", IsKey = false, IDentity = false});
		///<summary>
		///行为说明
		///</summary>
		public String Password
		{
			set { this.SetValue(ppy_register_ucenter_memberpasswordProperty, value); }
			get { return (String) this.GetValue(ppy_register_ucenter_memberpasswordProperty); }
		}

		public static ExtendProperty ppy_register_ucenter_membermobileProperty = ExtendProperty.RegisterProperty("mobile", typeof(String), typeof(ppy_register_ucenter_member),
			new DbMetaData() { FieldName = "mobile", IsKey = false, IDentity = false});
		///<summary>
		///行为描述
		///</summary>
		public String Mobile
		{
			set { this.SetValue(ppy_register_ucenter_membermobileProperty, value); }
			get { return (String) this.GetValue(ppy_register_ucenter_membermobileProperty); }
		}

		public static ExtendProperty ppy_register_ucenter_memberreg_timeProperty = ExtendProperty.RegisterProperty("reg_time", typeof(UInt32), typeof(ppy_register_ucenter_member),
			new DbMetaData() { FieldName = "reg_time", IsKey = false, IDentity = false});
		///<summary>
		///行为规则
		///</summary>
		public UInt32 Reg_Time
		{
			set { this.SetValue(ppy_register_ucenter_memberreg_timeProperty, value); }
			get { return (UInt32) this.GetValue(ppy_register_ucenter_memberreg_timeProperty); }
		}

		public static ExtendProperty ppy_register_ucenter_memberreg_ipProperty = ExtendProperty.RegisterProperty("reg_ip", typeof(Int64), typeof(ppy_register_ucenter_member),
			new DbMetaData() { FieldName = "reg_ip", IsKey = false, IDentity = false});
		///<summary>
		///日志规则
		///</summary>
		public Int64 Reg_Ip
		{
			set { this.SetValue(ppy_register_ucenter_memberreg_ipProperty, value); }
			get { return (Int64) this.GetValue(ppy_register_ucenter_memberreg_ipProperty); }
		}

		public static ExtendProperty ppy_register_ucenter_memberstatusProperty = ExtendProperty.RegisterProperty("status", typeof(Nullable<SByte>), typeof(ppy_register_ucenter_member),
			new DbMetaData() { FieldName = "status", IsKey = false, IDentity = false});
		///<summary>
		///类型
		///</summary>
		public Nullable<SByte> Status
		{
			set { this.SetValue(ppy_register_ucenter_memberstatusProperty, value); }
			get { return (Nullable<SByte>) this.GetValue(ppy_register_ucenter_memberstatusProperty); }
		}

		public static ExtendProperty ppy_register_ucenter_membernicknameProperty = ExtendProperty.RegisterProperty("nickname", typeof(String), typeof(ppy_register_ucenter_member),
			new DbMetaData() { FieldName = "nickname", IsKey = false, IDentity = false});
		///<summary>
		///状态
		///</summary>
		public String Nickname
		{
			set { this.SetValue(ppy_register_ucenter_membernicknameProperty, value); }
			get { return (String) this.GetValue(ppy_register_ucenter_membernicknameProperty); }
		}

		public static ExtendProperty ppy_register_ucenter_memberaddressProperty = ExtendProperty.RegisterProperty("address", typeof(String), typeof(ppy_register_ucenter_member),
			new DbMetaData() { FieldName = "address", IsKey = false, IDentity = false});
		///<summary>
		///修改时间
		///</summary>
		public String Address
		{
			set { this.SetValue(ppy_register_ucenter_memberaddressProperty, value); }
			get { return (String) this.GetValue(ppy_register_ucenter_memberaddressProperty); }
		}

		public static ExtendProperty ppy_register_ucenter_memberprovince_idProperty = ExtendProperty.RegisterProperty("province_id", typeof(Nullable<Int32>), typeof(ppy_register_ucenter_member),
			new DbMetaData() { FieldName = "province_id", IsKey = false, IDentity = false});
		///<summary>
		///主键
		///</summary>
		public Nullable<Int32> Province_Id
		{
			set { this.SetValue(ppy_register_ucenter_memberprovince_idProperty, value); }
			get { return (Nullable<Int32>) this.GetValue(ppy_register_ucenter_memberprovince_idProperty); }
		}

		public static ExtendProperty ppy_register_ucenter_membercity_idProperty = ExtendProperty.RegisterProperty("city_id", typeof(Nullable<Int32>), typeof(ppy_register_ucenter_member),
			new DbMetaData() { FieldName = "city_id", IsKey = false, IDentity = false});
		///<summary>
		///行为id
		///</summary>
		public Nullable<Int32> City_Id
		{
			set { this.SetValue(ppy_register_ucenter_membercity_idProperty, value); }
			get { return (Nullable<Int32>) this.GetValue(ppy_register_ucenter_membercity_idProperty); }
		}

		public static ExtendProperty ppy_register_ucenter_memberdistrict_idProperty = ExtendProperty.RegisterProperty("district_id", typeof(Nullable<Int32>), typeof(ppy_register_ucenter_member),
			new DbMetaData() { FieldName = "district_id", IsKey = false, IDentity = false});
		///<summary>
		///执行用户id
		///</summary>
		public Nullable<Int32> District_Id
		{
			set { this.SetValue(ppy_register_ucenter_memberdistrict_idProperty, value); }
			get { return (Nullable<Int32>) this.GetValue(ppy_register_ucenter_memberdistrict_idProperty); }
		}

		public static ExtendProperty ppy_register_ucenter_membernameProperty = ExtendProperty.RegisterProperty("name", typeof(String), typeof(ppy_register_ucenter_member),
			new DbMetaData() { FieldName = "name", IsKey = false, IDentity = false});
		///<summary>
		///执行行为者ip
		///</summary>
		public String Name
		{
			set { this.SetValue(ppy_register_ucenter_membernameProperty, value); }
			get { return (String) this.GetValue(ppy_register_ucenter_membernameProperty); }
		}

		public static ExtendProperty ppy_register_ucenter_memberremarkProperty = ExtendProperty.RegisterProperty("remark", typeof(String), typeof(ppy_register_ucenter_member),
			new DbMetaData() { FieldName = "remark", IsKey = false, IDentity = false});
		///<summary>
		///触发行为的表
		///</summary>
		public String Remark
		{
			set { this.SetValue(ppy_register_ucenter_memberremarkProperty, value); }
			get { return (String) this.GetValue(ppy_register_ucenter_memberremarkProperty); }
		}

	}

	public partial class ppy_schedule : DbObject
	{
		static ppy_schedule() {
			TableNameProperty.AddOwner(typeof(ppy_schedule),"ppy_schedule");
			KeysProperty.AddOwner(typeof(ppy_schedule),new string[]{"Id"});
		} 
		public static ExtendProperty ppy_scheduleIdProperty = ExtendProperty.RegisterProperty("Id", typeof(Int32), typeof(ppy_schedule),
			new DbMetaData() { FieldName = "Id", IsKey = true, IDentity = true});
		///<summary>
		///主键
		///</summary>
		public Int32 Id
		{
			set { this.SetValue(ppy_scheduleIdProperty, value); }
			get { return (Int32) this.GetValue(ppy_scheduleIdProperty); }
		}

		public static ExtendProperty ppy_scheduleStarIdProperty = ExtendProperty.RegisterProperty("StarId", typeof(Int32), typeof(ppy_schedule),
			new DbMetaData() { FieldName = "StarId", IsKey = false, IDentity = false});
		///<summary>
		///行为唯一标识
		///</summary>
		public Int32 Starid
		{
			set { this.SetValue(ppy_scheduleStarIdProperty, value); }
			get { return (Int32) this.GetValue(ppy_scheduleStarIdProperty); }
		}

		public static ExtendProperty ppy_scheduleStartTimeProperty = ExtendProperty.RegisterProperty("StartTime", typeof(Int32), typeof(ppy_schedule),
			new DbMetaData() { FieldName = "StartTime", IsKey = false, IDentity = false});
		///<summary>
		///行为说明
		///</summary>
		public Int32 Starttime
		{
			set { this.SetValue(ppy_scheduleStartTimeProperty, value); }
			get { return (Int32) this.GetValue(ppy_scheduleStartTimeProperty); }
		}

		public static ExtendProperty ppy_scheduleEndTimeProperty = ExtendProperty.RegisterProperty("EndTime", typeof(Int32), typeof(ppy_schedule),
			new DbMetaData() { FieldName = "EndTime", IsKey = false, IDentity = false});
		///<summary>
		///行为描述
		///</summary>
		public Int32 Endtime
		{
			set { this.SetValue(ppy_scheduleEndTimeProperty, value); }
			get { return (Int32) this.GetValue(ppy_scheduleEndTimeProperty); }
		}

	}

	public partial class ppy_star_format : DbObject
	{
		static ppy_star_format() {
			TableNameProperty.AddOwner(typeof(ppy_star_format),"ppy_star_format");
			KeysProperty.AddOwner(typeof(ppy_star_format),new string[]{"Id"});
		} 
		public static ExtendProperty ppy_star_formatIdProperty = ExtendProperty.RegisterProperty("Id", typeof(Int32), typeof(ppy_star_format),
			new DbMetaData() { FieldName = "Id", IsKey = true, IDentity = true});
		///<summary>
		///主键
		///</summary>
		public Int32 Id
		{
			set { this.SetValue(ppy_star_formatIdProperty, value); }
			get { return (Int32) this.GetValue(ppy_star_formatIdProperty); }
		}

		public static ExtendProperty ppy_star_formatStarIdProperty = ExtendProperty.RegisterProperty("StarId", typeof(Int32), typeof(ppy_star_format),
			new DbMetaData() { FieldName = "StarId", IsKey = false, IDentity = false});
		///<summary>
		///行为唯一标识
		///</summary>
		public Int32 Starid
		{
			set { this.SetValue(ppy_star_formatStarIdProperty, value); }
			get { return (Int32) this.GetValue(ppy_star_formatStarIdProperty); }
		}

		public static ExtendProperty ppy_star_formatFormatIdProperty = ExtendProperty.RegisterProperty("FormatId", typeof(Int32), typeof(ppy_star_format),
			new DbMetaData() { FieldName = "FormatId", IsKey = false, IDentity = false});
		///<summary>
		///行为说明
		///</summary>
		public Int32 Formatid
		{
			set { this.SetValue(ppy_star_formatFormatIdProperty, value); }
			get { return (Int32) this.GetValue(ppy_star_formatFormatIdProperty); }
		}

		public static ExtendProperty ppy_star_formatRetailPriceProperty = ExtendProperty.RegisterProperty("RetailPrice", typeof(Decimal), typeof(ppy_star_format),
			new DbMetaData() { FieldName = "RetailPrice", IsKey = false, IDentity = false});
		///<summary>
		///行为描述
		///</summary>
		public Decimal Retailprice
		{
			set { this.SetValue(ppy_star_formatRetailPriceProperty, value); }
			get { return (Decimal) this.GetValue(ppy_star_formatRetailPriceProperty); }
		}

		public static ExtendProperty ppy_star_formatChannelPriceProperty = ExtendProperty.RegisterProperty("ChannelPrice", typeof(Decimal), typeof(ppy_star_format),
			new DbMetaData() { FieldName = "ChannelPrice", IsKey = false, IDentity = false});
		///<summary>
		///行为规则
		///</summary>
		public Decimal Channelprice
		{
			set { this.SetValue(ppy_star_formatChannelPriceProperty, value); }
			get { return (Decimal) this.GetValue(ppy_star_formatChannelPriceProperty); }
		}

		public static ExtendProperty ppy_star_formatStarPriceProperty = ExtendProperty.RegisterProperty("StarPrice", typeof(Decimal), typeof(ppy_star_format),
			new DbMetaData() { FieldName = "StarPrice", IsKey = false, IDentity = false});
		///<summary>
		///日志规则
		///</summary>
		public Decimal Starprice
		{
			set { this.SetValue(ppy_star_formatStarPriceProperty, value); }
			get { return (Decimal) this.GetValue(ppy_star_formatStarPriceProperty); }
		}

	}

	public partial class ppy_startremark : DbObject
	{
		static ppy_startremark() {
			TableNameProperty.AddOwner(typeof(ppy_startremark),"ppy_startremark");
			KeysProperty.AddOwner(typeof(ppy_startremark),new string[]{"STARTCODE"});
		} 
		public static ExtendProperty ppy_startremarkSTARTCODEProperty = ExtendProperty.RegisterProperty("STARTCODE", typeof(UInt32), typeof(ppy_startremark),
			new DbMetaData() { FieldName = "STARTCODE", IsKey = true, IDentity = false});
		///<summary>
		///主键
		///</summary>
		public UInt32 STARTCODE
		{
			set { this.SetValue(ppy_startremarkSTARTCODEProperty, value); }
			get { return (UInt32) this.GetValue(ppy_startremarkSTARTCODEProperty); }
		}

		public static ExtendProperty ppy_startremarkALIASProperty = ExtendProperty.RegisterProperty("ALIAS", typeof(String), typeof(ppy_startremark),
			new DbMetaData() { FieldName = "ALIAS", IsKey = false, IDentity = false});
		///<summary>
		///行为唯一标识
		///</summary>
		public String ALIAS
		{
			set { this.SetValue(ppy_startremarkALIASProperty, value); }
			get { return (String) this.GetValue(ppy_startremarkALIASProperty); }
		}

		public static ExtendProperty ppy_startremarkNATIONALITYProperty = ExtendProperty.RegisterProperty("NATIONALITY", typeof(String), typeof(ppy_startremark),
			new DbMetaData() { FieldName = "NATIONALITY", IsKey = false, IDentity = false});
		///<summary>
		///行为说明
		///</summary>
		public String NATIONALITY
		{
			set { this.SetValue(ppy_startremarkNATIONALITYProperty, value); }
			get { return (String) this.GetValue(ppy_startremarkNATIONALITYProperty); }
		}

		public static ExtendProperty ppy_startremarkHEIGHTProperty = ExtendProperty.RegisterProperty("HEIGHT", typeof(Nullable<Int16>), typeof(ppy_startremark),
			new DbMetaData() { FieldName = "HEIGHT", IsKey = false, IDentity = false});
		///<summary>
		///行为描述
		///</summary>
		public Nullable<Int16> HEIGHT
		{
			set { this.SetValue(ppy_startremarkHEIGHTProperty, value); }
			get { return (Nullable<Int16>) this.GetValue(ppy_startremarkHEIGHTProperty); }
		}

		public static ExtendProperty ppy_startremarkWEIGHTProperty = ExtendProperty.RegisterProperty("WEIGHT", typeof(Nullable<Int16>), typeof(ppy_startremark),
			new DbMetaData() { FieldName = "WEIGHT", IsKey = false, IDentity = false});
		///<summary>
		///行为规则
		///</summary>
		public Nullable<Int16> WEIGHT
		{
			set { this.SetValue(ppy_startremarkWEIGHTProperty, value); }
			get { return (Nullable<Int16>) this.GetValue(ppy_startremarkWEIGHTProperty); }
		}

		public static ExtendProperty ppy_startremarkCONSTELLAIONProperty = ExtendProperty.RegisterProperty("CONSTELLAION", typeof(String), typeof(ppy_startremark),
			new DbMetaData() { FieldName = "CONSTELLAION", IsKey = false, IDentity = false});
		///<summary>
		///日志规则
		///</summary>
		public String CONSTELLAION
		{
			set { this.SetValue(ppy_startremarkCONSTELLAIONProperty, value); }
			get { return (String) this.GetValue(ppy_startremarkCONSTELLAIONProperty); }
		}

		public static ExtendProperty ppy_startremarkOCCUPATIONProperty = ExtendProperty.RegisterProperty("OCCUPATION", typeof(String), typeof(ppy_startremark),
			new DbMetaData() { FieldName = "OCCUPATION", IsKey = false, IDentity = false});
		///<summary>
		///类型
		///</summary>
		public String OCCUPATION
		{
			set { this.SetValue(ppy_startremarkOCCUPATIONProperty, value); }
			get { return (String) this.GetValue(ppy_startremarkOCCUPATIONProperty); }
		}

	}

	public partial class ppy_startworks : DbObject
	{
		static ppy_startworks() {
			TableNameProperty.AddOwner(typeof(ppy_startworks),"ppy_startworks");
			KeysProperty.AddOwner(typeof(ppy_startworks),new string[]{"CODE"});
		} 
		public static ExtendProperty ppy_startworksCODEProperty = ExtendProperty.RegisterProperty("CODE", typeof(Int64), typeof(ppy_startworks),
			new DbMetaData() { FieldName = "CODE", IsKey = true, IDentity = true});
		///<summary>
		///主键
		///</summary>
		public Int64 CODE
		{
			set { this.SetValue(ppy_startworksCODEProperty, value); }
			get { return (Int64) this.GetValue(ppy_startworksCODEProperty); }
		}

		public static ExtendProperty ppy_startworksSTARTCODEProperty = ExtendProperty.RegisterProperty("STARTCODE", typeof(UInt32), typeof(ppy_startworks),
			new DbMetaData() { FieldName = "STARTCODE", IsKey = false, IDentity = false});
		///<summary>
		///行为唯一标识
		///</summary>
		public UInt32 STARTCODE
		{
			set { this.SetValue(ppy_startworksSTARTCODEProperty, value); }
			get { return (UInt32) this.GetValue(ppy_startworksSTARTCODEProperty); }
		}

		public static ExtendProperty ppy_startworksWORKNAMEProperty = ExtendProperty.RegisterProperty("WORKNAME", typeof(String), typeof(ppy_startworks),
			new DbMetaData() { FieldName = "WORKNAME", IsKey = false, IDentity = false});
		///<summary>
		///行为说明
		///</summary>
		public String WORKNAME
		{
			set { this.SetValue(ppy_startworksWORKNAMEProperty, value); }
			get { return (String) this.GetValue(ppy_startworksWORKNAMEProperty); }
		}

		public static ExtendProperty ppy_startworksWORKIMGProperty = ExtendProperty.RegisterProperty("WORKIMG", typeof(String), typeof(ppy_startworks),
			new DbMetaData() { FieldName = "WORKIMG", IsKey = false, IDentity = false});
		///<summary>
		///行为描述
		///</summary>
		public String WORKIMG
		{
			set { this.SetValue(ppy_startworksWORKIMGProperty, value); }
			get { return (String) this.GetValue(ppy_startworksWORKIMGProperty); }
		}

		public static ExtendProperty ppy_startworksWORKTIMEProperty = ExtendProperty.RegisterProperty("WORKTIME", typeof(Nullable<DateTime>), typeof(ppy_startworks),
			new DbMetaData() { FieldName = "WORKTIME", IsKey = false, IDentity = false});
		///<summary>
		///行为规则
		///</summary>
		public Nullable<DateTime> WORKTIME
		{
			set { this.SetValue(ppy_startworksWORKTIMEProperty, value); }
			get { return (Nullable<DateTime>) this.GetValue(ppy_startworksWORKTIMEProperty); }
		}

		public static ExtendProperty ppy_startworksPERFOMERSProperty = ExtendProperty.RegisterProperty("PERFOMERS", typeof(String), typeof(ppy_startworks),
			new DbMetaData() { FieldName = "PERFOMERS", IsKey = false, IDentity = false});
		///<summary>
		///日志规则
		///</summary>
		public String PERFOMERS
		{
			set { this.SetValue(ppy_startworksPERFOMERSProperty, value); }
			get { return (String) this.GetValue(ppy_startworksPERFOMERSProperty); }
		}

		public static ExtendProperty ppy_startworksACTINGProperty = ExtendProperty.RegisterProperty("ACTING", typeof(String), typeof(ppy_startworks),
			new DbMetaData() { FieldName = "ACTING", IsKey = false, IDentity = false});
		///<summary>
		///类型
		///</summary>
		public String ACTING
		{
			set { this.SetValue(ppy_startworksACTINGProperty, value); }
			get { return (String) this.GetValue(ppy_startworksACTINGProperty); }
		}

		public static ExtendProperty ppy_startworksCSHORTProperty = ExtendProperty.RegisterProperty("CSHORT", typeof(Nullable<SByte>), typeof(ppy_startworks),
			new DbMetaData() { FieldName = "CSHORT", IsKey = false, IDentity = false});
		///<summary>
		///状态
		///</summary>
		public Nullable<SByte> CSHORT
		{
			set { this.SetValue(ppy_startworksCSHORTProperty, value); }
			get { return (Nullable<SByte>) this.GetValue(ppy_startworksCSHORTProperty); }
		}

	}

	public partial class ppy_state : DbObject
	{
		static ppy_state() {
			TableNameProperty.AddOwner(typeof(ppy_state),"ppy_state");
			KeysProperty.AddOwner(typeof(ppy_state),new string[]{"Id"});
		} 
		public static ExtendProperty ppy_stateIdProperty = ExtendProperty.RegisterProperty("Id", typeof(Int32), typeof(ppy_state),
			new DbMetaData() { FieldName = "Id", IsKey = true, IDentity = true});
		///<summary>
		///主键
		///</summary>
		public Int32 Id
		{
			set { this.SetValue(ppy_stateIdProperty, value); }
			get { return (Int32) this.GetValue(ppy_stateIdProperty); }
		}

		public static ExtendProperty ppy_stateStateTypeProperty = ExtendProperty.RegisterProperty("StateType", typeof(SByte), typeof(ppy_state),
			new DbMetaData() { FieldName = "StateType", IsKey = false, IDentity = false});
		///<summary>
		///行为唯一标识
		///</summary>
		public SByte Statetype
		{
			set { this.SetValue(ppy_stateStateTypeProperty, value); }
			get { return (SByte) this.GetValue(ppy_stateStateTypeProperty); }
		}

		public static ExtendProperty ppy_stateMeaningProperty = ExtendProperty.RegisterProperty("Meaning", typeof(String), typeof(ppy_state),
			new DbMetaData() { FieldName = "Meaning", IsKey = false, IDentity = false});
		///<summary>
		///行为说明
		///</summary>
		public String Meaning
		{
			set { this.SetValue(ppy_stateMeaningProperty, value); }
			get { return (String) this.GetValue(ppy_stateMeaningProperty); }
		}

		public static ExtendProperty ppy_stateNormalProperty = ExtendProperty.RegisterProperty("Normal", typeof(SByte), typeof(ppy_state),
			new DbMetaData() { FieldName = "Normal", IsKey = false, IDentity = false});
		///<summary>
		///行为描述
		///</summary>
		public SByte Normal
		{
			set { this.SetValue(ppy_stateNormalProperty, value); }
			get { return (SByte) this.GetValue(ppy_stateNormalProperty); }
		}

		public static ExtendProperty ppy_stateNotNormalProperty = ExtendProperty.RegisterProperty("NotNormal", typeof(SByte), typeof(ppy_state),
			new DbMetaData() { FieldName = "NotNormal", IsKey = false, IDentity = false});
		///<summary>
		///行为规则
		///</summary>
		public SByte Notnormal
		{
			set { this.SetValue(ppy_stateNotNormalProperty, value); }
			get { return (SByte) this.GetValue(ppy_stateNotNormalProperty); }
		}

	}

	public partial class ppy_sysconfig : DbObject
	{
		static ppy_sysconfig() {
			TableNameProperty.AddOwner(typeof(ppy_sysconfig),"ppy_sysconfig");
			KeysProperty.AddOwner(typeof(ppy_sysconfig),new string[]{"id"});
		} 
		public static ExtendProperty ppy_sysconfigidProperty = ExtendProperty.RegisterProperty("id", typeof(Int32), typeof(ppy_sysconfig),
			new DbMetaData() { FieldName = "id", IsKey = true, IDentity = true});
		///<summary>
		///主键
		///</summary>
		public Int32 Id
		{
			set { this.SetValue(ppy_sysconfigidProperty, value); }
			get { return (Int32) this.GetValue(ppy_sysconfigidProperty); }
		}

		public static ExtendProperty ppy_sysconfignameProperty = ExtendProperty.RegisterProperty("name", typeof(String), typeof(ppy_sysconfig),
			new DbMetaData() { FieldName = "name", IsKey = false, IDentity = false});
		///<summary>
		///行为唯一标识
		///</summary>
		public String Name
		{
			set { this.SetValue(ppy_sysconfignameProperty, value); }
			get { return (String) this.GetValue(ppy_sysconfignameProperty); }
		}

		public static ExtendProperty ppy_sysconfiginfoProperty = ExtendProperty.RegisterProperty("info", typeof(String), typeof(ppy_sysconfig),
			new DbMetaData() { FieldName = "info", IsKey = false, IDentity = false});
		///<summary>
		///行为说明
		///</summary>
		public String Info
		{
			set { this.SetValue(ppy_sysconfiginfoProperty, value); }
			get { return (String) this.GetValue(ppy_sysconfiginfoProperty); }
		}

		public static ExtendProperty ppy_sysconfigconfigvalueProperty = ExtendProperty.RegisterProperty("configvalue", typeof(Int32), typeof(ppy_sysconfig),
			new DbMetaData() { FieldName = "configvalue", IsKey = false, IDentity = false});
		///<summary>
		///行为描述
		///</summary>
		public Int32 Configvalue
		{
			set { this.SetValue(ppy_sysconfigconfigvalueProperty, value); }
			get { return (Int32) this.GetValue(ppy_sysconfigconfigvalueProperty); }
		}

		public static ExtendProperty ppy_sysconfigdisplayvalueProperty = ExtendProperty.RegisterProperty("displayvalue", typeof(Int32), typeof(ppy_sysconfig),
			new DbMetaData() { FieldName = "displayvalue", IsKey = false, IDentity = false});
		///<summary>
		///行为规则
		///</summary>
		public Int32 Displayvalue
		{
			set { this.SetValue(ppy_sysconfigdisplayvalueProperty, value); }
			get { return (Int32) this.GetValue(ppy_sysconfigdisplayvalueProperty); }
		}

		public static ExtendProperty ppy_sysconfigtypeProperty = ExtendProperty.RegisterProperty("type", typeof(SByte), typeof(ppy_sysconfig),
			new DbMetaData() { FieldName = "type", IsKey = false, IDentity = false});
		///<summary>
		///日志规则
		///</summary>
		public SByte Type
		{
			set { this.SetValue(ppy_sysconfigtypeProperty, value); }
			get { return (SByte) this.GetValue(ppy_sysconfigtypeProperty); }
		}

	}

	public partial class ppy_ucenter_admin : DbObject
	{
		static ppy_ucenter_admin() {
			TableNameProperty.AddOwner(typeof(ppy_ucenter_admin),"ppy_ucenter_admin");
			KeysProperty.AddOwner(typeof(ppy_ucenter_admin),new string[]{"id"});
		} 
		public static ExtendProperty ppy_ucenter_adminidProperty = ExtendProperty.RegisterProperty("id", typeof(UInt32), typeof(ppy_ucenter_admin),
			new DbMetaData() { FieldName = "id", IsKey = true, IDentity = false});
		///<summary>
		///主键
		///</summary>
		public UInt32 Id
		{
			set { this.SetValue(ppy_ucenter_adminidProperty, value); }
			get { return (UInt32) this.GetValue(ppy_ucenter_adminidProperty); }
		}

		public static ExtendProperty ppy_ucenter_adminmember_idProperty = ExtendProperty.RegisterProperty("member_id", typeof(UInt32), typeof(ppy_ucenter_admin),
			new DbMetaData() { FieldName = "member_id", IsKey = false, IDentity = false});
		///<summary>
		///行为唯一标识
		///</summary>
		public UInt32 Member_Id
		{
			set { this.SetValue(ppy_ucenter_adminmember_idProperty, value); }
			get { return (UInt32) this.GetValue(ppy_ucenter_adminmember_idProperty); }
		}

		public static ExtendProperty ppy_ucenter_adminstatusProperty = ExtendProperty.RegisterProperty("status", typeof(Byte), typeof(ppy_ucenter_admin),
			new DbMetaData() { FieldName = "status", IsKey = false, IDentity = false});
		///<summary>
		///行为说明
		///</summary>
		public Byte Status
		{
			set { this.SetValue(ppy_ucenter_adminstatusProperty, value); }
			get { return (Byte) this.GetValue(ppy_ucenter_adminstatusProperty); }
		}

	}

	public partial class ppy_ucenter_app : DbObject
	{
		static ppy_ucenter_app() {
			TableNameProperty.AddOwner(typeof(ppy_ucenter_app),"ppy_ucenter_app");
			KeysProperty.AddOwner(typeof(ppy_ucenter_app),new string[]{"id"});
		} 
		public static ExtendProperty ppy_ucenter_appidProperty = ExtendProperty.RegisterProperty("id", typeof(UInt32), typeof(ppy_ucenter_app),
			new DbMetaData() { FieldName = "id", IsKey = true, IDentity = false});
		///<summary>
		///主键
		///</summary>
		public UInt32 Id
		{
			set { this.SetValue(ppy_ucenter_appidProperty, value); }
			get { return (UInt32) this.GetValue(ppy_ucenter_appidProperty); }
		}

		public static ExtendProperty ppy_ucenter_apptitleProperty = ExtendProperty.RegisterProperty("title", typeof(String), typeof(ppy_ucenter_app),
			new DbMetaData() { FieldName = "title", IsKey = false, IDentity = false});
		///<summary>
		///行为唯一标识
		///</summary>
		public String Title
		{
			set { this.SetValue(ppy_ucenter_apptitleProperty, value); }
			get { return (String) this.GetValue(ppy_ucenter_apptitleProperty); }
		}

		public static ExtendProperty ppy_ucenter_appurlProperty = ExtendProperty.RegisterProperty("url", typeof(String), typeof(ppy_ucenter_app),
			new DbMetaData() { FieldName = "url", IsKey = false, IDentity = false});
		///<summary>
		///行为说明
		///</summary>
		public String Url
		{
			set { this.SetValue(ppy_ucenter_appurlProperty, value); }
			get { return (String) this.GetValue(ppy_ucenter_appurlProperty); }
		}

		public static ExtendProperty ppy_ucenter_appipProperty = ExtendProperty.RegisterProperty("ip", typeof(String), typeof(ppy_ucenter_app),
			new DbMetaData() { FieldName = "ip", IsKey = false, IDentity = false});
		///<summary>
		///行为描述
		///</summary>
		public String Ip
		{
			set { this.SetValue(ppy_ucenter_appipProperty, value); }
			get { return (String) this.GetValue(ppy_ucenter_appipProperty); }
		}

		public static ExtendProperty ppy_ucenter_appauth_keyProperty = ExtendProperty.RegisterProperty("auth_key", typeof(String), typeof(ppy_ucenter_app),
			new DbMetaData() { FieldName = "auth_key", IsKey = false, IDentity = false});
		///<summary>
		///行为规则
		///</summary>
		public String Auth_Key
		{
			set { this.SetValue(ppy_ucenter_appauth_keyProperty, value); }
			get { return (String) this.GetValue(ppy_ucenter_appauth_keyProperty); }
		}

		public static ExtendProperty ppy_ucenter_appsys_loginProperty = ExtendProperty.RegisterProperty("sys_login", typeof(Byte), typeof(ppy_ucenter_app),
			new DbMetaData() { FieldName = "sys_login", IsKey = false, IDentity = false});
		///<summary>
		///日志规则
		///</summary>
		public Byte Sys_Login
		{
			set { this.SetValue(ppy_ucenter_appsys_loginProperty, value); }
			get { return (Byte) this.GetValue(ppy_ucenter_appsys_loginProperty); }
		}

		public static ExtendProperty ppy_ucenter_appallow_ipProperty = ExtendProperty.RegisterProperty("allow_ip", typeof(String), typeof(ppy_ucenter_app),
			new DbMetaData() { FieldName = "allow_ip", IsKey = false, IDentity = false});
		///<summary>
		///类型
		///</summary>
		public String Allow_Ip
		{
			set { this.SetValue(ppy_ucenter_appallow_ipProperty, value); }
			get { return (String) this.GetValue(ppy_ucenter_appallow_ipProperty); }
		}

		public static ExtendProperty ppy_ucenter_appcreate_timeProperty = ExtendProperty.RegisterProperty("create_time", typeof(UInt32), typeof(ppy_ucenter_app),
			new DbMetaData() { FieldName = "create_time", IsKey = false, IDentity = false});
		///<summary>
		///状态
		///</summary>
		public UInt32 Create_Time
		{
			set { this.SetValue(ppy_ucenter_appcreate_timeProperty, value); }
			get { return (UInt32) this.GetValue(ppy_ucenter_appcreate_timeProperty); }
		}

		public static ExtendProperty ppy_ucenter_appupdate_timeProperty = ExtendProperty.RegisterProperty("update_time", typeof(UInt32), typeof(ppy_ucenter_app),
			new DbMetaData() { FieldName = "update_time", IsKey = false, IDentity = false});
		///<summary>
		///修改时间
		///</summary>
		public UInt32 Update_Time
		{
			set { this.SetValue(ppy_ucenter_appupdate_timeProperty, value); }
			get { return (UInt32) this.GetValue(ppy_ucenter_appupdate_timeProperty); }
		}

		public static ExtendProperty ppy_ucenter_appstatusProperty = ExtendProperty.RegisterProperty("status", typeof(SByte), typeof(ppy_ucenter_app),
			new DbMetaData() { FieldName = "status", IsKey = false, IDentity = false});
		///<summary>
		///主键
		///</summary>
		public SByte Status
		{
			set { this.SetValue(ppy_ucenter_appstatusProperty, value); }
			get { return (SByte) this.GetValue(ppy_ucenter_appstatusProperty); }
		}

	}

	public partial class ppy_ucenter_member : DbObject
	{
		static ppy_ucenter_member() {
			TableNameProperty.AddOwner(typeof(ppy_ucenter_member),"ppy_ucenter_member");
			KeysProperty.AddOwner(typeof(ppy_ucenter_member),new string[]{"id"});
		} 
		public static ExtendProperty ppy_ucenter_memberidProperty = ExtendProperty.RegisterProperty("id", typeof(UInt32), typeof(ppy_ucenter_member),
			new DbMetaData() { FieldName = "id", IsKey = true, IDentity = false});
		///<summary>
		///主键
		///</summary>
		public UInt32 Id
		{
			set { this.SetValue(ppy_ucenter_memberidProperty, value); }
			get { return (UInt32) this.GetValue(ppy_ucenter_memberidProperty); }
		}

		public static ExtendProperty ppy_ucenter_memberusernameProperty = ExtendProperty.RegisterProperty("username", typeof(String), typeof(ppy_ucenter_member),
			new DbMetaData() { FieldName = "username", IsKey = false, IDentity = false});
		///<summary>
		///行为唯一标识
		///</summary>
		public String Username
		{
			set { this.SetValue(ppy_ucenter_memberusernameProperty, value); }
			get { return (String) this.GetValue(ppy_ucenter_memberusernameProperty); }
		}

		public static ExtendProperty ppy_ucenter_memberpasswordProperty = ExtendProperty.RegisterProperty("password", typeof(String), typeof(ppy_ucenter_member),
			new DbMetaData() { FieldName = "password", IsKey = false, IDentity = false});
		///<summary>
		///行为说明
		///</summary>
		public String Password
		{
			set { this.SetValue(ppy_ucenter_memberpasswordProperty, value); }
			get { return (String) this.GetValue(ppy_ucenter_memberpasswordProperty); }
		}

		public static ExtendProperty ppy_ucenter_memberemailProperty = ExtendProperty.RegisterProperty("email", typeof(String), typeof(ppy_ucenter_member),
			new DbMetaData() { FieldName = "email", IsKey = false, IDentity = false});
		///<summary>
		///行为描述
		///</summary>
		public String Email
		{
			set { this.SetValue(ppy_ucenter_memberemailProperty, value); }
			get { return (String) this.GetValue(ppy_ucenter_memberemailProperty); }
		}

		public static ExtendProperty ppy_ucenter_membermobileProperty = ExtendProperty.RegisterProperty("mobile", typeof(String), typeof(ppy_ucenter_member),
			new DbMetaData() { FieldName = "mobile", IsKey = false, IDentity = false});
		///<summary>
		///行为规则
		///</summary>
		public String Mobile
		{
			set { this.SetValue(ppy_ucenter_membermobileProperty, value); }
			get { return (String) this.GetValue(ppy_ucenter_membermobileProperty); }
		}

		public static ExtendProperty ppy_ucenter_memberreg_timeProperty = ExtendProperty.RegisterProperty("reg_time", typeof(Nullable<UInt32>), typeof(ppy_ucenter_member),
			new DbMetaData() { FieldName = "reg_time", IsKey = false, IDentity = false});
		///<summary>
		///日志规则
		///</summary>
		public Nullable<UInt32> Reg_Time
		{
			set { this.SetValue(ppy_ucenter_memberreg_timeProperty, value); }
			get { return (Nullable<UInt32>) this.GetValue(ppy_ucenter_memberreg_timeProperty); }
		}

		public static ExtendProperty ppy_ucenter_memberreg_ipProperty = ExtendProperty.RegisterProperty("reg_ip", typeof(Nullable<Int64>), typeof(ppy_ucenter_member),
			new DbMetaData() { FieldName = "reg_ip", IsKey = false, IDentity = false});
		///<summary>
		///类型
		///</summary>
		public Nullable<Int64> Reg_Ip
		{
			set { this.SetValue(ppy_ucenter_memberreg_ipProperty, value); }
			get { return (Nullable<Int64>) this.GetValue(ppy_ucenter_memberreg_ipProperty); }
		}

		public static ExtendProperty ppy_ucenter_memberlast_login_timeProperty = ExtendProperty.RegisterProperty("last_login_time", typeof(Nullable<UInt32>), typeof(ppy_ucenter_member),
			new DbMetaData() { FieldName = "last_login_time", IsKey = false, IDentity = false});
		///<summary>
		///状态
		///</summary>
		public Nullable<UInt32> Last_Login_Time
		{
			set { this.SetValue(ppy_ucenter_memberlast_login_timeProperty, value); }
			get { return (Nullable<UInt32>) this.GetValue(ppy_ucenter_memberlast_login_timeProperty); }
		}

		public static ExtendProperty ppy_ucenter_memberlast_login_ipProperty = ExtendProperty.RegisterProperty("last_login_ip", typeof(Nullable<Int64>), typeof(ppy_ucenter_member),
			new DbMetaData() { FieldName = "last_login_ip", IsKey = false, IDentity = false});
		///<summary>
		///修改时间
		///</summary>
		public Nullable<Int64> Last_Login_Ip
		{
			set { this.SetValue(ppy_ucenter_memberlast_login_ipProperty, value); }
			get { return (Nullable<Int64>) this.GetValue(ppy_ucenter_memberlast_login_ipProperty); }
		}

		public static ExtendProperty ppy_ucenter_memberupdate_timeProperty = ExtendProperty.RegisterProperty("update_time", typeof(Nullable<UInt32>), typeof(ppy_ucenter_member),
			new DbMetaData() { FieldName = "update_time", IsKey = false, IDentity = false});
		///<summary>
		///主键
		///</summary>
		public Nullable<UInt32> Update_Time
		{
			set { this.SetValue(ppy_ucenter_memberupdate_timeProperty, value); }
			get { return (Nullable<UInt32>) this.GetValue(ppy_ucenter_memberupdate_timeProperty); }
		}

		public static ExtendProperty ppy_ucenter_memberstatusProperty = ExtendProperty.RegisterProperty("status", typeof(Nullable<SByte>), typeof(ppy_ucenter_member),
			new DbMetaData() { FieldName = "status", IsKey = false, IDentity = false});
		///<summary>
		///行为id
		///</summary>
		public Nullable<SByte> Status
		{
			set { this.SetValue(ppy_ucenter_memberstatusProperty, value); }
			get { return (Nullable<SByte>) this.GetValue(ppy_ucenter_memberstatusProperty); }
		}

		public static ExtendProperty ppy_ucenter_membermobile2Property = ExtendProperty.RegisterProperty("mobile2", typeof(String), typeof(ppy_ucenter_member),
			new DbMetaData() { FieldName = "mobile2", IsKey = false, IDentity = false});
		///<summary>
		///执行用户id
		///</summary>
		public String Mobile2
		{
			set { this.SetValue(ppy_ucenter_membermobile2Property, value); }
			get { return (String) this.GetValue(ppy_ucenter_membermobile2Property); }
		}

		public static ExtendProperty ppy_ucenter_memberclientidProperty = ExtendProperty.RegisterProperty("clientid", typeof(String), typeof(ppy_ucenter_member),
			new DbMetaData() { FieldName = "clientid", IsKey = false, IDentity = false});
		///<summary>
		///执行行为者ip
		///</summary>
		public String Clientid
		{
			set { this.SetValue(ppy_ucenter_memberclientidProperty, value); }
			get { return (String) this.GetValue(ppy_ucenter_memberclientidProperty); }
		}

		public static ExtendProperty ppy_ucenter_memberdevicetokenProperty = ExtendProperty.RegisterProperty("devicetoken", typeof(String), typeof(ppy_ucenter_member),
			new DbMetaData() { FieldName = "devicetoken", IsKey = false, IDentity = false});
		///<summary>
		///触发行为的表
		///</summary>
		public String Devicetoken
		{
			set { this.SetValue(ppy_ucenter_memberdevicetokenProperty, value); }
			get { return (String) this.GetValue(ppy_ucenter_memberdevicetokenProperty); }
		}

		public static ExtendProperty ppy_ucenter_membersystypeProperty = ExtendProperty.RegisterProperty("systype", typeof(Nullable<SByte>), typeof(ppy_ucenter_member),
			new DbMetaData() { FieldName = "systype", IsKey = false, IDentity = false});
		///<summary>
		///触发行为的数据id
		///</summary>
		public Nullable<SByte> Systype
		{
			set { this.SetValue(ppy_ucenter_membersystypeProperty, value); }
			get { return (Nullable<SByte>) this.GetValue(ppy_ucenter_membersystypeProperty); }
		}

		public static ExtendProperty ppy_ucenter_memberisshowProperty = ExtendProperty.RegisterProperty("isshow", typeof(Nullable<SByte>), typeof(ppy_ucenter_member),
			new DbMetaData() { FieldName = "isshow", IsKey = false, IDentity = false});
		///<summary>
		///日志备注
		///</summary>
		public Nullable<SByte> Isshow
		{
			set { this.SetValue(ppy_ucenter_memberisshowProperty, value); }
			get { return (Nullable<SByte>) this.GetValue(ppy_ucenter_memberisshowProperty); }
		}

		public static ExtendProperty ppy_ucenter_membersortProperty = ExtendProperty.RegisterProperty("sort", typeof(Nullable<Int32>), typeof(ppy_ucenter_member),
			new DbMetaData() { FieldName = "sort", IsKey = false, IDentity = false});
		///<summary>
		///状态
		///</summary>
		public Nullable<Int32> Sort
		{
			set { this.SetValue(ppy_ucenter_membersortProperty, value); }
			get { return (Nullable<Int32>) this.GetValue(ppy_ucenter_membersortProperty); }
		}

	}

	public partial class ppy_ucenter_setting : DbObject
	{
		static ppy_ucenter_setting() {
			TableNameProperty.AddOwner(typeof(ppy_ucenter_setting),"ppy_ucenter_setting");
			KeysProperty.AddOwner(typeof(ppy_ucenter_setting),new string[]{"id"});
		} 
		public static ExtendProperty ppy_ucenter_settingidProperty = ExtendProperty.RegisterProperty("id", typeof(UInt32), typeof(ppy_ucenter_setting),
			new DbMetaData() { FieldName = "id", IsKey = true, IDentity = false});
		///<summary>
		///主键
		///</summary>
		public UInt32 Id
		{
			set { this.SetValue(ppy_ucenter_settingidProperty, value); }
			get { return (UInt32) this.GetValue(ppy_ucenter_settingidProperty); }
		}

		public static ExtendProperty ppy_ucenter_settingtypeProperty = ExtendProperty.RegisterProperty("type", typeof(Byte), typeof(ppy_ucenter_setting),
			new DbMetaData() { FieldName = "type", IsKey = false, IDentity = false});
		///<summary>
		///行为唯一标识
		///</summary>
		public Byte Type
		{
			set { this.SetValue(ppy_ucenter_settingtypeProperty, value); }
			get { return (Byte) this.GetValue(ppy_ucenter_settingtypeProperty); }
		}

		public static ExtendProperty ppy_ucenter_settingvalueProperty = ExtendProperty.RegisterProperty("value", typeof(String), typeof(ppy_ucenter_setting),
			new DbMetaData() { FieldName = "value", IsKey = false, IDentity = false});
		///<summary>
		///行为说明
		///</summary>
		public String Value
		{
			set { this.SetValue(ppy_ucenter_settingvalueProperty, value); }
			get { return (String) this.GetValue(ppy_ucenter_settingvalueProperty); }
		}

	}

	public partial class ppy_url : DbObject
	{
		static ppy_url() {
			TableNameProperty.AddOwner(typeof(ppy_url),"ppy_url");
			KeysProperty.AddOwner(typeof(ppy_url),new string[]{"id"});
		} 
		public static ExtendProperty ppy_urlidProperty = ExtendProperty.RegisterProperty("id", typeof(UInt32), typeof(ppy_url),
			new DbMetaData() { FieldName = "id", IsKey = true, IDentity = false});
		///<summary>
		///主键
		///</summary>
		public UInt32 Id
		{
			set { this.SetValue(ppy_urlidProperty, value); }
			get { return (UInt32) this.GetValue(ppy_urlidProperty); }
		}

		public static ExtendProperty ppy_urlurlProperty = ExtendProperty.RegisterProperty("url", typeof(String), typeof(ppy_url),
			new DbMetaData() { FieldName = "url", IsKey = false, IDentity = false});
		///<summary>
		///行为唯一标识
		///</summary>
		public String Url
		{
			set { this.SetValue(ppy_urlurlProperty, value); }
			get { return (String) this.GetValue(ppy_urlurlProperty); }
		}

		public static ExtendProperty ppy_urlshortProperty = ExtendProperty.RegisterProperty("short", typeof(String), typeof(ppy_url),
			new DbMetaData() { FieldName = "short", IsKey = false, IDentity = false});
		///<summary>
		///行为说明
		///</summary>
		public String Short
		{
			set { this.SetValue(ppy_urlshortProperty, value); }
			get { return (String) this.GetValue(ppy_urlshortProperty); }
		}

		public static ExtendProperty ppy_urlstatusProperty = ExtendProperty.RegisterProperty("status", typeof(SByte), typeof(ppy_url),
			new DbMetaData() { FieldName = "status", IsKey = false, IDentity = false});
		///<summary>
		///行为描述
		///</summary>
		public SByte Status
		{
			set { this.SetValue(ppy_urlstatusProperty, value); }
			get { return (SByte) this.GetValue(ppy_urlstatusProperty); }
		}

		public static ExtendProperty ppy_urlcreate_timeProperty = ExtendProperty.RegisterProperty("create_time", typeof(UInt32), typeof(ppy_url),
			new DbMetaData() { FieldName = "create_time", IsKey = false, IDentity = false});
		///<summary>
		///行为规则
		///</summary>
		public UInt32 Create_Time
		{
			set { this.SetValue(ppy_urlcreate_timeProperty, value); }
			get { return (UInt32) this.GetValue(ppy_urlcreate_timeProperty); }
		}

	}

	public partial class ppy_video : DbObject
	{
		static ppy_video() {
			TableNameProperty.AddOwner(typeof(ppy_video),"ppy_video");
			KeysProperty.AddOwner(typeof(ppy_video),new string[]{"Id"});
		} 
		public static ExtendProperty ppy_videoIdProperty = ExtendProperty.RegisterProperty("Id", typeof(Int32), typeof(ppy_video),
			new DbMetaData() { FieldName = "Id", IsKey = true, IDentity = true});
		///<summary>
		///主键
		///</summary>
		public Int32 Id
		{
			set { this.SetValue(ppy_videoIdProperty, value); }
			get { return (Int32) this.GetValue(ppy_videoIdProperty); }
		}

		public static ExtendProperty ppy_videoOrderIdProperty = ExtendProperty.RegisterProperty("OrderId", typeof(Int32), typeof(ppy_video),
			new DbMetaData() { FieldName = "OrderId", IsKey = false, IDentity = false});
		///<summary>
		///行为唯一标识
		///</summary>
		public Int32 Orderid
		{
			set { this.SetValue(ppy_videoOrderIdProperty, value); }
			get { return (Int32) this.GetValue(ppy_videoOrderIdProperty); }
		}

		public static ExtendProperty ppy_videoUrlProperty = ExtendProperty.RegisterProperty("Url", typeof(String), typeof(ppy_video),
			new DbMetaData() { FieldName = "Url", IsKey = false, IDentity = false});
		///<summary>
		///行为说明
		///</summary>
		public String Url
		{
			set { this.SetValue(ppy_videoUrlProperty, value); }
			get { return (String) this.GetValue(ppy_videoUrlProperty); }
		}

		public static ExtendProperty ppy_videoUploadTimeProperty = ExtendProperty.RegisterProperty("UploadTime", typeof(Int32), typeof(ppy_video),
			new DbMetaData() { FieldName = "UploadTime", IsKey = false, IDentity = false});
		///<summary>
		///行为描述
		///</summary>
		public Int32 Uploadtime
		{
			set { this.SetValue(ppy_videoUploadTimeProperty, value); }
			get { return (Int32) this.GetValue(ppy_videoUploadTimeProperty); }
		}

		public static ExtendProperty ppy_videoStateProperty = ExtendProperty.RegisterProperty("State", typeof(SByte), typeof(ppy_video),
			new DbMetaData() { FieldName = "State", IsKey = false, IDentity = false});
		///<summary>
		///行为规则
		///</summary>
		public SByte State
		{
			set { this.SetValue(ppy_videoStateProperty, value); }
			get { return (SByte) this.GetValue(ppy_videoStateProperty); }
		}

	}

}
