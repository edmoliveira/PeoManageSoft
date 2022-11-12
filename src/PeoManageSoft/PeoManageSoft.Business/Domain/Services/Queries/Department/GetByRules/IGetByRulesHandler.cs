using PeoManageSoft.Business.Domain.Services.Queries.Department.Get.Response;
using PeoManageSoft.Business.Infrastructure.ObjectRelationalMapper.Interfaces;
using PeoManageSoft.Business.Infrastructure.Repositories.Department;

namespace PeoManageSoft.Business.Domain.Services.Queries.Department.GetByRules
{
    /// <summary>
    /// Handles all queries to get the department by rules.
    /// </summary>
    internal interface IGetByRulesHandler :
        IHandlerAsync<IRule<DepartmentEntityField>, IEnumerable<GetResponse>>,
        IBaseGetByRulesHandler<DepartmentEntityField>
    {
    }
}
