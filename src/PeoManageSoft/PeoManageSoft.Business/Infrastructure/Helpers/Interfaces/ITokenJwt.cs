using System.Security.Claims;

namespace PeoManageSoft.Business.Infrastructure.Helpers.Interfaces
{
    /// <summary>
    /// Manages Json Web Token and Cryptography.
    /// </summary>
    internal interface ITokenJwt
    {
        #region Methods

        /// <summary>
        /// Creates a Json Web Token (JWT) by certificate.
        /// </summary>
        /// <param name="claimsIdentity">Represents a claims-based identity.</param>
        /// <param name="expires">The value of the 'expiration' claim.</param>
        /// <returns>Token in Compact Serialization Format.</returns>
        Task<string> CreateTokenAsync(ClaimsIdentity claimsIdentity, DateTime expires);
        /// <summary>
        ///  Encrypts the password.
        /// </summary>
        /// <param name="password">Value</param>
        /// <returns>Encrypted password</returns>
        string EncryptPassword(string password);
        /// <summary>
        /// Create a encrypted password token to create a new passaword
        /// </summary>
        /// <param name="userId">User identifier.</param>
        /// <returns>Encrypted token</returns>
        string CreatePasswordToken(long userId);

        /// <summary>
        /// Checks whether the token has expired 
        /// </summary>
        /// <param name="passwordToken">Token to change the user password.</param>
        /// <returns>Return true if the token is valid.</returns>
        bool CheckPasswordToken(string passwordToken);
        /// <summary>
        /// Create a encrypted user token to create a new passaword
        /// </summary>
        /// <param name="userId">User identifier.</param>
        /// <param name="userEmail">User email</param>
        /// <returns>Encrypted token</returns>
        string CreateUserToken(long userId, string userEmail);

        /// <summary>
        /// Tries to get the user id by user token
        /// </summary>
        /// <param name="userToken">User token to create a new passaword</param>
        /// <returns>Return true if the token is valid.</returns>
        bool TryGetUserIdByUserToken(string userToken, out long userId);

        #endregion
    }
}
