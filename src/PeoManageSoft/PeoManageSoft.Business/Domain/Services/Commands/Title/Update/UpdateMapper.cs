using AutoMapper;
using PeoManageSoft.Business.Infrastructure.Repositories.Title;

namespace PeoManageSoft.Business.Domain.Services.Commands.Title.Update
{
    /// <summary>
    /// Configuration for maps.
    /// </summary>
    internal sealed class UpdateMapper : Profile
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the PeoManageSoft.Business.Domain.Services.Commands.Title.Update.UpdateMapper class.
        /// </summary>
        public UpdateMapper()
        {
            CreateMap<UpdateRequest, TitleEntity>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => src.IsActive))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));
        }

        #endregion
    }
}
