using PeoManageSoft.Business.Infrastructure.Helpers.Structs;

namespace PeoManageSoft.Business.Domain.Services.Commands.Role.Update.Models
{
    /// <summary>
    /// Request for the update resource command.
    /// </summary>
    internal sealed class RoleResource
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
