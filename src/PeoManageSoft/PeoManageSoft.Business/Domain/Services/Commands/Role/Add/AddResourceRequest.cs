using PeoManageSoft.Business.Domain.Services.Commands.Role.Add.Models;

namespace PeoManageSoft.Business.Domain.Services.Commands.Role.Add
{

    /// <summary>
    /// Request for the add resource command.
    /// </summary>
    internal sealed class AddResourceRequest
    {
        #region Properties

        /// <summary>
        /// Role identifier
        /// </summary>
        public long RoleId { get; set; }
        /// <summary>
        /// Resources
        /// </summary>
        public IEnumerable<RoleResource> Resources { get; set; }

        #endregion
    }
}
