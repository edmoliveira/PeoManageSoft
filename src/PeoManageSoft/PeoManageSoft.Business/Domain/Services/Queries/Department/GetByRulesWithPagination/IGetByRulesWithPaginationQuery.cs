using PeoManageSoft.Business.Domain.Services.Queries.Department.Get.Response;

namespace PeoManageSoft.Business.Domain.Services.Queries.Department.GetByRulesWithPagination
{
    /// <summary>
    /// Query to get departments by rules with pagination.
    /// </summary>
    internal interface IGetByRulesWithPaginationQuery : IQueryScopeAsync<GetByRulesWithPaginationRequest, IEnumerable<GetResponse>>
    {
    }
}
