using AutoMapper;
using PeoManageSoft.Business.Domain.Services.Queries.Department.Get;

namespace PeoManageSoft.Business.Domain.Services.Queries.Department
{
    /// <summary>
    /// Extension methods to add department query mappers.
    /// </summary>
    internal static class DepartmentQueryMappers
    {
        #region Methods

        #region public

        /// <summary>
        /// Adds an existing profiles type. Profile will be instantiated and added to the configuration.
        /// </summary>
        /// <param name="services">Create a MapperConfiguration instance and initialize configuration via the constructor.</param>
        public static void AddDepartmentQueryProfiles(this IMapperConfigurationExpression configuration)
        {
            configuration.AddProfile<GetMapper>();
        }

        #endregion

        #endregion
    }
}
