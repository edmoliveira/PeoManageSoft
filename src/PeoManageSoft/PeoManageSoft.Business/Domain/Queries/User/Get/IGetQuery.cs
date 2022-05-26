using PeoManageSoft.Business.Domain.Queries.User.Get.Response;

namespace PeoManageSoft.Business.Domain.Queries.User.Get
{
    /// <summary>
    /// Get user query.
    /// </summary>
    internal interface IGetQuery : IQueryScopeAsync<GetRequest, GetResponse>
    {
    }
}
