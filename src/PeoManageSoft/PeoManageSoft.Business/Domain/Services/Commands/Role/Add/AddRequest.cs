using PeoManageSoft.Business.Domain.Services.Commands.Role.Add.Models;

namespace PeoManageSoft.Business.Domain.Services.Commands.Role.Add
{
    /// <summary>
    /// Request for the add role command.
    /// </summary>
    internal sealed class AddRequest
    {
        #region Properties

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
