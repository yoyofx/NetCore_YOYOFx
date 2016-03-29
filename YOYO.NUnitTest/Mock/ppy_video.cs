using System;
using MaxZhang.EasyEntities.Persistence.Mapping;
using ExtendPropertyLib;
using System.Data;

namespace YOYO.NUnitTest
{
	public partial class ppy_video: DbObject 
	{
		static ppy_video ()
		{
			TableNameProperty.AddOwner(typeof(ppy_video), "ppy_video");
			KeysProperty.AddOwner(typeof(ppy_video),new string[]{"Id"});
		}

		public static ExtendProperty ppy_videoIdProperty = ExtendProperty.RegisterProperty("Id", typeof(int), typeof(ppy_video),
			new DbMetaData() { FieldName = "Id", IsKey = true, IDentity = false });
              
		public int Id
		{
			set
			{
				this.SetValue(ppy_videoIdProperty, value);
			}
			get
			{
				return (int)this.GetValue(ppy_videoIdProperty);
			}
		}             

		public static ExtendProperty ppy_videoOrderIdProperty = ExtendProperty.RegisterProperty("OrderId", typeof(int), typeof(ppy_video),
			new DbMetaData() { FieldName = "OrderId", IsKey = false, IDentity = false });

		public int OrderId
		{
			set
			{
				this.SetValue(ppy_videoOrderIdProperty, value);
			}
			get
			{
				return (int)this.GetValue(ppy_videoOrderIdProperty);
			}
		}

		public static ExtendProperty ppy_videoUrlProperty = ExtendProperty.RegisterProperty("Url", typeof(string), typeof(ppy_video),
			new DbMetaData() { FieldName = "Url", IsKey = false, IDentity = false });

		public String Url
		{
			set
			{
				this.SetValue(ppy_videoUrlProperty, value);
			}
			get
			{
				return (String)this.GetValue(ppy_videoUrlProperty);
			}
		}



		public static ExtendProperty ppy_videoUploadTimeProperty = ExtendProperty.RegisterProperty("UploadTime", typeof(int), typeof(ppy_video),
			new DbMetaData() { FieldName = "UploadTime", IsKey = false, IDentity = false });

		public int UploadTime
		{
			set
			{
				this.SetValue(ppy_videoUploadTimeProperty, value);
			}
			get
			{
				return (int)this.GetValue(ppy_videoUploadTimeProperty);
			}
		}


		public static ExtendProperty ppy_videoStateProperty = ExtendProperty.RegisterProperty("State", typeof(int), typeof(ppy_video),
			new DbMetaData() { FieldName = "State", IsKey = false, IDentity = false });

		public int State
		{
			set
			{
				this.SetValue(ppy_videoStateProperty, value);
			}
			get
			{
				return (int)this.GetValue(ppy_videoStateProperty);
			}
		}


		public override string ToString ()
		{
			return string.Format ("[ppy_video: Id={0}, OrderId={1}, Url={2}, UploadTime={3}, State={4}]", Id, OrderId, Url, UploadTime, State);
		}

	}






}

