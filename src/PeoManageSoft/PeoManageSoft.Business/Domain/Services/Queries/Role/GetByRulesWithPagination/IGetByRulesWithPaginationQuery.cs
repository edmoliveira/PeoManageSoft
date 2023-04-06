using PeoManageSoft.Business.Domain.Services.Queries.Role.Get.Response;

namespace PeoManageSoft.Business.Domain.Services.Queries.Role.GetByRulesWithPagination
{
    /// <summary>
    /// Query to get roles by rules with pagination.
    /// </summary>
    internal interface IGetByRulesWithPaginationQuery : IQueryScopeAsync<GetByRulesWithPaginationRequest, IEnumerable<GetResponse>>
    {
    }
}
