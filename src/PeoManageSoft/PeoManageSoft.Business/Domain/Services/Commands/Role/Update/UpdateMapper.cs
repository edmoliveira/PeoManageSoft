using AutoMapper;
using PeoManageSoft.Business.Domain.Services.Commands.Role.Update.Models;
using PeoManageSoft.Business.Infrastructure.Repositories.Role;
using PeoManageSoft.Business.Infrastructure.RepositoriesNoSql.Databases.Authorization.Role;
using PeoManageSoft.Business.Infrastructure.RepositoriesNoSql.Databases.Authorization.Role.Models;

namespace PeoManageSoft.Business.Domain.Services.Commands.Role.Update
{
    /// <summary>
    /// Configuration for maps.
    /// </summary>
    internal sealed class UpdateMapper : Profile
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the PeoManageSoft.Business.Domain.Services.Commands.Role.Update.UpdateMapper class.
        /// </summary>
        public UpdateMapper()
        {
            CreateMap<UpdateRequest, RoleEntity>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => src.IsActive))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));

            CreateMap<RoleResource, ResourceDocument>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Permissions, opt => opt.MapFrom(src => src.Permissions));

            CreateMap<UpdateResourceRequest, RoleDocument>()
                .ForMember(dest => dest.Resources, opt => opt.MapFrom(src => src.Resources));
        }

        #endregion
    }
}
