using Microsoft.AspNetCore.Authorization;

namespace PeoManageSoft.Business.Infrastructure.Helpers.Attributes
{
    /// <summary>
    /// Specifies that the class or method "Role" that this attribute is applied to requires the specified authorization.
    /// </summary>
    public class AuthorizeRolesAttribute : AuthorizeAttribute
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the PeoManageSoft.Business.Infrastructure.Helpers.Attributes.AuthorizeRolesAttribute class.
        /// </summary>
        /// <param name="roles">Roles</param>
        /// <exception cref="ArgumentNullException">The exception that is thrown when a null reference is passed to a method that does not accept it as a valid argument.</exception>
        public AuthorizeRolesAttribute(params UserRole[] roles)
        {
            if (roles == null) { throw new ArgumentNullException(nameof(roles)); }

            IEnumerable<string> allowedRolesAsStrings = roles.Select(x => Enum.GetName(typeof(UserRole), x));

            Roles = string.Join(",", allowedRolesAsStrings);
        }

        #endregion
    }
}
