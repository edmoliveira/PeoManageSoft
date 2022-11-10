using Microsoft.Extensions.Logging;
using PeoManageSoft.Business.Domain.Services.Functions.User;
using PeoManageSoft.Business.Infrastructure.Helpers.Exceptions;
using PeoManageSoft.Business.Infrastructure.Helpers.Extensions;
using PeoManageSoft.Business.Infrastructure.Helpers.Interfaces;
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
        /// User function facade that provides a simplified interface.
        /// </summary>
        private readonly IUserFunctionFacade _functionFacade;
        /// <summary>
        /// Manages Json Web Token and Cryptography.
        /// </summary>
        private readonly ITokenJwt _tokenJwt;
        /// <summary>
        /// Class to be used on one instance throughout the application per request.
        /// </summary>
        private readonly IApplicationContext _applicationContext;
        /// <summary>
        /// Application Configuration.
        /// </summary>
        private readonly IAppConfig _appConfig;
        /// <summary>
        /// Log
        /// </summary>
        private readonly ILogger<ChangePasswordApplication> _logger;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the PeoManageSoft.Business.Application.User.CreateNewPassword.CreateNewPasswordApplication class.
        /// </summary>
        /// <param name="functionFacade">User function facade that provides a simplified interface.</param>
        /// <param name="tokenJwt">Manages Json Web Token and Cryptography.</param>
        /// <param name="applicationContext">Class to be used on one instance throughout the application per request.</param>
        /// <param name="appConfig">Application Configuration.</param>
        /// <param name="logger">Log</param>
        public ChangePasswordApplication(
                IUserFunctionFacade functionFacade,
                ITokenJwt tokenJwt,
                IApplicationContext applicationContext,
                IAppConfig appConfig,
                ILogger<ChangePasswordApplication> logger
            )
        {
            _functionFacade = functionFacade;
            _tokenJwt = tokenJwt;
            _applicationContext = applicationContext;
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
        public async Task HandleAsync(ChangePasswordRequest request)
        {
            string methodName = nameof(HandleAsync);

            _logger.LogBeginInformation(methodName);

            var userResponse = await _functionFacade
                .GetByAuthenticationAsync
                (
                    _applicationContext.LoggedUser.User, _tokenJwt.EncryptPassword(request.OldPassword)
                ).ConfigureAwait(false);

            if (userResponse is null)
            {
                throw new RequestException(HttpStatusCode.Unauthorized, _appConfig.MessagesCatalogResource.GetMessageUnauthorized());
            }

            await _functionFacade
                .PutPasswordAsync(userResponse.Id, _tokenJwt.EncryptPassword(request.NewPassword))
                .ConfigureAwait(false);

            _logger.LogEndInformation(methodName);
        }

        #endregion

        #endregion
    }
}
