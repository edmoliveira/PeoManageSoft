using Microsoft.Extensions.DependencyInjection;
using PeoManageSoft.Business.Domain.Services.Factories.Interfaces;

namespace PeoManageSoft.Business.Domain.Services.Factories
{
    /// <summary>
    /// Extension methods to add services from factories
    /// </summary>
    internal static class FactoryDependencyService
    {
        #region Methods

        #region public

        /// <summary>
        /// Adds factories services to the container..
        /// </summary>
        /// <param name="services">Specifies the contract for a collection of service descriptors.</param>
        public static void AddFactoryDependencies(this IServiceCollection services)
        {
            services.AddSingleton<IRepositoryFactory, RepositoryFactory>();
        }

        #endregion

        #endregion
    }
}

