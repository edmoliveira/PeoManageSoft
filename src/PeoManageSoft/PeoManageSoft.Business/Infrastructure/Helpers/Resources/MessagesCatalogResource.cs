using PeoManageSoft.Business.Infrastructure.Helpers.Resources.Interfaces;

namespace PeoManageSoft.Business.Infrastructure.Helpers.Resources
{
    /// <summary>
    /// Platform messages catalog.
    /// </summary>
    internal sealed class MessagesCatalogResource : IMessagesCatalogResource
    {
        #region Properties

        /// <summary>
        /// Message dictionary
        /// </summary>
        public Dictionary<ResourceMessageKey, string> MessageDictionary { get; set; }

        #endregion

        #region Methods

        #region public

        /// <summary>
        /// Gets the message required.
        /// </summary>
        /// <param name="fieldName">Field Name</param>
        /// <returns>Returns the message required.</returns>
        public string GetMessageRequired(string fieldName)
        {
            return MessageDictionary[ResourceMessageKey.Required].Replace("{fieldName}", fieldName);
        }

        /// <summary>
        /// Gets the message invalid email.
        /// </summary>
        /// <param name="fieldName">Field Name</param>
        /// <returns>Returns the message invalid email.</returns>
        public string GetMessageInvalidEmail(string fieldName)
        {
            return MessageDictionary[ResourceMessageKey.InvalidEmail].Replace("{fieldName}", fieldName);
        }

        /// <summary>
        /// Gets the message invalid uri.
        /// </summary>
        /// <param name="fieldName">Field Name</param>
        /// <returns>Returns the message invalid uri.</returns>
        public string GetMessageInvalidUri(string fieldName)
        {
            return MessageDictionary[ResourceMessageKey.InvalidUri].Replace("{fieldName}", fieldName);
        }

        /// <summary>
        /// Gets the message not match.
        /// </summary>
        /// <param name="fieldName1">First Field Name</param>
        /// <param name="fieldName2">Second Field Name</param>
        /// <returns>Returns the message not match.</returns>
        public string GetMessageNotMatch(string fieldName1, string fieldName2)
        {
            return MessageDictionary[ResourceMessageKey.NotMatch]
                .Replace("{fieldName1}", fieldName1)
                .Replace("{fieldName2}", fieldName2);
        }

        /// <summary>
        /// Gets the message minimum length.
        /// </summary>
        /// <param name="fieldName">Field Name</param>
        /// <param name="minimumLength">Minimum field length</param>
        /// <returns>Returns the message minimum length.</returns>
        public string GetMessageMinimumLength(string fieldName, int minimumLength)
        {
            return MessageDictionary[ResourceMessageKey.MinimumLength]
                .Replace("{fieldName}", fieldName)
                .Replace("{minimumLength}", minimumLength.ToString());
        }

        /// <summary>
        /// Gets the message already exists.
        /// </summary>
        /// <param name="fieldName">Field Name</param>
        /// <returns>Returns the message already exists.</returns>
        public string GetMessageAlreadyExists(string fieldName)
        {
            return MessageDictionary[ResourceMessageKey.AlreadyExists].Replace("{fieldName}", fieldName);
        }

        /// <summary>
        /// Gets the message no exists.
        /// </summary>
        /// <param name="fieldName">Field Name</param>
        /// <returns>Returns the message no exists.</returns>
        public string GetMessageNoExists(string fieldName)
        {
            return MessageDictionary[ResourceMessageKey.NoExists].Replace("{fieldName}", fieldName);
        }

        /// <summary>
        /// Gets the message password length.
        /// </summary>
        /// <returns>Returns the message password length.</returns>
        public string GetMessagePasswordLength()
        {
            return MessageDictionary[ResourceMessageKey.PasswordLength];
        }

        /// <summary>
        /// Gets the message password uppercase letter.
        /// </summary>
        /// <returns>Returns the message password uppercase letter.</returns>
        public string GetMessagePasswordUppercaseLetter()
        {
            return MessageDictionary[ResourceMessageKey.PasswordUppercaseLetter];
        }

        /// <summary>
        /// Gets the message password lowercase letter.
        /// </summary>
        /// <returns>Returns the message password lowercase letter.</returns>
        public string GetMessagePasswordLowercaseLetter()
        {
            return MessageDictionary[ResourceMessageKey.PasswordLowercaseLetter];
        }

        /// <summary>
        /// Gets the message password digit.
        /// </summary>
        /// <returns>Returns the message password digit.</returns>
        public string GetMessagePasswordDigit()
        {
            return MessageDictionary[ResourceMessageKey.PasswordDigit];
        }

        /// <summary>
        /// Gets the message password special character.
        /// </summary>
        /// <returns>Returns the message password special character.</returns>
        public string GetMessagePasswordSpecialCharacter()
        {
            return MessageDictionary[ResourceMessageKey.PasswordSpecialCharacter];
        }

        /// <summary>
        /// Gets the message unauthorized.
        /// </summary>
        /// <returns>Returns the message unauthorized.</returns>
        public string GetMessageUnauthorized()
        {
            return MessageDictionary[ResourceMessageKey.Unauthorized];
        }

        /// <summary>
        /// Gets the message expired token.
        /// </summary>
        /// <returns>Returns the message expired token.</returns>
        public string GetMessageExpiredToken()
        {
            return MessageDictionary[ResourceMessageKey.ExpiredToken];
        }

        /// <summary>
        /// Gets the message not found.
        /// </summary>
        /// <param name="fieldName">Field Name</param>
        /// <returns>Returns the message not found.</returns>
        public string GetMessageNotFound(string fieldName)
        {
            return MessageDictionary[ResourceMessageKey.NotFound].Replace("{fieldName}", fieldName);
        }

        /// <summary>
        /// Gets the message greater than.
        /// </summary>
        /// <param name="fieldName">Field Name</param>
        /// <param name="value">The compared value</param>
        /// <returns>Returns the message greater than.</returns>
        public string GetMessageGreaterThan(string fieldName, double value)
        {
            return MessageDictionary[ResourceMessageKey.GreaterThan]
                .Replace("{fieldName}", fieldName)
                .Replace("{value}", value.ToString());
        }

        #endregion

        #endregion
    }
}
