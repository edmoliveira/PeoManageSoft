using AutoMapper;
using Microsoft.Extensions.Logging;
using PeoManageSoft.Business.Domain.Services.Commands.User.CreateToken;
using PeoManageSoft.Business.Domain.Services.Commands.User.Patch;
using PeoManageSoft.Business.Domain.Services.Queries.User.Get.Response;
using PeoManageSoft.Business.Domain.Services.Queries.User.GetByRules;
using PeoManageSoft.Business.Infrastructure;
using PeoManageSoft.Business.Infrastructure.Helpers.Exceptions;
using PeoManageSoft.Business.Infrastructure.Helpers.Extensions;
using PeoManageSoft.Business.Infrastructure.Helpers.Interfaces;
using PeoManageSoft.Business.Infrastructure.ObjectRelationalMapper;
using PeoManageSoft.Business.Infrastructure.ObjectRelationalMapper.Interfaces;
using PeoManageSoft.Business.Infrastructure.Repositories.User;
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
        ///  Handles all queries to get the user by rules.
        /// </summary>
        private readonly IGetByRulesHandler _getByRulesHandler;
        /// <summary>
        ///  Handles all commands to create the token.
        /// </summary>
        private readonly ICreateTokenHandler _createTokenHandler;
        /// <summary>
        ///  Handles all commands to patch the user.
        /// </summary>
        private readonly IPatchHandler _patchHandler;
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
        /// <param name="getByRulesHandler">Handles all queries to get the user by rules.</param>
        /// <param name="createTokenHandler">Handles all commands to create the token.</param>
        /// <param name="patchHandler">Handles all commands to patch the user.</param>
        /// <param name="tokenJwt">Manages Json Web Token and Cryptography.</param>
        /// <param name="appConfig">Application Configuration</param>
        /// <param name="mapper">Data Mapper </param>
        /// <param name="logger">Log</param>
        public SignInApplication(
                IGetByRulesHandler getByRulesHandler,
                ICreateTokenHandler createTokenHandler,
                IPatchHandler patchHandler,
                ITokenJwt tokenJwt,
                IAppConfig appConfig,
                IMapper mapper,
                ILogger<SignInApplication> logger
            )
        {
            _getByRulesHandler = getByRulesHandler;
            _createTokenHandler = createTokenHandler;
            _patchHandler = patchHandler;
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

            var authResponse = await GetByAuthentication(request.Login, request.Password).ConfigureAwait(false);

            if (authResponse is null)
            {
                throw new RequestException(HttpStatusCode.Unauthorized, "Not authorized!");
            }

            await _patchHandler.HandleAsync(new PatchRequest
            {
                Id = authResponse.Id,
                Fields = new List<Field<UserEntityField>>
                {
                    new Field<UserEntityField>{ Type = UserEntityField.Location, Value = request.Location.ToString() }
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

        #region private

        /// <summary>
        /// Gets the user by login and password
        /// </summary>
        /// <param name="login">User login</param>
        /// <param name="password">User password</param>
        /// <returns>User data</returns>
        private async Task<GetResponse> GetByAuthentication(string login, string password)
        {
            var encryptedPassword = _tokenJwt.EncryptPassword(password);

            var rules = new IRule<UserEntityField>[2]
                {
                    _getByRulesHandler.CreateRule(UserEntityField.Login_Readonly, SqlComparisonOperator.EqualTo, login),
                    _getByRulesHandler.CreateRule(UserEntityField.Password, SqlComparisonOperator.EqualTo, encryptedPassword, SqlOperator.And)
                };

            var result = await _getByRulesHandler.HandleAsync(_getByRulesHandler.CreateRule(rules)).ConfigureAwait(false);

            return result.FirstOrDefault();
        }

        #endregion

        #endregion
    }
}
