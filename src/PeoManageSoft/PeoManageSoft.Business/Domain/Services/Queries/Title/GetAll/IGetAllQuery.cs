using PeoManageSoft.Business.Domain.Services.Queries.Title.Get.Response;

namespace PeoManageSoft.Business.Domain.Services.Queries.Title.GetAll
{
    /// <summary>
    /// Get all title query.
    /// </summary>
    internal interface IGetAllQuery : IQueryScopeAsync<IEnumerable<GetResponse>>
    {
    }
}
