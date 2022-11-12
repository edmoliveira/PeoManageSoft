using AutoMapper;
using PeoManageSoft.Business.Domain.Services.Commands.Title.Add;
using PeoManageSoft.Business.Domain.Services.Commands.Title.Update;

namespace PeoManageSoft.Business.Domain.Services.Commands.Title
{
    /// <summary>
    /// Extension methods to add title command mappers.
    /// </summary>
    internal static class TitleCommandMappers
    {
        #region Methods

        #region public

        /// <summary>
        /// Adds an existing profiles type. Profile will be instantiated and added to the configuration.
        /// </summary>
        /// <param name="services">Create a MapperConfiguration instance and initialize configuration via the constructor.</param>
        public static void AddTitleCommandProfiles(this IMapperConfigurationExpression configuration)
        {
            configuration.AddProfile<AddMapper>();
            configuration.AddProfile<UpdateMapper>();
        }

        #endregion

        #endregion
    }
}
