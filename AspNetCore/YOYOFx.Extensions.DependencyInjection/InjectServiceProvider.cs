using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.ServiceLookup;
using YOYOFx.Extensions.Utils.Extensions;
using YOYOFx.Extensions.DependencyInjection.Attributes;
using System.Collections.Concurrent;
using System.Reflection;
using System.FastReflection;
using YOYOFx.Extensions.DependencyInjection.AOP;

namespace YOYOFx.Extensions.DependencyInjection
{
    public class InjectServiceProvider : IServiceProvider, IDisposable
    {

        private static ConcurrentDictionary<Type, List<PropertyInfo>> injectServiceTypes = 
                                                    new ConcurrentDictionary<Type, List<PropertyInfo>>();

        private IServiceProvider serviceProvider = null;


        public InjectServiceProvider(IServiceCollection serviceCollection)
        {
            this.serviceProvider = serviceCollection.BuildServiceProvider();
        }

        public InjectServiceProvider(IServiceProvider sp)
        {
            this.serviceProvider = sp;
        }



        public object GetService(Type serviceType)
        {
            TypeDef def = TypeDef.Object;

            Type genericType = null;
            if (serviceType.IsGenericType) {  genericType = serviceType.GetGenericTypeDefinition();  }

            if (!serviceType.IsGenericType){}
            else if (genericType == typeof(List<>))
            {
                serviceType = serviceType.GetGenericArguments()[0];
                def = TypeDef.List;
            }
            else if (genericType == typeof(IEnumerable<>))
            {
                serviceType = serviceType.GetGenericArguments()[0];
                def = TypeDef.IEnumerable;
            }
            else if (genericType == typeof(IInvocation<>) || genericType == typeof(IInvocation<,>))
            {
                def = TypeDef.Proxy;
            }

            object result = null;

            switch (def)
            {
                case TypeDef.IEnumerable:
                    result = this.serviceProvider.GetServices(serviceType);
                    break;
                case TypeDef.List:
                    result = this.serviceProvider.GetServices(serviceType)?.ToList();
                    break;
                case TypeDef.Object:
                    result = this.serviceProvider.GetService(serviceType);
                    if(result != null)
                        this.GetInjectService(result, serviceType);
                    break;
                case TypeDef.Proxy:
                    Type proxyType = null;
                    object proxy = null;
                    if (genericType == typeof(IInvocation<>))
                    {
                        proxyType = serviceType.GetGenericArguments()[0];
                        proxy = DynamicProxy.Create(proxyType);
                        result = InvocationProxyFactory.CreateInvocation(proxyType, proxy);
                    }
                    else if(genericType == typeof(IInvocation<,>))
                    {
                        proxyType = serviceType.GetGenericArguments()[0];
                        var interceptorType = serviceType.GetGenericArguments()[1];
                        IMethodInterceptor methodInterceptor = (IMethodInterceptor)
                                         this.serviceProvider.GetRequiredService(interceptorType);

                        proxy = DynamicProxy.CreateWithInterceptor(proxyType, methodInterceptor);
                        result = InvocationProxyFactory.CreateInvocationWithInterceptor(proxyType, proxy, methodInterceptor);
                    }
                   
                    break;
            }

            return result;
        }


        private void GetInjectService(object serviceInstance,Type serviceType)
        {
            if(!injectServiceTypes.ContainsKey(serviceType))
            {
                var propertys = serviceType.GetProperties();
                var propertyInfoList = new List<PropertyInfo>();

                foreach (var propertyInfo in propertys)
                {
                    var injectAttr = propertyInfo.GetAttribute<InjectAttribute>();
                    if (injectAttr != null)
                        propertyInfoList.Add(propertyInfo);
                }
                if(propertyInfoList.Count > 0)
                    injectServiceTypes.TryAdd(serviceType, propertyInfoList);
            }

            var injectPropertyInfoList = injectServiceTypes.GetOrDefault(serviceType);
            if(injectPropertyInfoList != null)
            {
                foreach(var injectPropertyInfo in injectPropertyInfoList)
                {
                    var propertyValue = this.GetService(injectPropertyInfo.PropertyType);
                    if(propertyValue != null)
                        injectPropertyInfo.FastSetValue(serviceInstance,propertyValue);
                }
            }





        }



        public void Dispose()
        {
            ((IDisposable)serviceProvider)?.Dispose();
        }

    }

    enum TypeDef
    {
        List,
        IEnumerable,
        Object,
        Proxy
    }

}
