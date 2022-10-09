namespace PeoManageSoft.Business.Domain.Queries.User.GetByAuthentication
{
    /// <summary>
    /// Request for the get user by authentication query.
    /// </summary>
    internal class GetByAuthenticationRequest
    {
        #region Properties

        /// <summary>
        /// Login
        /// </summary>
        public string Login { get; set; }

        /// <summary>
        /// User password
        /// </summary>
        public string Password { get; set; }

        #endregion
    }
}
