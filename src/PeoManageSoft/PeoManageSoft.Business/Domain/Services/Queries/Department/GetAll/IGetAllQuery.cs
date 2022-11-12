using PeoManageSoft.Business.Domain.Services.Queries.Department.Get.Response;

namespace PeoManageSoft.Business.Domain.Services.Queries.Department.GetAll
{
    /// <summary>
    /// Get all department query.
    /// </summary>
    internal interface IGetAllQuery : IQueryScopeAsync<IEnumerable<GetResponse>>
    {
    }
}
