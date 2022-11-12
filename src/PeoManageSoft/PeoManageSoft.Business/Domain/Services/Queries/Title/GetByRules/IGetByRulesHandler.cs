using PeoManageSoft.Business.Domain.Services.Queries.Title.Get.Response;
using PeoManageSoft.Business.Infrastructure.ObjectRelationalMapper.Interfaces;
using PeoManageSoft.Business.Infrastructure.Repositories.Title;

namespace PeoManageSoft.Business.Domain.Services.Queries.Title.GetByRules
{
    /// <summary>
    /// Handles all queries to get the title by rules.
    /// </summary>
    internal interface IGetByRulesHandler :
        IHandlerAsync<IRule<TitleEntityField>, IEnumerable<GetResponse>>,
        IBaseGetByRulesHandler<TitleEntityField>
    {
    }
}
