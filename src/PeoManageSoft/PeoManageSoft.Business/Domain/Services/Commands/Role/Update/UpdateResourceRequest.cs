using PeoManageSoft.Business.Domain.Services.Commands.Role.Update.Models;

namespace PeoManageSoft.Business.Domain.Services.Commands.Role.Update
{
    /// <summary>
    /// Request for the update resource command.
    /// </summary>
    internal sealed class UpdateResourceRequest
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
