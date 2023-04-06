using PeoManageSoft.Business.Domain.Services.Queries.Role.Get.Response;
using PeoManageSoft.Business.Infrastructure.Repositories.Role;

namespace PeoManageSoft.Business.Domain.Services.Queries.Role.GetByRulesWithPagination
{
    /// <summary>
    /// Handles all queries to get roles by rules with pagination.
    /// </summary>
    internal interface IGetByRulesWithPaginationHandler :
        IHandlerAsync<GetByRulesWithPaginationRequest, IEnumerable<GetResponse>>,
        IBaseGetByRulesHandler<RoleEntityField>
    {
    }
}
