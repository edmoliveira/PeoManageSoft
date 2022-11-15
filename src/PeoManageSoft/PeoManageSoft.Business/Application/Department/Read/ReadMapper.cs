using AutoMapper;
using PeoManageSoft.Business.Application.Department.Read.Response;
using PeoManageSoft.Business.Domain.Services.Queries.Department.Get;
using PeoManageSoft.Business.Domain.Services.Queries.Department.Get.Response;

namespace PeoManageSoft.Business.Application.Department.Read
{
    /// <summary>
    /// Configuration for maps.
    /// </summary>
    internal sealed class ReadMapper : Profile
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the PeoManageSoft.Business.Application.Department.Read.ReadMapper class.
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
