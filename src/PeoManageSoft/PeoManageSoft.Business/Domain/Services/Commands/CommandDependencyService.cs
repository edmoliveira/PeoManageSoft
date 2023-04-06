using Microsoft.Extensions.DependencyInjection;
using PeoManageSoft.Business.Domain.Services.Commands.Department;
using PeoManageSoft.Business.Domain.Services.Commands.Messaging;
using PeoManageSoft.Business.Domain.Services.Commands.Role;
using PeoManageSoft.Business.Domain.Services.Commands.Title;
using PeoManageSoft.Business.Domain.Services.Commands.User;

namespace PeoManageSoft.Business.Domain.Services.Commands
{
    /// <summary>
    /// Extension methods to add services from commands
    /// </summary>
    internal static class CommandDependencyService
    {
        #region Methods

        #region public

        /// <summary>
        /// Adds commands services to the container.
        /// </summary>
        /// <param name="services">Specifies the contract for a collection of service descriptors.</param>
        public static void AddCommandDependencies(this IServiceCollection services)
        {
            services.AddRoleCommandDependencies();
            services.AddUserCommandDependencies();
            services.AddTitleCommandDependencies();
            services.AddDepartmentCommandDependencies();
            services.AddMessagingCommandDependencies();
        }

        #endregion

        #endregion
    }
}
