using System.Net;
using System.Net.Mail;
using System.Security.Cryptography.X509Certificates;

namespace PeoManageSoft.Business.Domain.Services.Middlewares.Interfaces
{
    /// <summary>
    /// Allows applications to send email by using the Simple Mail Transfer Protocol (SMTP).
    /// </summary>
    internal interface ISmtpClient
    {
        #region Properties

        /// <summary>
        /// Gets or sets a value that specifies the amount of time after which a synchronous
        /// Overload:System.Net.Mail.SmtpClient.Send call times out.
        /// </summary>
        int Timeout { get; set; }
        /// <summary>
        /// Gets or sets the Service Provider Name (SPN) to use for authentication when using
        /// extended protection.
        /// </summary>
        string TargetName { get; set; }
        /// <summary>
        /// Gets the network connection used to transmit the email message.
        /// </summary>
        ServicePoint ServicePoint { get; }
        /// <summary>
        /// Gets or sets the port used for SMTP transactions.
        /// </summary>
        int Port { get; set; }
        /// <summary>
        /// Gets or sets the folder where applications save mail messages to be processed
        /// by the local SMTP server.
        /// </summary>
        string PickupDirectoryLocation { get; set; }
        /// <summary>
        /// Gets or sets the name or IP address of the host used for SMTP transactions.
        /// </summary>
        string Host { get; set; }
        /// <summary>
        /// Specify whether the System.Net.Mail.SmtpClient uses Secure Sockets Layer (SSL)
        /// to encrypt the connection.
        /// </summary>
        bool EnableSsl { get; set; }
        /// <summary>
        /// Specifies how outgoing email messages will be handled.
        /// </summary>
        SmtpDeliveryMethod DeliveryMethod { get; set; }
        /// <summary>
        /// Gets or sets the delivery format used by System.Net.Mail.SmtpClient to send email.
        /// </summary>
        SmtpDeliveryFormat DeliveryFormat { get; set; }
        /// <summary>
        /// Gets or sets a System.Boolean value that controls whether the System.Net.CredentialCache.DefaultCredentials
        /// are sent with requests.
        /// </summary>
        bool UseDefaultCredentials { get; set; }
        /// <summary>
        /// Specify which certificates should be used to establish the Secure Sockets Layer
        /// (SSL) connection.
        /// </summary>
        X509CertificateCollection ClientCertificates { get; }
        /// <summary>
        /// Gets or sets the credentials used to authenticate the sender.
        /// </summary>
        ICredentialsByHost Credentials { get; set; }
        /// <summary>
        /// Occurs when an asynchronous email send operation completes.
        /// </summary>
        event SendCompletedEventHandler SendCompleted;

        #endregion

        #region Methods 

        /// <summary>
        /// Sends the specified message to an SMTP server for delivery.
        /// </summary>
        void Send();

        /// <summary>
        /// Sends the specified message to an SMTP server for delivery as an asynchronous operation.
        /// </summary>
        /// <returns>The task object representing the asynchronous operation.</returns>
        Task SendAsync();

        #endregion
    }
}
