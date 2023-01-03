using PeoManageSoft.Business.Application.Department.Read.Response;

namespace PeoManageSoft.Business.Application.Department.ReadAllWithPagination
{
    /// <summary>
    /// Read all departments with pagination application layer.
    /// </summary>
    internal interface IReadAllWithPaginationApplication : IApplicationAsync<ReadAllWithPaginationRequest, IEnumerable<ReadResponse>>
    {
    }
}