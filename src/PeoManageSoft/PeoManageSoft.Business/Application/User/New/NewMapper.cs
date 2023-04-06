using AutoMapper;
using PeoManageSoft.Business.Application.User._Models;
using PeoManageSoft.Business.Domain.Services.Commands.User.Add;
using PeoManageSoft.Business.Domain.Services.Commands.User.Add.Models;

namespace PeoManageSoft.Business.Application.User.New
{
    /// <summary>
    /// Configuration for maps.
    /// </summary>
    internal sealed class NewMapper : Profile
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the PeoManageSoft.Business.Application.User.New.NewMapper class.
        /// </summary>
        public NewMapper()
        {
            CreateMap<UserSchemaResource, SchemaResource>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Permissions, opt => opt.MapFrom(src => src.Permissions))
                .ForMember(dest => dest.Children, opt => opt.MapFrom(src => src.Children));

            CreateMap<NewRequest, AddRequest>()
                .ForMember(dest => dest.RoleId, opt => opt.MapFrom(src => src.RoleId))
                .ForMember(dest => dest.Login, opt => opt.MapFrom(src => src.Login))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.ShortName, opt => opt.MapFrom(src => src.ShortName))
                .ForMember(dest => dest.TitleId, opt => opt.MapFrom(src => src.TitleId))
                .ForMember(dest => dest.DepartmentId, opt => opt.MapFrom(src => src.DepartmentId))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.BussinessPhone, opt => opt.MapFrom(src => src.BussinessPhone))
                .ForMember(dest => dest.MobilePhone, opt => opt.MapFrom(src => src.MobilePhone))
                .ForMember(dest => dest.Location, opt => opt.MapFrom(src => src.Location))
                .ForMember(dest => dest.SchemaResources, opt => opt.MapFrom(src => src.SchemaResources));

            CreateMap<AddResponse, NewResponse>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.NewId));
        }

        #endregion
    }
}
