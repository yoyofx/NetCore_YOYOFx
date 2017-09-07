using System;
using System.Collections.Generic;
using System.Text;

namespace YOYOFx.Extensions.DependencyInjection.AOP
{
    public class InvocationProxyFactory
    {
        public static object CreateInvocation(Type serviceType,object target)
        {
            Type invocationType = typeof(InvocationProxy<>);
            Type[] GenericTypeArgs = { serviceType };
            var invocationGenericType = invocationType.MakeGenericType(GenericTypeArgs);
            object result = Activator.CreateInstance(invocationGenericType,target);
            return result;
        }


        public static object CreateInvocationWithInterceptor(Type serviceType, object target, IMethodInterceptor interceptor)
        {
            Type invocationType = typeof(InvocationProxy<,>);
            Type[] GenericTypeArgs = { serviceType , interceptor.GetType() };
            var invocationGenericType = invocationType.MakeGenericType(GenericTypeArgs);
            object result = Activator.CreateInstance(invocationGenericType, target, interceptor);
            return result;
        }


    }
}
