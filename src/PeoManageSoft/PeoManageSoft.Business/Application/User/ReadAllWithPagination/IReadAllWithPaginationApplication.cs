using PeoManageSoft.Business.Application.User.Read.Response;

namespace PeoManageSoft.Business.Application.User.ReadAllWithPagination
{
    /// <summary>
    /// Read all users with pagination application layer.
    /// </summary>
    internal interface IReadAllWithPaginationApplication : IApplicationAsync<ReadAllWithPaginationRequest, IEnumerable<ReadResponse>>
    {
    }
}