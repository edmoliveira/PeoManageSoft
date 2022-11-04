namespace PeoManageSoft.Business.Application.User.ValidatePasswordToken
{
    /// <summary>
    /// Response data.
    /// </summary>
    public sealed class ValidatePasswordTokenResponse
    {
        #region Properties

        /// <summary>
        /// User token to authorize his password change
        /// </summary>
        public string UserToken { get; set; }

        #endregion
    }
}
