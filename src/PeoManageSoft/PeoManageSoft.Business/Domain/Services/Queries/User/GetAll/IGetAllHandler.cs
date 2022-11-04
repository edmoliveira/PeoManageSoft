using PeoManageSoft.Business.Domain.Services.Queries.User.Get.Response;

namespace PeoManageSoft.Business.Domain.Services.Queries.User.GetAll
{
    /// <summary>
    /// Handles all queries to get all the user.
    /// </summary>
    internal interface IGetAllHandler : IResponseHandlerAsync<IEnumerable<GetResponse>>
    {
    }
}
