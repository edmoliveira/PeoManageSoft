using AutoMapper;
using PeoManageSoft.Business.Domain.Services.Commands.Role.Add;
using PeoManageSoft.Business.Domain.Services.Commands.Role.Update;

namespace PeoManageSoft.Business.Domain.Services.Commands.Role
{
    /// <summary>
    /// Extension methods to add role command mappers.
    /// </summary>
    internal static class RoleCommandMappers
    {
        #region Methods

        #region public

        /// <summary>
        /// Adds an existing profiles type. Profile will be instantiated and added to the configuration.
        /// </summary>
        /// <param name="services">Create a MapperConfiguration instance and initialize configuration via the constructor.</param>
        public static void AddRoleCommandProfiles(this IMapperConfigurationExpression configuration)
        {
            configuration.AddProfile<AddMapper>();
            configuration.AddProfile<UpdateMapper>();
        }

        #endregion

        #endregion
    }
}
