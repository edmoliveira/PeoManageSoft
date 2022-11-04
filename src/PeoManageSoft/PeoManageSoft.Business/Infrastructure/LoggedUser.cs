namespace PeoManageSoft.Business.Infrastructure
{
    /// <summary>
    /// Logged in user.
    /// </summary>
    public sealed class LoggedUser
    {
        #region Properties

        /// <summary>
        /// User identifier
        /// </summary>
        public long Id { get; set; }
        /// <summary>
        /// User login
        /// </summary>
        public string User { get; set; }
        /// <summary>
        /// Set of permissions for actions available in application
        /// </summary>
        public UserRole Role { get; set; }

        #endregion
    }
}
