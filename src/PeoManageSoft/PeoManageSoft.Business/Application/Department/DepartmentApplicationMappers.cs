using AutoMapper;
using PeoManageSoft.Business.Application.Department.Change;
using PeoManageSoft.Business.Application.Department.Delete;
using PeoManageSoft.Business.Application.Department.New;
using PeoManageSoft.Business.Application.Department.Read;

namespace PeoManageSoft.Business.Application.Department
{
    /// <summary>
    /// Extension methods to add department application mappers.
    /// </summary>
    internal static class DepartmentApplicationMappers
    {
        #region Methods

        #region public

        /// <summary>
        /// Adds an existing profiles type. Profile will be instantiated and added to the configuration.
        /// </summary>
        /// <param name="services">Create a MapperConfiguration instance and initialize configuration via the constructor.</param>
        public static void AddDepartmentApplicationProfiles(this IMapperConfigurationExpression configuration)
        {
            configuration.AddProfile<ChangeMapper>();
            configuration.AddProfile<DeleteMapper>();
            configuration.AddProfile<NewMapper>();
            configuration.AddProfile<ReadMapper>();
        }

        #endregion

        #endregion
    }
}
