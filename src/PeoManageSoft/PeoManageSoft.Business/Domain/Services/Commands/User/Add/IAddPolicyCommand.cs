using PeoManageSoft.Business.Domain.Services.Commands.User.Add.Models;
using PeoManageSoft.Business.Infrastructure.RepositoriesNoSql.Databases.Authorization.Policy;

namespace PeoManageSoft.Business.Domain.Services.Commands.User.Add
{
    /// <summary>
    /// Add policy command.
    /// </summary>
    internal interface IAddPolicyCommand : ICommandNoSqlAsync<IPolicyCollection, IEnumerable<PolicyDocument>>
    {
    }
}