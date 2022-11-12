using PeoManageSoft.Business.Infrastructure.ObjectRelationalMapper;
using PeoManageSoft.Business.Infrastructure.Repositories.Department;

namespace PeoManageSoft.Business.Domain.Services.Commands.Department.Patch
{
    /// <summary>
    /// Request for the patch department command.
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
        public IEnumerable<Field<DepartmentEntityField>> Fields { get; set; }

        #endregion
    }
}
