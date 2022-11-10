namespace PeoManageSoft.Business.Domain.Services.Functions.User.SendEmailToActiveUser
{
    /// <summary>
    /// Request data.
    /// </summary>
    internal sealed class SendEmailToActiveUserFunctionRequest
    {
        #region Properties

        /// <summary>
        /// Application url
        /// </summary>
        public string Url { get; set; }
        /// <summary>
        /// User email
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// User token to authorize to activate
        /// </summary>
        public string UserToken { get; set; }

        #endregion
    }
}
