namespace PeoManageSoft.Business.Application.User.ChangePassword
{
    /// <summary>
    /// Request data.
    /// </summary>
    public sealed class ChangePasswordRequest
    {
        #region Properties

        /// <summary>
        /// User old password
        /// </summary>
        public string OldPassword { get; set; }
        /// <summary>
        /// User new password
        /// </summary>
        public string NewPassword { get; set; }
        /// <summary>
        /// Repeat user password
        /// </summary>
        public string RepeatPassword { get; set; }

        #endregion
    }
}
