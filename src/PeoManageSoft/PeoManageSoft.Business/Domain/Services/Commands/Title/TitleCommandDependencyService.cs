using Microsoft.Extensions.DependencyInjection;
using PeoManageSoft.Business.Domain.Services.Commands.Title.Add;
using PeoManageSoft.Business.Domain.Services.Commands.Title.Patch;
using PeoManageSoft.Business.Domain.Services.Commands.Title.Remove;
using PeoManageSoft.Business.Domain.Services.Commands.Title.Update;

namespace PeoManageSoft.Business.Domain.Services.Commands.Title
{
    /// <summary>
    /// Extension methods to add services from title commands
    /// </summary>
    internal static class TitleCommandDependencyService
    {
        #region Methods

        #region public

        /// <summary>
        /// Adds title command services to the container..
        /// </summary>
        /// <param name="services">Specifies the contract for a collection of service descriptors.</param>
        public static void AddTitleCommandDependencies(this IServiceCollection services)
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
