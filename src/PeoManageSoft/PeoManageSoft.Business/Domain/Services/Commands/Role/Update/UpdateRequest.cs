using PeoManageSoft.Business.Domain.Services.Commands.Role.Update.Models;

namespace PeoManageSoft.Business.Domain.Services.Commands.Role.Update
{
    /// <summary>
    /// Request for the update role command.
    /// </summary>
    internal sealed class UpdateRequest
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
