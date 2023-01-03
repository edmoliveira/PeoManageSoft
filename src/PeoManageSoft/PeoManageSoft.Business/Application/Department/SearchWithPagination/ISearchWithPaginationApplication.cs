using PeoManageSoft.Business.Application.Department.Read.Response;

namespace PeoManageSoft.Business.Application.Department.SearchWithPagination
{
    /// <summary>
    /// Search departments with pagination application layer.
    /// </summary>
    internal interface ISearchWithPaginationApplication : IApplicationAsync<SearchWithPaginationRequest, IEnumerable<ReadResponse>>
    {
    }
}
