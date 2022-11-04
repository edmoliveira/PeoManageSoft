using System.Collections.Specialized;

namespace PeoManageSoft.Business.Domain.Services.Commands.Messaging.SendEmail.Models
{
    /// <summary>
    /// Represents a MIME protocol Content-Type header.
    /// </summary>
    public sealed class EmailContentType
    {
        #region Properties

        /// <summary>
        /// A System.String, for example, "text/plain; charset=us-ascii", that contains the
        /// MIME media type, subtype, and optional parameters.
        /// </summary>
        public string ContentType { get; set; }
        /// <summary>
        /// Gets or sets the value of the boundary parameter included in the Content-Type
        /// header represented by this instance.
        /// </summary>
        public string Boundary { get; set; }
        /// <summary>
        /// Gets or sets the value of the charset parameter included in the Content-Type
        /// header represented by this instance.
        /// </summary>
        public string CharSet { get; set; }
        /// <summary>
        /// Gets or sets the media type value included in the Content-Type header represented
        /// by this instance.
        /// </summary>
        public string MediaType { get; set; }
        /// <summary>
        /// Gets or sets the value of the name parameter included in the Content-Type header
        /// represented by this instance.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Gets the dictionary that contains the parameters included in the Content-Type
        /// header represented by this instance.
        /// </summary>
        public StringDictionary Parameters { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new default instance of the PeoManageSoft.Business.Domain.Services.Commands.Messaging.SendEmail.Models.EmailContentType class.
        /// </summary>  
        public EmailContentType()
        {

        }

        /// <summary>
        /// Initializes a new instance of the PeoManageSoft.Business.Domain.Services.Commands.Messaging.SendEmail.Models.EmailContentType class using the
        /// specified string.
        /// </summary>
        /// <param name="contentType">
        /// A System.String, for example, "text/plain; charset=us-ascii", that contains the
        /// MIME media type, subtype, and optional parameters.
        /// </param>
        public EmailContentType(string contentType)
        {
            ContentType = contentType;
        }

        #endregion
    }
}
