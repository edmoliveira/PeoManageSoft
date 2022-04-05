using System.Security.Claims;

namespace PeoManageSoft.Business.Infrastructure.Tokens
{
    /// <summary>
    /// Token validation result.
    /// </summary>
    public class NetResultValidToken
    {
        #region Properties

        /// <summary>
        /// Indicate whether validation was successful.
        /// </summary>
        public bool Sucess { get; set; }
        /// <summary>
        /// Exception
        /// </summary>
        public Exception Exception { get; set; }
        /// <summary>
        /// An System.Security.Principal.IPrincipal implementation that supports multiple
        /// claims-based identities.
        /// </summary>
        public ClaimsPrincipal Principal { get; set; }

        #endregion
    }
}
