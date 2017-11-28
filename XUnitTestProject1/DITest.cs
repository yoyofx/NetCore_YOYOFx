using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Xunit;
using YOYOFx.Extensions.DependencyInjection;
using YOYOFx.Extensions.DependencyInjection.AOP;
using YOYOFx.Extensions.DependencyInjection.Attributes;
using YOYOFx.Extensions.DependencyInjection.Registration;

namespace XUnitTestProject1
{
    public class YOYO_DI_Test
    {
        private IServiceCollection Collection { get; } = new ServiceCollection();


        [Fact]
        public void CanAopTypesForServiceProvider()
        {
            Collection.Scan(scan => scan.FromAssemblyOf<ITransientService>()
             .AddClasses()
             .AsImplementedInterfacesOrDefault());


            Collection.AddScoped<HttpInterceptor>();

            var sp1 = Collection.BuildInjectServiceProvider();

            var invocation = sp1.GetService<IInvocation<IUserService, HttpInterceptor>>();

            //[DisplayName("IUserService.Register")]
            string name = invocation.Proxy.Register("max zhang");

            Assert.Equal(name, $"Call Interface . Get DisplayName Attribute by:  IUserService.Register , args: max zhang");
        }


        [Fact]
        public void CanInjectTypesForServiceProvider()
        {
            Collection.Scan(scan => scan.FromAssemblyOf<ITransientService>()
               .AddClasses()
               .AsImplementedInterfacesOrDefault()
            );

            var sp1 = Collection.BuildInjectServiceProvider();

            var helloService = (HelloController)sp1.GetService(typeof(HelloController));
 

            Assert.Equal(helloService.UserService.Name, "hello");
            Assert.NotEqual(helloService.TransienServices.Count() , 0);
        }

        [Fact]
        public void AttributeMetadataTest()
        {
            Collection.Scan(scan => scan.FromAssemblyOf<ITransientService>()
              .AddClasses(t => t.AssignableTo<ITransientService>())
              .UsingAttributes() );


            var serviceProvider = Collection.BuildInjectServiceProvider();



            var ts = serviceProvider.GetServiceByMetadata<ITransientService>( 
                            metadata =>  metadata.Name == "s1"
                     );

            Assert.Equal(ts?.GetType(), typeof(MyService1));

            var query = serviceProvider.GetServicesByMetadata<ITransientService>();

            Assert.Equal(query.Count(), 2);


        }

        [Fact]
        public void RegisterInstanceByMetadataTest()
        {
            var serviceProvider = Collection
                .RegisterInstance<UserService>(new UserService { Name = "u1" }, "u1")
                .RegisterInstance<UserService>(new UserService { Name = "u2" }, "u2")
                .BuildInjectServiceProvider();

            var u1 = serviceProvider.GetServiceByMetadata<UserService>(
                           metadata => metadata.Name == "u1"
                    );

            var u2 = serviceProvider.GetServiceByMetadata<UserService>(
                          metadata => metadata.Name == "u2"
                   );

            Assert.Equal(u1.Name, "u1");

            Assert.Equal(u2.Name, "u2");


        }






        [Fact]
        public void CanFilterTypesToScan()
        {
            Collection.Scan(scan => scan.FromAssemblyOf<ITransientService>()
                .AddClasses(classes => classes.AssignableTo<ITransientService>())
                    .AsImplementedInterfaces()
                    .WithTransientLifetime());


            var services = Collection.GetDescriptors<ITransientService>();

            Assert.Equal(services, Collection);

            Assert.All(services, service =>
            {
                Assert.Equal(ServiceLifetime.Transient, service.Lifetime);
                Assert.Equal(typeof(ITransientService), service.ServiceType);
            });


          

        }


        [Fact]
        public void CanFilterAttributeTypes()
        {
            Collection.Scan(scan => scan.FromAssemblyOf<ITransientService>()
                .AddClasses(t => t.AssignableTo<ITransientService>())
                    .UsingAttributes());

            Assert.NotEqual(Collection.Count, 0);

            var service = Collection.GetDescriptor<ITransientService>();

            Assert.NotNull(service);
            //Assert.Equal(ServiceLifetime.Scoped, service.Lifetime);
        }

        [Fact]
        public void CanRegisterAsSpecificType()
        {
            Collection.Scan(scan => scan.FromAssemblyOf<ITransientService>()
                .AddClasses(classes => classes.AssignableTo<ITransientService>())
                    .As<ITransientService>());

            var services = Collection.GetDescriptors<ITransientService>();

            Assert.Equal(services, Collection);

            Assert.All(services, service =>
            {
                Assert.Equal(ServiceLifetime.Transient, service.Lifetime);
                Assert.Equal(typeof(ITransientService), service.ServiceType);
            });
        }

        [Fact]
        public void CanSpecifyLifetime()
        {
            Collection.Scan(scan => scan.FromAssemblyOf<IScopedService>()
                .AddClasses(classes => classes.AssignableTo<IScopedService>())
                    .AsImplementedInterfaces()
                    .WithScopedLifetime());

            var services = Collection.GetDescriptors<IScopedService>();

            Assert.Equal(services, Collection);

            Assert.All(services, service =>
            {
                Assert.Equal(ServiceLifetime.Scoped, service.Lifetime);
                Assert.Equal(typeof(IScopedService), service.ServiceType);
            });
        }

        [Fact]
        public void CanRegisterGenericTypes()
        {
            Collection.Scan(scan => scan.FromAssemblyOf<IScopedService>()
                .AddClasses(classes => classes.AssignableTo(typeof(IQueryHandler<,>)))
                    .AsImplementedInterfaces()
                    .WithScopedLifetime());

            var service = Collection.GetDescriptor<IQueryHandler<string, int>>();

            Assert.NotNull(service);
            Assert.Equal(ServiceLifetime.Scoped, service.Lifetime);
            Assert.Equal(typeof(QueryHandler), service.ImplementationType);
        }


        [Fact]
        public void AutoRegisterAsMatchingInterfaceSameNamespaceOnly()
        {
            Collection.Scan(scan => scan.FromAssemblyOf<ITransientService>()
                .AddClasses()
                    .AsMatchingInterface((t, x) => x.InNamespaces(t.Namespace))
                    .WithTransientLifetime());

            Assert.Equal(2, Collection.Count);

            var service = Collection.GetDescriptor<ITransientService>();

            Assert.NotNull(service);
            Assert.Equal(ServiceLifetime.Transient, service.Lifetime);
            Assert.Equal(typeof(TransientService), service.ImplementationType);
        }

    }

    public class HelloController
    {
        [Inject]
        public IUserService UserService { set; get; }

        [Inject]
        public IEnumerable<ITransientService> TransienServices { set; get; }

    }




    public interface IUserService
    {
        string Name { set; get; }

        [DisplayName("IUserService.Register")]
        string Register(string name);

    }

    public class HttpInterceptor : MethodInterceptorAttribute
    {
        public override object OnAfter(Type targetType, object target, object returnValue, MethodInfo targetMethod, object[] args)
        {

            var attr = targetMethod.GetCustomAttribute<DisplayNameAttribute>();

            return $"Call Interface . Get DisplayName Attribute by:  {attr.DisplayName} , args: {args[0]}";
        }
    }







    public class UserService: IUserService
    {
       
        public string Name { set; get; } = "hello";

        public string Register(string name)
        {
            this.Name = name;
            return name;
        }
    }



    public interface ITransientService { }


    [ServiceDescriptor("s1",typeof(ITransientService),ServiceLifetime.Scoped)]
    public class MyService1 : ITransientService { }

    [ServiceDescriptor(typeof(ITransientService),ServiceLifetime.Scoped)]
    public class MyService : ITransientService { }


    public class TransientService1 : ITransientService { }

    public class TransientService2 : ITransientService { }

    public class TransientService : ITransientService { }

    public interface IScopedService { }

    public class ScopedService1 : IScopedService { }

    public class ScopedService2 : IScopedService { }

    public interface IQueryHandler<TQuery, TResult> { }

    public class QueryHandler : IQueryHandler<string, int> { }

    public class BaseQueryHandler<T> : IQueryHandler<T, int> { }

    internal static class ServiceCollectionExtensions
    {
        public static ServiceDescriptor GetDescriptor<T>(this IServiceCollection services)
        {
            return services.GetDescriptors<T>().FirstOrDefault();
        }

        public static ServiceDescriptor[] GetDescriptors<T>(this IServiceCollection services)
        {
            return services.Where(x => x.ServiceType == typeof(T)).ToArray();
        }
    }

}
