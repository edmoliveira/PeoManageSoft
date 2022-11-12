using PeoManageSoft.Business.Domain.Services.Queries.Department.Get.Response;
using PeoManageSoft.Business.Infrastructure.ObjectRelationalMapper.Interfaces;
using PeoManageSoft.Business.Infrastructure.Repositories.Department;

namespace PeoManageSoft.Business.Domain.Services.Queries.Department.GetByRules
{
    /// <summary>
    /// Get department by rules query.
    /// </summary>
    internal interface IGetByRulesQuery : IQueryScopeAsync<IRule<DepartmentEntityField>, IEnumerable<GetResponse>>
    {
    }
}
