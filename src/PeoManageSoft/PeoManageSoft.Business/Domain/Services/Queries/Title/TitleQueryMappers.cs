using AutoMapper;
using PeoManageSoft.Business.Domain.Services.Queries.Title.Get;

namespace PeoManageSoft.Business.Domain.Services.Queries.Title
{
    /// <summary>
    /// Extension methods to add title query mappers.
    /// </summary>
    internal static class TitleQueryMappers
    {
        #region Methods

        #region public

        /// <summary>
        /// Adds an existing profiles type. Profile will be instantiated and added to the configuration.
        /// </summary>
        /// <param name="services">Create a MapperConfiguration instance and initialize configuration via the constructor.</param>
        public static void AddTitleQueryProfiles(this IMapperConfigurationExpression configuration)
        {
            configuration.AddProfile<GetMapper>();
        }

        #endregion

        #endregion
    }
}
