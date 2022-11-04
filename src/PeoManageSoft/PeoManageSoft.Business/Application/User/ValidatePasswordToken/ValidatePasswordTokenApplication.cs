using Microsoft.Extensions.Logging;
using PeoManageSoft.Business.Application.User.SendPasswordToken;
using PeoManageSoft.Business.Domain.Services.Queries.User.Get.Response;
using PeoManageSoft.Business.Domain.Services.Queries.User.GetByRules;
using PeoManageSoft.Business.Infrastructure;
using PeoManageSoft.Business.Infrastructure.Helpers.Exceptions;
using PeoManageSoft.Business.Infrastructure.Helpers.Extensions;
using PeoManageSoft.Business.Infrastructure.Helpers.Interfaces;
using PeoManageSoft.Business.Infrastructure.ObjectRelationalMapper.Interfaces;
using PeoManageSoft.Business.Infrastructure.Repositories.User;
using System.Net;

namespace PeoManageSoft.Business.Application.User.ValidatePasswordToken
{
    /// <summary>
    /// Application layer to validate if the password token is valid. 
    /// </summary>
    internal sealed class ValidatePasswordTokenApplication: IValidatePasswordTokenApplication
    {
        #region Fields

        /// <summary>
        /// Handles all queries to get the user by rules.
        /// </summary>
        private readonly IGetByRulesHandler _getByRulesHandler;
        /// <summary>
        /// Manages Json Web Token and Cryptography.
        /// </summary>
        private readonly ITokenJwt _tokenJwt;
        /// <summary>
        /// Log
        /// </summary>
        private readonly ILogger<SendPasswordTokenApplication> _logger;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the PeoManageSoft.Business.Application.User.ValidatePasswordToken.ValidPasswordTokenApplication class.
        /// </summary>
        /// <param name="getByRulesHandler">Handles all queries to get the user by rules.</param>
        /// <param name="tokenJwt">Manages Json Web Token and Cryptography.</param>
        /// <param name="logger">Log</param>
        public ValidatePasswordTokenApplication(
                IGetByRulesHandler getByRulesHandler,
                ITokenJwt tokenJwt,
                ILogger<SendPasswordTokenApplication> logger
            )
        {
            _getByRulesHandler = getByRulesHandler;
            _tokenJwt = tokenJwt;
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

            var userResponse = await GetByPasswordToken(request.PasswordToken).ConfigureAwait(false);

            if (userResponse is null || !_tokenJwt.CheckPasswordToken(userResponse.PasswordToken))
            {
                throw new RequestException(HttpStatusCode.Unauthorized, "Expired token!");
            }

            var response = new ValidatePasswordTokenResponse
            {
                UserToken = _tokenJwt.CreateUserToken(userResponse.Id, userResponse.Email)
            };

            _logger.LogEndInformation(methodName);

            return response;
        }

        #endregion

        #region private

        /// <summary>
        /// Gets the user by PasswordToken
        /// </summary>
        /// <param name="passwordToken">Token to change the user password.</param>
        /// <returns>User data</returns>
        private async Task<GetResponse> GetByPasswordToken(string passwordToken)
        {
            var rules = new IRule<UserEntityField>[1]
                {
                    _getByRulesHandler.CreateRule(UserEntityField.PasswordToken, SqlComparisonOperator.EqualTo, passwordToken)
                };

            var result = await _getByRulesHandler.HandleAsync(_getByRulesHandler.CreateRule(rules)).ConfigureAwait(false);

            return result.FirstOrDefault();
        }

        #endregion

        #endregion
    }
}
