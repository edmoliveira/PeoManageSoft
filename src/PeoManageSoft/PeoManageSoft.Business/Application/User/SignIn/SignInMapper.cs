using AutoMapper;
using PeoManageSoft.Business.Domain.Services.Queries.User.GetByAuthentication;

namespace PeoManageSoft.Business.Application.User.SignIn
{
    /// <summary>
    /// Configuration for maps.
    /// </summary>
    internal class SignInMapper : Profile
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the PeoManageSoft.Business.Application.User.SignIn.SignInMapper class.
        /// </summary>
        public SignInMapper()
        {
            CreateMap<SignInRequest, GetByAuthenticationRequest>()
                .ForMember(dest => dest.Login, opt => opt.MapFrom(src => src.Login));
        }

        #endregion
    }
}
