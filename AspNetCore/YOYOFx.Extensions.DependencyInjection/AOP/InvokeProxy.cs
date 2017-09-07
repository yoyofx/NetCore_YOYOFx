using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using YOYOFx.Extensions.Utils.Extensions;

namespace YOYOFx.Extensions.DependencyInjection.AOP
{
    public class InvokeProxy : DispatchProxy
    {
        private object _instance;
        private Type _serviceType = null;
        private Dictionary<MethodInfo, MethodInfo> _dispatchTable;

        public List<IMethodInterceptor> Interceptors { set; get; }


        public InvokeProxy() {
            this.Interceptors = new List<IMethodInterceptor>();
        }

        internal void Initialize(Type serviceType, object model)
        {
            _instance = model;
            _serviceType = serviceType;
            _dispatchTable = new Dictionary<MethodInfo, MethodInfo>(new MethodInfoEqualityComparer());
            foreach (var method in serviceType.GetRuntimeMethods())
            {
                var target = _instance.GetType().GetRuntimeMethods().Single(m =>
                                m.Name == method.Name
                                && m.GetGenericArguments().SequenceEqual(method.GetGenericArguments())
                                && m.GetParameters().Select(p => p.ParameterType).SequenceEqual(method.GetParameters().Select(p => p.ParameterType))
                             );
                _dispatchTable.Add(method, target);
            }
        }

        internal void Initialize(Type serviceType,IMethodInterceptor interceptor)
        {
            this._serviceType = serviceType;
            this.Interceptors.Add(interceptor);
        }


        protected override object Invoke(MethodInfo targetMethod, object[] args)
        {
            var interceptors = targetMethod.GetCustomAttributes<MethodInterceptorAttribute>();
            this.Interceptors.AddRange(interceptors.Cast<IMethodInterceptor>());
           
            object result = null;
            foreach(var interceptor in this.Interceptors)
            {
                interceptor.OnBefore(_serviceType, _instance, targetMethod, args);
            }
            if(_instance != null)
            {
                try
                {
                    result = _dispatchTable[targetMethod].Invoke(_instance, args);
                }
                catch(Exception ex)
                {
                    foreach (var interceptor in this.Interceptors)
                    {
                        interceptor.OnException(_serviceType, _instance, targetMethod, args,ex);
                    }
                    throw ex;
                }

            }

            foreach (var interceptor in this.Interceptors)
            {
                result = interceptor.OnAfter(_serviceType, _instance, result, targetMethod, args);
            }

            return result;
        }


        private class MethodInfoEqualityComparer : EqualityComparer<MethodInfo>
        {
            public MethodInfoEqualityComparer() { }

            public override bool Equals(MethodInfo left, MethodInfo right)
            {
                return left?.MetadataToken == right?.MetadataToken;
            }

            public override int GetHashCode(MethodInfo obj)
            {
                return (obj?.MetadataToken.GetHashCode()).GetValueOrDefault();
            }
        }

    }
}
