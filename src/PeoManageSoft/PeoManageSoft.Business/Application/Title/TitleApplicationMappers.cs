using AutoMapper;
using PeoManageSoft.Business.Application.Title.Change;
using PeoManageSoft.Business.Application.Title.Delete;
using PeoManageSoft.Business.Application.Title.New;
using PeoManageSoft.Business.Application.Title.Read;
using PeoManageSoft.Business.Application.Title.ReadAllWithPagination;

namespace PeoManageSoft.Business.Application.Title
{
    /// <summary>
    /// Extension methods to add title application mappers.
    /// </summary>
    internal static class TitleApplicationMappers
    {
        #region Methods

        #region public

        /// <summary>
        /// Adds an existing profiles type. Profile will be instantiated and added to the configuration.
        /// </summary>
        /// <param name="services">Create a MapperConfiguration instance and initialize configuration via the constructor.</param>
        public static void AddTitleApplicationProfiles(this IMapperConfigurationExpression configuration)
        {
            configuration.AddProfile<ChangeMapper>();
            configuration.AddProfile<DeleteMapper>();
            configuration.AddProfile<NewMapper>();
            configuration.AddProfile<ReadMapper>();
            configuration.AddProfile<ReadAllWithPaginationMapper>();
        }

        #endregion

        #endregion
    }
}
