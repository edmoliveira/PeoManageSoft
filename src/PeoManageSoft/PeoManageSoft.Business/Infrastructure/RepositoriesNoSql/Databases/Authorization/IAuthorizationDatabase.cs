using PeoManageSoft.Business.Infrastructure.RepositoriesNoSql.Databases.Authorization.Policy;
using PeoManageSoft.Business.Infrastructure.RepositoriesNoSql.Databases.Authorization.Role;
using PeoManageSoft.Business.Infrastructure.RepositoriesNoSql.Databases.Authorization.Schema;

namespace PeoManageSoft.Business.Infrastructure.RepositoriesNoSql.Databases.Authorization
{
    /// <summary>
    /// Cross-platform NoSQL database "Authorization"
    /// </summary>
    internal interface IAuthorizationDatabase
    {
        #region Properties

        /// <summary>
        /// Cross-platform NoSQL collection. "Role". 
        /// </summary>
        IRoleCollection Role { get; }
        /// <summary>
        /// Cross-platform NoSQL collection. "Schema". 
        /// </summary>
        ISchemaCollection Schema { get; }
        /// <summary>
        /// Cross-platform NoSQL collection. "Policy". 
        /// </summary>
        IPolicyCollection Policy { get; }

        #endregion
    }
}
