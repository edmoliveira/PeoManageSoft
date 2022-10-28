using PeoManageSoft.Business.Domain.Services.Queries.User.Get.Response;

namespace PeoManageSoft.Business.Domain.Services.Queries.User.Get
{
    /// <summary>
    /// Handles all queries to get the user.
    /// </summary>
    internal interface IGetHandler : IHandlerAsync<GetRequest, GetResponse>
    {
    }
}
