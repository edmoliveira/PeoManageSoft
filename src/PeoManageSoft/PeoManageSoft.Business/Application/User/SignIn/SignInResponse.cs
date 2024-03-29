﻿namespace PeoManageSoft.Business.Application.User.SignIn
{
    /// <summary>
    /// Response data.
    /// </summary>
    public sealed class SignInResponse
    {
        #region Properties

        /// <summary>
        /// Token
        /// </summary>
        public string Key { get; set; }
        /// <summary>
        /// The value of the 'expiration'.
        /// </summary>
        public DateTime Expires { get; set; }
        /// <summary>
        /// User's role id.
        /// </summary>
        public long RoleId { get; set; }
        /// <summary>
        /// User's role name.
        /// </summary>
        public string RoleName { get; set; }
        /// <summary>
        /// Full username
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Short username
        /// </summary>
        public string ShortName { get; set; }

        #endregion
    }
}