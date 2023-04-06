using PeoManageSoft.Business.Infrastructure.ObjectRelationalMapper;
using PeoManageSoft.Business.Infrastructure.Repositories.Role;

namespace PeoManageSoft.Business.Domain.Services.Commands.Role.Patch
{
    /// <summary>
    /// Request for the patch role command.
    /// </summary>
    internal sealed class PatchRequest
    {
        #region Properties

        /// <summary>
        /// Identifier value
        /// </summary>
        public long Id { get; set; }
        /// <summary>
        /// Fields that will be updated
        /// </summary>
        public IEnumerable<Field<RoleEntityField>> Fields { get; set; }

        #endregion
    }
}
