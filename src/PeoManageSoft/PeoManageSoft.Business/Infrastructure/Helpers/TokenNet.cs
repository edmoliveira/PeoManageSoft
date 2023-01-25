using PeoManageSoft.Business.Infrastructure.Helpers.Interfaces;
using PeoManageSoft.Business.Infrastructure.Tokens;
using System.Security.Claims;

namespace PeoManageSoft.Business.Infrastructure.Helpers
{
    /// <summary>
    /// Manages Json Web Token and Cryptography.
    /// </summary>
    internal sealed class TokenNet : ITokenJwt
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

        #region Methods 

        #region public

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

        /// <summary>
        ///  Encrypts the password.
        /// </summary>
        /// <param name="password">Value</param>
        /// <returns>Encrypted password</returns>
        public string EncryptPassword(string password)
        {
            //TODO: https://jasonwatmore.com/post/2021/05/27/net-5-hash-and-verify-passwords-with-bcrypt
            return Cryptography.Encrypt(password, _appConfig.AuthTokenSecrect);
        }

        /// <summary>
        /// Create a encrypted password token to create a new passaword
        /// </summary>
        /// <param name="userId">User identifier.</param>
        /// <returns>Encrypted token</returns>
        public string CreatePasswordToken(long userId)
        {
            return Cryptography.EncryptQueryString($"{userId}_{DateTime.Now.AddHours(_appConfig.PasswordTokenExpireHours):dd/MM/yyyy HH:mm:ss}", _appConfig.PasswordTokenSecrect);
        }

        /// <summary>
        /// Checks whether the token has expired 
        /// </summary>
        /// <param name="passwordToken">Token to change the user password.</param>
        /// <returns>Return true if the token is valid.</returns>
        public bool CheckPasswordToken(string passwordToken)
        {
            string value = Cryptography.DecryptQueryString(passwordToken, _appConfig.PasswordTokenSecrect, true);

            DateTime now = DateTime.Now;
            DateTime currentDateTime = new(now.Year, now.Month, now.Day, now.Hour, now.Minute, now.Second);

            return value.IndexOf("_") > -1 && DateTime.TryParse(value.Split('_')[1], out DateTime dateTime) && currentDateTime <= dateTime;
        }

        /// <summary>
        /// Create a encrypted user token to create a new passaword
        /// </summary>
        /// <param name="userId">User identifier.</param>
        /// <param name="userEmail">User email</param>
        /// <returns>Encrypted token</returns>
        public string CreateUserToken(long userId, string userEmail)
        {
            return Cryptography.Encrypt($"{userId}_{userEmail}", _appConfig.PasswordTokenSecrect);
        }

        /// <summary>
        /// Tries to get the user id by user token
        /// </summary>
        /// <param name="userToken">User token to create a new passaword</param>
        /// <returns>Return true if the token is valid.</returns>
        public bool TryGetUserIdByUserToken(string userToken, out long userId)
        {
            userId = 0;

            try
            {
                string value = Cryptography.Decrypt(userToken, _appConfig.PasswordTokenSecrect);

                if (value.IndexOf("_") > -1 && long.TryParse(value.Split('_')[0], out long result))
                {
                    userId = result;
                }

                return userId != 0;
            }
            catch
            {
                return false;
            }
        }

        #endregion

        #endregion
    }
}
