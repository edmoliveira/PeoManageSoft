using Microsoft.Extensions.Logging;
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

namespace PeoManageSoft.Business.Application.User.ChangePassword
{
    /// <summary>
    /// Application layer to change password if the old password is valid. 
    /// </summary>
    internal sealed class ChangePasswordApplication : IChangePasswordApplication
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
        /// Class to be used on one instance throughout the application per request.
        /// </summary>
        private readonly IApplicationContext _applicationContext;
        /// <summary>
        /// Log
        /// </summary>
        private readonly ILogger<ChangePasswordApplication> _logger;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the PeoManageSoft.Business.Application.User.CreateNewPassword.CreateNewPasswordApplication class.
        /// </summary>
        /// <param name="getByRulesHandler">Handles all queries to get the user by rules.</param>
        /// <param name="patchHandler">Handles all commands to patch the user.</param>
        /// <param name="tokenJwt">Manages Json Web Token and Cryptography.</param>
        /// <param name="applicationContext">Class to be used on one instance throughout the application per request.</param>
        /// <param name="logger">Log</param>
        public ChangePasswordApplication(
                IGetByRulesHandler getByRulesHandler,
                IPatchHandler patchHandler,
                ITokenJwt tokenJwt,
                IApplicationContext applicationContext,
                ILogger<ChangePasswordApplication> logger
            )
        {
            _getByRulesHandler = getByRulesHandler;
            _patchHandler = patchHandler;
            _tokenJwt = tokenJwt;
            _applicationContext = applicationContext;
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
        public async Task HandleAsync(ChangePasswordRequest request)
        {
            string methodName = nameof(HandleAsync);

            _logger.LogBeginInformation(methodName);

            var userResponse = await GetByAuthentication(_applicationContext.LoggedUser.User, request.OldPassword).ConfigureAwait(false);

            if (userResponse is null)
            {
                throw new RequestException(HttpStatusCode.Unauthorized, "Not authorized!");
            }

            var password = _tokenJwt.EncryptPassword(request.NewPassword);

            await _patchHandler.HandleAsync(new PatchRequest
            {
                Id = userResponse.Id,
                Fields = new List<Field<UserEntityField>>
                    {
                        new Field<UserEntityField> {
                            Type = UserEntityField.Password,
                            Value = password
                        }
                    }
            }).ConfigureAwait(false);

            _logger.LogEndInformation(methodName);
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
