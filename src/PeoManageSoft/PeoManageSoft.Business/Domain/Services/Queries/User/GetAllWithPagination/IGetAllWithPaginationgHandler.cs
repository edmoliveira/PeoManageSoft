using PeoManageSoft.Business.Domain.Services.Queries.User.Get.Response;

namespace PeoManageSoft.Business.Domain.Services.Queries.User.GetAllWithPagination
{
    /// <summary>
    /// Handles all queries to get all the user with paginationg.
    /// </summary>
    internal interface IGetAllWithPaginationgHandler : IHandlerAsync<GetAllWithPaginationRequest, IEnumerable<GetResponse>>
    {
    }
}
