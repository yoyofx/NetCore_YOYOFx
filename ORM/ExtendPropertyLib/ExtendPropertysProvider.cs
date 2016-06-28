using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.Concurrent;

namespace ExtendPropertyLib
{
    public sealed class ExtendPropertys : ConcurrentDictionary<int, ExtendProperty> { }

    public class ExtendPropertysProvider
    {
        private static object lockProvider = new object();
        private static ExtendPropertys propertys = new ExtendPropertys();

        public static ExtendProperty Get(int key)
        {
            ExtendProperty property = null;
            lock (lockProvider)
            {
                propertys.TryGetValue(key, out property);
            }
            return property;
        }

        public static void Set(int key, ExtendProperty property)
        {
            if (propertys.Keys.Any(k => k == key))
                throw new NotSupportedException("不能为类型注册重复的属性!");
            lock (lockProvider)
            {
                propertys.TryAdd(key, property);
            }
        }

        public static ExtendProperty[] GetByType(Type ownerType)
        {
            return propertys.Values.Where(p => p.OwnerType == ownerType).ToArray();
        }

    }

    

}
