using PeoManageSoft.Business.Application.Role.Read.Response;

namespace PeoManageSoft.Business.Application.Role.Read
{
    /// <summary>
    /// Read role application layer.
    /// </summary>
    internal interface IReadApplication : IApplicationAsync<ReadRequest, ReadResponse>
    {
    }
}
