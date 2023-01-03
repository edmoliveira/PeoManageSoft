using PeoManageSoft.Business.Domain.Services.Queries.Department.Get.Response;

namespace PeoManageSoft.Business.Domain.Services.Queries.Department.GetAllWithPagination
{
    /// <summary>
    /// Handles all queries to get all the department with paginationg.
    /// </summary>
    internal interface IGetAllWithPaginationHandler : IHandlerAsync<GetAllWithPaginationRequest, IEnumerable<GetResponse>>
    {
    }
}
