﻿namespace PeoManageSoft.Business.Infrastructure.Helpers.Resources.Interfaces
{
    /// <summary>
    /// Platform messages catalog.
    /// </summary>
    internal interface IMessagesCatalogResource
    {
        #region Methods

        /// <summary>
        /// Gets the message required.
        /// </summary>
        /// <param name="fieldName">Field Name</param>
        /// <returns>Returns the message required.</returns>
        string GetMessageRequired(string fieldName);
        /// <summary>
        /// Gets the message invalid email.
        /// </summary>
        /// <param name="fieldName">Field Name</param>
        /// <returns>Returns the message invalid email.</returns>
        string GetMessageInvalidEmail(string fieldName);
        /// <summary>
        /// Gets the message invalid uri.
        /// </summary>
        /// <param name="fieldName">Field Name</param>
        /// <returns>Returns the message invalid uri.</returns>
        string GetMessageInvalidUri(string fieldName);
        /// <summary>
        /// Gets the message not match.
        /// </summary>
        /// <param name="fieldName1">First Field Name</param>
        /// <param name="fieldName2">Second Field Name</param>
        /// <returns>Returns the message not match.</returns>
        string GetMessageNotMatch(string fieldName1, string fieldName2);
        /// <summary>
        /// Gets the message minimum length.
        /// </summary>
        /// <param name="fieldName">Field Name</param>
        /// <param name="minimumLength">Minimum field length</param>
        /// <returns>Returns the message minimum length.</returns>
        string GetMessageMinimumLength(string fieldName, int minimumLength);
        /// <summary>
        /// Gets the message already exists.
        /// </summary>
        /// <param name="fieldName">Field Name</param>
        /// <returns>Returns the message already exists.</returns>
        string GetMessageAlreadyExists(string fieldName);
        /// <summary>
        /// Gets the message no exists.
        /// </summary>
        /// <param name="fieldName">Field Name</param>
        /// <returns>Returns the message no exists.</returns>
        string GetMessageNoExists(string fieldName);
        /// <summary>
        /// Gets the message password length.
        /// </summary>
        /// <returns>Returns the message password length.</returns>
        string GetMessagePasswordLength();
        /// <summary>
        /// Gets the message password uppercase letter.
        /// </summary>
        /// <returns>Returns the message password uppercase letter.</returns>
        string GetMessagePasswordUppercaseLetter();
        /// <summary>
        /// Gets the message password lowercase letter.
        /// </summary>
        /// <returns>Returns the message password lowercase letter.</returns>
        string GetMessagePasswordLowercaseLetter();
        /// <summary>
        /// Gets the message password digit.
        /// </summary>
        /// <returns>Returns the message password digit.</returns>
        string GetMessagePasswordDigit();
        /// <summary>
        /// Gets the message password special character.
        /// </summary>
        /// <returns>Returns the message password special character.</returns>
        string GetMessagePasswordSpecialCharacter();
        /// <summary>
        /// Gets the message unauthorized.
        /// </summary>
        /// <returns>Returns the message unauthorized.</returns>
        string GetMessageUnauthorized();
        /// <summary>
        /// Gets the message expired token.
        /// </summary>
        /// <returns>Returns the message expired token.</returns>
        string GetMessageExpiredToken();
        /// <summary>
        /// Gets the message not found.
        /// </summary>
        /// <param name="fieldName">Field Name</param>
        /// <returns>Returns the message not found.</returns>
        string GetMessageNotFound(string fieldName);
        /// <summary>
        /// Gets the message greater than.
        /// </summary>
        /// <param name="fieldName">Field Name</param>
        /// <param name="value">The compared value</param>
        /// <returns>Returns the message greater than.</returns>
        string GetMessageGreaterThan(string fieldName, double value);

        #endregion
    }
}
