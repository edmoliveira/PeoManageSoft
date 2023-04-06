using PeoManageSoft.Business.Application.Role.Read.Response;

namespace PeoManageSoft.Business.Application.Role.ReadAll
{
    /// <summary>
    /// Read all role application layer.
    /// </summary>
    internal interface IReadAllApplication : IResponseApplicationAsync<IEnumerable<ReadResponse>>
    {
    }
}
