using PeoManageSoft.Business.Application.Title.Read.Response;

namespace PeoManageSoft.Business.Application.Title.ReadAllWithPagination
{
    /// <summary>
    /// Read all titles with pagination application layer.
    /// </summary>
    internal interface IReadAllWithPaginationApplication : IApplicationAsync<ReadAllWithPaginationRequest, IEnumerable<ReadResponse>>
    {
    }
}