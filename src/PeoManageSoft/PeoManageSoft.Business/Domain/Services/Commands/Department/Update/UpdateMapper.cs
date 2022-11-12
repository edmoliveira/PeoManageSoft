using AutoMapper;
using PeoManageSoft.Business.Infrastructure.Repositories.Department;

namespace PeoManageSoft.Business.Domain.Services.Commands.Department.Update
{
    /// <summary>
    /// Configuration for maps.
    /// </summary>
    internal sealed class UpdateMapper : Profile
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the PeoManageSoft.Business.Domain.Services.Commands.Department.Update.UpdateMapper class.
        /// </summary>
        public UpdateMapper()
        {
            CreateMap<UpdateRequest, DepartmentEntity>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => src.IsActive))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));
        }

        #endregion
    }
}
