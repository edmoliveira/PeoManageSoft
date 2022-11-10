using Microsoft.Extensions.DependencyInjection;
using PeoManageSoft.Business.Domain.Services.Functions.Title.Exists;

namespace PeoManageSoft.Business.Domain.Services.Functions.Title
{
    /// <summary>
    /// Extension methods to add services from title functions
    /// </summary>
    internal static class TitleFunctionDependencyService
    {
        #region Methods

        #region public

        /// <summary>
        /// Adds title functions services to the container.
        /// </summary>
        /// <param name="services">Specifies the contract for a collection of service descriptors.</param>
        public static void AddTitleFunctionDependencies(this IServiceCollection services)
        {
            services.AddScoped<ITitleFunctionFacade, TitleFunctionFacade>();
            services.AddScoped<IExistsFunction, ExistsFunction>();
        }

        #endregion

        #endregion
    }
}
