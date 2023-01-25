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
    }
}
