using PeoManageSoft.Business.Infrastructure.ObjectRelationalMapper;
using static PeoManageSoft.Business.Infrastructure.Repositories.User.UserEntityConfig;

namespace PeoManageSoft.Business.Domain.Services.Commands.User.Patch
{
    /// <summary>
    /// Request for the patch user command.
    /// </summary>
    internal class PatchRequest
    {
        #region Properties

        /// <summary>
        /// Identifier value
        /// </summary>
        public long Id { get; set; }
        /// <summary>
        /// Fields that will be updated
        /// </summary>
        public IEnumerable<Field<EntityField>> Fields { get; set; }

        #endregion
    }
}
