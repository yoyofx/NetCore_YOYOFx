using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Dynamic;

namespace ExtendPropertyLib
{
    /// <summary>
    /// 动态扩展对象
    /// </summary>
    public class ExtendDynamicObject : DynamicObject
    {
        private ExtendObject extendObject;

        public ExtendDynamicObject(ExtendObject exObject)
        {
            extendObject = exObject;
        }
        /// <summary>
        /// 设置成员访问器
        /// </summary>
        /// <param name="binder"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            string propertyName = binder.Name;

            if (this.extendObject.IsExtendProperty(propertyName))
                this.extendObject.SetValue(binder.Name, value);
            else
            {
                object owner = this.extendObject.GetOwner();
                Type ownerType = owner.GetType();
                var propertyInfo = ownerType.GetProperty(propertyName);
                propertyInfo.SetValue(owner, value, null);
            }
            return true;
        }
        /// <summary>
        /// 获取成员访问器
        /// </summary>
        /// <param name="binder"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            result = null;

            string propertyName = binder.Name;

            if (this.extendObject.IsExtendProperty(propertyName))
                result = this.extendObject.GetValue(binder.Name);
            else
            {
                object owner = this.extendObject.GetOwner();
                Type ownerType = owner.GetType();
                var propertyInfo = ownerType.GetProperty(propertyName);
                propertyInfo.GetValue(owner, null);
            }
            return true;
        }

    }

}
