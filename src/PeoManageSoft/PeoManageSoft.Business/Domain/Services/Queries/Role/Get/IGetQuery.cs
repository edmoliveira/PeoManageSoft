using PeoManageSoft.Business.Domain.Services.Queries.Role.Get.Response;

namespace PeoManageSoft.Business.Domain.Services.Queries.Role.Get
{
    /// <summary>
    /// Get role query.
    /// </summary>
    internal interface IGetQuery : IQueryScopeAsync<GetRequest, GetResponse>
    {
    }
}
