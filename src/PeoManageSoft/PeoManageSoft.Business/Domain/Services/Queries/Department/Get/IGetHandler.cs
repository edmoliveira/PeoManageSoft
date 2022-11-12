using PeoManageSoft.Business.Domain.Services.Queries.Department.Get.Response;

namespace PeoManageSoft.Business.Domain.Services.Queries.Department.Get
{
    /// <summary>
    /// Handles all queries to get the department.
    /// </summary>
    internal interface IGetHandler : IHandlerAsync<GetRequest, GetResponse>
    {
    }
}
