using Microsoft.Extensions.DependencyInjection;
using PeoManageSoft.Business.Domain.Services.Queries.Department;
using PeoManageSoft.Business.Domain.Services.Queries.Title;
using PeoManageSoft.Business.Domain.Services.Queries.User;

namespace PeoManageSoft.Business.Domain.Services.Queries
{
    /// <summary>
    /// Extension methods to add services from queries
    /// </summary>
    internal static class QueryDependencyService
    {
        #region Methods

        #region public

        /// <summary>
        /// Adds queries services to the container.
        /// </summary>
        /// <param name="services">Specifies the contract for a collection of service descriptors.</param>
        public static void AddQueryDependencies(this IServiceCollection services)
        {
            services.AddDepartmentQueryDependencies();
            services.AddTitleQueryDependencies();
            services.AddUserQueryDependencies();
        }

        #endregion

        #endregion
    }
}
