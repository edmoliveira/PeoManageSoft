using Microsoft.Extensions.DependencyInjection;
using PeoManageSoft.Business.Domain.Services.Creators.ActiveUserEmail;
using PeoManageSoft.Business.Domain.Services.Creators.ActiveUserEmail.Interfaces;
using PeoManageSoft.Business.Domain.Services.Creators.RememberPasswordEmail;
using PeoManageSoft.Business.Domain.Services.Creators.RememberPasswordEmail.Interfaces;

namespace PeoManageSoft.Business.Domain.Services.Creators
{
    /// <summary>
    /// Extension methods to add services from creators
    /// </summary>
    internal static class CreatorDependencyService
    {
        #region Methods

        #region public

        /// <summary>
        /// Adds creators services to the container..
        /// </summary>
        /// <param name="services">Specifies the contract for a collection of service descriptors.</param>
        public static void AddCreatorDependencies(this IServiceCollection services)
        {
            services.AddSingleton<IRememberPasswordEmailCreator, RememberPasswordEmailCreator>();
            services.AddSingleton<IActiveUserEmailCreator, ActiveUserEmailCreator>();
        }

        #endregion

        #endregion
    }
}