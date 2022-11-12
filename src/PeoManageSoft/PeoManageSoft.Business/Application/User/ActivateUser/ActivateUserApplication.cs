using Microsoft.Extensions.Logging;
using PeoManageSoft.Business.Domain.Services.Functions.User;
using PeoManageSoft.Business.Domain.Services.Queries.User.Get;
using PeoManageSoft.Business.Infrastructure.Helpers.Exceptions;
using PeoManageSoft.Business.Infrastructure.Helpers.Extensions;
using PeoManageSoft.Business.Infrastructure.Helpers.Interfaces;
using System.Net;

namespace PeoManageSoft.Business.Application.User.ActivateUser
{
    /// <summary>
    /// Application layer to activate the user if the user token is valid. 
    /// </summary>
    internal sealed class ActivateUserApplication : IActivateUserApplication
    {
        #region Fields

        /// <summary>
        /// User function facade that provides a simplified interface.
        /// </summary>
        private readonly IUserFunctionFacade _functionFacade;
        /// <summary>
        /// Handles all queries to get the user.
        /// </summary>
        private readonly IGetHandler _getHandler;
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
        private readonly ILogger<ActivateUserApplication> _logger;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the PeoManageSoft.Business.Application.User.ActivateUser.ActivateUserApplication class.
        /// </summary>
        /// <param name="functionFacade">User function facade that provides a simplified interface.</param>
        /// <param name="getHandler">Handles all queries to get the user.</param>
        /// <param name="tokenJwt">Manages Json Web Token and Cryptography.</param>
        /// <param name="appConfig">Application Configuration.</param>
        /// <param name="logger">Log</param>
        public ActivateUserApplication(
                IUserFunctionFacade functionFacade,
                IGetHandler getHandler,
                ITokenJwt tokenJwt,
                IAppConfig appConfig,
                ILogger<ActivateUserApplication> logger
            )
        {
            _functionFacade = functionFacade;
            _getHandler = getHandler;
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
        /// <returns>Represents an asynchronous operation.</returns>
        public async Task HandleAsync(ActivateUserRequest request)
        {
            string methodName = nameof(HandleAsync);

            _logger.LogBeginInformation(methodName);

            if (_tokenJwt.TryGetUserIdByUserToken(request.UserToken, out var userId))
            {
                var userResponse = await _getHandler.HandleAsync(new GetRequest
                {
                    Id = userId
                }).ConfigureAwait(false);

                if (userResponse is null)
                {
                    throw new RequestException(HttpStatusCode.NotFound, _appConfig.MessagesCatalogResource.GetMessageNotFound(nameof(userId)));
                }

                if (!userResponse.IsActive)
                {
                    await _functionFacade.ActivateUserAsync(userResponse.Id).ConfigureAwait(false);
                }
            }
            else
            {
                throw new RequestException(HttpStatusCode.Unauthorized, _appConfig.MessagesCatalogResource.GetMessageExpiredToken());
            }

            _logger.LogEndInformation(methodName);
        }

        #endregion

        #endregion
    }
}
