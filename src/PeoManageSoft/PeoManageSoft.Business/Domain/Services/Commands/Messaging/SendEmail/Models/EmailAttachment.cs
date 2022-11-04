using PeoManageSoft.Business.Infrastructure;
using System.Text;

namespace PeoManageSoft.Business.Domain.Services.Commands.Messaging.SendEmail.Models
{
    /// <summary>
    /// Represents an attachment to an email.
    /// </summary>
    public sealed class EmailAttachment
    {
        #region Properties

        /// <summary>
        /// The file name holding the content for this attachment.
        /// </summary>
        public string FileName { get; set; }
        /// <summary>
        /// Gets or sets the MIME content type name value in the content type associated
        /// with this attachment.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Specifies the encoding for the attachment name.
        /// </summary>
        public Encoding NameEncoding { get; set; }
        /// <summary>
        /// Gets or sets the MIME content ID for this attachment.
        /// </summary>
        public string ContentId { get; set; }
        /// <summary>
        /// Gets the content type of this attachment.
        /// </summary>
        public EmailContentType ContentType { get; set; }
        /// <summary>
        /// Gets or sets the encoding of this attachment.
        /// </summary>
        public TransferEncoding TransferEncoding { get; set; }
        /// <summary>
        /// The MIME media type of the content.
        /// </summary>
        public string MediaType { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Instantiates an PeoManageSoft.Business.Domain.Services.Commands.Messaging.SendEmail.Models.EmailAttachment with the specified file name.
        /// </summary>
        /// <param name="fileName">The file name holding the content for this attachment.</param>
        public EmailAttachment(string fileName)
        {
            FileName = fileName;
        }

        /// <summary>
        /// Instantiates an PeoManageSoft.Business.Domain.Services.Commands.Messaging.SendEmail.Models.EmailAttachment with the specified file name and content type.
        /// </summary>
        /// <param name="fileName">The file name holding the content for this attachment.</param>
        /// <param name="contentType">The type of the content.</param>
        public EmailAttachment(string fileName, EmailContentType contentType)
        {
            FileName = fileName;
            ContentType = contentType;
        }

        /// <summary>
        /// Instantiates an PeoManageSoft.Business.Domain.Services.Commands.Messaging.SendEmail.Models.EmailAttachment with the specified file name and media type.
        /// </summary>
        /// <param name="fileName">The file name holding the content for this attachment.</param>
        /// <param name="mediaType">The MIME media type of the content.</param>
        public EmailAttachment(string fileName, string mediaType)
        {
            FileName = fileName;
            MediaType = mediaType;
        }

        #endregion
    }
}
