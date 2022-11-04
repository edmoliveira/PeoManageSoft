namespace PeoManageSoft.Business.Application.User.CreateNewPassword
{
    /// <summary>
    /// Request data.
    /// </summary>
    public sealed class CreateNewPasswordRequest
    {
        #region Properties

        /// <summary>
        /// User token to authorize his password change
        /// </summary>
        public string UserToken { get; set; }
        /// <summary>
        /// User password
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// Repeat user password
        /// </summary>
        public string RepeatPassword { get; set; }

        #endregion
    }
}
