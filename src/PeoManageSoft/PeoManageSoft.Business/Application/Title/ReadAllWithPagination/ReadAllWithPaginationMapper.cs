using AutoMapper;
using PeoManageSoft.Business.Domain.Services.Queries.Title.GetAllWithPagination;
using PeoManageSoft.Business.Infrastructure.ObjectRelationalMapper;
using PeoManageSoft.Business.Infrastructure.Repositories.Title;

namespace PeoManageSoft.Business.Application.Title.ReadAllWithPagination
{
    /// <summary>
    /// Configuration for maps.
    /// </summary>
    internal sealed class ReadAllWithPaginationMapper : Profile
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the PeoManageSoft.Business.Application.Title.ReadAllWithPagination.ReadAllWithPaginationMapper class.
        /// </summary>
        public ReadAllWithPaginationMapper()
        {
            CreateMap<ReadAllWithPaginationRequest, GetAllWithPaginationRequest>()
                .ForMember(dest => dest.Page, opt => opt.MapFrom(src => src.Page))
                .ForMember(dest => dest.QuantityPerPage, opt => opt.MapFrom(src => src.QuantityPerPage))
                .ForMember(dest => dest.OrderBy, opt => opt.MapFrom(src => new OrderBy<TitleEntityField>(src.OrderByFields.Select(f => TitleEnumerators.ToEntityField(f)), src.OrderByIsDesc)));
        }

        #endregion
    }
}
