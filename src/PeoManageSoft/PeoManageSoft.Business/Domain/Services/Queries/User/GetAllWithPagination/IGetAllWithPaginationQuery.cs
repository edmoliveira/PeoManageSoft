using PeoManageSoft.Business.Domain.Services.Queries.User.Get.Response;

namespace PeoManageSoft.Business.Domain.Services.Queries.User.GetAllWithPagination
{
    /// <summary>
    /// Query to get all users with pagination.
    /// </summary>
    internal interface IGetAllWithPaginationQuery : IQueryScopeAsync<GetAllWithPaginationRequest, IEnumerable<GetResponse>>
    {
    }
}
