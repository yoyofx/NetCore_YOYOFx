using System;
using System.Collections.Generic;
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

        public static IServiceCollection AddServiceExtensions(this IServiceCollection services)
        {
            var method = typeof(ServiceCollectionExtensions).GetMethod(nameof(GetServiceExtensions), BindingFlags.NonPublic | BindingFlags.Static);

            foreach (var service in services.ToArray().GroupBy(i => i.ServiceType).Select(i => i.First()).Where(i => !i.ServiceType.ContainsGenericParameters))
            {
                var extensionsDescriptors = (IEnumerable<ServiceDescriptor>)method.MakeGenericMethod(service.ServiceType).Invoke(null, null);
                foreach (var serviceDescriptor in extensionsDescriptors)
                {
                    services.Add(serviceDescriptor);
                }
            }

            return services;
        }

        private static IEnumerable<ServiceDescriptor> GetServiceExtensions<T>()
        {
            yield return ServiceDescriptor.Transient(typeof(Lazy<T>), provider => new Lazy<T>(provider.GetRequiredService<T>));
            yield return ServiceDescriptor.Transient(typeof(Lazy<IEnumerable<T>>), provider => new Lazy<IEnumerable<T>>(provider.GetRequiredService<IEnumerable<T>>));
            yield return ServiceDescriptor.Singleton(typeof(Func<T>), provider => new Func<T>(provider.GetRequiredService<T>));
            yield return ServiceDescriptor.Singleton(typeof(Func<IEnumerable<T>>), provider => new Func<IEnumerable<T>>(provider.GetRequiredService<IEnumerable<T>>));
        }



    }
}
