using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace YOYOFx.Extensions.DependencyInjection.Internal
{
    internal class InjectServiceScope : IServiceScope
    {
        public InjectServiceScope(IServiceProvider serviceProvider)
        {
            ServiceProvider = serviceProvider;
        }

        #region Implementation of IDisposable

        /// <inheritdoc />
        /// <summary>Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.</summary>
        public void Dispose()
        {
            if (ServiceProvider is IDisposable disposable)
            {
                disposable.Dispose();
            }
        }

        #endregion Implementation of IDisposable

        #region Implementation of IServiceScope

        /// <inheritdoc />
        /// <summary>
        /// The <see cref="T:System.IServiceProvider" /> used to resolve dependencies from the scope.
        /// </summary>
        public IServiceProvider ServiceProvider { get; }

        #endregion Implementation of IServiceScope
    }


    internal class InjectServiceScopeFactory : IServiceScopeFactory
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IServiceCollection _serviceDescriptors;

        public InjectServiceScopeFactory(IServiceProvider serviceProvider, IServiceCollection serviceDescriptors)
        {
            _serviceProvider = serviceProvider;
            _serviceDescriptors = serviceDescriptors;
        }

        #region Implementation of IServiceScopeFactory

        /// <inheritdoc />
        /// <summary>
        /// Create an <see cref="T:Microsoft.Extensions.DependencyInjection.IServiceScope" /> which
        /// contains an <see cref="T:System.IServiceProvider" /> used to resolve dependencies from a
        /// newly created scope.
        /// </summary>
        /// <returns>
        /// An <see cref="T:Microsoft.Extensions.DependencyInjection.IServiceScope" /> controlling the
        /// lifetime of the scope. Once this is disposed, any scoped services that have been resolved
        /// from the <see cref="P:Microsoft.Extensions.DependencyInjection.IServiceScope.ServiceProvider" />
        /// will also be disposed.
        /// </returns>
        public IServiceScope CreateScope()
        {
            return new InjectServiceScope(
                new InjectServiceProvider(_serviceProvider ,_serviceDescriptors));
        }

        #endregion Implementation of IServiceScopeFactory
    }
}
