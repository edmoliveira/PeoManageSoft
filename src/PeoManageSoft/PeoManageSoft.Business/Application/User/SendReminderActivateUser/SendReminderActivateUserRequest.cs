namespace PeoManageSoft.Business.Application.User.SendReminderActivateUser
{
    /// <summary>
    /// Request data.
    /// </summary>
    public sealed class SendReminderActivateUserRequest
    {
        #region Properties

        /// <summary>
        /// Application url
        /// </summary>
        public string Url { get; set; }
        /// <summary>
        /// User identifier
        /// </summary>
        public long Id { get; set; }

        #endregion
    }
}
