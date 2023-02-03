using PeoManageSoft.Business.Infrastructure.RepositoriesNoSql.Databases.Authorization.Schema.Models;
using PeoManageSoft.Business.Infrastructure.RepositoriesNoSql.Driver;

namespace PeoManageSoft.Business.Infrastructure.RepositoriesNoSql.Databases.Authorization.Schema
{
    /// <summary>
    /// NoSql document "Schema".
    /// </summary>
    internal sealed class SchemaDocument : BaseDocumentNoSql, IDocumentNoSql
    {
        #region Properties

        /// <summary>
        /// User identifier
        /// </summary>
        public long UserId { get; private set; }

        /// <summary>
        /// Resources
        /// </summary>
        public IEnumerable<ResourceDocument> Resources { get; private set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the PeoManageSoft.Business.Infrastructure.RepositoriesNoSql.Databases.Authorization.Schema.SchemaDocument class.
        /// </summary>
        public SchemaDocument() { }

        /// <summary>
        /// Initializes a new instance of the PeoManageSoft.Business.Infrastructure.RepositoriesNoSql.Databases.Authorization.Schema.SchemaDocument class.
        /// </summary>
        /// <param name="userId">User identifier</param>
        /// <param name="resources">Resources</param>
        public SchemaDocument(long userId, IEnumerable<ResourceDocument> resources) 
        { 
            this.UserId = userId;
            this.Resources = resources;
        }

        #endregion
    }
}
