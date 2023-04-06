using PeoManageSoft.Business.Infrastructure.RepositoriesNoSql.Databases.Authorization.Role;

namespace PeoManageSoft.Business.Domain.Services.Commands.Role.Update
{
    /// <summary>
    /// Update resource command.
    /// </summary>
    internal interface IUpdateResourceCommand : ICommandNoSqlAsync<IRoleCollection, UpdateResourceRequest>
    {
    }
}
