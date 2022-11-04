using Microsoft.Extensions.Logging;
using PeoManageSoft.Business.Infrastructure.Helpers.Extensions;

namespace PeoManageSoft.Business.Domain.Services.Commands.Messaging.SendEmail
{
    /// <summary>
    /// Handles all commands to send email.
    /// </summary>
    internal sealed class SendEmailHandler : ISendEmailHandler
    {
        #region Fields

        /// <summary>
        /// Send email command.
        /// </summary>
        private readonly ISendEmailCommand _command;
        /// <summary>
        /// Log
        /// </summary>
        private readonly ILogger<SendEmailHandler> _logger;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the PeoManageSoft.Business.Domain.Services.Commands.Messaging.SendEmail.SendEmailHandler class.
        /// </summary>
        /// <param name="command">Send email command.</param>
        /// <param name="logger">Log</param>
        public SendEmailHandler(
                ISendEmailCommand command,
                ILogger<SendEmailHandler> logger
            )
        {
            _command = command;
            _logger = logger;
        }

        #endregion

        #region Methods

        #region public

        /// <summary>
        /// Handles the send email command
        /// </summary>
        /// <param name="request">Request for the send email command.</param>
        /// <returns>
        /// Task: Represents an asynchronous operation. 
        /// Response for the send email command.
        /// </returns>
        public async Task<SendEmailResponse> HandleAsync(SendEmailRequest request)
        {
            string methodName = nameof(HandleAsync);

            _logger.LogBeginInformation(methodName);

            SendEmailResponse result = await _command.ExecuteAsync(request).ConfigureAwait(false);

            _logger.LogEndInformation(methodName);

            return result;
        }

        #endregion

        #endregion
    }
}
