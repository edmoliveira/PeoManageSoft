using PeoManageSoft.Business.Infrastructure.ObjectRelationalMapper;
using PeoManageSoft.Business.Infrastructure.Repositories.Title;

namespace PeoManageSoft.Business.Domain.Services.Commands.Title.Patch
{
    /// <summary>
    /// Request for the patch title command.
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
        public IEnumerable<Field<TitleEntityField>> Fields { get; set; }

        #endregion
    }
}
