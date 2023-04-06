using AutoMapper;
using PeoManageSoft.Business.Infrastructure.RepositoriesNoSql.Databases.Authorization.Policy;

namespace PeoManageSoft.Business.Domain.Services.Queries.User.GetPolicies
{
    /// <summary>
    /// Configuration for maps.
    /// </summary>
    internal sealed class GetPoliciesMapper : Profile
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the PeoManageSoft.Business.Domain.Services.Queries.User.GetPolicies.GetPoliciesMapper class.
        /// </summary>
        public GetPoliciesMapper()
        {
            CreateMap<PolicyDocument, GetPoliciesResponse>()
            .ForMember(dest => dest.ResourceName, opt => opt.MapFrom(src => src.ResourceName))
            .ForMember(dest => dest.Permissions, opt => opt.MapFrom(src => src.Permissions));
        }

        #endregion
    }
}
