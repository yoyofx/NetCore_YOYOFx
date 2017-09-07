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


            Collection.AddScoped<HttpService>();

            var sp = Collection.BuildServiceProvider();
            var sp1 = new InjectServiceProvider(sp);

            


            var invocation = sp1.GetService<IInvocation<IUserService, HttpService>>();

            //invocation.Proxy.Name = "hello world";

            invocation.Proxy.Register("max zhang");

            Assert.Equal(invocation.Proxy.Name, "max zhang");
        }


        [Fact]
        public void CanInjectTypesForServiceProvider()
        {
            Collection.Scan(scan => scan.FromAssemblyOf<ITransientService>()
               .AddClasses()
               .AsImplementedInterfacesOrDefault()
            );
            var sp = Collection.BuildServiceProvider();
            var sp1 = new InjectServiceProvider(sp);

            var helloService = (HelloController)sp1.GetService(typeof(HelloController));

            //IEnumerable<ITransientService> ts = (IEnumerable<ITransientService>)sp.GetServices(typeof(ITransientService));

            Assert.Equal(helloService.UserService.Name, "hello");
            Assert.Equal(helloService.TransienServices.Count(), 3);
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

            Assert.Equal(Collection.Count, 1);

            var service = Collection.GetDescriptor<ITransientService>();

            Assert.NotNull(service);
            Assert.Equal(ServiceLifetime.Transient, service.Lifetime);
            Assert.Equal(typeof(TransientService1), service.ImplementationType);
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
        void Register(string name);

    }

    public class HttpService : MethodInterceptorAttribute
    {
        public override object OnAfter(Type targetType, object target, object returnValue, MethodInfo targetMethod, object[] args)
        {



            return base.OnAfter(targetType, target, returnValue, targetMethod, args);
        }
    }







    public class UserService: IUserService
    {
       
        public string Name { set; get; } = "hello";

        public void Register(string name)
        {
            this.Name = name;
        }
    }



    public interface ITransientService { }

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
            return services.GetDescriptors<T>().Single();
        }

        public static ServiceDescriptor[] GetDescriptors<T>(this IServiceCollection services)
        {
            return services.Where(x => x.ServiceType == typeof(T)).ToArray();
        }
    }

}
