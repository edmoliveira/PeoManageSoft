using PeoManageSoft.Business.Infrastructure.ObjectRelationalMapper;
using PeoManageSoft.Business.Infrastructure.ObjectRelationalMapper.Interfaces;
using PeoManageSoft.Business.Infrastructure.Repositories.Department;

namespace PeoManageSoft.Business.Domain.Services.Queries.Department.GetByRulesWithPagination
{
    /// <summary>
    /// Request for the query to get departments by rules with pagination.
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
        public OrderBy<DepartmentEntityField> OrderBy { get; set; }
        /// <summary>
        /// Rules to filter the data.
        /// </summary>
        public IRule<DepartmentEntityField> Rule { get; set; }

        #endregion
    }
}
