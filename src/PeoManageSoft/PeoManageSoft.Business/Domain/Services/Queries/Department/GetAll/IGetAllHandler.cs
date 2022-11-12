using PeoManageSoft.Business.Domain.Services.Queries.Department.Get.Response;

namespace PeoManageSoft.Business.Domain.Services.Queries.Department.GetAll
{
    /// <summary>
    /// Handles all queries to get all the department.
    /// </summary>
    internal interface IGetAllHandler : IResponseHandlerAsync<IEnumerable<GetResponse>>
    {
    }
}
