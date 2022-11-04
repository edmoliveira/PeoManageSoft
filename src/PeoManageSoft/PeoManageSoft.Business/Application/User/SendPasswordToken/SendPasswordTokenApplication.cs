using Microsoft.Extensions.Logging;
using PeoManageSoft.Business.Domain.Services.Apis.Geo.Interfaces;
using PeoManageSoft.Business.Domain.Services.Commands.Messaging.SendEmail;
using PeoManageSoft.Business.Domain.Services.Commands.User.Patch;
using PeoManageSoft.Business.Domain.Services.Creators.RememberPasswordEmail.Interfaces;
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

namespace PeoManageSoft.Business.Application.User.SendPasswordToken
{
    /// <summary>
    /// Application layer to send an email to the user to change his password.
    /// </summary>
    internal sealed class SendPasswordTokenApplication : ISendPasswordTokenApplication
    {
        #region Fields

        /// <summary>
        /// Handles all queries to get the user by rules.
        /// </summary>
        private readonly IGetByRulesHandler _getByRulesHandler;
        /// <summary>
        /// Handles all commands to patch the user.
        /// </summary>
        private readonly IPatchHandler _patchHandler;
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
        /// Log
        /// </summary>
        private readonly ILogger<SendPasswordTokenApplication> _logger;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the PeoManageSoft.Business.Application.User.SendPasswordToken.SendPasswordTokenApplication class.
        /// </summary>
        /// <param name="getByRulesHandler">Handles all queries to get the user by rules.</param>
        /// <param name="patchHandler">Handles all commands to patch the user.</param>
        /// <param name="tokenJwt">Manages Json Web Token and Cryptography.</param>
        /// <param name="rememberPasswordEmailCreator">>Provides a creator to create an email layout "Remember Password".</param>
        /// <param name="sendEmailHandler">Handles all commands to send email.</param>
        /// <param name="geoApi">Reverse geocoding is the process of converting geographic coordinates into a human-readable address.</param>
        /// <param name="logger">Log</param>
        public SendPasswordTokenApplication(
                IGetByRulesHandler getByRulesHandler,
                IPatchHandler patchHandler,
                ITokenJwt tokenJwt,
                IRememberPasswordEmailCreator rememberPasswordEmailCreator,
                ISendEmailHandler sendEmailHandler,
                IGeoApi geoApi,
                ILogger<SendPasswordTokenApplication> logger
            )
        {
            _getByRulesHandler = getByRulesHandler;
            _patchHandler = patchHandler;
            _tokenJwt = tokenJwt;
            _rememberPasswordEmailCreator = rememberPasswordEmailCreator;
            _sendEmailHandler = sendEmailHandler;
            _geoApi = geoApi;
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

            var userResponse = await GetByEmail(request.Email).ConfigureAwait(false);

            if (userResponse is null)
            {
                throw new RequestException(HttpStatusCode.NotFound, "Email not found!");
            }

            var passwordToken = _tokenJwt.CreatePasswordToken(userResponse.Id);

            await _patchHandler.HandleAsync(new PatchRequest
            {
                Id = userResponse.Id,
                Fields = new List<Field<UserEntityField>>
                {
                    new Field<UserEntityField> { 
                        Type = UserEntityField.PasswordToken, 
                        Value = passwordToken
                    }
                }
            }).ConfigureAwait(false);

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

        #region private

        /// <summary>
        /// Gets the user by email
        /// </summary>
        /// <param name="email">User email</param>
        /// <returns>User data</returns>
        private async Task<GetResponse> GetByEmail(string email)
        {
            var rules = new IRule<UserEntityField>[1]
                {
                    _getByRulesHandler.CreateRule(UserEntityField.Email_Readonly, SqlComparisonOperator.EqualTo, email)
                };

            var result = await _getByRulesHandler.HandleAsync(_getByRulesHandler.CreateRule(rules)).ConfigureAwait(false);

            return result.FirstOrDefault();
        }

        #endregion

        #endregion
    }
}
