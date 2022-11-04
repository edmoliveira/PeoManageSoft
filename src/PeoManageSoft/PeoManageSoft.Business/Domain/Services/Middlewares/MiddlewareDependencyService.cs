using Microsoft.Extensions.DependencyInjection;
using PeoManageSoft.Business.Domain.Services.Middlewares.Interfaces;

namespace PeoManageSoft.Business.Domain.Services.Middlewares
{
    /// <summary>
    /// Extension methods to add services from middlewares
    /// </summary>
    internal static class MiddlewareDependencyService
    {
        #region Methods

        #region public

        /// <summary>
        /// Adds middlewares services to the container..
        /// </summary>
        /// <param name="services">Specifies the contract for a collection of service descriptors.</param>
        public static void AddMiddlewareDependencies(this IServiceCollection services)
        {
            services.AddTransient<IMailMiddleware>(c =>
            {
                return new MailMiddleware(
                    new System.Net.Mail.SmtpClient(),
                    new System.Net.Mail.MailMessage()
                );
            });
        }

        #endregion

        #endregion
    }
}
