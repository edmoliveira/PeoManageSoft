using PeoManageSoft.Business.Infrastructure.ObjectRelationalMapper;
using PeoManageSoft.Business.Infrastructure.Repositories.Role;

namespace PeoManageSoft.Business.Domain.Services.Queries.Role.GetAllWithPagination
{
    /// <summary>
    /// Request for the query to get all roles with pagination.
    /// </summary>
    internal sealed class GetAllWithPaginationRequest
    {
        #region Properties

        /// <summary>
        /// Current page
        /// </summary>
        public int Page { get; set; }
        /// <summary>
        /// Quantity per page
        /// </summary>
        public int QuantityPerPage { get; set; }
        /// <summary>
        /// OrderBy sql command
        /// </summary>
        public OrderBy<RoleEntityField> OrderBy { get; set; }

        #endregion
    }
}
