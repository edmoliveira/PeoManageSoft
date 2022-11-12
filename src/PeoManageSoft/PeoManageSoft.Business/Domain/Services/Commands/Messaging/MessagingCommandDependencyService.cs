using Microsoft.Extensions.DependencyInjection;
using PeoManageSoft.Business.Domain.Services.Commands.Messaging.SendEmail;

namespace PeoManageSoft.Business.Domain.Services.Commands.Messaging
{
    /// <summary>
    /// Extension methods to add services from messaging commands
    /// </summary>
    internal static class MessagingCommandDependencyService
    {
        #region Methods

        #region public

        /// <summary>
        /// Adds messaging commands services to the container.
        /// </summary>
        /// <param name="services">Specifies the contract for a collection of service descriptors.</param>
        public static void AddMessagingCommandDependencies(this IServiceCollection services)
        {
            services.AddScoped<ISendEmailHandler, SendEmailHandler>();
            services.AddScoped<ISendEmailCommand, SendEmailCommand>();
        }

        #endregion

        #endregion
    }
}
