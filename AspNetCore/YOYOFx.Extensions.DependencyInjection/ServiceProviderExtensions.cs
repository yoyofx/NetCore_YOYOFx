using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace YOYOFx.Extensions.DependencyInjection
{
    public static class ServiceProviderExtensions
    {

        public static TService GetServiceByMetadata<TService>(this IServiceProvider serviceProvider,
            Predicate<ServiceTypeMetadata> predicate)
        {
            var serviceQuery = QueryServiceByMeatdata<TService>(serviceProvider);

            var service = serviceQuery.FirstOrDefault(s => predicate.Invoke(s.Metadata));

            return service != null? service.Value : default(TService);
        }

        public static IEnumerable<TService> GetServicesByMetadata<TService>(this IServiceProvider serviceProvider,
            Predicate<ServiceTypeMetadata> predicate = null)
        {
            var serviceQuery = QueryServiceByMeatdata<TService>(serviceProvider);

            if (predicate != null)
                serviceQuery = serviceQuery.Where(s => predicate.Invoke(s.Metadata));

            var services = serviceQuery.Select(s=>s.Value);

            return services;
        }



        private static IEnumerable<Lazy<TService, ServiceTypeMetadata>> QueryServiceByMeatdata<TService>(IServiceProvider serviceProvider)
        {
            var serviceQuery = (IEnumerable<Lazy<TService, ServiceTypeMetadata>>)
                serviceProvider.GetService(typeof(IEnumerable<Lazy<TService, ServiceTypeMetadata>>));

            return serviceQuery;
        }




    }
}
