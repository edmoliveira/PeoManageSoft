using Microsoft.Extensions.Logging;
using PeoManageSoft.Business.Application.User.SendPasswordToken;
using PeoManageSoft.Business.Domain.Services.Functions.User;
using PeoManageSoft.Business.Infrastructure.Helpers.Exceptions;
using PeoManageSoft.Business.Infrastructure.Helpers.Extensions;
using PeoManageSoft.Business.Infrastructure.Helpers.Interfaces;
using System.Net;

namespace PeoManageSoft.Business.Application.User.ValidatePasswordToken
{
    /// <summary>
    /// Application layer to validate if the password token is valid. 
    /// </summary>
    internal sealed class ValidatePasswordTokenApplication : IValidatePasswordTokenApplication
    {
        #region Fields

        /// <summary>
        /// User function facade that provides a simplified interface.
        /// </summary>
        private readonly IUserFunctionFacade _functionFacade;
        /// <summary>
        /// Manages Json Web Token and Cryptography.
        /// </summary>
        private readonly ITokenJwt _tokenJwt;
        /// <summary>
        /// Application Configuration.
        /// </summary>
        private readonly IAppConfig _appConfig;
        /// <summary>
        /// Log
        /// </summary>
        private readonly ILogger<SendPasswordTokenApplication> _logger;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the PeoManageSoft.Business.Application.User.ValidatePasswordToken.ValidPasswordTokenApplication class.
        /// </summary>
        /// <param name="functionFacade">User function facade that provides a simplified interface.</param>
        /// <param name="tokenJwt">Manages Json Web Token and Cryptography.</param>
        /// <param name="appConfig">Application Configuration.</param>
        /// <param name="logger">Log</param>
        public ValidatePasswordTokenApplication(
                IUserFunctionFacade functionFacade,
                ITokenJwt tokenJwt,
                IAppConfig appConfig,
                ILogger<SendPasswordTokenApplication> logger
            )
        {
            _functionFacade = functionFacade;
            _tokenJwt = tokenJwt;
            _appConfig = appConfig;
            _logger = logger;
        }

        #endregion

        #region Methods

        #region public

        /// <summary>
        /// Handles the application layer and asynchronously using Task.
        /// </summary>
        /// <param name="request">Request for the application layer.</param>
        /// <returns>
        /// Task: Represents an asynchronous operation. 
        /// Response for the application layer.
        /// </returns>
        public async Task<ValidatePasswordTokenResponse> HandleAsync(ValidatePasswordTokenRequest request)
        {
            string methodName = nameof(HandleAsync);

            _logger.LogBeginInformation(methodName);

            var userResponse = await _functionFacade.GetByPasswordTokenAsync(request.PasswordToken).ConfigureAwait(false);

            if (userResponse is null || !_tokenJwt.CheckPasswordToken(userResponse.PasswordToken))
            {
                throw new RequestException(HttpStatusCode.Unauthorized, _appConfig.MessagesCatalogResource.GetMessageExpiredToken());
            }

            var response = new ValidatePasswordTokenResponse
            {
                UserToken = _tokenJwt.CreateUserToken(userResponse.Id, userResponse.Email)
            };

            _logger.LogEndInformation(methodName);

            return response;
        }

        #endregion

        #endregion
    }
}
