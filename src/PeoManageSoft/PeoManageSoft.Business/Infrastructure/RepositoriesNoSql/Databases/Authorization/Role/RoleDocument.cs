using PeoManageSoft.Business.Infrastructure.RepositoriesNoSql.Databases.Authorization.Role.Models;
using PeoManageSoft.Business.Infrastructure.RepositoriesNoSql.Driver;

namespace PeoManageSoft.Business.Infrastructure.RepositoriesNoSql.Databases.Authorization.Role
{
    /// <summary>
    /// NoSql document "Role".
    /// </summary>
    internal sealed class RoleDocument : BaseDocumentNoSql, IDocumentNoSql
    {
        #region Properties

        /// <summary>
        /// Role identifier
        /// </summary>
        public long RoleId { get; private set; }

        /// <summary>
        /// Resources
        /// </summary>
        public IEnumerable<ResourceDocument> Resources { get; private set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the PeoManageSoft.Business.Infrastructure.RepositoriesNoSql.Databases.Authorization.Role.RoleDocument class.
        /// </summary>
        public RoleDocument() { }

        /// <summary>
        /// Initializes a new instance of the PeoManageSoft.Business.Infrastructure.RepositoriesNoSql.Databases.Authorization.Role.RoleDocument class.
        /// </summary>
        /// <param name="roleId">Role name</param>
        /// <param name="resources">Resources</param>
        public RoleDocument(long roleId, IEnumerable<ResourceDocument> resources)
        {
            this.RoleId = roleId;
            this.Resources = resources;
        }

        #endregion
    }
}
