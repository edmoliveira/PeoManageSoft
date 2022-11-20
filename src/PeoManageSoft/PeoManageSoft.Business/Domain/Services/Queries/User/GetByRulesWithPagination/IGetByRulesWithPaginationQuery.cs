using PeoManageSoft.Business.Domain.Services.Queries.User.Get.Response;

namespace PeoManageSoft.Business.Domain.Services.Queries.User.GetByRulesWithPagination
{
    /// <summary>
    /// Query to get users by rules with pagination.
    /// </summary>
    internal interface IGetByRulesWithPaginationQuery : IQueryScopeAsync<GetByRulesWithPaginationRequest, IEnumerable<GetResponse>>
    {
    }
}
