using PeoManageSoft.Business.Infrastructure;

namespace PeoManageSoft.Business.Domain.Commands.User.CreateToken
{
    /// <summary>
    /// Request for the create token command.
    /// </summary>
    internal class CreateTokenRequest
    {
        #region Properties

        /// <summary>
        /// User identifier
        /// </summary>
        public long Id { get; set; }
        /// <summary>
        /// Set of permissions for actions available in application
        /// </summary>
        public UserRole Role { get; set; }
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
