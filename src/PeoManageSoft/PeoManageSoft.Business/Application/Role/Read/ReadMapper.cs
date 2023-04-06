using AutoMapper;
using PeoManageSoft.Business.Application.Role.Read.Response;
using PeoManageSoft.Business.Domain.Services.Queries.Role.Get;
using PeoManageSoft.Business.Domain.Services.Queries.Role.Get.Response;

namespace PeoManageSoft.Business.Application.Role.Read
{
    /// <summary>
    /// Configuration for maps.
    /// </summary>
    internal sealed class ReadMapper : Profile
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the PeoManageSoft.Business.Application.Role.Read.ReadMapper class.
        /// </summary>
        public ReadMapper()
        {
            CreateMap<ReadRequest, GetRequest>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));

            CreateMap<GetResponse, ReadResponse>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => src.IsActive))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));
        }

        #endregion
    }
}
