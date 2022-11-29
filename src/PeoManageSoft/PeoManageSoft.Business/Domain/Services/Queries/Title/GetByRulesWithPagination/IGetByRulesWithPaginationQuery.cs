using PeoManageSoft.Business.Domain.Services.Queries.Title.Get.Response;

namespace PeoManageSoft.Business.Domain.Services.Queries.Title.GetByRulesWithPagination
{
    /// <summary>
    /// Query to get titles by rules with pagination.
    /// </summary>
    internal interface IGetByRulesWithPaginationQuery : IQueryScopeAsync<GetByRulesWithPaginationRequest, IEnumerable<GetResponse>>
    {
    }
}
