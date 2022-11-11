using AutoMapper;
using PeoManageSoft.Business.Infrastructure.Repositories.User;

namespace PeoManageSoft.Business.Domain.Services.Commands.User.Update
{
    /// <summary>
    /// Configuration for maps.
    /// </summary>
    internal sealed class UpdateMapper : Profile
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the PeoManageSoft.Business.Domain.Services.Commands.User.Update.UpdateMapper class.
        /// </summary>
        public UpdateMapper()
        {
            CreateMap<UpdateRequest, UserEntity>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => src.IsActive))
                .ForMember(dest => dest.Role, opt => opt.MapFrom(src => (int)src.Role))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.ShortName, opt => opt.MapFrom(src => src.ShortName))
                .ForMember(dest => dest.TitleId, opt => opt.MapFrom(src => src.TitleId))
                .ForMember(dest => dest.DepartmentId, opt => opt.MapFrom(src => src.DepartmentId))
                .ForMember(dest => dest.BussinessPhone, opt => opt.MapFrom(src => src.BussinessPhone))
                .ForMember(dest => dest.MobilePhone, opt => opt.MapFrom(src => src.MobilePhone));
        }

        #endregion
    }
}
