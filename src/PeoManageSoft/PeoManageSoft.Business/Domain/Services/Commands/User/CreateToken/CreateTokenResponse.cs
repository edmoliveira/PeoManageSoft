namespace PeoManageSoft.Business.Domain.Services.Commands.User.CreateToken
{
    /// <summary>
    /// Response for the create token command.
    /// </summary>
    internal sealed class CreateTokenResponse
    {
        #region Properties

        /// <summary>
        /// Token
        /// </summary>
        public string Key { get; set; }
        /// <summary>
        /// The value of the 'expiration'.
        /// </summary>
        public DateTime Expires { get; set; }

        #endregion
    }
}
