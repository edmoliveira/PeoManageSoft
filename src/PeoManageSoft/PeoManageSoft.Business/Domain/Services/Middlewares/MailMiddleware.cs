using PeoManageSoft.Business.Domain.Services.Middlewares.Interfaces;
using System.Collections.Specialized;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace PeoManageSoft.Business.Domain.Services.Middlewares
{
    /// <summary>
    /// Middleware for MailMessage.
    /// </summary>
    /// <remarks>
    /// MailMessage class => 
    /// Represents an email message that can be sent using the System.Net.Mail.SmtpClient class.
    /// </remarks>
    internal sealed class MailMiddleware : IMailMiddleware, ISmtpClient
    {
        #region Fields

        /// <summary>
        /// Allows applications to send email by using the Simple Mail Transfer Protocol (SMTP).
        /// </summary>
        public readonly SmtpClient _smtpClient;
        /// <summary>
        /// Represents an email message that can be sent using the System.Net.Mail.SmtpClient
        /// class.
        /// </summary>
        public readonly MailMessage _mailMessage;

        #endregion

        #region Properties

        /// <summary>
        /// Allows applications to send email by using the Simple Mail Transfer Protocol (SMTP).
        /// </summary>
        public ISmtpClient SmtpClient { get; private set; }
        /// <summary>
        /// Occurs when an asynchronous email send operation completes.
        /// </summary>
        public event SendCompletedEventHandler SendCompleted;

        #region MailMessage

        /// <summary>
        /// Gets or sets the subject line for this email message.
        /// </summary>
        public string Subject { get => _mailMessage.Subject; set => _mailMessage.Subject = value; }
        /// <summary>
        ///  Gets or sets the sender's address for this email message.
        /// </summary>
        public MailAddress Sender { get => _mailMessage.Sender; set => _mailMessage.Sender = value; }
        /// <summary>
        /// Gets the list of addresses to reply to for the mail message.
        /// </summary>
        public MailAddressCollection ReplyToList => _mailMessage.ReplyToList;
        /// <summary>
        /// Gets or sets the priority of this email message.
        /// </summary>
        public MailPriority Priority { get => _mailMessage.Priority; set => _mailMessage.Priority = value; }
        /// <summary>
        /// Gets or sets a value indicating whether the mail message body is in HTML.
        /// </summary>
        public bool IsBodyHtml { get => _mailMessage.IsBodyHtml; set => _mailMessage.IsBodyHtml = value; }
        /// <summary>
        /// Gets or sets the encoding used for the user-defined custom headers for this email
        /// message.
        /// </summary>
        public Encoding HeadersEncoding { get => _mailMessage.HeadersEncoding; set => _mailMessage.HeadersEncoding = value; }
        /// <summary>
        /// Gets the email headers that are transmitted with this email message.
        /// </summary>
        public NameValueCollection Headers => _mailMessage.Headers;
        /// <summary>
        /// Gets or sets the from address for this email message.
        /// </summary>
        public MailAddress From { get => _mailMessage.From; set => _mailMessage.From = value; }
        /// <summary>
        /// Gets the address collection that contains the carbon copy (CC) recipients for
        /// this email message.
        /// </summary>
        public MailAddressCollection CC => _mailMessage.CC;
        /// <summary>
        /// Gets or sets the encoding used for the subject content for this email message.
        /// </summary>
        public Encoding SubjectEncoding { get => _mailMessage.SubjectEncoding; set => _mailMessage.SubjectEncoding = value; }
        /// <summary>
        /// Gets or sets the transfer encoding used to encode the message body.
        /// </summary>
        public TransferEncoding BodyTransferEncoding { get => _mailMessage.BodyTransferEncoding; set => _mailMessage.BodyTransferEncoding = value; }
        /// <summary>
        /// Gets or sets the encoding used to encode the message body.
        /// </summary>
        public Encoding BodyEncoding { get => _mailMessage.BodyEncoding; set => _mailMessage.BodyEncoding = value; }
        /// <summary>
        /// Gets or sets the message body.
        /// </summary>
        public string Body { get => _mailMessage.Body; set => _mailMessage.Body = value; }
        /// <summary>
        /// Gets the address collection that contains the blind carbon copy (BCC) recipients
        /// for this email message.
        /// </summary>
        public MailAddressCollection Bcc => _mailMessage.Bcc;
        /// <summary>
        /// Gets the attachment collection used to store data attached to this email message.
        /// </summary>
        public AttachmentCollection Attachments => _mailMessage.Attachments;
        /// <summary>
        /// Gets the attachment collection used to store alternate forms of the message body.
        /// </summary>
        public AlternateViewCollection AlternateViews => _mailMessage.AlternateViews;
        /// <summary>
        /// Gets or sets the delivery notifications for this email message.
        /// </summary>
        public DeliveryNotificationOptions DeliveryNotificationOptions { get => _mailMessage.DeliveryNotificationOptions; set => _mailMessage.DeliveryNotificationOptions = value; }
        /// <summary>
        /// Gets the address collection that contains the recipients of this email message.
        /// </summary>
        public MailAddressCollection To => _mailMessage.To;

        #endregion

        #region SmtpClient

        /// <summary>
        /// Gets or sets a value that specifies the amount of time after which a synchronous
        /// Overload:System.Net.Mail.SmtpClient.Send call times out.
        /// </summary>
        int ISmtpClient.Timeout { get => _smtpClient.Timeout; set => _smtpClient.Timeout = value; }
        /// <summary>
        /// Gets or sets the Service Provider Name (SPN) to use for authentication when using
        /// extended protection.
        /// </summary>
        string ISmtpClient.TargetName { get => _smtpClient.TargetName; set => _smtpClient.TargetName = value; }
        /// <summary>
        /// Gets the network connection used to transmit the email message.
        /// </summary>
        ServicePoint ISmtpClient.ServicePoint => _smtpClient.ServicePoint;
        /// <summary>
        /// Gets or sets the port used for SMTP transactions.
        /// </summary>
        int ISmtpClient.Port { get => _smtpClient.Port; set => _smtpClient.Port = value; }
        /// <summary>
        /// Gets or sets the folder where applications save mail messages to be processed
        /// by the local SMTP server.
        /// </summary>
        string ISmtpClient.PickupDirectoryLocation { get => _smtpClient.PickupDirectoryLocation; set => _smtpClient.PickupDirectoryLocation = value; }
        /// <summary>
        /// Gets or sets the name or IP address of the host used for SMTP transactions.
        /// </summary>
        string ISmtpClient.Host { get => _smtpClient.Host; set => _smtpClient.Host = value; }
        /// <summary>
        /// Specify whether the System.Net.Mail.SmtpClient uses Secure Sockets Layer (SSL)
        /// to encrypt the connection.
        /// </summary>
        bool ISmtpClient.EnableSsl { get => _smtpClient.EnableSsl; set => _smtpClient.EnableSsl = value; }
        /// <summary>
        /// Specifies how outgoing email messages will be handled.
        /// </summary>
        SmtpDeliveryMethod ISmtpClient.DeliveryMethod { get => _smtpClient.DeliveryMethod; set => _smtpClient.DeliveryMethod = value; }
        /// <summary>
        /// Gets or sets the delivery format used by System.Net.Mail.SmtpClient to send email.
        /// </summary>
        SmtpDeliveryFormat ISmtpClient.DeliveryFormat { get => _smtpClient.DeliveryFormat; set => _smtpClient.DeliveryFormat = value; }
        /// <summary>
        /// Gets or sets a System.Boolean value that controls whether the System.Net.CredentialCache.DefaultCredentials
        /// are sent with requests.
        /// </summary>
        bool ISmtpClient.UseDefaultCredentials { get => _smtpClient.UseDefaultCredentials; set => _smtpClient.UseDefaultCredentials = value; }
        /// <summary>
        /// Specify which certificates should be used to establish the Secure Sockets Layer
        /// (SSL) connection.
        /// </summary>
        X509CertificateCollection ISmtpClient.ClientCertificates => _smtpClient.ClientCertificates;
        /// <summary>
        /// Gets or sets the credentials used to authenticate the sender.
        /// </summary>
        ICredentialsByHost ISmtpClient.Credentials { get => _smtpClient.Credentials; set => _smtpClient.Credentials = value; }

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the PeoManageSoft.Business.Domain.Services.Middlewares.MailMiddleware class.
        /// </summary>
        /// <param name="smtpClient">Allows applications to send email by using the Simple Mail Transfer Protocol (SMTP).</param>
        /// <param name="mailMessage">Represents an email message that can be sent using the System.Net.Mail.SmtpClient</param>
        public MailMiddleware(SmtpClient smtpClient, MailMessage mailMessage)
        {
            SmtpClient = this;

            _smtpClient = smtpClient;
            _mailMessage = mailMessage;

            _smtpClient.SendCompleted += (sender, e) =>
            {
                SendCompleted(sender, e);
            };
        }

        /// <summary>
        /// Initializes a new instance of the PeoManageSoft.Business.Domain.Services.Middlewares.MailMiddleware class.
        /// </summary>
        /// <param name="smtpClient">Allows applications to send email by using the Simple Mail Transfer Protocol (SMTP).</param>
        /// <param name="mailMessage">Represents an email message that can be sent using the System.Net.Mail.SmtpClient</param>
        /// <param name="smtpClientMock">Mock SmtpClient</param>
        public MailMiddleware(SmtpClient smtpClient, MailMessage mailMessage, ISmtpClient smtpClientMock)
        {
            SmtpClient = smtpClientMock;

            _smtpClient = smtpClient;
            _mailMessage = mailMessage;

            _smtpClient.SendCompleted += (sender, e) =>
            {
                SendCompleted(sender, e);
            };
        }

        #endregion

        #region Methods

        #region public

        /// <summary>
        /// Sends the specified message to an SMTP server for delivery.
        /// </summary>
        void ISmtpClient.Send()
        {
            _smtpClient.Send(_mailMessage);
        }

        /// <summary>
        /// Sends the specified message to an SMTP server for delivery as an asynchronous operation.
        /// </summary>
        /// <returns>The task object representing the asynchronous operation.</returns>
        Task ISmtpClient.SendAsync()
        {
            return _smtpClient.SendMailAsync(_mailMessage);
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting
        /// unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            _mailMessage.Dispose();
            _smtpClient.Dispose();

        }

        #endregion

        #endregion
    }
}
