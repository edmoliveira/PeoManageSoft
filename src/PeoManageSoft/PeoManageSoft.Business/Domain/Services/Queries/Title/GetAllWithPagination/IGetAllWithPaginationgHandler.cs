using PeoManageSoft.Business.Domain.Services.Queries.Title.Get.Response;

namespace PeoManageSoft.Business.Domain.Services.Queries.Title.GetAllWithPagination
{
    /// <summary>
    /// Handles all queries to get all the title with paginationg.
    /// </summary>
    internal interface IGetAllWithPaginationgHandler : IHandlerAsync<GetAllWithPaginationRequest, IEnumerable<GetResponse>>
    {
    }
}
