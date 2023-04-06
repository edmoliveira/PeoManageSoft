using AutoMapper;
using PeoManageSoft.Business.Domain.Services.Queries.User.Get;
using PeoManageSoft.Business.Domain.Services.Queries.User.GetPolicies;

namespace PeoManageSoft.Business.Domain.Services.Queries.User
{
    /// <summary>
    /// Extension methods to add user query mappers.
    /// </summary>
    internal static class UserQueryMappers
    {
        #region Methods

        #region public

        /// <summary>
        /// Adds an existing profiles type. Profile will be instantiated and added to the configuration.
        /// </summary>
        /// <param name="services">Create a MapperConfiguration instance and initialize configuration via the constructor.</param>
        public static void AddUserQueryProfiles(this IMapperConfigurationExpression configuration)
        {
            configuration.AddProfile<GetMapper>();
            configuration.AddProfile<GetPoliciesMapper>();
        }

        #endregion

        #endregion
    }
}
