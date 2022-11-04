using PeoManageSoft.Business.Domain.Services.Middlewares.Interfaces;
using PeoManageSoft.Business.Infrastructure.Helpers.Interfaces;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;

namespace PeoManageSoft.Business.Domain.Services.Commands.Messaging.SendEmail
{
    /// <summary>
    /// Configuration for maps.
    /// </summary>
    sealed class SendEmailMapper
    {
        #region Fields

        /// <summary>
        /// Smtp Configuration
        /// </summary>
        private readonly ISmtpConfiguration _smtpConfig;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the PeoManageSoft.Business.Domain.Services.Commands.Messaging.SendEmail.SendEmailMapper class.
        /// </summary>
        /// <param name="appConfig">Application Configuration</param>
        public SendEmailMapper(IAppConfig appConfig)
        {
            _smtpConfig = appConfig.SmtpConfig;
        }

        #endregion

        #region Methods

        #region public

        /// <summary>
        /// Execute a mapping from the source object to a new destination object
        /// </summary>
        /// <param name="source">Source object to map from</param>
        /// <param name="destination">Destination object to map into</param>
        public void Map(SendEmailRequest source, IMailMiddleware destination)
        {
            destination.Subject = source.Data.Subject;
            destination.Priority = (MailPriority)source.Data.Priority;
            destination.IsBodyHtml = source.Data.IsBodyHtml;
            destination.HeadersEncoding = source.Data.HeadersEncoding;
            destination.SubjectEncoding = source.Data.SubjectEncoding ?? Encoding.GetEncoding(_smtpConfig.SubjectEncodingEmail);
            destination.BodyTransferEncoding = (TransferEncoding)source.Data.BodyTransferEncoding;
            destination.BodyEncoding = source.Data.BodyEncoding ?? Encoding.GetEncoding(_smtpConfig.BodyEncodingEmail);
            destination.Body = source.Data.Body;
            destination.DeliveryNotificationOptions = (DeliveryNotificationOptions)source.Data.DeliveryNotificationOptions;

            source.Data.ReplyToList?.ForEach(item =>
            {
                destination.ReplyToList.Add(new MailAddress(item.Address, item.DisplayName));
            });

            source.Data.CC?.ForEach(item =>
            {
                destination.CC.Add(new MailAddress(item.Address, item.DisplayName));
            });

            source.Data.Bcc?.ForEach(item =>
            {
                destination.Bcc.Add(new MailAddress(item.Address, item.DisplayName));
            });

            source.Data.Attachments?.ForEach(item =>
            {
                if (item.ContentType != null)
                {
                    destination.Attachments.Add(new Attachment(item.FileName, new ContentType(item.ContentType.ContentType)));
                }
                else
                {
                    destination.Attachments.Add(new Attachment(item.FileName));
                }
            });

            source.Data.AlternateViews?.ForEach(item =>
            {
                AlternateView alternateView = null;

                if (item.ContentType != null)
                {
                    alternateView = AlternateView.CreateAlternateViewFromString(item.Content, new ContentType(item.ContentType.ContentType));
                }
                else
                {
                    alternateView = AlternateView.CreateAlternateViewFromString(item.Content);
                }

                item.LinkedResources?.ForEach(resource =>
                {
                    LinkedResource linkedResource;

                    if (resource.ContentType != null)
                    {
                        linkedResource = new LinkedResource(resource.FileName, new ContentType(resource.ContentType.ContentType));
                    }
                    else
                    {
                        linkedResource = new LinkedResource(resource.FileName);
                    }

                    linkedResource.ContentId = resource.ContentId;
                    linkedResource.ContentLink = resource.ContentLink;

                    alternateView.LinkedResources.Add(linkedResource);
                });
            });

            if (source.Data.From != null)
            {
                destination.From = new MailAddress(source.Data.From.Address, source.Data.From.DisplayName);
            }
            else if (source.Data.Sender != null)
            {
                destination.Sender = new MailAddress(source.Data.Sender.Address, source.Data.Sender.DisplayName);
            }
            else
            {
                destination.From = new MailAddress(_smtpConfig.SenderAddressEmail, _smtpConfig.DisplayNameEmail);
            }

            source.Data.To.ForEach(item =>
            {
                destination.To.Add(new MailAddress(item.Address, item.DisplayName));
            });

            destination.SmtpClient.Host = _smtpConfig.HostEmail;
            destination.SmtpClient.Port = _smtpConfig.PortEmail;
            destination.SmtpClient.Credentials = new NetworkCredential(
                _smtpConfig.UserNameEmail,
                _smtpConfig.PasswordEmail
            );
        }

        #endregion

        #endregion
    }
}
