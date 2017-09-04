using Microsoft.Extensions.DependencyInjection;

namespace YOYOFx.Extensions.DependencyInjection.Registration
{
    /// <summary>
    /// Ñ¡ÔñÆ÷
    /// </summary>
    internal interface ISelector
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        void Populate(IServiceCollection services);
    }
}