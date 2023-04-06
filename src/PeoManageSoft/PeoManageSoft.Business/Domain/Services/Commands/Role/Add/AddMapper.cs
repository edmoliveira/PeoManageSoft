using AutoMapper;
using PeoManageSoft.Business.Domain.Services.Commands.Role.Add.Models;
using PeoManageSoft.Business.Infrastructure.Repositories.Role;
using PeoManageSoft.Business.Infrastructure.RepositoriesNoSql.Databases.Authorization.Role.Models;

namespace PeoManageSoft.Business.Domain.Services.Commands.Role.Add
{
    /// <summary>
    /// Configuration for maps.
    /// </summary>
    internal sealed class AddMapper : Profile
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the PeoManageSoft.Business.Domain.Services.Commands.Role.Add.AddMapper class.
        /// </summary>
        public AddMapper()
        {
            CreateMap<AddRequest, RoleEntity>()
                .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => src.IsActive))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));

            CreateMap<RoleEntity, AddResponse>()
                .ForMember(dest => dest.NewId, opt => opt.MapFrom(src => src.Id));

            CreateMap<RoleResource, ResourceDocument>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Permissions, opt => opt.MapFrom(src => src.Permissions));
        }

        #endregion
    }
}
