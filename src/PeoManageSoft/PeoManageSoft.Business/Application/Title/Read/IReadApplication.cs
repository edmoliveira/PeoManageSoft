using PeoManageSoft.Business.Application.Title.Read.Response;

namespace PeoManageSoft.Business.Application.Title.Read
{
    /// <summary>
    /// Read title application layer.
    /// </summary>
    internal interface IReadApplication : IApplicationAsync<ReadRequest, ReadResponse>
    {
    }
}
