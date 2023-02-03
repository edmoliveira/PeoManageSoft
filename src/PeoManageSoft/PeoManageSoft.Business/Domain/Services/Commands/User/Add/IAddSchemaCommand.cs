using PeoManageSoft.Business.Infrastructure.RepositoriesNoSql.Databases.Authorization.Schema;

namespace PeoManageSoft.Business.Domain.Services.Commands.User.Add
{
    /// <summary>
    /// Add schema command.
    /// </summary>
    internal interface IAddSchemaCommand : ICommandNoSqlAsync<ISchemaCollection, AddSchemaRequest>
    {
    }
}
