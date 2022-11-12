using PeoManageSoft.Business.Domain.Services.Queries.Title.Get.Response;

namespace PeoManageSoft.Business.Domain.Services.Queries.Title.Get
{
    /// <summary>
    /// Get title query.
    /// </summary>
    internal interface IGetQuery : IQueryScopeAsync<GetRequest, GetResponse>
    {
    }
}
