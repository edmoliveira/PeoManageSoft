using PeoManageSoft.Business.Infrastructure.Helpers;

namespace PeoManageSoft.Business.Infrastructure.Tokens
{
    /// <summary>
    ///  A NetSecurityTokenHandler designed for creating and validating Json Web Tokens.
    /// </summary>
    internal sealed class NetSecurityTokenHandler : INetSecurityTokenHandler
    {
        #region Methods

        #region public

        /// <summary>
        /// Validation of the authentication token and asynchronously using Task.
        /// </summary>
        /// <param name="token">Token for validation</param>
        /// <param name="tokenSecrect">Authentication token secrect.</param>
        /// <param name="tokenCache">Token Cache</param>
        /// <returns>NetResultValidToken: Token validation result.</returns>
        public async Task<NetResultValidToken> ValidTokenAsync(string token, string tokenSecrect, ITokenCache tokenCache)
        {
            try
            {
                if (tokenCache == null) { throw new ArgumentNullException(nameof(tokenCache)); }

                NetResultValidToken netResultValidToken = new();

                NetSecurityTokenData securityTokenData = Cryptography.Decrypt<NetSecurityTokenData>(token, tokenSecrect);

                bool hasToken = await tokenCache.CheckHasTokenAsync(securityTokenData.Key).ConfigureAwait(false);

                if (hasToken)
                {
                    netResultValidToken.Sucess = true;
                    netResultValidToken.Principal = securityTokenData.GetClaimsPrincipal();
                }

                return netResultValidToken;
            }
            catch (Exception exception)
            {
                return new NetResultValidToken
                {
                    Sucess = false,
                    Exception = exception
                };
            }
        }

        /// <summary>
        /// Creates a Json Web Token (JWT).
        /// </summary>
        /// <param name="tokenDescriptor">Contains some information which used to create a security token.</param>
        /// <param name="tokenCache">Token cache</param>
        /// <returns>Security token</returns>
        public async Task<string> CreateTokenAsync(NetSecurityTokenDescriptor tokenDescriptor, ITokenCache tokenCache)
        {
            if (tokenDescriptor == null) { throw new ArgumentNullException(nameof(tokenDescriptor)); }
            if (tokenCache == null) { throw new ArgumentNullException(nameof(tokenCache)); }

            string tokenKey = tokenDescriptor.Subject.Claims.Select(c => c.Value)
                .Aggregate((current, item) => string.Concat(current, "_", item));

            string securityToken = Cryptography.Encrypt(new NetSecurityTokenData(tokenKey, tokenDescriptor.Subject), tokenDescriptor.TokenSecrect);

            await tokenCache.SetTokenAsync(tokenKey, securityToken, tokenDescriptor.Expires).ConfigureAwait(false);

            return securityToken;
        }

        #endregion

        #endregion
    }
}
