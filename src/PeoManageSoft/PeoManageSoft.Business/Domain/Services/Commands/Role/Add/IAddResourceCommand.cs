using PeoManageSoft.Business.Infrastructure.RepositoriesNoSql.Databases.Authorization.Role;

namespace PeoManageSoft.Business.Domain.Services.Commands.Role.Add
{
    /// <summary>
    /// Add resource command.
    /// </summary>
    internal interface IAddResourceCommand : ICommandNoSqlAsync<IRoleCollection, AddResourceRequest>
    {
    }
}
