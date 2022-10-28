using AutoMapper;
using PeoManageSoft.Business.Domain.Services.Commands.User.Add;
using PeoManageSoft.Business.Domain.Services.Commands.User.Update;

namespace PeoManageSoft.Business.Domain.Services.Commands.User
{
    /// <summary>
    /// Extension methods to add user command mappers.
    /// </summary>
    internal static class UserCommandMappers
    {
        #region Methods

        #region public

        /// <summary>
        /// Adds an existing profiles type. Profile will be instantiated and added to the configuration.
        /// </summary>
        /// <param name="services">Create a MapperConfiguration instance and initialize configuration via the constructor.</param>
        public static void AddUserCommandProfiles(this IMapperConfigurationExpression configuration)
        {
            configuration.AddProfile<AddMapper>();
            configuration.AddProfile<UpdateMapper>();
        }

        #endregion

        #endregion
    }
}
