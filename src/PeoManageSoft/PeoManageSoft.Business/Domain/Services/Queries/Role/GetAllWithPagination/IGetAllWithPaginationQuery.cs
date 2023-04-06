using PeoManageSoft.Business.Domain.Services.Queries.Role.Get.Response;

namespace PeoManageSoft.Business.Domain.Services.Queries.Role.GetAllWithPagination
{
    /// <summary>
    /// Query to get all roles with pagination.
    /// </summary>
    internal interface IGetAllWithPaginationQuery : IQueryScopeAsync<GetAllWithPaginationRequest, IEnumerable<GetResponse>>
    {
    }
}
