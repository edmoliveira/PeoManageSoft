using Microsoft.Extensions.DependencyInjection;
using PeoManageSoft.Business.Domain.Services.Commands.Role.Add;
using PeoManageSoft.Business.Domain.Services.Commands.Role.Patch;
using PeoManageSoft.Business.Domain.Services.Commands.Role.Remove;
using PeoManageSoft.Business.Domain.Services.Commands.Role.Update;

namespace PeoManageSoft.Business.Domain.Services.Commands.Role
{
    /// <summary>
    /// Extension methods to add services from role commands
    /// </summary>
    internal static class RoleCommandDependencyService
    {
        #region Methods

        #region public

        /// <summary>
        /// Adds role command services to the container..
        /// </summary>
        /// <param name="services">Specifies the contract for a collection of service descriptors.</param>
        public static void AddRoleCommandDependencies(this IServiceCollection services)
        {
            services.AddScoped<IAddHandler, AddHandler>();
            services.AddScoped<IAddCommand, AddCommand>();
            services.AddScoped<IAddResourceCommand, AddResourceCommand>(); 
            services.AddScoped<IUpdateHandler, UpdateHandler>();
            services.AddScoped<IUpdateCommand, UpdateCommand>();
            services.AddScoped<IUpdateResourceCommand, UpdateResourceCommand>();
            services.AddScoped<IPatchHandler, PatchHandler>();
            services.AddScoped<IPatchCommand, PatchCommand>();
            services.AddScoped<IRemoveHandler, RemoveHandler>();
            services.AddScoped<IRemoveCommand, RemoveCommand>();
            services.AddScoped<IRemoveResourceCommand, RemoveResourceCommand>();
        }

        #endregion

        #endregion
    }
}
