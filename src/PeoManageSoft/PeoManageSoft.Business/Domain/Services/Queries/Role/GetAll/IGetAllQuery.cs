using PeoManageSoft.Business.Domain.Services.Queries.Role.Get.Response;

namespace PeoManageSoft.Business.Domain.Services.Queries.Role.GetAll
{
    /// <summary>
    /// Get all role query.
    /// </summary>
    internal interface IGetAllQuery : IQueryScopeAsync<IEnumerable<GetResponse>>
    {
    }
}
