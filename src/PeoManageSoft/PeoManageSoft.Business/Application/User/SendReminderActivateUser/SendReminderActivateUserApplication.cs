using Microsoft.Extensions.Logging;
using PeoManageSoft.Business.Domain.Services.Functions.User;
using PeoManageSoft.Business.Domain.Services.Functions.User.SendEmailToActiveUser;
using PeoManageSoft.Business.Domain.Services.Queries.User.Get;
using PeoManageSoft.Business.Infrastructure.Helpers.Exceptions;
using PeoManageSoft.Business.Infrastructure.Helpers.Extensions;
using PeoManageSoft.Business.Infrastructure.Helpers.Interfaces;
using System.Net;

namespace PeoManageSoft.Business.Application.User.SendReminderActivateUser
{
    /// <summary>
    /// Application layer to send an email with a reminder to activate the user.
    /// </summary>
    internal sealed class SendReminderActivateUserApplication : ISendReminderActivateUserApplication
    {
        #region Fields

        /// <summary>
        /// Handles all queries to get the user.
        /// </summary>
        private readonly IGetHandler _getHandler;
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
        private readonly ILogger<SendReminderActivateUserApplication> _logger;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the PeoManageSoft.Business.Application.User.SendReminderActivateUser.SendReminderActivateUserApplication class.
        /// </summary>
        /// <param name="getHandler">Handles all queries to get the user.</param>
        /// <param name="functionFacade">User function facade that provides a simplified interface.</param>
        /// <param name="tokenJwt">Manages Json Web Token and Cryptography.</param>
        /// <param name="appConfig">Application Configuration.</param>
        /// <param name="logger">Log</param>
        public SendReminderActivateUserApplication(
            IGetHandler getHandler,
            IUserFunctionFacade functionFacade,
            ITokenJwt tokenJwt,
            IAppConfig appConfig,
            ILogger<SendReminderActivateUserApplication> logger
        )
        {
            _getHandler = getHandler;
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
        /// <returns>Represents an asynchronous operation.</returns>
        public async Task HandleAsync(SendReminderActivateUserRequest request)
        {
            string methodName = nameof(HandleAsync);

            _logger.LogBeginInformation(methodName);

            var userResponse = await _getHandler.HandleAsync(new GetRequest { Id = request.Id }).ConfigureAwait(false);

            if (userResponse is null)
            {
                throw new RequestException(HttpStatusCode.NotFound, _appConfig.MessagesCatalogResource.GetMessageNotFound(nameof(request.Id)));
            }

            _ = _functionFacade.SendEmailToActiveUserAsync(new SendEmailToActiveUserFunctionRequest
            {
                Email = userResponse.Email,
                Url = request.Url,
                UserToken = _tokenJwt.CreateUserToken(userResponse.Id, userResponse.Email)
            })
            .ConfigureAwait(false);

            _logger.LogEndInformation(methodName);
        }

        #endregion

        #endregion
    }
}
