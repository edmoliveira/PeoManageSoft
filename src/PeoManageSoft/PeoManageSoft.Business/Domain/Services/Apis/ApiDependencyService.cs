using Microsoft.Extensions.DependencyInjection;
using PeoManageSoft.Business.Domain.Services.Apis.Geo;
using PeoManageSoft.Business.Domain.Services.Apis.Geo.Interfaces;

namespace PeoManageSoft.Business.Domain.Services.Apis
{
    /// <summary>
    /// Extension methods to add services from the apis
    /// </summary>
    internal static class ApiDependencyService
    {
        #region Methods

        #region public

        /// <summary>
        /// Adds apis services to the container..
        /// </summary>
        /// <param name="services">Specifies the contract for a collection of service descriptors.</param>
        public static void AddApiDependencies(this IServiceCollection services)
        {
            services.AddSingleton<IGeoApi, GeoApi>();
        }

        #endregion

        #endregion
    }
}
