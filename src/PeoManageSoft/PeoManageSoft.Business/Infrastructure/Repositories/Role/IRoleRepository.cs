using PeoManageSoft.Business.Infrastructure.Repositories.Interfaces;

namespace PeoManageSoft.Business.Infrastructure.Repositories.Role
{
    /// <summary>
    /// Base encapsulation of logic to access data sources.
    /// </summary>
    internal interface IRoleRepository : IBaseRepository<RoleEntity, RoleEntityField>
    {
    }
}
