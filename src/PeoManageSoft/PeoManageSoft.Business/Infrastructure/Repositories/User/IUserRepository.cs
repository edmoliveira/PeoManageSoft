using PeoManageSoft.Business.Infrastructure.Repositories.Interfaces;
using static PeoManageSoft.Business.Infrastructure.Repositories.User.UserEntityConfig;

namespace PeoManageSoft.Business.Infrastructure.Repositories.User
{
    /// <summary>
    /// User encapsulation of logic to access data sources.
    /// </summary>
    internal interface IUserRepository : IBaseRepository<UserEntity, EntityField>
    {

    }
}
