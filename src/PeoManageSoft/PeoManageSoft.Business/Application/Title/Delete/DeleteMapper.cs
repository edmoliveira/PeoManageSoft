using AutoMapper;
using PeoManageSoft.Business.Domain.Services.Commands.Title.Remove;

namespace PeoManageSoft.Business.Application.Title.Delete
{
    /// <summary>
    /// Configuration for maps.
    /// </summary>
    internal sealed class DeleteMapper : Profile
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the PeoManageSoft.Business.Application.Title.Delete.DeleteMapper class.
        /// </summary>
        public DeleteMapper()
        {
            CreateMap<DeleteRequest, RemoveRequest>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));
        }

        #endregion
    }
}
