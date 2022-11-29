using Microsoft.Extensions.DependencyInjection;
using PeoManageSoft.Business.Domain.Services.Queries.Title.Get;
using PeoManageSoft.Business.Domain.Services.Queries.Title.GetAll;
using PeoManageSoft.Business.Domain.Services.Queries.Title.GetAllWithPagination;
using PeoManageSoft.Business.Domain.Services.Queries.Title.GetByRules;
using PeoManageSoft.Business.Domain.Services.Queries.Title.GetByRulesWithPagination;

namespace PeoManageSoft.Business.Domain.Services.Queries.Title
{
    /// <summary>
    /// Extension methods to add services from title queries
    /// </summary>
    internal static class TitleQueryDependencyService
    {
        #region Methods

        #region public

        /// <summary>
        /// Adds title query services to the container..
        /// </summary>
        /// <param name="services">Specifies the contract for a collection of service descriptors.</param>
        public static void AddTitleQueryDependencies(this IServiceCollection services)
        {
            services.AddScoped<IGetHandler, GetHandler>();
            services.AddScoped<IGetQuery, GetQuery>();
            services.AddScoped<IGetAllHandler, GetAllHandler>();
            services.AddScoped<IGetAllQuery, GetAllQuery>();
            services.AddScoped<IGetByRulesHandler, GetByRulesHandler>();
            services.AddScoped<IGetByRulesQuery, GetByRulesQuery>();
            services.AddScoped<IGetAllWithPaginationgHandler, GetAllWithPaginationgHandler>();
            services.AddScoped<IGetAllWithPaginationQuery, GetAllWithPaginationQuery>();
            services.AddScoped<IGetByRulesWithPaginationHandler, GetByRulesWithPaginationHandler>();
            services.AddScoped<IGetByRulesWithPaginationQuery, GetByRulesWithPaginationQuery>();
        }

        #endregion

        #endregion
    }
}
