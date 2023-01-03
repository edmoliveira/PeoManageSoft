using PeoManageSoft.Business.Application.Title.Read.Response;

namespace PeoManageSoft.Business.Application.Title.SearchWithPagination
{
    /// <summary>
    /// Search titles with pagination application layer.
    /// </summary>
    internal interface ISearchWithPaginationApplication : IApplicationAsync<SearchWithPaginationRequest, IEnumerable<ReadResponse>>
    {
    }
}
