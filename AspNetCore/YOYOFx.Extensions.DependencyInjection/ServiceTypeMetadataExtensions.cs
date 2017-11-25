using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using YOYOFx.Extensions.DependencyInjection.Attributes;

namespace YOYOFx.Extensions.DependencyInjection
{
    internal class ServiceTypeMetadataExtensions
    {
        private static ConcurrentDictionary<Type, ServiceTypeMetadata> serviceTypesMetadataList =
                                               new ConcurrentDictionary<Type, ServiceTypeMetadata>();



        public static void AddMetadata(Type serviceType,string name = null)
        {
            if (!serviceTypesMetadataList.ContainsKey(serviceType))
            {
                var smd = GetDefaultServiceTypeMetadata(serviceType);

                if (!string.IsNullOrEmpty(name)) smd.Name = name;

                serviceTypesMetadataList.TryAdd(serviceType,smd);

            }
        }


        public static void AddMetadata(Type serviceType, ServiceTypeMetadata metadata)
        {
            if (!serviceTypesMetadataList.ContainsKey(serviceType))
            {
                if(metadata != null)
                {
                    serviceTypesMetadataList.TryAdd(serviceType, metadata);
                }
                else
                {
                    serviceTypesMetadataList.TryAdd(serviceType,
                           GetDefaultServiceTypeMetadata(serviceType));
                }
            }


        }


        public static ServiceTypeMetadata GetDefaultServiceTypeMetadata(Type serviceType)
        {
            return new ServiceTypeMetadata() { Name = serviceType.Name , NameSpace = serviceType.Namespace, ServiceType = serviceType };
        }

        public static ServiceTypeMetadata GetServiceTypeMetadata(Type serviceType)
        {
            ServiceTypeMetadata metadata = null;
            if(!serviceTypesMetadataList.TryGetValue(serviceType, out metadata))
            {
                metadata = GetDefaultServiceTypeMetadata(serviceType);
            }

            return metadata;
        }



    }
}
