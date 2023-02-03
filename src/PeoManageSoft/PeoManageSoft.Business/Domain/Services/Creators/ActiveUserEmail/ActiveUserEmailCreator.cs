using Microsoft.Extensions.Logging;
using PeoManageSoft.Business.Domain.Services.Commands.Messaging.SendEmail.Models;
using PeoManageSoft.Business.Domain.Services.Creators.ActiveUserEmail.Interfaces;
using PeoManageSoft.Business.Infrastructure;
using PeoManageSoft.Business.Infrastructure.Helpers;
using PeoManageSoft.Business.Infrastructure.Helpers.Extensions;
using PeoManageSoft.Business.Infrastructure.Helpers.Interfaces;
using PeoManageSoft.Business.Infrastructure.Helpers.Resources.Interfaces;

namespace PeoManageSoft.Business.Domain.Services.Creators.ActiveUserEmail
{
    /// <summary>
    /// Provides a creator to create an email layout "Active User".
    /// </summary>
    internal sealed class ActiveUserEmailCreator : IActiveUserEmailCreator
    {
        #region Fields private

        /// <summary>
        /// Application Configuration
        /// </summary>
        private readonly IAppConfig _appConfig;
        /// <summary>
        /// Log
        /// </summary>
        private readonly ILogger<ActiveUserEmailCreator> _logger;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the PeoManageSoft.Business.Domain.Services.Creators.ActiveUserEmail.ActiveUserEmailCreator class.
        /// </summary>
        /// <param name="appConfig">Application Configuration</param>
        /// <param name="logger">Log</param>
        public ActiveUserEmailCreator(IAppConfig appConfig, ILogger<ActiveUserEmailCreator> logger)
        {
            _appConfig = appConfig;
            _logger = logger;
        }

        #endregion

        #region Method 

        #region public

        /// <summary>
        /// Create the object of the class PeoManageSoft.Business.Domain.Services.Commands.Messaging.SendEmail.Models.EmailData
        /// </summary>
        /// <param name="to">Email address that will be sent</param>
        /// <param name="urlToken">Url with token.</param>
        /// <returns>EmailData</returns>
        public EmailData CreateEmail(string to, string urlToken)
        {
            string methodName = nameof(CreateEmail);

            _logger.LogBeginInformation(methodName);

            IEmailTemplateResource templateResource = _appConfig.EmailTemplatesCatalog.ActiveUser;
            IImagesCatalogResource imagesResource = _appConfig.ImagesCatalog;

            EmailLinkedResource logoLinkedResource = new(imagesResource.Logo64x64, Guid.NewGuid().ToString());
            EmailLinkedResource keysLinkedResource = new(imagesResource.Keys256x256, Guid.NewGuid().ToString());

            string html = templateResource.ReadHtmlFile(_appConfig.ApplicationLanguage)
                            .Replace(InfraSettings.EmailLogoGuidVariable, logoLinkedResource.ContentId)
                            .Replace(InfraSettings.EmailKeysGuidVariable, keysLinkedResource.ContentId)
                            .Replace(InfraSettings.EmailUrlVariable, urlToken);

            EmailAlternateView alternateView = new(html, new EmailContentType(System.Net.Mime.MediaTypeNames.Text.Html))
            {
                LinkedResources = new List<EmailLinkedResource>
                    {
                        logoLinkedResource,
                        keysLinkedResource
                    }
            };

            EmailData emailData = new()
            {
                To = new List<EmailAddress> { new EmailAddress(to) },
                Priority = EmailPriority.High,
                IsBodyHtml = true,
                Subject = templateResource.ReadSubjectFile(_appConfig.ApplicationLanguage).Replace(InfraSettings.ApplicationNameVariable, _appConfig.ApplicationName),
                AlternateViews = new List<EmailAlternateView> { alternateView }
            };

            _logger.LogEndInformation(methodName);

            return emailData;
        }

        #endregion

        #endregion
    }
}
