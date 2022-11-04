namespace PeoManageSoft.Business.Infrastructure.Helpers.Interfaces
{
    /// <summary>
    /// Smtp configuration
    /// </summary>
    internal interface ISmtpConfiguration
    {
        #region Properties

        /// <summary>
        /// Gets or sets the name or IP address of the host used for SMTP transactions.
        /// </summary>
        string HostEmail { get; }
        /// <summary>
        /// Gets or sets the port used for SMTP transactions.
        /// </summary>
        int PortEmail { get; }
        /// <summary>
        /// Gets or sets the user name associated with the credentials.
        /// </summary>
        string UserNameEmail { get; }
        /// <summary>
        /// Gets or sets the password for the user name associated with the credentials.
        /// </summary>
        string PasswordEmail { get; }
        /// <summary>
        /// Gets or sets the sender's address for email message.
        /// </summary>
        string SenderAddressEmail { get; }
        /// <summary>
        /// Gets or sets the sender's display name for email message.
        /// </summary>
        string DisplayNameEmail { get; }
        /// <summary>
        /// Gets or sets the encoding used for the subject content for this email message.
        /// </summary>
        string SubjectEncodingEmail { get; }
        /// <summary>
        /// Gets or sets the encoding used to encode the message body.
        /// </summary>
        string BodyEncodingEmail { get; }

        #endregion
    }
}
