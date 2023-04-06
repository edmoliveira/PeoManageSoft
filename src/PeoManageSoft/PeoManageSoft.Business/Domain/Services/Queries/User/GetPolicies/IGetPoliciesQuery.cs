using PeoManageSoft.Business.Infrastructure.RepositoriesNoSql.Databases.Authorization.Policy;

namespace PeoManageSoft.Business.Domain.Services.Queries.User.GetPolicies
{
    /// <summary>
    /// Get policies query.
    /// </summary>
    internal interface IGetPoliciesQuery : IQueryNoSqlAsync<IPolicyCollection, GetPoliciesRequest, IEnumerable<GetPoliciesResponse>>
    {
    }
}
