namespace PeoManageSoft.Business.Application.User.ValidatePasswordToken
{
    /// <summary>
    /// Request data.
    /// </summary>
    public sealed class ValidatePasswordTokenRequest
    {
        #region Properties

        /// <summary>
        /// Token to change the user password.
        /// </summary>
        public string PasswordToken { get; set; }

        #endregion
    }
}
