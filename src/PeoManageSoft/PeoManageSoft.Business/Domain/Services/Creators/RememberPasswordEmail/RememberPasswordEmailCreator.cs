using Microsoft.Extensions.Logging;
using PeoManageSoft.Business.Domain.Services.Commands.Messaging.SendEmail.Models;
using PeoManageSoft.Business.Domain.Services.Creators.RememberPasswordEmail.Interfaces;
using PeoManageSoft.Business.Infrastructure.Helpers;
using PeoManageSoft.Business.Infrastructure;
using PeoManageSoft.Business.Infrastructure.Helpers.Extensions;
using PeoManageSoft.Business.Infrastructure.Helpers.Interfaces;
using PeoManageSoft.Business.Infrastructure.Helpers.Resources.Interfaces;

namespace PeoManageSoft.Business.Domain.Services.Creators.RememberPasswordEmail
{
    /// <summary>
    /// Provides a creator to create an email layout "Remember Password".
    /// </summary>
    internal sealed class RememberPasswordEmailCreator : IRememberPasswordEmailCreator
    {
        #region Fields private

        /// <summary>
        /// Application Configuration
        /// </summary>
        private readonly IAppConfig _appConfig;
        /// <summary>
        /// Log
        /// </summary>
        private readonly ILogger<RememberPasswordEmailCreator> _logger;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the PeoManageSoft.Business.Domain.Services.Creators.RememberPasswordEmail.RememberPasswordEmailCreator class.
        /// </summary>
        /// <param name="appConfig">Application Configuration</param>
        /// <param name="logger">Log</param>
        public RememberPasswordEmailCreator(IAppConfig appConfig, ILogger<RememberPasswordEmailCreator> logger)
        {
            _appConfig = appConfig;
            _logger = logger;
        }

        #endregion

        #region Method 

        #region public

        /// <summary>
        /// Create the object of the class Salep.Domain.Service.Messages.Models.EmailData
        /// </summary>
        /// <param name="to">Email address that will be sent</param>
        /// <param name="urlToken">Url with token.</param>
        /// <param name="location">Where the password reminder request was made</param>
        /// <returns>EmailData</returns>
        public EmailData CreateEmail(string to, string urlToken, string location)
        {
            string methodName = nameof(CreateEmail);

            _logger.LogBeginInformation(methodName);

            IEmailTemplateResource templateResource = _appConfig.EmailTemplatesCatalog.RememberPassword;
            IImagesCatalogResource imagesResource = _appConfig.ImagesCatalog;

            EmailLinkedResource logoLinkedResource = new(imagesResource.Logo64x64, Guid.NewGuid().ToString());
            EmailLinkedResource keysLinkedResource = new(imagesResource.Keys256x256, Guid.NewGuid().ToString());

            string html = templateResource.ReadHtmlFile(_appConfig.ApplicationLanguage)
                            .Replace(ApplicationResource.RememberPasswordLogoGuidVariable, logoLinkedResource.ContentId)
                            .Replace(ApplicationResource.RememberPasswordKeysGuidVariable, keysLinkedResource.ContentId)
                            .Replace(ApplicationResource.RememberPasswordUrlVariable, urlToken)
                            .Replace(ApplicationResource.RememberPasswordLocationVariable, location);

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
                Subject = templateResource.ReadSubjectFile(_appConfig.ApplicationLanguage).Replace(ApplicationResource.ApplicationNameVariable, _appConfig.ApplicationName),
                AlternateViews = new List<EmailAlternateView> { alternateView }
            };

            _logger.LogEndInformation(methodName);

            return emailData;
        }

        #endregion

        #endregion
    }
}
