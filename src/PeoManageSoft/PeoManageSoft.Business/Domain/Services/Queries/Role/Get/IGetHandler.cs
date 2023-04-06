using PeoManageSoft.Business.Domain.Services.Queries.Role.Get.Response;

namespace PeoManageSoft.Business.Domain.Services.Queries.Role.Get
{
    /// <summary>
    /// Handles all queries to get the role.
    /// </summary>
    internal interface IGetHandler : IHandlerAsync<GetRequest, GetResponse>
    {
    }
}
