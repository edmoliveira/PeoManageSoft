using AutoMapper;
using PeoManageSoft.Business.Domain.Services.Commands.Role.Remove;

namespace PeoManageSoft.Business.Application.Role.Delete
{
    /// <summary>
    /// Configuration for maps.
    /// </summary>
    internal sealed class DeleteMapper : Profile
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the PeoManageSoft.Business.Application.Role.Delete.DeleteMapper class.
        /// </summary>
        public DeleteMapper()
        {
            CreateMap<DeleteRequest, RemoveRequest>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));
        }

        #endregion
    }
}
