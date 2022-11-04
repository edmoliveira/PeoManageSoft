using PeoManageSoft.Business.Infrastructure;
using System.Text;

namespace PeoManageSoft.Business.Domain.Services.Commands.Messaging.SendEmail.Models
{
    /// <summary>
    /// Email data
    /// </summary>
    public sealed class EmailData
    {
        #region Properties 

        /// <summary>
        /// Gets or sets the subject line for this email message.
        /// </summary>
        public string Subject { get; set; }
        /// <summary>
        /// Gets or sets the sender's address for this email message.
        /// </summary>
        public EmailAddress Sender { get; set; }
        /// <summary>
        /// Gets the list of addresses to reply to for the mail message.
        /// </summary>
        public List<EmailAddress> ReplyToList { get; set; }
        /// <summary>
        /// Gets or sets the priority of this email message.
        /// </summary>
        public EmailPriority Priority { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether the mail message body is in HTML.
        /// </summary>
        public bool IsBodyHtml { get; set; }
        /// <summary>
        /// Gets or sets the encoding used for the user-defined custom headers for this email message.
        /// </summary>
        public Encoding HeadersEncoding { get; set; }
        /// <summary>
        /// Gets or sets the from address for this email message.
        /// </summary>
        public EmailAddress From { get; set; }
        /// <summary>
        /// Gets the address collection that contains the carbon copy (CC) recipients for
        /// this email message.
        /// </summary>
        public List<EmailAddress> CC { get; set; }
        /// <summary>
        /// Gets or sets the encoding used for the subject content for this email message.
        /// </summary>
        public Encoding SubjectEncoding { get; set; }
        /// <summary>
        /// Gets or sets the transfer encoding used to encode the message body.
        /// </summary>
        public TransferEncoding BodyTransferEncoding { get; set; }
        /// <summary>
        /// Gets or sets the encoding used to encode the message body.
        /// </summary>
        public Encoding BodyEncoding { get; set; }
        /// <summary>
        /// Gets or sets the message body.
        /// </summary>
        public string Body { get; set; }
        /// <summary>
        /// Gets the address collection that contains the blind carbon copy (BCC) recipients
        /// for this email message.
        /// </summary>
        public List<EmailAddress> Bcc { get; set; }
        /// <summary>
        /// Gets the attachment collection used to store data attached to this email message.
        /// </summary>
        public List<EmailAttachment> Attachments { get; set; }
        /// <summary>
        /// Gets the attachment collection used to store alternate forms of the message body.
        /// </summary>
        public List<EmailAlternateView> AlternateViews { get; set; }
        /// <summary>
        /// Gets or sets the delivery notifications for this email message.
        /// </summary>
        public DeliveryNotificationOptions DeliveryNotificationOptions { get; set; }
        /// <summary>
        /// Gets the address collection that contains the recipients of this email message.
        /// </summary>
        public List<EmailAddress> To { get; set; }

        #endregion
    }
}
