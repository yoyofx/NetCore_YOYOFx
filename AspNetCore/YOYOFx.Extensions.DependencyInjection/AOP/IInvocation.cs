using System;
using System.Collections.Generic;
using System.Text;

namespace YOYOFx.Extensions.DependencyInjection.AOP
{
    //MethodInterceptor

    public interface IInvocation<T>
    {
        T Proxy { set; get; }
    }

    public interface IInvocation<T,P> 
    {
        T Proxy { set; get; }
        P Interceptor { set; get; }
    }


    public class InvocationProxy<TProxy> : IInvocation<TProxy>
    {
        public InvocationProxy(TProxy instance)
        {
            this.Proxy = instance;
        }

        public TProxy Proxy { set; get; }
    }


    public class InvocationProxy<TProxy, TInterceptor> : IInvocation<TProxy, TInterceptor> where TInterceptor : IMethodInterceptor
    {
        public InvocationProxy(TProxy instance, TInterceptor interceptor)
        {
            this.Proxy = instance;
            this.Interceptor = interceptor;
        }

        public TProxy Proxy { set; get; }
        public TInterceptor Interceptor { set; get; }
    }



}
