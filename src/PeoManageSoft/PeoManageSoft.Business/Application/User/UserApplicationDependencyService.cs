using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using PeoManageSoft.Business.Application.User.ActivateUser;
using PeoManageSoft.Business.Application.User.Change;
using PeoManageSoft.Business.Application.User.ChangePassword;
using PeoManageSoft.Business.Application.User.CreateNewPassword;
using PeoManageSoft.Business.Application.User.Delete;
using PeoManageSoft.Business.Application.User.New;
using PeoManageSoft.Business.Application.User.Read;
using PeoManageSoft.Business.Application.User.ReadAll;
using PeoManageSoft.Business.Application.User.SendPasswordToken;
using PeoManageSoft.Business.Application.User.SendReminderActivateUser;
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
            services.AddScoped<IActivateUserApplication, ActivateUserApplication>();
            services.AddScoped<IUserApplicationFacade, UserApplicationFacade>();
            services.AddScoped<IChangeApplication, ChangeApplication>();
            services.AddScoped<IChangeValidation, ChangeValidation>();
            services.AddScoped<IChangePasswordApplication, ChangePasswordApplication>();
            services.AddScoped<ICreateNewPasswordApplication, CreateNewPasswordApplication>();
            services.AddScoped<IDeleteApplication, DeleteApplication>();
            services.AddScoped<IDeleteValidation, DeleteValidation>();
            services.AddScoped<INewApplication, NewApplication>();
            services.AddScoped<INewValidation, NewValidation>();
            services.AddScoped<IReadApplication, ReadApplication>();
            services.AddScoped<IReadValidation, ReadValidation>(); 
            services.AddScoped<IReadAllApplication, ReadAllApplication>();
            services.AddScoped<ISendPasswordTokenApplication, SendPasswordTokenApplication>();
            services.AddScoped<ISendReminderActivateUserApplication, SendReminderActivateUserApplication>();
            services.AddScoped<ISignInApplication, SignInApplication>();
            services.AddScoped<IValidatePasswordTokenApplication, ValidatePasswordTokenApplication>();
        }

        /// <summary>
        /// Adds user application validation to the container.
        /// </summary>
        /// <param name="services">Specifies the contract for a collection of service descriptors.</param>
        public static void AddUserApplicationValidation(this IServiceCollection services)
        {
            services.AddScoped<IValidator<ActivateUserRequest>, ActivateUserValidator>();
            services.AddScoped<IValidator<ChangeRequest>, ChangeValidator>();
            services.AddScoped<IValidator<ChangePasswordRequest>, ChangePasswordValidator>();
            services.AddScoped<IValidator<CreateNewPasswordRequest>, CreateNewPasswordValidator>();
            services.AddScoped<IValidator<DeleteRequest>, DeleteValidator>();
            services.AddScoped<IValidator<NewRequest>, NewValidator>();
            services.AddScoped<IValidator<ReadRequest>, ReadValidator>();
            services.AddScoped<IValidator<SendPasswordTokenRequest>, SendPasswordTokenValidator>();
            services.AddScoped<IValidator<SendReminderActivateUserRequest>, SendReminderActivateUserValidator>();
            services.AddScoped<IValidator<SignInRequest>, SignInValidator>();
            services.AddScoped<IValidator<ValidatePasswordTokenRequest>, ValidatePasswordTokenValidator>();
        }

        #endregion

        #endregion
    }
}
