using AutoMapper;
using PeoManageSoft.Business.Domain.Services.Commands.User.Remove;

namespace PeoManageSoft.Business.Application.User.Delete
{
    /// <summary>
    /// Configuration for maps.
    /// </summary>
    internal class DeleteMapper : Profile
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the PeoManageSoft.Business.Application.User.Delete.DeleteMapper class.
        /// </summary>
        public DeleteMapper()
        {
            CreateMap<DeleteRequest, RemoveRequest>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));
        }

        #endregion
    }
}
