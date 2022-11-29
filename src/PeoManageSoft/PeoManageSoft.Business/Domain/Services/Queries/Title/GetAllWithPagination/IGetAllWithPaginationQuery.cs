using PeoManageSoft.Business.Domain.Services.Queries.Title.Get.Response;

namespace PeoManageSoft.Business.Domain.Services.Queries.Title.GetAllWithPagination
{
    /// <summary>
    /// Query to get all titles with pagination.
    /// </summary>
    internal interface IGetAllWithPaginationQuery : IQueryScopeAsync<GetAllWithPaginationRequest, IEnumerable<GetResponse>>
    {
    }
}
