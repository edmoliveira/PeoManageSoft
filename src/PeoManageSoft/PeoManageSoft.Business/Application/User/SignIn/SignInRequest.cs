namespace PeoManageSoft.Business.Application.User.SignIn
{
    /// <summary>
    /// Request data.
    /// </summary>
    public class SignInRequest
    {
        #region Properties

        /// <summary>
        /// User login
        /// </summary>
        public string Login { get; set; }
        /// <summary>
        /// User password
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// Indicates the last location where the user logged in "Longitude and latitude"
        /// </summary>
        public string Location { get; set; }

        #endregion
    }
}
