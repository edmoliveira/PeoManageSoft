using PeoManageSoft.Business.Domain.Services.Queries.Title.Get.Response;

namespace PeoManageSoft.Business.Domain.Services.Queries.Title.Get
{
    /// <summary>
    /// Handles all queries to get the title.
    /// </summary>
    internal interface IGetHandler : IHandlerAsync<GetRequest, GetResponse>
    {
    }
}
