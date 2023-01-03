using PeoManageSoft.Business.Application.User.Read.Response;

namespace PeoManageSoft.Business.Application.User.SearchWithPagination
{
    /// <summary>
    /// Search users with pagination application layer.
    /// </summary>
    internal interface ISearchWithPaginationApplication : IApplicationAsync<SearchWithPaginationRequest, IEnumerable<ReadResponse>>
    {
    }
}
