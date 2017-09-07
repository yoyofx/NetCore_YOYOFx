using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace YOYOFx.Extensions.DependencyInjection.AOP
{
    public class MethodInterceptorAttribute : Attribute, IMethodInterceptor
    {
        public virtual object OnAfter(Type targetType, object target, object returnValue, MethodInfo targetMethod, object[] args)
        {
            throw new NotSupportedException();
        }

        public virtual void OnBefore(Type targetType, object target, MethodInfo targetMethod, object[] args)
        {
        }
        public virtual void OnException(Type targetType, object target, MethodInfo targetMethod, object[] args, Exception ex)
        {

        }

    }
}
