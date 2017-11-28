using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using YOYOFx.Extensions.DependencyInjection.Attributes;
using System.FastReflection;

namespace YOYOFx.Extensions.DependencyInjection.Registration
{
    internal class AttributeSelector : ISelector
    {



        public AttributeSelector(IEnumerable<Type> types)
        {
            Types = types;
        }

        private IEnumerable<Type> Types { get; }

        void ISelector.Populate(IServiceCollection services)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            foreach (var type in Types)
            {
                var typeInfo = type.GetTypeInfo();

                var attributes = typeInfo.GetCustomAttributes<ServiceDescriptorAttribute>().ToArray();

                // Check if the type has multiple attributes with same ServiceType.
                var duplicates = attributes
                    .GroupBy(s => s.ServiceType)
                    .SelectMany(grp => grp.Skip(1));

                if (duplicates.Any())
                {
                    throw new InvalidOperationException($@"Type ""{type.FullName}"" has multiple ServiceDescriptor attributes with the same service type.");
                }

                foreach (var attribute in attributes)
                {
                    var serviceTypes = GetServiceTypes(type, attribute);

                    foreach (var serviceType in serviceTypes)
                    {
                        var descriptor = new ServiceDescriptor(serviceType, type, attribute.Lifetime);

                        services.Add(descriptor);

                        if (serviceType.IsInterface)
                        {
                            var extensionDescriptor = (ServiceDescriptor)ServiceTypeMetadataExtensions
                                                        .getMetadataServiceDescriptorMethodInfo
                                                        .MakeGenericMethod(descriptor.ServiceType)
                                                        .FastInvoke(null, new object[] { descriptor.ImplementationType,null });

                            services.Add(extensionDescriptor);

                            ServiceTypeMetadataExtensions.AddMetadata(descriptor.ImplementationType, attribute.Name);

                        }

                    }
                }
            }
        }




        private static IEnumerable<Type> GetServiceTypes(Type type, ServiceDescriptorAttribute attribute)
        {
            var typeInfo = type.GetTypeInfo();

            var serviceType = attribute.ServiceType;

            if (serviceType == null)
            {
                yield return type;

                foreach (var implementedInterface in typeInfo.ImplementedInterfaces)
                {
                    yield return implementedInterface;
                }

                if (typeInfo.BaseType != null && typeInfo.BaseType != typeof(object))
                {
                    yield return typeInfo.BaseType;
                }

                yield break;
            }

            var serviceTypeInfo = serviceType.GetTypeInfo();

            if (!serviceTypeInfo.IsAssignableFrom(typeInfo))
            {
                throw new InvalidOperationException($@"Type ""{typeInfo.FullName}"" is not assignable to ""${serviceTypeInfo.FullName}"".");
            }

            yield return serviceType;
            yield return type;

        }
    }
}
