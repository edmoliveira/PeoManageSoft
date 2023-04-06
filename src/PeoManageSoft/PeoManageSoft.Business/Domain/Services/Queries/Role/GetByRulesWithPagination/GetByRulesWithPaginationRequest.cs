using PeoManageSoft.Business.Infrastructure.ObjectRelationalMapper;
using PeoManageSoft.Business.Infrastructure.ObjectRelationalMapper.Interfaces;
using PeoManageSoft.Business.Infrastructure.Repositories.Role;

namespace PeoManageSoft.Business.Domain.Services.Queries.Role.GetByRulesWithPagination
{
    /// <summary>
    /// Request for the query to get roles by rules with pagination.
    /// </summary>
    internal sealed class GetByRulesWithPaginationRequest
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
        /// <summary>
        /// Rules to filter the data.
        /// </summary>
        public IRule<RoleEntityField> Rule { get; set; }

        #endregion
    }
}
