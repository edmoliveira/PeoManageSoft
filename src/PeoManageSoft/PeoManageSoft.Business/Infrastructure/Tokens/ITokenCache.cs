namespace PeoManageSoft.Business.Infrastructure.Tokens
{
    /// <summary>
    /// Token Cache
    /// </summary>
    public interface ITokenCache
    {
        #region Methods

        /// <summary>
        /// Checks if the token exists  in the cache.
        /// </summary>
        /// <param name="tokenKey">Token Key</param>
        /// <returns>If the token exists  in the cache, it returns true.</returns>
        Task<bool> CheckHasTokenAsync(string tokenKey);

        /// <summary>
        /// Gets the token in the cache.
        /// </summary>
        /// <param name="tokenKey">Token Key</param>
        /// <returns>Security token</returns>
        Task<string> GetTokenAsync(string tokenKey);

        /// <summary>
        /// Saves the token in the cache.
        /// </summary>
        /// <param name="tokenKey">Token Key</param>
        /// <param name="securityToken">Security token</param>
        /// <param name="expires">The value of the 'expiration' claim.</param>
        Task SetTokenAsync(string tokenKey, string securityToken, DateTime expires);

        #endregion
    }
}
