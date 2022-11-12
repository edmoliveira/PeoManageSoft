using AutoMapper;
using PeoManageSoft.Business.Domain.Services.Queries.Title.Get.Response;
using PeoManageSoft.Business.Infrastructure.Repositories.Title;

namespace PeoManageSoft.Business.Domain.Services.Queries.Title.Get
{
    /// <summary>
    /// Configuration for maps.
    /// </summary>
    internal sealed class GetMapper : Profile
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the PeoManageSoft.Business.Domain.Services.Queries.Title.Get.GetMapper class.
        /// </summary>
        public GetMapper()
        {
            CreateMap<TitleEntity, GetResponse>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => src.IsActive))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));
        }

        #endregion
    }
}
