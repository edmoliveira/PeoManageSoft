using Microsoft.Extensions.DependencyInjection;
using PeoManageSoft.Business.Application.Department;
using PeoManageSoft.Business.Application.Title;
using PeoManageSoft.Business.Application.User;

namespace PeoManageSoft.Business.Application
{
    /// <summary>
    /// Extension methods to add services from applications
    /// </summary>
    internal static class ApplicationDependencyService
    {
        #region Methods

        #region public

        /// <summary>
        /// Adds applications services to the container..
        /// </summary>
        /// <param name="services">Specifies the contract for a collection of service descriptors.</param>
        public static void AddApplicationDependencies(this IServiceCollection services)
        {
            services.AddUserApplicationDependencies();
            services.AddUserApplicationValidation();
            services.AddTitleApplicationDependencies();
            services.AddTitleApplicationValidation();
            services.AddDepartmentApplicationDependencies();
            services.AddDepartmentApplicationValidation();
        }

        #endregion

        #endregion
    }
}
