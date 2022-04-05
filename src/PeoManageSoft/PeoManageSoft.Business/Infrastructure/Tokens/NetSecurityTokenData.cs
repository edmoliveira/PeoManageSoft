using System.Security.Claims;

namespace PeoManageSoft.Business.Infrastructure.Tokens
{
    /// <summary>
    /// Data stored inside token.
    /// </summary>
    public sealed class NetSecurityTokenData
    {
        #region Properties

        /// <summary>
        /// Token Key
        /// </summary>
        public string Key { get; set; }
        /// <summary>
        /// Gets or sets the claims associated with this claims identity.
        /// </summary>
        public IDictionary<string, string> Claims { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the PeoManageSoft.Business.Infrastructure.Tokens.NetSecurityTokenData class.
        /// </summary>
        public NetSecurityTokenData() { }

        /// <summary>
        /// Initializes a new instance of the PeoManageSoft.Business.Infrastructure.Tokens.NetSecurityTokenData class.
        /// </summary>
        /// <param name="key">Token Key</param>
        /// <param name="claimsIdentity">Represents a claims-based identity.</param>
        public NetSecurityTokenData(string key, ClaimsIdentity claimsIdentity)
        {
            Key = key;

            Claims = new Dictionary<string, string>();

            foreach (Claim claim in claimsIdentity.Claims)
            {
                Claims.Add(claim.Type, claim.Value);
            }
        }

        #endregion

        #region Methods

        #region public

        /// <summary>
        /// Gets claims-based identities.
        /// </summary>
        /// <returns>An System.Security.Principal.IPrincipal implementation that supports multiple claims-based identities.</returns>
        public ClaimsPrincipal GetClaimsPrincipal()
        {
            List<Claim> array = new();

            foreach (KeyValuePair<string, string> claim in Claims)
            {
                array.Add(new Claim(claim.Key, claim.Value));
            }

            return new ClaimsPrincipal(new ClaimsIdentity(array));
        }

        #endregion

        #endregion
    }
}
