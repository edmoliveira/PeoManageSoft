using System.Text;

namespace PeoManageSoft.Business.Domain.Services.Commands.Messaging.SendEmail.Models
{
    /// <summary>
    /// Represents the address of an electronic mail sender or recipient.
    /// </summary>
    public sealed class EmailAddress
    {
        #region Properties

        /// <summary>
        /// Gets the email address specified when this instance was created.
        /// </summary>
        public string Address { get; }
        /// <summary>
        /// Gets the display name composed from the display name and address information specified when this instance was created.
        /// </summary>
        public string DisplayName { get; }
        /// <summary>
        /// The System.Text.Encoding that defines the character set used for displayName.
        /// </summary>
        public Encoding DisplayNameEncoding { get; }

        #endregion

        #region Consctructors

        /// <summary>
        /// Initializes a new instance of the PeoManageSoft.Business.Domain.Services.Commands.Messaging.SendEmail.Models.EmailAddress class using the specified address.
        /// </summary>
        /// <param name="address">A System.String that contains an email address.</param>
        public EmailAddress(string address)
        {
            Address = address;
        }

        /// <summary>
        /// Initializes a new instance of the PeoManageSoft.Business.Domain.Services.Commands.Messaging.SendEmail.Models.EmailAddress class using the specified address and display name.
        /// </summary>
        /// <param name="address">A System.String that contains an email address.</param>
        /// <param name="displayName">A System.String that contains the display name associated with address. This parameter can be null.</param>
        public EmailAddress(string address, string displayName)
        {
            Address = address;
            DisplayName = displayName;
        }

        /// <summary>
        /// Initializes a new instance of the PeoManageSoft.Business.Domain.Services.Commands.Messaging.SendEmail.Models.EmailAddress class using the specified address, display name, and encoding.
        /// </summary>
        /// <param name="address">A System.String that contains an email address.</param>
        /// <param name="displayName">A System.String that contains the display name associated with address.</param>
        /// <param name="displayNameEncoding">The System.Text.Encoding that defines the character set used for displayName.</param>
        public EmailAddress(string address, string displayName, Encoding displayNameEncoding)
        {
            Address = address;
            DisplayName = displayName;
            DisplayNameEncoding = displayNameEncoding;
        }

        #endregion
    }
}
