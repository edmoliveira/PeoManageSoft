using AutoMapper;
using PeoManageSoft.Business.Domain.Services.Commands.Title.Add;

namespace PeoManageSoft.Business.Application.Title.New
{
    /// <summary>
    /// Configuration for maps.
    /// </summary>
    internal sealed class NewMapper : Profile
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the PeoManageSoft.Business.Application.Title.New.NewMapper class.
        /// </summary>
        public NewMapper()
        {
            CreateMap<NewRequest, AddRequest>()
                .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => src.IsActive))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));

            CreateMap<AddResponse, NewResponse>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.NewId));
        }

        #endregion
    }
}
