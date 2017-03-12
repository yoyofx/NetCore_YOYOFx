using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace YOYO.AspNetCore.Mvc.Extensions
{
    public static class TypeExtensions
    {
        public static object GetTypeDefaultValue(this Type type)
        {
            if (type.GetTypeInfo().IsValueType)
                return Activator.CreateInstance(type);

            return null;

        }
    }
}
