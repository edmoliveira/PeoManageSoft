using AutoMapper;
using PeoManageSoft.Business.Domain.Services.Commands.Department;
using PeoManageSoft.Business.Domain.Services.Commands.Title;
using PeoManageSoft.Business.Domain.Services.Commands.User;

namespace PeoManageSoft.Business.Domain.Services.Commands
{
    /// <summary>
    /// Extension methods to add command mappers.
    /// </summary>
    internal static class CommandMappers
    {
        #region Methods

        #region public

        /// <summary>
        /// Adds an existing profiles type. Profile will be instantiated and added to the configuration.
        /// </summary>
        /// <param name="configuration">Create a MapperConfiguration instance and initialize configuration via the constructor.</param>
        public static void AddCommandProfiles(this IMapperConfigurationExpression configuration)
        {
            configuration.AddUserCommandProfiles();
            configuration.AddTitleCommandProfiles();
            configuration.AddDepartmentCommandProfiles();
        }

        #endregion

        #endregion
    }
}
