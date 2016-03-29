using System;
using System.ComponentModel;

namespace MaxZhang.EasyEntities.Persistence.Mapping
{
    /// <summary>
    /// 属性元数据比较器
    /// </summary>
    public class MetaMember 
    {
        private object oldValue;
        private object newValue;

        public object OldValue
        {
            get { return oldValue; }
            set { oldValue = value; }
        }

        public object NewValue
        {
            get { return newValue; }
            set { newValue = value; }
        }

        public bool IsChanged
        {

            get { 
                //TypeConverter.
            
                return oldValue != null && !oldValue.Equals(newValue); 
            }
        }

     

    }
}