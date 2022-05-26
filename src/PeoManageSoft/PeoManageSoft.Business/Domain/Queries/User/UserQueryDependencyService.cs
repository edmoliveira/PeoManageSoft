using Microsoft.Extensions.DependencyInjection;
using PeoManageSoft.Business.Domain.Queries.User.Get;
using PeoManageSoft.Business.Domain.Queries.User.GetAll;

namespace PeoManageSoft.Business.Domain.Queries.User
{
    /// <summary>
    /// Extension methods to add services from user queries
    /// </summary>
    internal static class UserQueryDependencyService
    {
        #region Methods

        #region public

        /// <summary>
        /// Adds user query services to the container..
        /// </summary>
        /// <param name="services">Specifies the contract for a collection of service descriptors.</param>
        public static void AddUserQueryDependencies(this IServiceCollection services)
        {
            services.AddScoped<IGetHandler, GetHandler>();
            services.AddScoped<IGetQuery, GetQuery>();
            services.AddScoped<IGetAllHandler, GetAllHandler>();
            services.AddScoped<IGetAllQuery, GetAllQuery>();
        }

        #endregion

        #endregion
    }
}
