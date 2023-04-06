using AutoMapper;
using Microsoft.Extensions.Logging;
using PeoManageSoft.Business.Domain.Services.Commands.User.CreateToken;
using PeoManageSoft.Business.Domain.Services.Functions.User;
using PeoManageSoft.Business.Infrastructure.Helpers.Exceptions;
using PeoManageSoft.Business.Infrastructure.Helpers.Extensions;
using PeoManageSoft.Business.Infrastructure.Helpers.Interfaces;
using System.Net;

namespace PeoManageSoft.Business.Application.User.SignIn
{
    /// <summary>
    /// Sign in application layer.
    /// </summary>
    internal sealed class SignInApplication : ISignInApplication
    {
        #region Fields

        /// <summary>
        /// User function facade that provides a simplified interface.
        /// </summary>
        private readonly IUserFunctionFacade _functionFacade;
        /// <summary>
        ///  Handles all commands to create the token.
        /// </summary>
        private readonly ICreateTokenHandler _createTokenHandler;
        /// <summary>
        ///  Manages Json Web Token and Cryptography.
        /// </summary>
        private readonly ITokenJwt _tokenJwt;
        /// <summary>
        /// Application Configuration
        /// </summary>
        private readonly IAppConfig _appConfig;
        /// <summary>
        /// Data Mapper 
        /// </summary>
        private readonly IMapper _mapper;
        /// <summary>
        /// Log
        /// </summary>
        private readonly ILogger<SignInApplication> _logger;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the PeoManageSoft.Business.Application.User.SignIn.SignInApplication class.
        /// </summary>
        /// <param name="functionFacade">User function facade that provides a simplified interface.</param>
        /// <param name="createTokenHandler">Handles all commands to create the token.</param>
        /// <param name="tokenJwt">Manages Json Web Token and Cryptography.</param>
        /// <param name="appConfig">Application Configuration</param>
        /// <param name="mapper">Data Mapper </param>
        /// <param name="logger">Log</param>
        public SignInApplication(
                IUserFunctionFacade functionFacade,
                ICreateTokenHandler createTokenHandler,
                ITokenJwt tokenJwt,
                IAppConfig appConfig,
                IMapper mapper,
                ILogger<SignInApplication> logger
            )
        {
            _functionFacade = functionFacade;
            _createTokenHandler = createTokenHandler;
            _tokenJwt = tokenJwt;
            _appConfig = appConfig;
            _mapper = mapper;
            _logger = logger;
        }

        #endregion

        #region Methods

        #region public

        /// <summary>
        /// Handles the application layer of the sing in and asynchronously using Task.
        /// </summary>
        /// <param name="request">Request for the application layer.</param>
        /// <returns>
        /// Task: Represents an asynchronous operation. 
        /// Response for the application layer.
        /// </returns>
        public async Task<SignInResponse> HandleAsync(SignInRequest request)
        {
            string methodName = nameof(HandleAsync);

            _logger.LogBeginInformation(methodName);

            var userResponse = await _functionFacade
                .GetByAuthenticationAsync(request.Login, _tokenJwt.EncryptPassword(request.Password))
                .ConfigureAwait(false);

            if (userResponse is null)
            {
                throw new RequestException(HttpStatusCode.Unauthorized, _appConfig.MessagesCatalogResource.GetMessageUnauthorized());
            }

            await _functionFacade
                    .PutLocationAsync(userResponse.Id, request.Location)
                    .ConfigureAwait(false);

            CreateTokenResponse tokenResponse = await _createTokenHandler.HandleAsync(new CreateTokenRequest
            {
                Id = userResponse.Id,
                Login = userResponse.Login,
                RoleId = userResponse.Role.Id,
                ExpireSeconds = _appConfig.AuthTokenExpireSeconds
            }).ConfigureAwait(false);

            _logger.LogEndInformation(methodName);

            return new SignInResponse
            {
                Key = tokenResponse.Key,
                ExpireSeconds = _appConfig.AuthTokenExpireSeconds,
                RoleId = userResponse.Role.Id,
                RoleName = userResponse.Role.Name,
                Name = userResponse.Name,
                ShortName = userResponse.ShortName
            };
        }

        #endregion

        #endregion
    }
}
