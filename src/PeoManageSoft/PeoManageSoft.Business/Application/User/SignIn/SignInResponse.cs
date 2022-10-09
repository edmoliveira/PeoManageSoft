using PeoManageSoft.Business.Infrastructure;

namespace PeoManageSoft.Business.Application.User.SignIn
{
    /// <summary>
    /// Response data.
    /// </summary>
    public class SignInResponse
    {
        #region Properties

        /// <summary>
        /// Token
        /// </summary>
        public string Key { get; set; }
        /// <summary>
        /// Authentication Token expiration in seconds.
        /// </summary>
        public double ExpireSeconds { get; set; }
        /// <summary>
        /// Set of permissions for actions available in application
        /// </summary>
        public UserRole Role { get; set; }
        /// <summary>
        /// Full username
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Short username
        /// </summary>
        public string ShortName { get; set; }

        #endregion
    }
}