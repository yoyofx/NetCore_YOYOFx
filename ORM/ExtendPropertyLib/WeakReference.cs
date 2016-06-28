using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ExtendPropertyLib
{
    public class WeakReference<T> : WeakReference where T : class
    {
        public WeakReference() : base(null) { }
        public WeakReference(T target) : base(target) { }
        public WeakReference(T target, bool trackResurrection) : base(target, trackResurrection) { }
        public WeakReference(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public new T Target
        {
            get
            {
                return base.Target as T;
            }
            set
            {
                base.Target = value;
            }
        }

        public static implicit operator T(WeakReference<T> o)
        {

            if (o != null && o.Target != null)
                return o.Target;
            return null;
        }

        public static implicit operator WeakReference<T>(T target)
        {
            return new WeakReference<T>(target);
        }
    }
}
