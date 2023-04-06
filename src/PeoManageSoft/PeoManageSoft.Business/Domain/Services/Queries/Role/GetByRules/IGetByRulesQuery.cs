using PeoManageSoft.Business.Domain.Services.Queries.Role.Get.Response;
using PeoManageSoft.Business.Infrastructure.ObjectRelationalMapper.Interfaces;
using PeoManageSoft.Business.Infrastructure.Repositories.Role;

namespace PeoManageSoft.Business.Domain.Services.Queries.Role.GetByRules
{
    /// <summary>
    /// Get role by rules query.
    /// </summary>
    internal interface IGetByRulesQuery : IQueryScopeAsync<IRule<RoleEntityField>, IEnumerable<GetResponse>>
    {
    }
}
