using AutoMapper;
using PeoManageSoft.Business.Application.Role.Change;
using PeoManageSoft.Business.Application.Role.Delete;
using PeoManageSoft.Business.Application.Role.New;
using PeoManageSoft.Business.Application.Role.Read;
using PeoManageSoft.Business.Application.Role.ReadAllWithPagination;

namespace PeoManageSoft.Business.Application.Role
{
    /// <summary>
    /// Extension methods to add role application mappers.
    /// </summary>
    internal static class RoleApplicationMappers
    {
        #region Methods

        #region public

        /// <summary>
        /// Adds an existing profiles type. Profile will be instantiated and added to the configuration.
        /// </summary>
        /// <param name="services">Create a MapperConfiguration instance and initialize configuration via the constructor.</param>
        public static void AddRoleApplicationProfiles(this IMapperConfigurationExpression configuration)
        {
            configuration.AddProfile<ChangeMapper>();
            configuration.AddProfile<DeleteMapper>();
            configuration.AddProfile<NewMapper>();
            configuration.AddProfile<ReadMapper>();
            configuration.AddProfile<ReadAllWithPaginationMapper>();
        }

        #endregion

        #endregion
    }
}
