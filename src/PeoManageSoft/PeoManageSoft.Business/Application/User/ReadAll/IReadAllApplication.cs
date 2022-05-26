using PeoManageSoft.Business.Application.User.ReadAll.Response;

namespace PeoManageSoft.Business.Application.User.ReadAll
{
    /// <summary>
    /// Read all user application layer.
    /// </summary>
    internal interface IReadAllApplication : IResponseApplicationAsync<IEnumerable<ReadAllResponse>>
    {
    }
}
