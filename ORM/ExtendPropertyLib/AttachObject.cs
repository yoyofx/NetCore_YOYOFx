using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Collections.Concurrent;
namespace ExtendPropertyLib
{
    /// <summary>
    /// 普通对象的装饰者使之成为一个扩展对象
    /// </summary>
    public class AttachObject : ExtendObject
    {
        private object owner;

        public AttachObject(object obj)
            : base()
        {
            owner = obj;
            if (owner is ExtendObject)
            {
                Type ownerType = typeof(ExtendObject);
                FieldInfo fInfo = ownerType.GetField("propertyValues", BindingFlags.Default | BindingFlags.NonPublic | BindingFlags.Instance);
                var ownerValues = fInfo.GetValue(owner) as ConcurrentDictionary<int, object>;

                foreach (var v in ownerValues)
                    this.propertyValues.TryAdd(v.Key, v.Value);

            }
            this.AttachOwner(owner.GetType());
        }

        public override object GetOwner()
        {
            return owner;
        }

        public override int GetHashCode()
        {
            return owner.GetHashCode();
        }



        public new void  Dispose()
        {
            this.owner = null;
 	         base.Dispose();
        }

    }
}
