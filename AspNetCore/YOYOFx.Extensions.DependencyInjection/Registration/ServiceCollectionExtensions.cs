using System;
using System.Collections.Generic;
using System.FastReflection;
using System.Linq;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace YOYOFx.Extensions.DependencyInjection.Registration
{
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Adds registrations to the <paramref name="services"/> collection using
        /// conventions specified using the <paramref name="action"/>.
        /// </summary>
        /// <param name="services">The services to add to.</param>
        /// <param name="action">The configuration action.</param>
        /// <exception cref="System.ArgumentNullException">If either the <paramref name="services"/>
        /// or <paramref name="action"/> arguments are <c>null</c>.</exception>
        public static IServiceCollection Scan(this IServiceCollection services, Action<IAssemblySelector> action)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            if (action == null)
            {
                throw new ArgumentNullException(nameof(action));
            }

            var selector = new Registration.AssemblySelector();

            action(selector);

            ((ISelector) selector).Populate(services);

            return services;
        }



        public static IServiceCollection RegisterInstance<TService>(this IServiceCollection services, object instance, string name)
        {
            var serviceType = typeof(TService);

            var descriptor = new ServiceDescriptor(typeof(TService), instance);

            services.Add(descriptor);


            var extensionDescriptor = (ServiceDescriptor)ServiceTypeMetadataExtensions
                                        .getMetadataServiceDescriptorMethodInfo
                                        .MakeGenericMethod(descriptor.ServiceType)
                                        .FastInvoke(null, new object[] { instance.GetType(), instance });

            services.Add(extensionDescriptor);

            int serviceKey = instance.GetHashCode();

            ServiceTypeMetadataExtensions.AddMetadata(instance.GetType(), serviceKey, name);



            return services;
        }




        /// <summary>
        /// 为简单类型创建Lazy<T>，Lazy<IEnumerable<T>>，Func<T>，Func<IEnumerable<T>>等注入表达式。
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddServiceExtensions(this IServiceCollection services,bool onlyInterface = true)
        {
            var method = typeof(ServiceCollectionExtensions).GetMethod(nameof(GetServiceExtensions), BindingFlags.NonPublic | BindingFlags.Static);

            var query = services.ToArray().Where(i => !i.ServiceType.ContainsGenericParameters
                        && i.ServiceType.IsInterface == onlyInterface);

            foreach (var service in query)
            {
                var extensionsDescriptors = (IEnumerable<ServiceDescriptor>)method
                    .MakeGenericMethod(service.ServiceType)
                    .Invoke(null, new object[] { service.ImplementationType });

                foreach (var serviceDescriptor in extensionsDescriptors)
                {
                    services.Add(serviceDescriptor);
                }
            }

            return services;
        }

        private static IEnumerable<ServiceDescriptor> GetServiceExtensions<T>(Type ImplementationType)
        {
            yield return ServiceDescriptor.Transient(typeof(Lazy<T>), provider => new Lazy<T>(provider.GetRequiredService<T>));
            yield return ServiceDescriptor.Transient(typeof(Lazy<IEnumerable<T>>), provider => new Lazy<IEnumerable<T>>(provider.GetRequiredService<IEnumerable<T>>));
            yield return ServiceDescriptor.Singleton(typeof(Func<T>), provider => new Func<T>(provider.GetRequiredService<T>));
            yield return ServiceDescriptor.Singleton(typeof(Func<IEnumerable<T>>), provider => new Func<IEnumerable<T>>(provider.GetRequiredService<IEnumerable<T>>));

            //yield return ServiceDescriptor.Transient(typeof(Lazy<T, ServiceTypeMetadata>), 
            //    provider => 
            //    new Lazy<T, ServiceTypeMetadata>(
            //        ()=> 
            //        (T)provider.GetRequiredService(ImplementationType), 
            //        ServiceTypeMetadataExtensions.GetServiceTypeMetadata(ImplementationType)
            //    ));

            //yield return ServiceDescriptor.Transient(typeof(IEnumerable<Lazy<T, ServiceTypeMetadata>>), 
            //    provider => provider.GetServices<Lazy<T, ServiceTypeMetadata>>());
        }



    }
}
