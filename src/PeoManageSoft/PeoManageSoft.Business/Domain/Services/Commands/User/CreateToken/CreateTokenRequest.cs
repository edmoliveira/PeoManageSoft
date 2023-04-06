namespace PeoManageSoft.Business.Domain.Services.Commands.User.CreateToken
{
    /// <summary>
    /// Request for the create token command.
    /// </summary>
    internal sealed class CreateTokenRequest
    {
        #region Properties

        /// <summary>
        /// User identifier
        /// </summary>
        public long Id { get; set; }
        /// <summary>
        /// Set of permissions for actions available in application
        /// </summary>
        public long RoleId { get; set; }
        /// <summary>
        /// User login
        /// </summary>
        public string Login { get; set; }
        /// <summary>
        /// Authentication Token expiration in seconds.
        /// </summary>
        public double ExpireSeconds { get; set; }

        #endregion
    }
}
