namespace PeoManageSoft.Business.Infrastructure.Tokens
{
    /// <summary>
    ///  A NetSecurityTokenHandler designed for creating and validating Json Web Tokens.
    /// </summary>
    public interface INetSecurityTokenHandler
    {
        #region Methods

        /// <summary>
        /// Validation of the authentication token and asynchronously using Task.
        /// </summary>
        /// <param name="token">Token for validation</param>
        /// <param name="tokenSecrect">Authentication token secrect.</param>
        /// <param name="tokenCache">Token Cache</param>
        /// <returns>NetResultValidToken: Token validation result.</returns>
        Task<NetResultValidToken> ValidTokenAsync(string token, string tokenSecrect, ITokenCache tokenCache);

        /// <summary>
        /// Creates a Json Web Token (JWT).
        /// </summary>
        /// <param name="tokenDescriptor">Contains some information which used to create a security token.</param>
        /// <param name="tokenCache">Token cache</param>
        /// <returns>Security token</returns>
        Task<string> CreateTokenAsync(NetSecurityTokenDescriptor tokenDescriptor, ITokenCache tokenCache);

        #endregion
    }
}
