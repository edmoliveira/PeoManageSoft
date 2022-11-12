using PeoManageSoft.Business.Domain.Services.Queries.Title.Get.Response;
using PeoManageSoft.Business.Infrastructure.ObjectRelationalMapper.Interfaces;
using PeoManageSoft.Business.Infrastructure.Repositories.Title;

namespace PeoManageSoft.Business.Domain.Services.Queries.Title.GetByRules
{
    /// <summary>
    /// Get title by rules query.
    /// </summary>
    internal interface IGetByRulesQuery : IQueryScopeAsync<IRule<TitleEntityField>, IEnumerable<GetResponse>>
    {
    }
}
