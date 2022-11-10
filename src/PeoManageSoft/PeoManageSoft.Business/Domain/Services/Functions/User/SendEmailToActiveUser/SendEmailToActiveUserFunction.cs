using Microsoft.Extensions.Logging;
using PeoManageSoft.Business.Domain.Services.Commands.Messaging.SendEmail;
using PeoManageSoft.Business.Domain.Services.Creators.ActiveUserEmail.Interfaces;
using PeoManageSoft.Business.Infrastructure.Helpers.Extensions;
using System.Collections.Specialized;

namespace PeoManageSoft.Business.Domain.Services.Functions.User.SendEmailToActiveUser
{
    /// <summary>
    /// Function to send an email with token in the url to activate the user.
    /// </summary>
    internal sealed class SendEmailToActiveUserFunction : ISendEmailToActiveUserFunction
    {
        #region Fields

        /// <summary>
        /// Provides a creator to create an email layout "Active User".
        /// </summary>
        private readonly IActiveUserEmailCreator _activeUserEmailCreator;
        /// <summary>
        /// Handles all commands to send email.
        /// </summary>
        private readonly ISendEmailHandler _sendEmailHandler;
        /// <summary>
        /// Log
        /// </summary>
        private readonly ILogger<SendEmailToActiveUserFunction> _logger;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the PeoManageSoft.Business.Domain.Services.Functions.User.SendEmailToActiveUser.SendEmailToActiveUserFunction class.
        /// </summary>
        /// <param name="activeUserEmailCreator">Provides a creator to create an email layout "Active User".</param>
        /// <param name="sendEmailHandler">Handles all commands to send email.</param>
        /// <param name="logger">Log</param>
        public SendEmailToActiveUserFunction(
                IActiveUserEmailCreator activeUserEmailCreator,
                ISendEmailHandler sendEmailHandler,
                ILogger<SendEmailToActiveUserFunction> logger
            )
        {
            _activeUserEmailCreator = activeUserEmailCreator;
            _sendEmailHandler = sendEmailHandler;
            _logger = logger;
        }

        #endregion

        #region Methods

        #region public

        /// <summary>
        /// Executes the function and asynchronously using Task.
        /// </summary>
        /// <param name="request">Request for the function.</param>
        /// <returns>
        /// Task: Represents an asynchronous operation. 
        /// The return value
        /// </returns>
        public async Task<StringDictionary> ExecuteAsync(SendEmailToActiveUserFunctionRequest request)
        {
            string methodName = nameof(ExecuteAsync);

            _logger.LogBeginInformation(methodName);

            var response = await _sendEmailHandler.HandleAsync(new SendEmailRequest
            {
                Data = _activeUserEmailCreator.CreateEmail(
                            request.Email,
                            string.Concat(request.Url, request.UserToken)
                        )
            }).ConfigureAwait(false);

            _logger.LogEndInformation(methodName);

            return response?.Headers;
        }

        #endregion

        #endregion
    }
}
