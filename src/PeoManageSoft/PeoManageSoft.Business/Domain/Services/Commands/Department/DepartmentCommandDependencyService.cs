using Microsoft.Extensions.DependencyInjection;
using PeoManageSoft.Business.Domain.Services.Commands.Department.Add;
using PeoManageSoft.Business.Domain.Services.Commands.Department.Patch;
using PeoManageSoft.Business.Domain.Services.Commands.Department.Remove;
using PeoManageSoft.Business.Domain.Services.Commands.Department.Update;

namespace PeoManageSoft.Business.Domain.Services.Commands.Department
{
    /// <summary>
    /// Extension methods to add services from department commands
    /// </summary>
    internal static class DepartmentCommandDependencyService
    {
        #region Methods

        #region public

        /// <summary>
        /// Adds department command services to the container..
        /// </summary>
        /// <param name="services">Specifies the contract for a collection of service descriptors.</param>
        public static void AddDepartmentCommandDependencies(this IServiceCollection services)
        {
            services.AddScoped<IAddHandler, AddHandler>();
            services.AddScoped<IAddCommand, AddCommand>();
            services.AddScoped<IUpdateHandler, UpdateHandler>();
            services.AddScoped<IUpdateCommand, UpdateCommand>();
            services.AddScoped<IPatchHandler, PatchHandler>();
            services.AddScoped<IPatchCommand, PatchCommand>();
            services.AddScoped<IRemoveHandler, RemoveHandler>();
            services.AddScoped<IRemoveCommand, RemoveCommand>();
        }

        #endregion

        #endregion
    }
}
