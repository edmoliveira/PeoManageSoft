using AutoMapper;
using PeoManageSoft.Business.Infrastructure.Repositories.User;

namespace PeoManageSoft.Business.Domain.Services.Commands.User.Add
{
    /// <summary>
    /// Configuration for maps.
    /// </summary>
    internal class AddMapper : Profile
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the PeoManageSoft.Business.Domain.Services.Commands.User.Add.AddMapper class.
        /// </summary>
        public AddMapper()
        {
            CreateMap<AddRequest, UserEntity>()
                .ForMember(dest => dest.Role, opt => opt.MapFrom(src => (int)src.Role))
                .ForMember(dest => dest.Login, opt => opt.MapFrom(src => src.Login))
                .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.Password))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.ShortName, opt => opt.MapFrom(src => src.ShortName))
                .ForMember(dest => dest.TitleId, opt => opt.MapFrom(src => src.TitleId))
                .ForMember(dest => dest.DepartmentId, opt => opt.MapFrom(src => src.DepartmentId))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.BussinessPhone, opt => opt.MapFrom(src => src.BussinessPhone))
                .ForMember(dest => dest.MobilePhone, opt => opt.MapFrom(src => src.MobilePhone))
                .ForMember(dest => dest.Location, opt => opt.MapFrom(src => src.Location));

            CreateMap<UserEntity, AddResponse>()
                .ForMember(dest => dest.NewId, opt => opt.MapFrom(src => src.Id));
        }

        #endregion
    }
}
