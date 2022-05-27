using AutoMapper;
using PeoManageSoft.Business.Application.User.Delete;
using PeoManageSoft.Business.Application.User.New;
using PeoManageSoft.Business.Application.User.Read;
using PeoManageSoft.Business.Application.User.ReadAll;

namespace PeoManageSoft.Business.Application.User
{
    /// <summary>
    /// Extension methods to add user application mappers.
    /// </summary>
    internal static class UserApplicationMappers
    {
        #region Methods

        #region public

        /// <summary>
        /// Adds an existing profiles type. Profile will be instantiated and added to the configuration.
        /// </summary>
        /// <param name="services">Create a MapperConfiguration instance and initialize configuration via the constructor.</param>
        public static void AddUserApplicationProfiles(this IMapperConfigurationExpression configuration)
        {
            configuration.AddProfile<NewMapper>();
            configuration.AddProfile<DeleteMapper>();
            configuration.AddProfile<ReadMapper>();
            configuration.AddProfile<ReadAllMapper>();
        }

        #endregion

        #endregion
    }
}
