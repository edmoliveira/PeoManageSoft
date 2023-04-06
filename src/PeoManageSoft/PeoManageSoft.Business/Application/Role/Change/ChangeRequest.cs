using PeoManageSoft.Business.Application.Role._Models;

namespace PeoManageSoft.Business.Application.Role.Change
{
    /// <summary>
    /// Request data.
    /// </summary>
    public sealed class ChangeRequest
    {
        #region Properties

        /// <summary>
        /// Role identifier
        /// </summary>
        public long Id { get; set; }
        /// <summary>
        /// Indicates whether the role is active
        /// </summary>
        public bool IsActive { get; set; }
        /// <summary>
        /// Full rolename
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Resources
        /// </summary>
        public IEnumerable<RoleResource> Resources { get; set; }

        #endregion
    }
}
