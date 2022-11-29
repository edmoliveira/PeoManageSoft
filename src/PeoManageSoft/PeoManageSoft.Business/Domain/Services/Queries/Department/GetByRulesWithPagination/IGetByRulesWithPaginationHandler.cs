using PeoManageSoft.Business.Domain.Services.Queries.Department.Get.Response;
using PeoManageSoft.Business.Infrastructure.ObjectRelationalMapper.Interfaces;
using PeoManageSoft.Business.Infrastructure.Repositories.Department;

namespace PeoManageSoft.Business.Domain.Services.Queries.Department.GetByRulesWithPagination
{
    /// <summary>
    /// Handles all queries to get departments by rules with pagination.
    /// </summary>
    internal interface IGetByRulesWithPaginationHandler :
        IHandlerAsync<GetByRulesWithPaginationRequest, IEnumerable<GetResponse>>,
        IBaseGetByRulesHandler<DepartmentEntityField>
    {
    }
}
