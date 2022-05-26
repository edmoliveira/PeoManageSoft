using PeoManageSoft.Business.Domain.Queries.User.GetAll.Response;

namespace PeoManageSoft.Business.Domain.Queries.User.GetAll
{
    /// <summary>
    /// Handles all queries to get all the user.
    /// </summary>
    internal interface IGetAllHandler : IResponseHandlerAsync<IEnumerable<GetAllResponse>>
    {
    }
}
