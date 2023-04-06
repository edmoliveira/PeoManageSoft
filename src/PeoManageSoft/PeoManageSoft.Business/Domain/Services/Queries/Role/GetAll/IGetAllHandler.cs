using PeoManageSoft.Business.Domain.Services.Queries.Role.Get.Response;

namespace PeoManageSoft.Business.Domain.Services.Queries.Role.GetAll
{
    /// <summary>
    /// Handles all queries to get all the role.
    /// </summary>
    internal interface IGetAllHandler : IResponseHandlerAsync<IEnumerable<GetResponse>>
    {
    }
}
