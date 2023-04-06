using PeoManageSoft.Business.Infrastructure.Helpers.Structs;

namespace PeoManageSoft.Business.Application.Role._Models
{
    /// <summary>
    /// Role resources
    /// </summary>
    public sealed class RoleResource
    {
        #region Properties

        /// <summary>
        /// Resource name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// User permissions.
        /// </summary>
        public Grant Permissions { get; set; }

        #endregion
    }
}
