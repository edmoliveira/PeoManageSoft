using AutoMapper;
using PeoManageSoft.Business.Infrastructure.Repositories.Department;
using PeoManageSoft.Business.Infrastructure.Repositories.Title;
using PeoManageSoft.Business.Infrastructure.Repositories.User;

namespace PeoManageSoft.Business.Infrastructure.Repositories
{
    /// <summary>
    /// Extension methods to add repository mappers.
    /// </summary>
    internal static class RepositoryMappers
    {
        #region Methods

        #region public

        /// <summary>
        /// Adds an existing profiles type. Profile will be instantiated and added to the configuration.
        /// </summary>
        /// <param name="configuration">Create a MapperConfiguration instance and initialize configuration via the constructor.</param>
        public static void AddRepositoryProfiles(this IMapperConfigurationExpression configuration)
        {
            configuration.AddProfile(new UserMapper());
            configuration.AddProfile(new TitleMapper());
            configuration.AddProfile(new DepartmentMapper());
        }

        #endregion

        #endregion
    }
}
