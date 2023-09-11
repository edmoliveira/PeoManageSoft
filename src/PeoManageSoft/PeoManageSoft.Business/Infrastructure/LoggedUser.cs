using PeoManageSoft.Business.Infrastructure.Helpers.Structs;
using System.Security.Claims;

namespace PeoManageSoft.Business.Infrastructure
{
    /// <summary>
    /// Logged in user data.
    /// </summary>
    public sealed class LoggedUser
    {
        #region Properties

        /// <summary>
        /// Gets a value that indicates if the user has been authenticated.
        /// </summary>
        public bool IsAuthenticated { get; private set; }
        /// <summary>
        /// User identifier
        /// </summary>
        public long Id { get; private set; }
        /// <summary>
        /// User login
        /// </summary>
        public string User { get; private set; }
        /// <summary>
        /// Set of permissions for actions available in application
        /// </summary>
        public long RoleId { get; private set; }
        /// <summary>
        /// The value of the 'expiration'
        /// </summary>
        public DateTime Expires { get; private set; }
        /// <summary>
        /// User policies
        /// </summary>
        public IEnumerable<LoggedUserPolicy> Policies { get; private set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the PeoManageSoft.Business.Infrastructure.LoggedUser class.
        /// </summary>
        public LoggedUser()
        {
            IsAuthenticated = false;
            Id = -1;
            User = "Anonymous";
            RoleId = 0;
            Policies = null;
        }

        /// <summary>
        /// Initializes a new instance of the PeoManageSoft.Business.Infrastructure.LoggedUser class.
        /// </summary>
        /// <param name="claimsIdentity">An Identity that is represented by a set of claims.</param>
        public LoggedUser(ClaimsIdentity claimsIdentity)
        {
            IsAuthenticated = true;
            Id = long.Parse(claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value);
            User = claimsIdentity.FindFirst(ClaimTypes.Name).Value;
            RoleId = long.Parse(claimsIdentity.FindFirst(ClaimTypes.Role).Value);
            Expires = DateTime.Parse(claimsIdentity.FindFirst(ClaimTypes.Expiration).Value);
        }

        #endregion

        #region Methods

        #region public

        /// <summary>
        /// Creates an array of the Claim (Clain is a statement about an entity by an Issuer)
        /// </summary>
        /// <param name="id">User identifier</param>
        /// <param name="user">User login</param>
        /// <param name="roleId">Set of permissions for actions available in application</param>
        /// <param name="expires">The value of the 'expiration'.</param>
        /// <returns>Returns an array of the Claim</returns>
        public static Claim[] CreateClaims(long id, string user, long roleId, DateTime expires)
        {
            return new Claim[]
            {
                new Claim(ClaimTypes.NameIdentifier, id.ToString()),
                new Claim(ClaimTypes.Name, user),
                new Claim(ClaimTypes.Role, roleId.ToString()),
                new Claim(ClaimTypes.Expiration, expires.ToString())
            };
        }

        #endregion

        #endregion
    }

    /// <summary>
    /// Logged in user policy.
    /// </summary>
    public sealed class LoggedUserPolicy
    {
        #region Properties

        /// <summary>
        /// Resource name
        /// </summary>
        public string ResourceName { get; set; }

        /// <summary>
        /// User permissions.
        /// </summary>
        public Grant Permissions { get; set; }

        #endregion
    }
}
