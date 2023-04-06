using PeoManageSoft.Business.Application.Role.Read.Response;

namespace PeoManageSoft.Business.Application.Role.SearchWithPagination
{
    /// <summary>
    /// Search roles with pagination application layer.
    /// </summary>
    internal interface ISearchWithPaginationApplication : IApplicationAsync<SearchWithPaginationRequest, IEnumerable<ReadResponse>>
    {
    }
}
