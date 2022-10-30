using AutoMapper;
using Microsoft.Extensions.Logging;
using PeoManageSoft.Business.Domain.Services.Commands.User.CreateToken;
using PeoManageSoft.Business.Domain.Services.Commands.User.Patch;
using PeoManageSoft.Business.Domain.Services.Queries.User.GetByAuthentication;
using PeoManageSoft.Business.Domain.Services.Queries.User.GetByAuthentication.Response;
using PeoManageSoft.Business.Infrastructure.Helpers;
using PeoManageSoft.Business.Infrastructure.Helpers.Exceptions;
using PeoManageSoft.Business.Infrastructure.Helpers.Extensions;
using PeoManageSoft.Business.Infrastructure.Helpers.Interfaces;
using PeoManageSoft.Business.Infrastructure.ObjectRelationalMapper;
using PeoManageSoft.Business.Infrastructure.Repositories.User;
using System.Net;

namespace PeoManageSoft.Business.Application.User.SignIn
{
    /// <summary>
    /// Sign in application layer.
    /// </summary>
    internal class SignInApplication : ISignInApplication
    {
        #region Fields

        /// <summary>
        ///  Handles all queries to get the user by authentication.
        /// </summary>
        private readonly IGetByAuthenticationHandler _getByAuthenticationHandler;
        /// <summary>
        ///  Handles all commands to create the token.
        /// </summary>
        private readonly ICreateTokenHandler _createTokenHandler;
        /// <summary>
        ///  Handles all commands to patch the user.
        /// </summary>
        private readonly IPatchHandler _patchHandler;
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
        /// <param name="getByAuthenticationHandler">Handles all queries to get the user by authentication.</param>
        /// <param name="createTokenHandler">Handles all commands to create the token.</param>
        /// <param name="patchHandler">Handles all commands to patch the user.</param>
        /// <param name="appConfig">Application Configuration</param>
        /// <param name="mapper">Data Mapper </param>
        /// <param name="logger">Log</param>
        public SignInApplication(
                IGetByAuthenticationHandler getByAuthenticationHandler,
                ICreateTokenHandler createTokenHandler,
                IPatchHandler patchHandler,
                IAppConfig appConfig,
                IMapper mapper,
                ILogger<SignInApplication> logger
            )
        {
            _getByAuthenticationHandler = getByAuthenticationHandler;
            _createTokenHandler = createTokenHandler;
            _patchHandler = patchHandler;
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

            GetByAuthenticationRequest queryRequest = _mapper.Map<GetByAuthenticationRequest>(request);

            queryRequest.Password = Cryptography.Encrypt(request.Password, _appConfig.AuthTokenSecrect);

            GetByAuthenticationResponse authResponse = await _getByAuthenticationHandler.HandleAsync(queryRequest).ConfigureAwait(false);

            if (authResponse == null)
            {
                throw new RequestException(HttpStatusCode.Unauthorized, "Not authorized!");
            }

            await _patchHandler.HandleAsync(new PatchRequest
            {
                Id = authResponse.Id,
                Fields = new List<Field<UserEntityField>>
                {
                    new Field<UserEntityField>{ Type = UserEntityField.Location, Value = request.Location }
                }
            }).ConfigureAwait(false);

            CreateTokenResponse tokenResponse = await _createTokenHandler.HandleAsync(new CreateTokenRequest
            {
                Id = authResponse.Id,
                Login = authResponse.Login,
                Role = authResponse.Role,
                ExpireSeconds = _appConfig.AuthTokenExpireSeconds
            }).ConfigureAwait(false);

            _logger.LogEndInformation(methodName);

            return new SignInResponse
            {
                Key = tokenResponse.Key,
                ExpireSeconds = _appConfig.AuthTokenExpireSeconds,
                Role = authResponse.Role,
                Name = authResponse.Name,
                ShortName = authResponse.ShortName
            };
        }

        #endregion

        #endregion
    }
}
