using AutoMapper;
using PeoManageSoft.Business.Infrastructure.Repositories.Title;

namespace PeoManageSoft.Business.Domain.Services.Commands.Title.Add
{
    /// <summary>
    /// Configuration for maps.
    /// </summary>
    internal sealed class AddMapper : Profile
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the PeoManageSoft.Business.Domain.Services.Commands.Title.Add.AddMapper class.
        /// </summary>
        public AddMapper()
        {
            CreateMap<AddRequest, TitleEntity>()
                .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => src.IsActive))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));

            CreateMap<TitleEntity, AddResponse>()
                .ForMember(dest => dest.NewId, opt => opt.MapFrom(src => src.Id));
        }

        #endregion
    }
}
