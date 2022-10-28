using PeoManageSoft.Business.Domain.Services.Queries.User.Get.Response;

namespace PeoManageSoft.Business.Domain.Services.Queries.User.Get
{
    /// <summary>
    /// Get user query.
    /// </summary>
    internal interface IGetQuery : IQueryScopeAsync<GetRequest, GetResponse>
    {
    }
}
