using Newtonsoft.Json;
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
        public UserRole Role { get; private set; }
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
            Id = -1;
            User = UserRole.Anonymous.ToString();
            Role = UserRole.Anonymous;
            Policies = null;
        }

        /// <summary>
        /// Initializes a new instance of the PeoManageSoft.Business.Infrastructure.LoggedUser class.
        /// </summary>
        /// <param name="claimsIdentity">An Identity that is represented by a set of claims.</param>
        public LoggedUser(ClaimsIdentity claimsIdentity)
        {
            Id = long.Parse(claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value);
            User = claimsIdentity.FindFirst(ClaimTypes.Name).Value;
            Role = (UserRole)Enum.Parse(typeof(UserRole), claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value);
            Policies = JsonConvert.DeserializeObject<IEnumerable<LoggedUserPolicy>>(claimsIdentity.FindFirst(ClaimTypes.UserData).Value);
        }

        #endregion

        #region Methods

        #region public

        /// <summary>
        /// Creates an array of the Claim (Clain is a statement about an entity by an Issuer)
        /// </summary>
        /// <param name="id">User identifier</param>
        /// <param name="user">User login</param>
        /// <param name="role">Set of permissions for actions available in application</param>
        /// <param name="policies">User policies</param>
        /// <returns>Returns an array of the Claim</returns>
        public static Claim[] CreateClaims(long id, string user, UserRole role, IEnumerable<LoggedUserPolicy> policies)
        {
            return new Claim[]
            {
                new Claim(ClaimTypes.NameIdentifier, id.ToString()),
                new Claim(ClaimTypes.Name, user),
                new Claim(ClaimTypes.Role, role.ToString()),
                new Claim(ClaimTypes.UserData, JsonConvert.SerializeObject(policies))
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
        /// Resource
        /// </summary>
        public AppResources Resource { get; set; }

        /// <summary>
        /// User permissions.
        /// </summary>
        public Grant Permissions { get; set; }

        #endregion
    }
}
