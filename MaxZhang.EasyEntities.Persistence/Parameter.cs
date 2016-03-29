using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace MaxZhang.EasyEntities.Persistence
{
    /// <summary>
    /// Command对象中的SQL语句参数，
    /// </summary>
    public class Parameter
    {
        public string Name { get; set; }
        public object Value { get; set; }
        public DbType Type { set; get; }
        public ParameterDirection Direction { set; get; }
        /// <summary>
        /// 是指它是一个函数参数还是值参数
        /// </summary>
        public bool IsMethodType { set; get; }
        public Parameter() { }

        public Parameter(string name, object value)
        {
            IsMethodType = false;
            Name = name;
            if(value != null)
                Value = value;
        }

        public Parameter(string name, object value , DbType type):this(name,value)
        {
            Type = type;
        }

        public Parameter(string name, object value ,ParameterDirection direction ):this(name,value)
        {
            Direction = direction;
        }

        public override string ToString()
        {
            return String.Format("  {0}={1}", Name, Value);
        }
    }
}