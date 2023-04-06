using AutoMapper;
using PeoManageSoft.Business.Domain.Services.Queries.Department;
using PeoManageSoft.Business.Domain.Services.Queries.Role;
using PeoManageSoft.Business.Domain.Services.Queries.Title;
using PeoManageSoft.Business.Domain.Services.Queries.User;

namespace PeoManageSoft.Business.Domain.Services.Queries
{
    /// <summary>
    /// Extension methods to add query mappers.
    /// </summary>
    internal static class QueryMappers
    {
        #region Methods

        #region public

        /// <summary>
        /// Adds an existing profiles type. Profile will be instantiated and added to the configuration.
        /// </summary>
        /// <param name="configuration">Create a MapperConfiguration instance and initialize configuration via the constructor.</param>
        public static void AddQueryProfiles(this IMapperConfigurationExpression configuration)
        {
            configuration.AddUserQueryProfiles();
            configuration.AddTitleQueryProfiles();
            configuration.AddDepartmentQueryProfiles();
            configuration.AddRoleQueryProfiles();
        }

        #endregion

        #endregion
    }
}
