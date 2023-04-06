using AutoMapper;
using PeoManageSoft.Business.Infrastructure.Repositories.Interfaces;

namespace PeoManageSoft.Business.Infrastructure.Repositories.Role
{
    /// <summary>
    /// Configuration for maps.
    /// </summary>
    internal sealed class RoleMapper : Profile
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the PeoManageSoft.Business.Infrastructure.Repositories.Role.RoleMapper class.
        /// </summary>
        public RoleMapper()
        {
            CreateMap<IDataReaderGetValue, RoleEntity>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.GetValue<long>(RoleEntityField.Id_Readonly)))
                .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => src.GetValue<bool>(RoleEntityField.IsActive)))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.GetValue<string>(RoleEntityField.Name)));
        }

        #endregion
    }
}
