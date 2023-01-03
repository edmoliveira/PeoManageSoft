using PeoManageSoft.Business.Domain.Services.Queries.Title.Get.Response;

namespace PeoManageSoft.Business.Domain.Services.Queries.Title.GetAllWithPagination
{
    /// <summary>
    /// Handles all queries to get all the title with paginationg.
    /// </summary>
    internal interface IGetAllWithPaginationHandler : IHandlerAsync<GetAllWithPaginationRequest, IEnumerable<GetResponse>>
    {
    }
}
