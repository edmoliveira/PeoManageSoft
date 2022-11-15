using PeoManageSoft.Business.Application.Department.Read.Response;

namespace PeoManageSoft.Business.Application.Department.Read
{
    /// <summary>
    /// Read department application layer.
    /// </summary>
    internal interface IReadApplication : IApplicationAsync<ReadRequest, ReadResponse>
    {
    }
}
