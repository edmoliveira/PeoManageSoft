using PeoManageSoft.Business.Domain.Services.Queries.Role.Get.Response;
using PeoManageSoft.Business.Infrastructure.ObjectRelationalMapper.Interfaces;
using PeoManageSoft.Business.Infrastructure.Repositories.Role;

namespace PeoManageSoft.Business.Domain.Services.Queries.Role.GetByRules
{
    /// <summary>
    /// Handles all queries to get the role by rules.
    /// </summary>
    internal interface IGetByRulesHandler :
        IHandlerAsync<IRule<RoleEntityField>, IEnumerable<GetResponse>>,
        IBaseGetByRulesHandler<RoleEntityField>
    {
    }
}
