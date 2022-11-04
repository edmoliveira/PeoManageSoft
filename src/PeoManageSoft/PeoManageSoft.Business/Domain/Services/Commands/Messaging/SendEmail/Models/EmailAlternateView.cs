namespace PeoManageSoft.Business.Domain.Services.Commands.Messaging.SendEmail.Models
{
    /// <summary>
    /// Represents the format to view an email message.
    /// </summary>
    public sealed class EmailAlternateView
    {
        #region Properties

        /// <summary>
        /// A string that contains the content for this attachment.
        /// </summary>
        public string Content { get; set; }
        /// <summary>
        /// A stream that contains the content for this attachment.
        /// </summary>
        public Stream ContentStream { get; set; }
        /// <summary>
        /// The type of the content.
        /// </summary>
        public EmailContentType ContentType { get; set; }
        /// <summary>
        /// Gets or sets the base URI to use for resolving relative URIs in the PeoManageSoft.Business.Domain.Services.Commands.Messaging.SendEmail.Models.EmailAlternateView.
        /// </summary>
        public Uri BaseUri { get; set; }
        /// <summary>
        /// Gets the set of embedded resources referred to by this attachment.
        /// </summary>
        public List<EmailLinkedResource> LinkedResources { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of PeoManageSoft.Business.Domain.Services.Commands.Messaging.SendEmail.Models.EmailAlternateView with the specified
        /// content and contentType.
        /// </summary>
        /// <param name="content">A string that contains the content for this attachment.</param>
        /// <param name="contentType">The type of the content.</param>
        public EmailAlternateView(string content, EmailContentType contentType)
        {
            Content = content;
            ContentType = contentType;
        }

        /// <summary>
        /// Initializes a new instance of PeoManageSoft.Business.Domain.Services.Commands.Messaging.SendEmail.Models.EmailAlternateView with the specified
        /// contentStream and contentType.
        /// </summary>
        /// <param name="contentStream">A stream that contains the content for this attachment.</param>
        /// <param name="contentType">The type of the content.</param>
        public EmailAlternateView(Stream contentStream, EmailContentType contentType)
        {
            ContentStream = contentStream;
            ContentType = contentType;
        }

        #endregion
    }
}
