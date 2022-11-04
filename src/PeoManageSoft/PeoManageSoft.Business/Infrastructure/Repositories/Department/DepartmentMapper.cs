using AutoMapper;
using PeoManageSoft.Business.Infrastructure.Repositories.Interfaces;

namespace PeoManageSoft.Business.Infrastructure.Repositories.Department
{
    /// <summary>
    /// Configuration for maps.
    /// </summary>
    internal sealed class DepartmentMapper : Profile
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the PeoManageSoft.Business.Infrastructure.Repositories.Department.DepartmentMapper class.
        /// </summary>
        public DepartmentMapper()
        {
            CreateMap<IDataReaderGetValue, DepartmentEntity>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.GetValue<long>(DepartmentEntityField.Id_Readonly)))
                .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => src.GetValue<bool>(DepartmentEntityField.IsActive)))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.GetValue<string>(DepartmentEntityField.Name)));
        }

        #endregion
    }
}
