using Microsoft.Extensions.DependencyInjection;
using PeoManageSoft.Business.Domain.Services.Queries.Role.Get;
using PeoManageSoft.Business.Domain.Services.Queries.Role.GetAll;
using PeoManageSoft.Business.Domain.Services.Queries.Role.GetAllWithPagination;
using PeoManageSoft.Business.Domain.Services.Queries.Role.GetByRules;
using PeoManageSoft.Business.Domain.Services.Queries.Role.GetByRulesWithPagination;
using PeoManageSoft.Business.Domain.Services.Queries.Role.GetResources;

namespace PeoManageSoft.Business.Domain.Services.Queries.Role
{
    /// <summary>
    /// Extension methods to add services from role queries
    /// </summary>
    internal static class RoleQueryDependencyService
    {
        #region Methods

        #region public

        /// <summary>
        /// Adds role query services to the container..
        /// </summary>
        /// <param name="services">Specifies the contract for a collection of service descriptors.</param>
        public static void AddRoleQueryDependencies(this IServiceCollection services)
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
            services.AddScoped<IGetResourcesHandler, GetResourcesHandler>();
            services.AddScoped<IGetResourcesQuery, GetResourcesQuery>();
        }

        #endregion

        #endregion
    }
}
