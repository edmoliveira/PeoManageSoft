namespace PeoManageSoft.Business.Domain.Services.Commands.User.CreateToken
{
    /// <summary>
    /// Response for the create token command.
    /// </summary>
    internal class CreateTokenResponse
    {
        #region Properties

        /// <summary>
        /// Token
        /// </summary>
        public string Key { get; set; }

        #endregion
    }
}
