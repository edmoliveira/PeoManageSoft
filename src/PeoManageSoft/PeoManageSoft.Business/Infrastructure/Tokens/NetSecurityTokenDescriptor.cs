using System.Security.Claims;

namespace PeoManageSoft.Business.Infrastructure.Tokens
{
    /// <summary>
    /// Contains some information which used to create a security token.
    /// </summary>
    public sealed class NetSecurityTokenDescriptor
    {
        #region Properties

        /// <summary>
        /// Gets or sets the System.Security.Claims.ClaimsIdentity.
        /// </summary>
        public ClaimsIdentity? Subject { get; set; }
        /// <summary>
        /// Gets or sets the value of the 'expiration' claim.
        /// </summary>
        public DateTime Expires { get; set; }
        /// <summary>
        /// Authentication token secrect
        /// </summary>
        public string TokenSecrect { get; set; }

        #endregion
    }
}
