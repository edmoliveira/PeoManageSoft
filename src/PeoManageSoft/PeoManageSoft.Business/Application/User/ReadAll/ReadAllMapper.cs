using AutoMapper;
using PeoManageSoft.Business.Application.User.ReadAll.Response;
using PeoManageSoft.Business.Domain.Queries.User.GetAll.Response;

namespace PeoManageSoft.Business.Application.User.ReadAll
{
    /// <summary>
    /// Configuration for maps.
    /// </summary>
    internal class ReadAllMapper : Profile
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the PeoManageSoft.Business.Application.User.ReadAll.ReadAllMapper class.
        /// </summary>
        public ReadAllMapper()
        {
            CreateMap<GetAllTitleResponse, ReadAllTitleResponse>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));

            CreateMap<GetAllDepartmentResponse, ReadAllDepartmentResponse>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));

            CreateMap<GetAllResponse, ReadAllResponse>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.Role))
                .ForMember(dest => dest.Login, opt => opt.MapFrom(src => src.Login))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.ShortName, opt => opt.MapFrom(src => src.ShortName))
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
                .ForMember(dest => dest.Department, opt => opt.MapFrom(src => src.Department))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.BussinessPhone, opt => opt.MapFrom(src => src.BussinessPhone))
                .ForMember(dest => dest.MobilePhone, opt => opt.MapFrom(src => src.MobilePhone));
        }

        #endregion
    }
}
