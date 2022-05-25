using AutoMapper;
using PeoManageSoft.Business.Domain.Commands.User.Add;

namespace PeoManageSoft.Business.Application.User.New
{
    /// <summary>
    /// Configuration for maps.
    /// </summary>
    public class NewMapper : Profile
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the PeoManageSoft.Business.Application.User.New.NewUserMapper class.
        /// </summary>
        public NewMapper()
        {
            CreateMap<NewRequest, AddRequest>()
                .ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.Role))
                .ForMember(dest => dest.Login, opt => opt.MapFrom(src => src.Login))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.ShortName, opt => opt.MapFrom(src => src.ShortName))
                .ForMember(dest => dest.TitleId, opt => opt.MapFrom(src => src.TitleId))
                .ForMember(dest => dest.DepartmentId, opt => opt.MapFrom(src => src.DepartmentId))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.BussinessPhone, opt => opt.MapFrom(src => src.BussinessPhone))
                .ForMember(dest => dest.MobilePhone, opt => opt.MapFrom(src => src.MobilePhone))
                .ForMember(dest => dest.Location, opt => opt.MapFrom(src => src.Location));

            CreateMap<AddResponse, NewResponse>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.NewId));
        }

        #endregion
    }
}
