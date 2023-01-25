using PeoManageSoft.Business.Infrastructure.Helpers.Structs;

namespace PeoManageSoft.Business.Infrastructure.RepositoriesNoSql.Databases.Authorization.Schema.Models
{
    /// <summary>
    /// Resource
    /// </summary>
    internal sealed class ResourceDocument
    {
        #region Properties

        /// <summary>
        /// Identifier
        /// </summary>
        public string Id { get; private set; }
        /// <summary>
        /// User permissions.
        /// </summary>
        public Grant Permissions { get; private set; }
        /// <summary>
        /// Children
        /// </summary>
        public IEnumerable<ResourceDocument> Children { get; private set; }

        #endregion
    }
}
