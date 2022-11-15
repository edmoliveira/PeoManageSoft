using PeoManageSoft.Business.Application.Department.Read.Response;

namespace PeoManageSoft.Business.Application.Department.ReadAll
{
    /// <summary>
    /// Read all department application layer.
    /// </summary>
    internal interface IReadAllApplication : IResponseApplicationAsync<IEnumerable<ReadResponse>>
    {
    }
}
