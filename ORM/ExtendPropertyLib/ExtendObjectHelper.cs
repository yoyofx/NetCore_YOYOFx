using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExtendPropertyLib
{
    /// <summary>
    /// 扩展对象扩展函数
    /// </summary>
    public static class ObjectExtend
    {
        /// <summary>
        /// 注册扩展属性
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        public static ExtendProperty RegisterProperty(this object obj, string propertyName)
        {
            return ExtendProperty.RegisterProperty(propertyName, typeof(object), obj.GetType());
        }
        /// <summary>
        /// 将普通对象转换成扩展对象
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static AttachObject ToAttachObject(this object obj)
        {
            return new AttachObject(obj);
        }
        /// <summary>
        /// 将普通对象转换成动态的扩展对象
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static dynamic ToDynamicAttachObject(this object obj)
        {
            return new AttachObject(obj).AsDynamic();
        }

      


    }
}
