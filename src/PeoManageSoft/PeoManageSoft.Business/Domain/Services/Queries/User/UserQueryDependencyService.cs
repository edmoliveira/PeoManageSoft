﻿using Microsoft.Extensions.DependencyInjection;
using PeoManageSoft.Business.Domain.Services.Queries.User.Get;
using PeoManageSoft.Business.Domain.Services.Queries.User.GetAll;
using PeoManageSoft.Business.Domain.Services.Queries.User.GetAllWithPagination;
using PeoManageSoft.Business.Domain.Services.Queries.User.GetByRules;
using PeoManageSoft.Business.Domain.Services.Queries.User.GetByRulesWithPagination;

namespace PeoManageSoft.Business.Domain.Services.Queries.User
{
    /// <summary>
    /// Extension methods to add services from user queries
    /// </summary>
    internal static class UserQueryDependencyService
    {
        #region Methods

        #region public

        /// <summary>
        /// Adds user query services to the container..
        /// </summary>
        /// <param name="services">Specifies the contract for a collection of service descriptors.</param>
        public static void AddUserQueryDependencies(this IServiceCollection services)
        {
            services.AddScoped<IGetHandler, GetHandler>();
            services.AddScoped<IGetQuery, GetQuery>();
            services.AddScoped<IGetAllHandler, GetAllHandler>();
            services.AddScoped<IGetAllQuery, GetAllQuery>();
            services.AddScoped<IGetAllWithPaginationgHandler, GetAllWithPaginationgHandler>();
            services.AddScoped<IGetAllWithPaginationQuery, GetAllWithPaginationQuery>();            
            services.AddScoped<IGetByRulesHandler, GetByRulesHandler>();
            services.AddScoped<IGetByRulesQuery, GetByRulesQuery>();
            services.AddScoped<IGetByRulesWithPaginationHandler, GetByRulesWithPaginationHandler>();
            services.AddScoped<IGetByRulesWithPaginationQuery, GetByRulesWithPaginationQuery>();
        }

        #endregion

        #endregion
    }
}
