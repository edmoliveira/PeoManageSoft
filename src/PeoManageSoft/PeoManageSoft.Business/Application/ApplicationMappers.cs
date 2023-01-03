using AutoMapper;
using PeoManageSoft.Business.Application.Department;
using PeoManageSoft.Business.Application.Title;
using PeoManageSoft.Business.Application.User;

namespace PeoManageSoft.Business.Application
{
    /// <summary>
    /// Extension methods to add application mappers.
    /// </summary>
    internal static class ApplicationMappers
    {
        #region Methods

        #region public

        /// <summary>
        /// Adds an existing profiles type. Profile will be instantiated and added to the configuration.
        /// </summary>
        /// <param name="configuration">Create a MapperConfiguration instance and initialize configuration via the constructor.</param>
        public static void AddApplicationProfiles(this IMapperConfigurationExpression configuration)
        {
            configuration.AddUserApplicationProfiles();
            configuration.AddTitleApplicationProfiles();
            configuration.AddDepartmentApplicationProfiles();
        }

        #endregion

        #endregion
    }
}
