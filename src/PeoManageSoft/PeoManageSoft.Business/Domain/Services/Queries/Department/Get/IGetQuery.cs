using PeoManageSoft.Business.Domain.Services.Queries.Department.Get.Response;

namespace PeoManageSoft.Business.Domain.Services.Queries.Department.Get
{
    /// <summary>
    /// Get department query.
    /// </summary>
    internal interface IGetQuery : IQueryScopeAsync<GetRequest, GetResponse>
    {
    }
}
