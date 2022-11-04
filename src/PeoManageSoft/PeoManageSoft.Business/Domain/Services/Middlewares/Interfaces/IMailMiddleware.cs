using System.Collections.Specialized;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;

namespace PeoManageSoft.Business.Domain.Services.Middlewares.Interfaces
{
    /// <summary>
    /// Middleware for MailMessage.
    /// </summary>
    /// <remarks>
    /// MailMessage class => 
    /// Represents an email message that can be sent using the System.Net.Mail.SmtpClient class.
    /// </remarks>
    internal interface IMailMiddleware : IDisposable
    {
        #region Properties

        /// <summary>
        /// Allows applications to send email by using the Simple Mail Transfer Protocol (SMTP).
        /// </summary>
        ISmtpClient SmtpClient { get; }
        /// <summary>
        /// Gets or sets the subject line for this email message.
        /// </summary>
        string Subject { get; set; }
        /// <summary>
        ///  Gets or sets the sender's address for this email message.
        /// </summary>
        MailAddress Sender { get; set; }
        /// <summary>
        /// Gets the list of addresses to reply to for the mail message.
        /// </summary>
        MailAddressCollection ReplyToList { get; }
        /// <summary>
        /// Gets or sets the priority of this email message.
        /// </summary>
        MailPriority Priority { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether the mail message body is in HTML.
        /// </summary>
        bool IsBodyHtml { get; set; }
        /// <summary>
        /// Gets or sets the encoding used for the user-defined custom headers for this email
        /// message.
        /// </summary>
        Encoding HeadersEncoding { get; set; }
        /// <summary>
        /// Gets the email headers that are transmitted with this email message.
        /// </summary>
        NameValueCollection Headers { get; }
        /// <summary>
        /// Gets or sets the from address for this email message.
        /// </summary>
        MailAddress From { get; set; }
        /// <summary>
        /// Gets the address collection that contains the carbon copy (CC) recipients for
        /// this email message.
        /// </summary>
        MailAddressCollection CC { get; }
        /// <summary>
        /// Gets or sets the encoding used for the subject content for this email message.
        /// </summary>
        Encoding SubjectEncoding { get; set; }
        /// <summary>
        /// Gets or sets the transfer encoding used to encode the message body.
        /// </summary>
        TransferEncoding BodyTransferEncoding { get; set; }
        /// <summary>
        /// Gets or sets the encoding used to encode the message body.
        /// </summary>
        Encoding BodyEncoding { get; set; }
        /// <summary>
        /// Gets or sets the message body.
        /// </summary>
        string Body { get; set; }
        /// <summary>
        /// Gets the address collection that contains the blind carbon copy (BCC) recipients
        /// for this email message.
        /// </summary>
        MailAddressCollection Bcc { get; }
        /// <summary>
        /// Gets the attachment collection used to store data attached to this email message.
        /// </summary>
        AttachmentCollection Attachments { get; }
        /// <summary>
        /// Gets the attachment collection used to store alternate forms of the message body.
        /// </summary>
        AlternateViewCollection AlternateViews { get; }
        /// <summary>
        /// Gets or sets the delivery notifications for this email message.
        /// </summary>
        DeliveryNotificationOptions DeliveryNotificationOptions { get; set; }
        /// <summary>
        /// Gets the address collection that contains the recipients of this email message.
        /// </summary>
        MailAddressCollection To { get; }

        #endregion
    }
}
