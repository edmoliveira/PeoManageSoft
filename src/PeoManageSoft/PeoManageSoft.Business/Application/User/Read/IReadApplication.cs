using PeoManageSoft.Business.Application.User.Read.Response;

namespace PeoManageSoft.Business.Application.User.Read
{
    /// <summary>
    /// Read user application layer.
    /// </summary>
    internal interface IReadApplication : IApplicationAsync<ReadRequest, ReadResponse>
    {
    }
}
