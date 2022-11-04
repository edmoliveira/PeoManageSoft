using Microsoft.Extensions.DependencyInjection;
using PeoManageSoft.Business.Domain.Services.Commands.Messaging.SendEmail;
using PeoManageSoft.Business.Domain.Services.Commands.User.Add;
using PeoManageSoft.Business.Domain.Services.Commands.User.CreateToken;
using PeoManageSoft.Business.Domain.Services.Commands.User.Patch;
using PeoManageSoft.Business.Domain.Services.Commands.User.Remove;
using PeoManageSoft.Business.Domain.Services.Commands.User.Update;

namespace PeoManageSoft.Business.Domain.Services.Commands.User
{
    /// <summary>
    /// Extension methods to add services from user commands
    /// </summary>
    internal static class UserCommandDependencyService
    {
        #region Methods

        #region public

        /// <summary>
        /// Adds user command services to the container..
        /// </summary>
        /// <param name="services">Specifies the contract for a collection of service descriptors.</param>
        public static void AddUserCommandDependencies(this IServiceCollection services)
        {
            services.AddScoped<IAddHandler, AddHandler>();
            services.AddScoped<IAddCommand, AddCommand>();
            services.AddScoped<IUpdateHandler, UpdateHandler>();
            services.AddScoped<IUpdateCommand, UpdateCommand>();
            services.AddScoped<IPatchHandler, PatchHandler>();
            services.AddScoped<IPatchCommand, PatchCommand>();
            services.AddScoped<IRemoveHandler, RemoveHandler>();
            services.AddScoped<IRemoveCommand, RemoveCommand>();
            services.AddScoped<ICreateTokenHandler, CreateTokenHandler>();
            services.AddScoped<ICreateTokenCommand, CreateTokenCommand>();
            services.AddScoped<ISendEmailHandler, SendEmailHandler>();
            services.AddScoped<ISendEmailCommand, SendEmailCommand>();
        }

        #endregion

        #endregion
    }
}
