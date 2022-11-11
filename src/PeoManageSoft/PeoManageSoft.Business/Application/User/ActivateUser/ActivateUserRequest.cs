namespace PeoManageSoft.Business.Application.User.ActivateUser
{
    /// <summary>
    /// Request data.
    /// </summary>
    public sealed class ActivateUserRequest
    {
        #region Properties

        /// <summary>
        /// User token to authorize to activate
        /// </summary>
        public string UserToken { get; set; }

        #endregion
    }
}
