using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using ExtendPropertyLib;

namespace MaxZhang.EasyEntities.Persistence.Mapping
{
    /// <summary>
    /// 数据库元数据，表示数据库中表字段的各种属性。
    /// </summary>
    public class DbMetaData : MetaData
    {

        public DbMetaData(bool isKey = false, bool isNull = false, bool isGentrne = false, string fieldName = null, DbType type = DbType.Object)
        {
            this.IsKey = isKey;
            this.IsNull = isNull;
            this.IDentity = isGentrne;
            this.FieldName = fieldName;
            this.Type = type;
        }
        /// <summary>
        /// 主键
        /// </summary>
        public bool IsKey { set; get; }
        /// <summary>
        /// 是否为空
        /// </summary>
        public bool IsNull { set; get; }
        /// <summary>
        /// 是否是自增列
        /// </summary>
        public bool IDentity { set; get; }
        /// <summary>
        /// 字段名
        /// </summary>
        public string FieldName { set; get; }
        /// <summary>
        /// 模型与数据库中对应的属性类型
        /// </summary>
        public DbType Type { set; get; }
        /// <summary>
        /// 数据库中的字段类型
        /// </summary>
        public string ColumnType { set; get; }
        /// <summary>
        /// 字段长度
        /// </summary>
        public uint ColumnLength { set; get; }
        /// <summary>
        /// 字段精度
        /// </summary>
        public uint ColumnPrecision { set; get; }
        /// <summary>
        /// 字段小数位数
        /// </summary>
        public uint ColumnScale { set; get; }
        /// <summary>
        /// 字段默认值
        /// </summary>
        public string DefaultValue { set; get; }

        /// <summary>
        /// 可移除字段，表示模型对象在数据库中或变为移除状态
        /// </summary>
        public bool RemoveAble { set; get; }

    }
}
