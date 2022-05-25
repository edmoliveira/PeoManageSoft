using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using PeoManageSoft.Business.Application.User.New;

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
        }

        #endregion

        #endregion
    }
}

