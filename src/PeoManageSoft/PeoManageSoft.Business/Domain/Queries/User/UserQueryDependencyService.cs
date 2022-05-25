﻿using Microsoft.Extensions.DependencyInjection;
using PeoManageSoft.Business.Domain.Commands.User.Add;
using PeoManageSoft.Business.Domain.Commands.User.Remove;
using PeoManageSoft.Business.Domain.Commands.User.Update;

namespace PeoManageSoft.Business.Domain.Queries.User
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
            services.AddScoped<IAddHandler, AddHandler>();
            services.AddScoped<IAddCommand, AddCommand>();
            services.AddScoped<IUpdateHandler, UpdateHandler>();
            services.AddScoped<IUpdateCommand, UpdateCommand>();
            services.AddScoped<IRemoveHandler, RemoveHandler>();
            services.AddScoped<IRemoveCommand, RemoveCommand>();
        }

        #endregion

        #endregion
    }
}
