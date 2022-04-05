using System.Security.Claims;

namespace PeoManageSoft.Business.Infrastructure.Helpers.Interfaces
{
    /// <summary>
    /// Manages Json Web Token.
    /// </summary>
    public interface ITokenJwt
    {
        #region Methods

        /// <summary>
        /// Creates a Json Web Token (JWT) by certificate.
        /// </summary>
        /// <param name="claimsIdentity">Represents a claims-based identity.</param>
        /// <param name="expires">The value of the 'expiration' claim.</param>
        /// <returns>Token in Compact Serialization Format.</returns>
        Task<string> CreateTokenAsync(ClaimsIdentity claimsIdentity, DateTime expires);

        #endregion
    }
}
