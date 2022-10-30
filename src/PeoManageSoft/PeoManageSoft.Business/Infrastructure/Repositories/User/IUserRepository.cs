using PeoManageSoft.Business.Infrastructure.Repositories.Interfaces;

namespace PeoManageSoft.Business.Infrastructure.Repositories.User
{
    /// <summary>
    /// Base encapsulation of logic to access data sources.
    /// </summary>
    internal interface IUserRepository : IBaseRepository<UserEntity, UserEntityField>
    {
    }
}
