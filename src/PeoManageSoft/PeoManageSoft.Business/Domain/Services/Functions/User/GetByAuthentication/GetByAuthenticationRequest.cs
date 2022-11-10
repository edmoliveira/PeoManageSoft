namespace PeoManageSoft.Business.Domain.Services.Functions.User.GetByAuthentication
{
    /// <summary>
    /// Request data.
    /// </summary>
    internal sealed class GetByAuthenticationRequest
    {
        #region Properties

        /// <summary>
        /// User login
        /// </summary>
        public string Login { get; set; }
        /// <summary>
        /// User encrypted Password
        /// </summary>
        public string EncryptedPassword { get; set; }

        #endregion
    }
}
