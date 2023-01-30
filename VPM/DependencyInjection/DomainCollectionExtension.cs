using Microsoft.Extensions.DependencyInjection;
using VPM.Domain.Implementation;
using VPM.Domain.Interface;

namespace VPM.DependencyInjection
{
    /// <summary>
    /// 
    /// </summary>
    public static class DomainCollectionExtension
    {
        /// <summary>
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddDomains(this IServiceCollection services)
        {
            services.AddScoped<IAccount, Account>();
            services.AddScoped<IProduct, Products>();
            services.AddScoped<IDropdowns, Dropdowns>();
            return services;
        }
    }
}
