using Microsoft.Extensions.DependencyInjection;
using PeoManageSoft.Business.Domain.Services.Queries.Department.Get;
using PeoManageSoft.Business.Domain.Services.Queries.Department.GetAll;
using PeoManageSoft.Business.Domain.Services.Queries.Department.GetByRules;

namespace PeoManageSoft.Business.Domain.Services.Queries.Department
{
    /// <summary>
    /// Extension methods to add services from department queries
    /// </summary>
    internal static class DepartmentQueryDependencyService
    {
        #region Methods

        #region public

        /// <summary>
        /// Adds department query services to the container..
        /// </summary>
        /// <param name="services">Specifies the contract for a collection of service descriptors.</param>
        public static void AddDepartmentQueryDependencies(this IServiceCollection services)
        {
            services.AddScoped<IGetHandler, GetHandler>();
            services.AddScoped<IGetQuery, GetQuery>();
            services.AddScoped<IGetAllHandler, GetAllHandler>();
            services.AddScoped<IGetAllQuery, GetAllQuery>();
            services.AddScoped<IGetByRulesHandler, GetByRulesHandler>();
            services.AddScoped<IGetByRulesQuery, GetByRulesQuery>();
        }

        #endregion

        #endregion
    }
}
