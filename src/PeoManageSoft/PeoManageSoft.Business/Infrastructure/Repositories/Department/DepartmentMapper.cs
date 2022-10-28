using AutoMapper;
using System.Data;
using static PeoManageSoft.Business.Infrastructure.Repositories.Department.DepartmentEntityConfig;

namespace PeoManageSoft.Business.Infrastructure.Repositories.Department
{
    /// <summary>
    /// Configuration for maps.
    /// </summary>
    internal class DepartmentMapper : Profile
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the PeoManageSoft.Business.Infrastructure.Repositories.Department.DepartmentMapper class.
        /// </summary>
        public DepartmentMapper()
        {
            var searchValue = GetFuncSearchValue();

            CreateMap<IDataReader, DepartmentEntity>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => (long)searchValue(EntityField.Id_Readonly, src)))
                .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => (bool)searchValue(EntityField.IsActive, src)))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => searchValue(EntityField.Name, src)));

        }

        #endregion
    }
}
