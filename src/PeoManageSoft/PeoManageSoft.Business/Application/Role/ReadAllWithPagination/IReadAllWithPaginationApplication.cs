using PeoManageSoft.Business.Application.Role.Read.Response;

namespace PeoManageSoft.Business.Application.Role.ReadAllWithPagination
{
    /// <summary>
    /// Read all roles with pagination application layer.
    /// </summary>
    internal interface IReadAllWithPaginationApplication : IApplicationAsync<ReadAllWithPaginationRequest, IEnumerable<ReadResponse>>
    {
    }
}