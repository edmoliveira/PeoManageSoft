using Microsoft.Extensions.DependencyInjection;
using PeoManageSoft.Business.Domain.Services.Queries.Department.Get;
using PeoManageSoft.Business.Domain.Services.Queries.Department.GetAll;
using PeoManageSoft.Business.Domain.Services.Queries.Department.GetAllWithPagination;
using PeoManageSoft.Business.Domain.Services.Queries.Department.GetByRules;
using PeoManageSoft.Business.Domain.Services.Queries.Department.GetByRulesWithPagination;

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
            services.AddScoped<IGetAllWithPaginationHandler, GetAllWithPaginationHandler>();
            services.AddScoped<IGetAllWithPaginationQuery, GetAllWithPaginationQuery>();
            services.AddScoped<IGetByRulesWithPaginationHandler, GetByRulesWithPaginationHandler>();
            services.AddScoped<IGetByRulesWithPaginationQuery, GetByRulesWithPaginationQuery>();
        }

        #endregion

        #endregion
    }
}
