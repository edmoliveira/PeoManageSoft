using AutoMapper;
using PeoManageSoft.Business.Domain.Services.Commands.Department.Add;
using PeoManageSoft.Business.Domain.Services.Commands.Department.Update;

namespace PeoManageSoft.Business.Domain.Services.Commands.Department
{
    /// <summary>
    /// Extension methods to add department command mappers.
    /// </summary>
    internal static class DepartmentCommandMappers
    {
        #region Methods

        #region public

        /// <summary>
        /// Adds an existing profiles type. Profile will be instantiated and added to the configuration.
        /// </summary>
        /// <param name="services">Create a MapperConfiguration instance and initialize configuration via the constructor.</param>
        public static void AddDepartmentCommandProfiles(this IMapperConfigurationExpression configuration)
        {
            configuration.AddProfile<AddMapper>();
            configuration.AddProfile<UpdateMapper>();
        }

        #endregion

        #endregion
    }
}
