using PeoManageSoft.Business.Infrastructure.Helpers.Interfaces;
using PeoManageSoft.Business.Infrastructure.Tokens;
using System.Security.Claims;

namespace PeoManageSoft.Business.Infrastructure.Helpers
{
    /// <summary>
    /// Manages Json Web Token.
    /// </summary>
    public sealed class TokenNet : ITokenJwt
    {
        #region Fields private

        /// <summary>
        /// A NetSecurityTokenHandler designed for creating and validating Json Web Tokens.
        /// </summary>
        private readonly INetSecurityTokenHandler _handler;
        /// <summary>
        /// Token Cache
        /// </summary>
        private readonly ITokenCache _tokenCache;
        /// <summary>
        /// Application Configuration
        /// </summary>
        private readonly IAppConfig _appConfig;

        #endregion

        #region Consctructors

        /// <summary>
        /// Initializes a new instance of the PeoManageSoft.Business.Infrastructure.Helpers.TokenJwt class.
        /// </summary>
        /// <param name="handler">A NetSecurityTokenHandler designed for creating and validating Json Web Tokens.</param>
        /// <param name="tokenCache">Token Cache</param>
        /// <param name="appConfig">Application Configuration</param>
        public TokenNet(INetSecurityTokenHandler handler, ITokenCache tokenCache, IAppConfig appConfig)
        {
            _handler = handler;
            _tokenCache = tokenCache;
            _appConfig = appConfig;
        }

        #endregion

        #region Methods public

        /// <summary>
        /// Creates a Json Web Token (JWT) by certificate.
        /// </summary>
        /// <param name="claimsIdentity">Represents a claims-based identity.</param>
        /// <param name="expires">The value of the 'expiration' claim.</param>
        /// <returns>Token in Compact Serialization Format.</returns>
        public async Task<string> CreateTokenAsync(ClaimsIdentity claimsIdentity, DateTime expires)
        {
            NetSecurityTokenDescriptor tokenDescriptor = new()
            {
                Subject = claimsIdentity,
                Expires = expires,
                TokenSecrect = _appConfig.AuthTokenSecrect
            };

            return await _handler.CreateTokenAsync(tokenDescriptor, _tokenCache).ConfigureAwait(false);
        }

        #endregion
    }
}
