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

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the PeoManageSoft.Business.Infrastructure.RepositoriesNoSql.Databases.Authorization.Schema.PolicyDocument class.
        /// </summary>
        public PolicyDocument() { }

        /// <summary>
        /// Initializes a new instance of the PeoManageSoft.Business.Infrastructure.RepositoriesNoSql.Databases.Authorization.Schema.PolicyDocument class.
        /// </summary>
        /// <param name="userId">User identifier</param>
        /// <param name="resourceName">Resource name</param>
        /// <param name="permissions">User permissions.</param>
        public PolicyDocument(long userId, string resourceName, Grant permissions)
        {
            this.UserId = userId;
            this.ResourceName = resourceName;
            this.Permissions = permissions;
        }

        #endregion
    }
}
