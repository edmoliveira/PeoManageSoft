using AutoMapper;
using PeoManageSoft.Business.Infrastructure.RepositoriesNoSql.Databases.Authorization.Role.Models;

namespace PeoManageSoft.Business.Domain.Services.Queries.Role.GetResources
{
    /// <summary>
    /// Configuration for maps.
    /// </summary>
    internal sealed class GetResourcesMapper : Profile
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the PeoManageSoft.Business.Domain.Services.Queries.Role.GetResources.GetResourcesMapper class.
        /// </summary>
        public GetResourcesMapper()
        {
            CreateMap<ResourceDocument, GetResourcesResponse>()
            .ForMember(dest => dest.ResourceName, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.Permissions, opt => opt.MapFrom(src => src.Permissions));
        }

        #endregion
    }
}
