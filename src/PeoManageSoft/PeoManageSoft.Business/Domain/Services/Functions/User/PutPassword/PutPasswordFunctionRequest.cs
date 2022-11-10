namespace PeoManageSoft.Business.Domain.Services.Functions.User.PutPassword
{
    /// <summary>
    /// Request data.
    /// </summary>
    internal sealed class PutPasswordFunctionRequest
    {
        #region Properties

        /// <summary>
        /// User identifier
        /// </summary>
        public long UserId { get; set; }
        /// <summary>
        /// User encrypted Password
        /// </summary>
        public string EncryptedPassword { get; set; }

        #endregion
    }
}
