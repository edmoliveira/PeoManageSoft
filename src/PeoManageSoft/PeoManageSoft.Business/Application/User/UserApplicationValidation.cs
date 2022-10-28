using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using PeoManageSoft.Business.Application.User.Change;
using PeoManageSoft.Business.Application.User.Delete;
using PeoManageSoft.Business.Application.User.New;
using PeoManageSoft.Business.Application.User.Read;
using PeoManageSoft.Business.Application.User.SignIn;

namespace PeoManageSoft.Business.Application.User
{
    /// <summary>
    /// Extension methods to add validation from user application
    /// </summary>
    internal static class UserApplicationValidation
    {
        #region Methods

        #region public

        /// <summary>
        /// Adds user application validation to the container.
        /// </summary>
        /// <param name="services">Specifies the contract for a collection of service descriptors.</param>
        public static void AddUserApplicationValidation(this IServiceCollection services)
        {
            services.AddScoped<IValidator<NewRequest>, NewValidator>();
            services.AddScoped<IValidator<ChangeRequest>, ChangeValidator>();
            services.AddScoped<IValidator<DeleteRequest>, DeleteValidator>();
            services.AddScoped<IValidator<ReadRequest>, ReadValidator>();
            services.AddScoped<IValidator<SignInRequest>, SignInValidator>();
        }

        #endregion

        #endregion
    }
}

