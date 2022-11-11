using Microsoft.Extensions.DependencyInjection;
using PeoManageSoft.Business.Domain.Services.Functions.User.ActivateUser;
using PeoManageSoft.Business.Domain.Services.Functions.User.EmailExists;
using PeoManageSoft.Business.Domain.Services.Functions.User.Exists;
using PeoManageSoft.Business.Domain.Services.Functions.User.GetByAuthentication;
using PeoManageSoft.Business.Domain.Services.Functions.User.GetByEmail;
using PeoManageSoft.Business.Domain.Services.Functions.User.GetByPasswordToken;
using PeoManageSoft.Business.Domain.Services.Functions.User.LoginExists;
using PeoManageSoft.Business.Domain.Services.Functions.User.PutPassword;
using PeoManageSoft.Business.Domain.Services.Functions.User.PutPasswordToken;
using PeoManageSoft.Business.Domain.Services.Functions.User.SendEmailToActiveUser;

namespace PeoManageSoft.Business.Domain.Services.Functions.User
{
    /// <summary>
    /// Extension methods to add services from user functions
    /// </summary>
    internal static class UserFunctionDependencyService
    {
        #region Methods

        #region public

        /// <summary>
        /// Adds user functions services to the container.
        /// </summary>
        /// <param name="services">Specifies the contract for a collection of service descriptors.</param>
        public static void AddUserFunctionDependencies(this IServiceCollection services)
        {
            services.AddScoped<IActivateUserFunction, ActivateUserFunction>();
            services.AddScoped<IUserFunctionFacade, UserFunctionFacade>();
            services.AddScoped<IExistsFunction, ExistsFunction>();
            services.AddScoped<IGetByPasswordTokenFunction, GetByPasswordTokenFunction>();
            services.AddScoped<IGetByAuthenticationFunction, GetByAuthenticationFunction>();
            services.AddScoped<IPutPasswordFunction, PutPasswordFunction>();
            services.AddScoped<IGetByEmailFunction, GetByEmailFunction>();
            services.AddScoped<IPutPasswordTokenFunction, PutPasswordTokenFunction>();
            services.AddScoped<IEmailExistsFunction, EmailExistsFunction>();
            services.AddScoped<ILoginExistsFunction, LoginExistsFunction>();
            services.AddScoped<ISendEmailToActiveUserFunction, SendEmailToActiveUserFunction>();
        }

        #endregion

        #endregion
    }
}
