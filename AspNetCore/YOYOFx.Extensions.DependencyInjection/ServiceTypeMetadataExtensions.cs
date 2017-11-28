using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using YOYOFx.Extensions.DependencyInjection.Attributes;

namespace YOYOFx.Extensions.DependencyInjection
{
    internal static class ServiceTypeMetadataExtensions
    {
        private static ConcurrentDictionary<int, ServiceTypeMetadata> serviceTypesMetadataList =
                                               new ConcurrentDictionary<int, ServiceTypeMetadata>();


        public static void AddMetadata(Type serviceType,string name = null)
        {

            var smd = GetDefaultServiceTypeMetadata(serviceType);
            if (!string.IsNullOrEmpty(name)) smd.Name = name;

            AddMetadata(serviceType, smd);
        }


        public static void AddMetadata(Type serviceType, ServiceTypeMetadata metadata)
        {
            var serviceKey = serviceType.GetServiceTypeKey();
            if (!serviceTypesMetadataList.ContainsKey(serviceKey))
            {
                if(metadata != null)
                {
                    serviceTypesMetadataList.TryAdd(serviceKey, metadata);
                }
                else
                {
                    serviceTypesMetadataList.TryAdd(serviceKey,
                           GetDefaultServiceTypeMetadata(serviceType));
                }
            }
        }

        public static void AddMetadata(Type serviceType,int serviceKey,string name)
        {
            var smd = GetDefaultServiceTypeMetadata(serviceType);
            if (!string.IsNullOrEmpty(name)) smd.Name = name;
            AddMetadata(serviceKey, smd);
        }

        public static void AddMetadata(int serviceKey , ServiceTypeMetadata metadata)
        {
            if (!serviceTypesMetadataList.ContainsKey(serviceKey))
            {
                if (metadata != null)
                {
                    serviceTypesMetadataList.TryAdd(serviceKey, metadata);
                }
            }
        }

        public static int GetServiceTypeKey(this Type serviceType)
        {
            return serviceType.GetHashCode();
        }





        public static ServiceTypeMetadata GetDefaultServiceTypeMetadata(this Type serviceType)
        {
            return new ServiceTypeMetadata() { Name = serviceType.Name , NameSpace = serviceType.Namespace, ServiceType = serviceType };
        }

        public static ServiceTypeMetadata GetServiceTypeMetadata(Type serviceType,int serviceKey)
        {
            int key = serviceKey;
            if (key == 0)
                key= serviceType.GetHashCode();

            ServiceTypeMetadata metadata = null;
            if(!serviceTypesMetadataList.TryGetValue(key, out metadata))
            {
                metadata = GetDefaultServiceTypeMetadata(serviceType);
            }

            return metadata;
        }




        public static MethodInfo getMetadataServiceDescriptorMethodInfo = typeof(ServiceTypeMetadataExtensions).GetMethod("GetMetadataServiceDescriptor", BindingFlags.NonPublic | BindingFlags.Static);


        private static ServiceDescriptor GetMetadataServiceDescriptor<T>(Type ImplementationType, object instance)
        {
            int serviceKey = instance != null ? instance.GetHashCode() : 0;

            return ServiceDescriptor.Transient(typeof(Lazy<T, ServiceTypeMetadata>),
               provider =>
               new Lazy<T, ServiceTypeMetadata>(
                   () =>
                   (T) (instance??provider.GetRequiredService(ImplementationType)),
                   GetServiceTypeMetadata(ImplementationType, serviceKey)
               ));

        }


    }
}
