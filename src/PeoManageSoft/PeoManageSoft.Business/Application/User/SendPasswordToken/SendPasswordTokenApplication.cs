using Microsoft.Extensions.Logging;
using PeoManageSoft.Business.Domain.Services.Apis.Geo.Interfaces;
using PeoManageSoft.Business.Domain.Services.Commands.Messaging.SendEmail;
using PeoManageSoft.Business.Domain.Services.Creators.RememberPasswordEmail.Interfaces;
using PeoManageSoft.Business.Domain.Services.Functions.User;
using PeoManageSoft.Business.Infrastructure.Helpers.Exceptions;
using PeoManageSoft.Business.Infrastructure.Helpers.Extensions;
using PeoManageSoft.Business.Infrastructure.Helpers.Interfaces;
using System.Net;

namespace PeoManageSoft.Business.Application.User.SendPasswordToken
{
    /// <summary>
    /// Application layer to send an email to the user to change his password.
    /// </summary>
    internal sealed class SendPasswordTokenApplication : ISendPasswordTokenApplication
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
        /// Provides a creator to create an email layout "Remember Password".
        /// </summary>
        private readonly IRememberPasswordEmailCreator _rememberPasswordEmailCreator;
        /// <summary>
        /// Handles all commands to send email.
        /// </summary>
        private readonly ISendEmailHandler _sendEmailHandler;
        /// <summary>
        /// Reverse geocoding is the process of converting geographic coordinates into a human-readable address.
        /// </summary>
        private readonly IGeoApi _geoApi;
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
        /// Initializes a new instance of the PeoManageSoft.Business.Application.User.SendPasswordToken.SendPasswordTokenApplication class.
        /// </summary>
        /// <param name="functionFacade">User function facade that provides a simplified interface.</param>
        /// <param name="tokenJwt">Manages Json Web Token and Cryptography.</param>
        /// <param name="rememberPasswordEmailCreator">>Provides a creator to create an email layout "Remember Password".</param>
        /// <param name="sendEmailHandler">Handles all commands to send email.</param>
        /// <param name="geoApi">Reverse geocoding is the process of converting geographic coordinates into a human-readable address.</param>
        /// <param name="appConfig">Application Configuration.</param>
        /// <param name="logger">Log</param>
        public SendPasswordTokenApplication(
                IUserFunctionFacade functionFacade,
                ITokenJwt tokenJwt,
                IRememberPasswordEmailCreator rememberPasswordEmailCreator,
                ISendEmailHandler sendEmailHandler,
                IGeoApi geoApi,
                IAppConfig appConfig,
                ILogger<SendPasswordTokenApplication> logger
            )
        {
            _functionFacade = functionFacade;
            _tokenJwt = tokenJwt;
            _rememberPasswordEmailCreator = rememberPasswordEmailCreator;
            _sendEmailHandler = sendEmailHandler;
            _geoApi = geoApi;
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
        /// <returns>Represents an asynchronous operation.</returns>
        public async Task HandleAsync(SendPasswordTokenRequest request)
        {
            string methodName = nameof(HandleAsync);

            _logger.LogBeginInformation(methodName);

            var userResponse = await _functionFacade
                                        .GetByEmailAsync(request.Email)
                                        .ConfigureAwait(false);

            if (userResponse is null)
            {
                throw new RequestException(HttpStatusCode.NotFound, _appConfig.MessagesCatalogResource.GetMessageNotFound(nameof(request.Email)));
            }

            var passwordToken = _tokenJwt.CreatePasswordToken(userResponse.Id);

            await _functionFacade
                .PutPasswordTokenAsync(userResponse.Id, passwordToken)
                .ConfigureAwait(false);

            var address = await _geoApi.FindAddressByLatLongAsync(
                                    request.Location.Latitude,
                                    request.Location.Longitude
                                ).ConfigureAwait(false);

            _ = await _sendEmailHandler.HandleAsync(new SendEmailRequest
            {
                Data = _rememberPasswordEmailCreator.CreateEmail(
                            userResponse.Email,
                            string.Concat(request.Url, passwordToken),
                            address
                        )
            }).ConfigureAwait(false);

            _logger.LogEndInformation(methodName);
        }

        #endregion

        #endregion
    }
}
