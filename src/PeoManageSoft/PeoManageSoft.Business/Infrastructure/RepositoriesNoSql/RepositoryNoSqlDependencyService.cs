using Microsoft.Extensions.DependencyInjection;

namespace PeoManageSoft.Business.Infrastructure.RepositoriesNoSql
{
    /// <summary>
    /// Extension methods for adding repository no sql services
    /// </summary>
    internal static class RepositoryNoSqlDependencyService
    {
        #region Methods

        #region public

        /// <summary>
        /// Adds repository no sql services to the container.
        /// </summary>
        /// <param name="services">Specifies the contract for a collection of service descriptors.</param>
        public static void AddRepositoryNoSqlDependencies(this IServiceCollection services)
        {
            services.AddScoped<IScopeNoSql, ScopeNoSql>();
            services.AddScoped<IRepositoryNoSql, RepositoryNoSql>();
        }

        #endregion

        #endregion
    }
}
