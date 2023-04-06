using PeoManageSoft.Business.Domain.Services.Queries.Role.Get.Response;

namespace PeoManageSoft.Business.Domain.Services.Queries.Role.GetAllWithPagination
{
    /// <summary>
    /// Handles all queries to get all the role with paginationg.
    /// </summary>
    internal interface IGetAllWithPaginationHandler : IHandlerAsync<GetAllWithPaginationRequest, IEnumerable<GetResponse>>
    {
    }
}
