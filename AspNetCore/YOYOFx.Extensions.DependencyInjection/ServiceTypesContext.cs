using System;
using System.Collections.Generic;
using System.Text;
using YOYOFx.Extensions.DependencyInjection.AOP;

namespace YOYOFx.Extensions.DependencyInjection
{
    internal class ServiceTypesContext
    {
        internal ServiceTypesContext(Type serviceType)
        {
            this.TypeDef = TypeDef.Object;
            this.RequestServiceType = serviceType;
            this.Build();
        }

        /// <summary>
        /// 请求类型
        /// </summary>
        public Type RequestServiceType { set; get; }
        /// <summary>
        /// 请求类型的泛型
        /// </summary>
        public Type RequestGenericTypeDefinition { set; get; }
        /// <summary>
        /// 请求泛型类型的参数类型
        /// </summary>
        public Type GenericArgType { set; get; }
        /// <summary>
        /// 请求类型是否是泛型
        /// </summary>
        public bool IsGenericType { set; get; }

        /// <summary>
        /// 类型类别
        /// </summary>
        public TypeDef TypeDef { set; get; } 

        private void Build()
        {
            if (this.RequestServiceType.IsGenericType) {
                this.IsGenericType = true;
                this.RequestGenericTypeDefinition = this.RequestServiceType.GetGenericTypeDefinition();
            }

            if (!this.RequestServiceType.IsGenericType) { }
            else if (RequestGenericTypeDefinition == typeof(List<>))
            {
                this.GenericArgType = this.RequestServiceType.GetGenericArguments()[0];
                this.TypeDef = TypeDef.List;
            }
            else if (RequestGenericTypeDefinition == typeof(IEnumerable<>))
            {
                this.GenericArgType = this.RequestServiceType.GetGenericArguments()[0];
                this.TypeDef = TypeDef.IEnumerable;
            }
            else if (RequestGenericTypeDefinition == typeof(IInvocation<>) ||
                     RequestGenericTypeDefinition == typeof(IInvocation<,>))
            {
                this.TypeDef = TypeDef.Proxy;
            }
        }

    }
}
