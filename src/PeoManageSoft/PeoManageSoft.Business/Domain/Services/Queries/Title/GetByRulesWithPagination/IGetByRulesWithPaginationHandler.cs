using PeoManageSoft.Business.Domain.Services.Queries.Title.Get.Response;
using PeoManageSoft.Business.Infrastructure.Repositories.Title;

namespace PeoManageSoft.Business.Domain.Services.Queries.Title.GetByRulesWithPagination
{
    /// <summary>
    /// Handles all queries to get titles by rules with pagination.
    /// </summary>
    internal interface IGetByRulesWithPaginationHandler :
        IHandlerAsync<GetByRulesWithPaginationRequest, IEnumerable<GetResponse>>,
        IBaseGetByRulesHandler<TitleEntityField>
    {
    }
}
