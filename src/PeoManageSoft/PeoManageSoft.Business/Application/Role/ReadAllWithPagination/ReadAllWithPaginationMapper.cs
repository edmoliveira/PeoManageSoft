using AutoMapper;
using PeoManageSoft.Business.Domain.Services.Queries.Role.GetAllWithPagination;
using PeoManageSoft.Business.Infrastructure.ObjectRelationalMapper;
using PeoManageSoft.Business.Infrastructure.Repositories.Role;

namespace PeoManageSoft.Business.Application.Role.ReadAllWithPagination
{
    /// <summary>
    /// Configuration for maps.
    /// </summary>
    internal sealed class ReadAllWithPaginationMapper : Profile
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the PeoManageSoft.Business.Application.Role.ReadAllWithPagination.ReadAllWithPaginationMapper class.
        /// </summary>
        public ReadAllWithPaginationMapper()
        {
            CreateMap<ReadAllWithPaginationRequest, GetAllWithPaginationRequest>()
                .ForMember(dest => dest.Page, opt => opt.MapFrom(src => src.Page))
                .ForMember(dest => dest.QuantityPerPage, opt => opt.MapFrom(src => src.QuantityPerPage))
                .ForMember(dest => dest.OrderBy, opt => opt.MapFrom(src => new OrderBy<RoleEntityField>(src.OrderByFields.Select(f => RoleEnumerators.ToEntityField(f)), src.OrderByIsDesc)));
        }

        #endregion
    }
}
