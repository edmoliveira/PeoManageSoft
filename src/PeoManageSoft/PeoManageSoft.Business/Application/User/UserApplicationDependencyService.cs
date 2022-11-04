using Microsoft.Extensions.DependencyInjection;
using PeoManageSoft.Business.Application.User.Change;
using PeoManageSoft.Business.Application.User.ChangePassword;
using PeoManageSoft.Business.Application.User.CreateNewPassword;
using PeoManageSoft.Business.Application.User.Delete;
using PeoManageSoft.Business.Application.User.New;
using PeoManageSoft.Business.Application.User.Read;
using PeoManageSoft.Business.Application.User.ReadAll;
using PeoManageSoft.Business.Application.User.SendPasswordToken;
using PeoManageSoft.Business.Application.User.SignIn;
using PeoManageSoft.Business.Application.User.ValidatePasswordToken;

namespace PeoManageSoft.Business.Application.User
{
    /// <summary>
    /// Extension methods to add services from user application
    /// </summary>
    internal static class UserApplicationDependencyService
    {
        #region Methods

        #region public

        /// <summary>
        /// Adds user application services to the container.
        /// </summary>
        /// <param name="services">Specifies the contract for a collection of service descriptors.</param>
        public static void AddUserApplicationDependencies(this IServiceCollection services)
        {
            services.AddScoped<IUserApplicationFacade, UserApplicationFacade>();
            services.AddScoped<IChangeApplication, ChangeApplication>();
            services.AddScoped<IChangePasswordApplication, ChangePasswordApplication>();
            services.AddScoped<ICreateNewPasswordApplication, CreateNewPasswordApplication>();
            services.AddScoped<IDeleteApplication, DeleteApplication>();
            services.AddScoped<INewApplication, NewApplication>();            
            services.AddScoped<IReadApplication, ReadApplication>();
            services.AddScoped<IReadAllApplication, ReadAllApplication>();
            services.AddScoped<ISendPasswordTokenApplication, SendPasswordTokenApplication>();
            services.AddScoped<ISignInApplication, SignInApplication>();
            services.AddScoped<IValidatePasswordTokenApplication, ValidatePasswordTokenApplication>();
        }

        #endregion

        #endregion
    }
}
