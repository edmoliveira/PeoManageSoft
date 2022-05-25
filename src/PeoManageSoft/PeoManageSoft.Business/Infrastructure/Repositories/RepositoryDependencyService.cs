using Microsoft.Extensions.DependencyInjection;
using PeoManageSoft.Business.Infrastructure.Repositories.User;

namespace PeoManageSoft.Business.Domain.Commands.User
{
    /// <summary>
    /// Extension methods for adding repository services
    /// </summary>
    internal static class RepositoryDependencyService
    {
        #region Methods

        #region public

        /// <summary>
        /// Adds repository services to the container.
        /// </summary>
        /// <param name="services">Specifies the contract for a collection of service descriptors.</param>
        public static void AddRepositoryDependencies(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
        }

        #endregion

        #endregion
    }
}
