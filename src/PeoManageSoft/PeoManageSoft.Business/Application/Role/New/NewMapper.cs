using AutoMapper;
using PeoManageSoft.Business.Domain.Services.Commands.Role.Add;
using PeoManageSoft.Business.Domain.Services.Commands.Role.Add.Models;
using Models = PeoManageSoft.Business.Application.Role._Models;

namespace PeoManageSoft.Business.Application.Role.New
{
    /// <summary>
    /// Configuration for maps.
    /// </summary>
    internal sealed class NewMapper : Profile
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the PeoManageSoft.Business.Application.Role.New.NewMapper class.
        /// </summary>
        public NewMapper()
        {
            CreateMap<Models.RoleResource, RoleResource>()                
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Permissions, opt => opt.MapFrom(src => src.Permissions));

            CreateMap<NewRequest, AddRequest>()
                .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => src.IsActive))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Resources, opt => opt.MapFrom(src => src.Resources));

            CreateMap<AddResponse, NewResponse>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.NewId));
        }

        #endregion
    }
}
