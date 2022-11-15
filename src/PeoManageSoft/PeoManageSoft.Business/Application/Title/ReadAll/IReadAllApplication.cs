using PeoManageSoft.Business.Application.Title.Read.Response;

namespace PeoManageSoft.Business.Application.Title.ReadAll
{
    /// <summary>
    /// Read all title application layer.
    /// </summary>
    internal interface IReadAllApplication : IResponseApplicationAsync<IEnumerable<ReadResponse>>
    {
    }
}
