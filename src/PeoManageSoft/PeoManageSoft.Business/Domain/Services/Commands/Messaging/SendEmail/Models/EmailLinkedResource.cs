namespace PeoManageSoft.Business.Domain.Services.Commands.Messaging.SendEmail.Models
{
    /// <summary>
    /// Represents an embedded external resource in an email attachment, such as an image
    /// in an HTML attachment.
    /// </summary>
    public sealed class EmailLinkedResource
    {
        #region Properties

        /// <summary>
        /// The file name that holds the content for this embedded resource.
        /// </summary>
        public string FileName { get; set; }
        /// <summary>
        /// A stream that contains the content for this attachment.
        /// </summary>
        public Stream ContentStream { get; set; }
        /// <summary>
        /// The type of the content.
        /// </summary>
        public EmailContentType ContentType { get; set; }
        /// <summary>
        /// Gets or sets a URI that the resource must match.
        /// </summary>
        public Uri ContentLink { get; set; }
        /// <summary>
        /// Gets or sets the MIME content ID for this linked resource.
        public string ContentId { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of PeoManageSoft.Business.Domain.Services.Commands.Messaging.SendEmail.Models.EmailLinkedResource with the specified
        /// file name.
        /// </summary>
        /// <param name="fileName">The file name that holds the content for this embedded resource.</param>
        public EmailLinkedResource(string fileName)
        {
            FileName = fileName;
        }

        /// <summary>
        /// Initializes a new instance of PeoManageSoft.Business.Domain.Services.Commands.Messaging.SendEmail.Models.EmailLinkedResource with the specified
        /// file name.
        /// </summary>
        /// <param name="fileName">The file name that holds the content for this embedded resource.</param>
        /// <param name="contentId">The MIME content ID for this linked resource.</param>
        public EmailLinkedResource(string fileName, string contentId)
        {
            FileName = fileName;
            ContentId = contentId;
        }

        /// <summary>
        /// Initializes a new instance of PeoManageSoft.Business.Domain.Services.Commands.Messaging.SendEmail.Models.EmailLinkedResource with the specified
        /// file name and content type.
        /// </summary>
        /// <param name="fileName">The file name that holds the content for this embedded resource.</param>
        /// <param name="contentType">The type of the content.</param>
        public EmailLinkedResource(string fileName, EmailContentType contentType)
        {
            FileName = fileName;
            ContentType = contentType;
        }

        /// <summary>
        /// Initializes a new instance of PeoManageSoft.Business.Domain.Services.Commands.Messaging.SendEmail.Models.EmailLinkedResource with the specified
        /// contentStream and contentType.
        /// </summary>
        /// <param name="contentStream">A stream that contains the content for this attachment.</param>
        /// <param name="contentType">The type of the content.</param>
        public EmailLinkedResource(Stream contentStream, EmailContentType contentType)
        {
            ContentStream = contentStream;
            ContentType = contentType;
        }

        #endregion
    }
}
