using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyModel;

namespace YOYOFx.Extensions.DependencyInjection.Registration.Registration
{
    internal class AssemblySelector : IAssemblySelector, ISelector
    {
        private List<ISelector> Selectors { get; } = new List<ISelector>();

        public IImplementationTypeSelector FromAssemblyOf<T>()
        {
            return FromAssembliesOf(typeof(T));
        }

        public IImplementationTypeSelector FromAssembliesOf(params Type[] types)
        {
            if (types == null)
            {
                throw new ArgumentNullException(nameof(types));
            }

            return FromAssembliesOf(types.AsEnumerable());
        }

        public IImplementationTypeSelector FromAssembliesOf(IEnumerable<Type> types)
        {
            if (types == null)
            {
                throw new ArgumentNullException(nameof(types));
            }

            return FromAssemblies(types.Select(t => t.GetTypeInfo().Assembly));
        }

        public IImplementationTypeSelector FromAssemblies(params Assembly[] assemblies)
        {
            if (assemblies == null)
            {
                throw new ArgumentNullException(nameof(assemblies));
            }

            return FromAssemblies(assemblies.AsEnumerable());
        }

        public IImplementationTypeSelector FromAssemblies(IEnumerable<Assembly> assemblies)
        {
            if (assemblies == null)
            {
                throw new ArgumentNullException(nameof(assemblies));
            }

            return AddSelector(assemblies.SelectMany(asm => asm.DefinedTypes.Select(x => x.AsType())));
        }


        public IImplementationTypeSelector FromRuntimeAssemblies(Func<AssemblyName, bool> predicate = null)
        {
            var assemblyNames = DependencyContext.Default.RuntimeLibraries.SelectMany(i => i.GetDefaultAssemblyNames(DependencyContext.Default));
            if (predicate != null)
                assemblyNames = assemblyNames.Where(predicate).ToArray();
            var assemblies = assemblyNames.Select(i => Assembly.Load(new AssemblyName(i.Name))).ToArray();
            return FromAssemblies( assemblies);
        }

        void ISelector.Populate(IServiceCollection services)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            foreach (var selector in Selectors)
            {
                selector.Populate(services);
            }
        }

        private IImplementationTypeSelector AddSelector(IEnumerable<Type> types)
        {
            var selector = new ImplementationTypeSelector(this, types);

            Selectors.Add(selector);

            return selector;
        }
    }
}
