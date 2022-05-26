using Microsoft.Extensions.DependencyInjection;
using PeoManageSoft.Business.Application.User.New;
using PeoManageSoft.Business.Application.User.ReadAll;

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
            services.AddScoped<INewApplication, NewApplication>();
            services.AddScoped<IReadAllApplication, ReadAllApplication>();
        }

        #endregion

        #endregion
    }
}
