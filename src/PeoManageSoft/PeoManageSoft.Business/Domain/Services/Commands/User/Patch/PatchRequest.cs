using PeoManageSoft.Business.Infrastructure.ObjectRelationalMapper;
using PeoManageSoft.Business.Infrastructure.Repositories.User;

namespace PeoManageSoft.Business.Domain.Services.Commands.User.Patch
{
    /// <summary>
    /// Request for the patch user command.
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
        public IEnumerable<Field<UserEntityField>> Fields { get; set; }

        #endregion
    }
}
