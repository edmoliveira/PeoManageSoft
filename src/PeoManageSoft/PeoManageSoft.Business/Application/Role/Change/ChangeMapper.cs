using AutoMapper;
using PeoManageSoft.Business.Domain.Services.Commands.Role.Update;
using PeoManageSoft.Business.Domain.Services.Commands.Role.Update.Models;
using Models = PeoManageSoft.Business.Application.Role._Models;

namespace PeoManageSoft.Business.Application.Role.Change
{
    /// <summary>
    /// Configuration for maps.
    /// </summary>
    internal sealed class ChangeMapper : Profile
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the PeoManageSoft.Business.Application.Role.Change.ChangeMapper class.
        /// </summary>
        public ChangeMapper()
        {
            CreateMap<Models.RoleResource, RoleResource>()
                .ForMember(dest => dest.Permissions, opt => opt.MapFrom(src => src.Permissions))
                .ForMember(dest => dest.Permissions, opt => opt.MapFrom(src => src.Permissions));

            CreateMap<ChangeRequest, UpdateRequest>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => src.IsActive))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Resources, opt => opt.MapFrom(src => src.Resources));
        }

        #endregion
    }
}
