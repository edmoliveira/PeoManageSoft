using PeoManageSoft.Business.Domain.Services.Queries.User.Get.Response;
using PeoManageSoft.Business.Infrastructure.ObjectRelationalMapper.Interfaces;
using PeoManageSoft.Business.Infrastructure.Repositories.User;

namespace PeoManageSoft.Business.Domain.Services.Queries.User.GetByRules
{
    /// <summary>
    /// Handles all queries to get the user by rules.
    /// </summary>
    internal interface IGetByRulesHandler : 
        IHandlerAsync<IRule<UserEntityField>, IEnumerable<GetResponse>>,
        IBaseGetByRulesHandler<UserEntityField>
    {
    }
}
