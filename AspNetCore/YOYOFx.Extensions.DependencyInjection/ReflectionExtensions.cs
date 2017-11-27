using System;
using System.Collections.Generic;
using System.FastReflection;
using System.Linq;
using System.Reflection;
using YOYOFx.Extensions.DependencyInjection.Registration;

namespace YOYOFx.Extensions.DependencyInjection
{
    internal static class ReflectionExtensions
    {
        public static bool IsNonAbstractClass(this Type type, bool publicOnly)
        {
            var typeInfo = type.GetTypeInfo();

            if (typeInfo.IsClass && !typeInfo.IsAbstract)
            {
                if (typeInfo.IsGenericType && typeInfo.ContainsGenericParameters)
                {
                    return false;
                }

                if (publicOnly)
                {
                    return typeInfo.IsPublic || typeInfo.IsNestedPublic;
                }

                return true;
            }

            return false;
        }

        public static bool IsInNamespace(this Type type, string @namespace)
        {
            var typeNamespace = type.Namespace ?? string.Empty;

            if (@namespace.Length > typeNamespace.Length)
            {
                return false;
            }

            var typeSubNamespace = typeNamespace.Substring(0, @namespace.Length);

            if (typeSubNamespace.Equals(@namespace, StringComparison.Ordinal))
            {
                if (typeNamespace.Length == @namespace.Length)
                {
                    //exactly the same
                    return true;
                }

                //is a subnamespace?
                return typeNamespace[@namespace.Length] == '.';
            }

            return false;
        }

        public static bool HasAttribute(this Type type, Type attributeType)
        {
            return type.GetTypeInfo().IsDefined(attributeType, inherit: true);
        }

        public static bool HasAttribute<T>(this Type type, Func<T, bool> predicate) where T : Attribute
        {
            return type.GetTypeInfo().GetCustomAttributes<T>(inherit: true).Any(predicate);
        }

        public static bool IsAssignableTo(this Type type, Type otherType)
        {
            var typeInfo = type.GetTypeInfo();
            var otherTypeInfo = otherType.GetTypeInfo();

            return otherTypeInfo.IsGenericTypeDefinition
                ? typeInfo.IsAssignableToGenericTypeDefinition(otherTypeInfo)
                : otherTypeInfo.IsAssignableFrom(typeInfo);
        }

        private static bool IsAssignableToGenericTypeDefinition(this TypeInfo typeInfo, TypeInfo genericTypeInfo)
        {
            var interfaceTypes = typeInfo.ImplementedInterfaces.Select(t => t.GetTypeInfo());

            foreach (var interfaceType in interfaceTypes)
            {
                if (interfaceType.IsGenericType)
                {
                    var typeDefinitionTypeInfo = interfaceType
                        .GetGenericTypeDefinition()
                        .GetTypeInfo();

                    if (typeDefinitionTypeInfo == genericTypeInfo)
                    {
                        return true;
                    }
                }
            }

            if (typeInfo.IsGenericType)
            {
                var typeDefinitionTypeInfo = typeInfo
                    .GetGenericTypeDefinition()
                    .GetTypeInfo();

                if (typeDefinitionTypeInfo == genericTypeInfo)
                {
                    return true;
                }
            }

            var baseTypeInfo = typeInfo.BaseType?.GetTypeInfo();

            if (baseTypeInfo == null)
            {
                return false;
            }

            return baseTypeInfo.IsAssignableToGenericTypeDefinition(genericTypeInfo);
        }

        /// <summary>
        /// Find matching interface by name C# interface name convention.  Optionally use a filter.
        /// </summary>
        /// <param name="typeInfo"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        public static IEnumerable<Type> FindMatchingInterface(this TypeInfo typeInfo, Action<TypeInfo, IImplementationTypeFilter> action)
        {
            var matchingInterfaceName = $"I{typeInfo.Name}";

            var matchedInterfaces = GetImplementedInterfacesToMap(typeInfo)
                .Where(x => string.Equals(x.Name, matchingInterfaceName, StringComparison.Ordinal))
                .ToArray();

            Type type;
            if (action != null)
            {
                var filter = new ImplementationTypeFilter(matchedInterfaces);

                action(typeInfo, filter);

                type = filter.Types.FirstOrDefault();
            }
            else
            {
                type = matchedInterfaces.FirstOrDefault();
            }

            if (type != null)
            {
                yield return type;
            }
        }

        private static IEnumerable<Type> GetImplementedInterfacesToMap(TypeInfo typeInfo)
        {
            if (!typeInfo.IsGenericType)
            {
                return typeInfo.ImplementedInterfaces;
            }

            if (!typeInfo.IsGenericTypeDefinition)
            {
                return typeInfo.ImplementedInterfaces;
            }

            return FilterMatchingGenericInterfaces(typeInfo);
        }

        private static IEnumerable<Type> FilterMatchingGenericInterfaces(TypeInfo typeInfo)
        {
            var genericTypeParameters = typeInfo.GenericTypeParameters;

            foreach (var current in typeInfo.ImplementedInterfaces)
            {
                var currentTypeInfo = current.GetTypeInfo();

                if (currentTypeInfo.IsGenericType && currentTypeInfo.ContainsGenericParameters
                    && GenericParametersMatch(genericTypeParameters, currentTypeInfo.GenericTypeArguments))
                {
                    yield return currentTypeInfo.GetGenericTypeDefinition();
                }
            }
        }

        private static bool GenericParametersMatch(IReadOnlyList<Type> parameters, IReadOnlyList<Type> interfaceArguments)
        {
            if (parameters.Count != interfaceArguments.Count)
            {
                return false;
            }

            for (var i = 0; i < parameters.Count; i++)
            {
                if (parameters[i] != interfaceArguments[i])
                {
                    return false;
                }
            }

            return true;
        }


        /// <summary>
        /// Get specified type attribute<br/>
        /// Return null if not found<br/>
        /// Will not search inherited attributes<br/>
        /// 获取指定类型的属性<br/>
        /// 不存在时返回null<br/>
        /// 不搜索继承的属性<br/>
        /// </summary>
        /// <typeparam name="TAttribute">Attribute type</typeparam>
        /// <param name="info">Member infomation</param>
        /// <returns></returns>
        /// <example>
        /// <code language="cs">
        /// var info = typeof(TestData).FastGetProperty("TestProperty");
        /// var attribute = info.GetAttribute&lt;DescriptionAttribute&gt;();
        /// </code>
        /// </example>
        public static TAttribute GetAttribute<TAttribute>(this MemberInfo info)
            where TAttribute : Attribute
        {
            return info.GetAttributes<TAttribute>().FirstOrDefault();
        }

        /// <summary>
        /// Get specified type attributes<br/>
        /// 获取指定类型的属性<br/>
        /// </summary>
        /// <typeparam name="TAttribute">Attribute type</typeparam>
        /// <param name="info">Member infomation</param>
        /// <returns></returns>
        /// <example>
        /// <code language="cs">
        /// var info = typeof(TestData).FastGetProperty("TestProperty");
        /// var attributes = info.GetAttributes&lt;Attribute&gt;();
        /// </code>
        /// </example>
        public static IEnumerable<TAttribute> GetAttributes<TAttribute>(this MemberInfo info)
            where TAttribute : Attribute
        {
            return info.FastGetCustomAttributes(typeof(TAttribute)).OfType<TAttribute>();
        }

        /// <summary>
        /// Get specified type attributes with inherit option<br/>
        /// 获取指定类型的属性, 可以指定是否搜索继承<br/>
        /// </summary>
        /// <typeparam name="TAttribute">Attribute type</typeparam>
        /// <param name="info">Member infomation</param>
        /// <param name="inherit">Should search override method or property's attributes</param>
        /// <returns></returns>
        /// <example>
        /// <code language="cs">
        /// var info = typeof(TestData).FastGetProperty("TestProperty");
        /// var attributes = info.GetAttributes&lt;Attribute&gt;(true);
        /// </code>
        /// </example>
        public static IEnumerable<TAttribute> GetAttributes<TAttribute>(this MemberInfo info, bool inherit)
            where TAttribute : Attribute
        {
            return info.FastGetCustomAttributes(typeof(TAttribute), inherit).OfType<TAttribute>();
        }
    }
}
