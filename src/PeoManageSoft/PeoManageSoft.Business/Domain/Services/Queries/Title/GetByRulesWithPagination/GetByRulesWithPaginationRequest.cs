using PeoManageSoft.Business.Infrastructure.ObjectRelationalMapper;
using PeoManageSoft.Business.Infrastructure.ObjectRelationalMapper.Interfaces;
using PeoManageSoft.Business.Infrastructure.Repositories.Title;

namespace PeoManageSoft.Business.Domain.Services.Queries.Title.GetByRulesWithPagination
{
    /// <summary>
    /// Request for the query to get titles by rules with pagination.
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
        public OrderBy<TitleEntityField> OrderBy { get; set; }
        /// <summary>
        /// Rules to filter the data.
        /// </summary>
        public IRule<TitleEntityField> Rule { get; set; }

        #endregion
    }
}
