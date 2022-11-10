using Microsoft.Extensions.DependencyInjection;
using PeoManageSoft.Business.Domain.Services.Functions.Department;
using PeoManageSoft.Business.Domain.Services.Functions.Title;
using PeoManageSoft.Business.Domain.Services.Functions.User;

namespace PeoManageSoft.Business.Domain.Services.Functions
{
    /// <summary>
    /// Extension methods to add services from functions
    /// </summary>
    internal static class FunctionDependencyService
    {
        #region Methods

        #region public

        /// <summary>
        /// Adds functions services to the container.
        /// </summary>
        /// <param name="services">Specifies the contract for a collection of service descriptors.</param>
        public static void AddFunctionDependencies(this IServiceCollection services)
        {
            services.AddDepartmentFunctionDependencies();
            services.AddTitleFunctionDependencies();
            services.AddUserFunctionDependencies();
        }

        #endregion

        #endregion
    }
}
