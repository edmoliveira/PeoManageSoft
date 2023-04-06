using PeoManageSoft.Business.Infrastructure.RepositoriesNoSql.Databases.Authorization.Role;

namespace PeoManageSoft.Business.Domain.Services.Queries.Role.GetResources
{
    /// <summary>
    /// Get resources query.
    /// </summary>
    internal interface IGetResourcesQuery : IQueryNoSqlAsync<IRoleCollection, GetResourcesRequest, IEnumerable<GetResourcesResponse>>
    {
    }
}
