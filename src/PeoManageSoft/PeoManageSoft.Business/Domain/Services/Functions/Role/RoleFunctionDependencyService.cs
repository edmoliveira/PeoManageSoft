using Microsoft.Extensions.DependencyInjection;
using PeoManageSoft.Business.Domain.Services.Functions.Role.Exists;
using PeoManageSoft.Business.Domain.Services.Functions.Role.NameExists;

namespace PeoManageSoft.Business.Domain.Services.Functions.Role
{
    /// <summary>
    /// Extension methods to add services from role functions
    /// </summary>
    internal static class RoleFunctionDependencyService
    {
        #region Methods

        #region public

        /// <summary>
        /// Adds role functions services to the container.
        /// </summary>
        /// <param name="services">Specifies the contract for a collection of service descriptors.</param>
        public static void AddRoleFunctionDependencies(this IServiceCollection services)
        {
            services.AddScoped<IRoleFunctionFacade, RoleFunctionFacade>();
            services.AddScoped<IExistsFunction, ExistsFunction>();
            services.AddScoped<INameExistsFunction, NameExistsFunction>();
        }

        #endregion

        #endregion
    }
}
