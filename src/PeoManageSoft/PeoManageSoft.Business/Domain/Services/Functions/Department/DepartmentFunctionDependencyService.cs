using Microsoft.Extensions.DependencyInjection;
using PeoManageSoft.Business.Domain.Services.Functions.Department.Exists;

namespace PeoManageSoft.Business.Domain.Services.Functions.Department
{
    /// <summary>
    /// Extension methods to add services from department functions
    /// </summary>
    internal static class DepartmentFunctionDependencyService
    {
        #region Methods

        #region public

        /// <summary>
        /// Adds department functions services to the container.
        /// </summary>
        /// <param name="services">Specifies the contract for a collection of service descriptors.</param>
        public static void AddDepartmentFunctionDependencies(this IServiceCollection services)
        {
            services.AddScoped<IDepartmentFunctionFacade, DepartmentFunctionFacade>();
            services.AddScoped<IExistsFunction, ExistsFunction>();
        }

        #endregion

        #endregion
    }
}
