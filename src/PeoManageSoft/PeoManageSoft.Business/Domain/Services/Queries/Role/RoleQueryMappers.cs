using AutoMapper;
using PeoManageSoft.Business.Domain.Services.Queries.Role.Get;
using PeoManageSoft.Business.Domain.Services.Queries.Role.GetResources;

namespace PeoManageSoft.Business.Domain.Services.Queries.Role
{
    /// <summary>
    /// Extension methods to add role query mappers.
    /// </summary>
    internal static class RoleQueryMappers
    {
        #region Methods

        #region public

        /// <summary>
        /// Adds an existing profiles type. Profile will be instantiated and added to the configuration.
        /// </summary>
        /// <param name="services">Create a MapperConfiguration instance and initialize configuration via the constructor.</param>
        public static void AddRoleQueryProfiles(this IMapperConfigurationExpression configuration)
        {
            configuration.AddProfile<GetMapper>();
            configuration.AddProfile<GetResourcesMapper>();
        }

        #endregion

        #endregion
    }
}
