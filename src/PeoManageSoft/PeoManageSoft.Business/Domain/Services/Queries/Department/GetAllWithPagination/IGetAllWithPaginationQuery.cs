using PeoManageSoft.Business.Domain.Services.Queries.Department.Get.Response;

namespace PeoManageSoft.Business.Domain.Services.Queries.Department.GetAllWithPagination
{
    /// <summary>
    /// Query to get all departments with pagination.
    /// </summary>
    internal interface IGetAllWithPaginationQuery : IQueryScopeAsync<GetAllWithPaginationRequest, IEnumerable<GetResponse>>
    {
    }
}
