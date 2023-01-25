using PeoManageSoft.Business.Infrastructure.Helpers.Structs;
using PeoManageSoft.Business.Infrastructure.RepositoriesNoSql.Driver;

namespace PeoManageSoft.Business.Infrastructure.RepositoriesNoSql.Databases.Authorization.Policy
{
    /// <summary>
    /// NoSql document "Policy".
    /// </summary>
    internal sealed class PolicyDocument: BaseDocumentNoSql, IDocumentNoSql
    {
        #region Properties

        /// <summary>
        /// User identifier
        /// </summary>
        public long UserId { get; private set; }

        /// <summary>
        /// Resource name
        /// </summary>
        public string ResourceName { get; private set; }

        /// <summary>
        /// User permissions.
        /// </summary>
        public Grant Permissions { get; private set; }

        #endregion
    }
}
