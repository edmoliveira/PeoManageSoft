using AutoMapper;
using PeoManageSoft.Business.Infrastructure.Repositories.Interfaces;

namespace PeoManageSoft.Business.Infrastructure.Repositories.Title
{
    /// <summary>
    /// Configuration for maps.
    /// </summary>
    internal class TitleMapper : Profile
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the PeoManageSoft.Business.Infrastructure.Repositories.Title.TitleMapper class.
        /// </summary>
        public TitleMapper()
        {
            CreateMap<IDataReaderGetValue, TitleEntity>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.GetValue<long>(TitleEntityField.Id_Readonly)))
                .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => src.GetValue<bool>(TitleEntityField.IsActive)))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.GetValue<string>(TitleEntityField.Name)));
        }

        #endregion
    }
}
