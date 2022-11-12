using PeoManageSoft.Business.Domain.Services.Queries.Title.Get.Response;

namespace PeoManageSoft.Business.Domain.Services.Queries.Title.GetAll
{
    /// <summary>
    /// Handles all queries to get all the title.
    /// </summary>
    internal interface IGetAllHandler : IResponseHandlerAsync<IEnumerable<GetResponse>>
    {
    }
}
