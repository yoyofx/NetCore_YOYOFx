using System;
using System.Collections.Generic;

namespace YOYOFx.Extensions.DependencyInjection.Registration
{
    internal class TypeMap
    {
        public TypeMap(Type implementationType, IEnumerable<Type> serviceTypes)
        {
            ImplementationType = implementationType;
            ServiceTypes = serviceTypes;
        }

        public Type ImplementationType { get; }

        public IEnumerable<Type> ServiceTypes { get; }
    }
}
