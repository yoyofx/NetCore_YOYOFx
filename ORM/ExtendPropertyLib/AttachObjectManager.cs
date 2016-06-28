using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExtendPropertyLib
{
    public sealed class AttachObjectManager
    {
        private Dictionary<int, AttachObject> attachObjects = new Dictionary<int, AttachObject>();

        public AttachObject AddObject(object obj)
        {
            AttachObject attachObj = new AttachObject(obj);
            int key = attachObj.GetHashCode();
            this.attachObjects.Add(key, attachObj);
            return attachObj;
        }

        public AttachObject GetObject(object obj)
        {
            AttachObject attach = null;

            if (obj != null)
                this.attachObjects.TryGetValue(obj.GetHashCode(), out attach);

            return attach;
        }


        public Predicate<int> ClearFunction;

        public void Clear()
        {
            var unloads = (from v in this.attachObjects.Values
                          select v.GetHashCode()).ToArray();

            foreach (var v in unloads)
            {
                if (this.ClearFunction != null && this.ClearFunction(v.GetHashCode()))
                    this.attachObjects.Remove(v.GetHashCode());
            }
        }

    }
}
