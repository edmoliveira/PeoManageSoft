using Microsoft.Extensions.Logging;
using PeoManageSoft.Business.Domain.Services.Middlewares.Interfaces;
using PeoManageSoft.Business.Infrastructure.Helpers.Exceptions;
using PeoManageSoft.Business.Infrastructure.Helpers.Extensions;
using PeoManageSoft.Business.Infrastructure.Helpers.Interfaces;
using System.Collections.Specialized;


namespace PeoManageSoft.Business.Domain.Services.Commands.Messaging.SendEmail
{
    /// <summary>
    /// Send email command.
    /// </summary>
    internal sealed class SendEmailCommand : ISendEmailCommand
    {
        #region Fields

        /// <summary>
        /// Defines a mechanism for retrieving a service object; that is, an object that provides custom support to other objects.
        /// </summary>
        private readonly IServiceProvider _provider;
        /// <summary>
        /// Configuration for maps.
        /// </summary>
        private readonly SendEmailMapper _mapper;
        /// <summary>
        /// Log
        /// </summary>
        private readonly ILogger<SendEmailCommand> _logger;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the PeoManageSoft.Business.Domain.Services.Commands.Messaging.SendEmail.SendEmailCommand class.
        /// </summary>
        /// <param name="provider">Defines a mechanism for retrieving a service object; that is, an object that provides custom support to other objects.</param>
        /// <param name="appConfig">Application Configuration</param>
        /// <param name="logger">Log</param>
        public SendEmailCommand(
            IServiceProvider provider,
            IAppConfig appConfig,
            ILogger<SendEmailCommand> logger)
        {
            _provider = provider;
            _mapper = new SendEmailMapper(appConfig);
            _logger = logger;
        }

        #endregion

        #region Methods

        #region public

        /// <summary>
        /// Executes the command and asynchronously using Task.
        /// </summary>
        /// <param name="request">Request for the add user command.</param>
        /// <returns>
        /// Task: Represents an asynchronous operation. 
        /// Response for the send email command.
        /// </returns>
        public async Task<SendEmailResponse> ExecuteAsync(SendEmailRequest request)
        {
            string methodName = nameof(ExecuteAsync);

            _logger.LogBeginInformation(methodName);

            using IMailMiddleware mail = GetMailMiddlewareService();

            _mapper.Map(request, mail);

            await mail.SmtpClient.SendAsync().ConfigureAwait(false);

            var response = new SendEmailResponse();

            if (mail.Headers?.AllKeys.Length > 0)
            {
                response.Headers = new StringDictionary();

                foreach (string key in mail.Headers.AllKeys)
                {
                    response.Headers.Add(key, mail.Headers[key]);
                }
            }

            _logger.LogEndInformation(methodName);

            return response;
        }

        #endregion

        #region private

        /// <summary>
        ///  Gets the service object of the Middleware for MailMessage.
        /// </summary>
        /// <returns>Middleware for MailMessage</returns>
        private IMailMiddleware GetMailMiddlewareService()
        {
            if (!(_provider.GetService(typeof(IMailMiddleware)) is IMailMiddleware service))
            {
                throw new ProviderServiceNotFoundException(nameof(IMailMiddleware));
            }

            return service;
        }

        #endregion

        #endregion
    }
}
