namespace PeoManageSoft.Business.Domain.Services.Functions.User.PutPasswordToken
{
    /// <summary>
    /// Request data.
    /// </summary>
    internal sealed class PutPasswordTokenFunctionRequest
    {
        #region Properties

        /// <summary>
        /// User identifier
        /// </summary>
        public long UserId { get; set; }
        /// <summary>
        /// Token to change the user password.
        /// </summary>
        public string PasswordToken { get; set; }

        #endregion
    }
}
