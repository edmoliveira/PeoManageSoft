using PeoManageSoft.Business.Domain.Services.Commands.Role.Update;
using PeoManageSoft.Business.Infrastructure.RepositoriesNoSql.Databases.Authorization.Role;

namespace PeoManageSoft.Business.Domain.Services.Commands.Role.Remove
{
    /// <summary>
    /// Remove resource command.
    /// </summary>
    internal interface IRemoveResourceCommand : ICommandNoSqlAsync<IRoleCollection, DeleteResourceRequest>
    {
    }
}
