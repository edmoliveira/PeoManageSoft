using PeoManageSoft.Business.Domain.Services.Queries.User.Get.Response;
using PeoManageSoft.Business.Infrastructure.ObjectRelationalMapper.Interfaces;
using PeoManageSoft.Business.Infrastructure.Repositories.User;

namespace PeoManageSoft.Business.Domain.Services.Queries.User.GetByRules
{
    /// <summary>
    /// Get user by rules query.
    /// </summary>
    internal interface IGetByRulesQuery : IQueryScopeAsync<IRule<UserEntityField>, IEnumerable<GetResponse>>
    {
    }
}
