using PeoManageSoft.Business.Infrastructure.Helpers.Interfaces;

namespace PeoManageSoft.Business.Infrastructure.Helpers
{
    /// <summary>
    /// Smtp configuration.
    /// </summary>
    internal sealed class SmtpConfiguration: ISmtpConfiguration
    {
        #region Properties

        /// <summary>
        /// Gets or sets the name or IP address of the host used for SMTP transactions.
        /// </summary>
        public string HostEmail { get; set; }
        /// <summary>
        /// Gets or sets the port used for SMTP transactions.
        /// </summary>
        public int PortEmail { get; set; }
        /// <summary>
        /// Gets or sets the user name associated with the credentials.
        /// </summary>
        public string UserNameEmail { get; set; }
        /// <summary>
        /// Gets or sets the password for the user name associated with the credentials.
        /// </summary>
        public string PasswordEmail { get; set; }
        /// <summary>
        /// Gets or sets the sender's address for email message.
        /// </summary>
        public string SenderAddressEmail { get; set; }
        /// <summary>
        /// Gets or sets the sender's display name for email message.
        /// </summary>
        public string DisplayNameEmail { get; set; }
        /// <summary>
        /// Gets or sets the encoding used for the subject content for this email message.
        /// </summary>
        public string SubjectEncodingEmail { get; set; }
        /// <summary>
        /// Gets or sets the encoding used to encode the message body.
        /// </summary>
        public string BodyEncodingEmail { get; set; }

        #endregion
    }
}
