using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.FastReflection;

namespace YOYOFx.Extensions.DependencyInjection.AOP
{
    public class DynamicProxy
    {
        public static T CreateWithInstance<T>(T model)
        {
            var proxy = DispatchProxy.Create<T, InvokeProxy>();
            ((InvokeProxy)(object)proxy).Initialize(typeof(T), model);
            return proxy;
        }


        public static T Create<T>(IServiceProvider sp)
        {
            var serviceInstance = sp.GetService(typeof(T));
            var proxy = DispatchProxy.Create<T, InvokeProxy>();
            ((InvokeProxy)(object)proxy).Initialize(typeof(T), serviceInstance);
            return proxy;
        }


        public static T Create<T>()
        {
            var proxy = DispatchProxy.Create<T, InvokeProxy>();
            return proxy;
        }

        public static object CreateWithInterceptor(Type serviceType, IMethodInterceptor methodInterceptor)
        {
            var proxy = Create(serviceType);
            ((InvokeProxy)(object)proxy).Initialize(serviceType, methodInterceptor);
            return proxy;
        }


        public static object Create(Type serviceType)
        {
            var genericMethodInfo = getCreateMethodByDispatchProxy(serviceType);
            object proxy = genericMethodInfo.FastInvoke(null, null);
            return proxy;
        }

        private static MethodInfo getCreateMethodByDispatchProxy(Type serviceType)
        {
            var factoryType = typeof(DispatchProxy);
            var methodInfo = factoryType.GetMethod("Create");
            MethodInfo genericMethodInfo = methodInfo.MakeGenericMethod(serviceType, typeof(InvokeProxy));
            return genericMethodInfo;
        }


    }
}
