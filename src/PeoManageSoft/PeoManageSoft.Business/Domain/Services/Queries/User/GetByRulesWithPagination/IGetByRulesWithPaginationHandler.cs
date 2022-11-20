using PeoManageSoft.Business.Domain.Services.Queries.User.Get.Response;
using PeoManageSoft.Business.Infrastructure.ObjectRelationalMapper.Interfaces;
using PeoManageSoft.Business.Infrastructure.Repositories.User;

namespace PeoManageSoft.Business.Domain.Services.Queries.User.GetByRulesWithPagination
{
    /// <summary>
    /// Handles all queries to get users by rules with pagination.
    /// </summary>
    internal interface IGetByRulesWithPaginationHandler :
        IHandlerAsync<GetByRulesWithPaginationRequest, IEnumerable<GetResponse>>,
        IBaseGetByRulesHandler<UserEntityField>
    {
    }
}
