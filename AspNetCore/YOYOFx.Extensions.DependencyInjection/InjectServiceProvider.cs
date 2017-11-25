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

            return this.ServiceFactory(new ServiceTypesContext(serviceType));
        }



        /// <summary>
        /// 构造指定类型实例的工厂
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private object ServiceFactory(ServiceTypesContext context)
        {
            object result = null;

            switch (context.TypeDef)
            {
                case TypeDef.IEnumerable:
                    result = this.serviceProvider.GetServices(
                                                    context.GenericArgType);
                    break;
                case TypeDef.List:
                    result = this.serviceProvider.GetServices(
                                        context.GenericArgType)?.ToList();
                    break;
                case TypeDef.Object:
                    result = this.GetObjectService(context.RequestServiceType);
                    break;
                case TypeDef.Proxy:
                    result = this.GetProxyService(
                                        context.RequestGenericTypeDefinition,
                                        context.RequestServiceType);
                    break;
            }

            return result;
        }


        /// <summary>
        /// 通过IOC向属性注入实例
        /// </summary>
        /// <param name="serviceInstance"></param>
        /// <param name="serviceType"></param>
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

        /// <summary>
        /// 获取指定类型的实例，并注入InjectAttribute标记的属性。
        /// </summary>
        /// <param name="serviceType"></param>
        /// <returns></returns>
        private object GetObjectService(Type serviceType)
        {
            var result = this.serviceProvider.GetRequiredService(serviceType);
            if (result != null)
                this.GetInjectService(result, serviceType);

            return result;
        } 

        /// <summary>
        /// 获取指定类型的动态代理
        /// </summary>
        /// <param name="genericType"></param>
        /// <param name="serviceType"></param>
        /// <returns></returns>
        private object GetProxyService(Type genericType, Type serviceType)
        {
            object result = null;
            Type proxyType = null;
            object proxy = null;
            if (genericType == typeof(IInvocation<>))
            {
                proxyType = serviceType.GetGenericArguments()[0];
                proxy = DynamicProxy.Create(proxyType);
                result = InvocationProxyFactory.CreateInvocation(proxyType, proxy);
            }
            else if (genericType == typeof(IInvocation<,>))
            {
                proxyType = serviceType.GetGenericArguments()[0];
                var interceptorType = serviceType.GetGenericArguments()[1];
                IMethodInterceptor methodInterceptor = (IMethodInterceptor)
                                 this.serviceProvider.GetRequiredService(interceptorType);

                proxy = DynamicProxy.CreateWithInterceptor(proxyType, methodInterceptor);
                result = InvocationProxyFactory.CreateInvocationWithInterceptor(proxyType, proxy, methodInterceptor);
            }
            return result;
        }



        public void Dispose()
        {
            ((IDisposable)serviceProvider)?.Dispose();
        }

    }

    /// <summary>
    /// 请求类型的定义
    /// </summary>
    enum TypeDef
    {
        List,
        IEnumerable,
        Object,
        Proxy
    }

}
