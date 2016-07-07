using Microsoft.Extensions.DependencyInjection;

namespace YOYO.Extensions.DI
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