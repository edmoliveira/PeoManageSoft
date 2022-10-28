using PeoManageSoft.Business.Domain.Services.Queries.User.GetAll.Response;

namespace PeoManageSoft.Business.Domain.Services.Queries.User.GetAll
{
    /// <summary>
    /// Get all user query.
    /// </summary>
    internal interface IGetAllQuery : IQueryScopeAsync<IEnumerable<GetAllResponse>>
    {
    }
}
