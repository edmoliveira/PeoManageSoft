using PeoManageSoft.Business.Infrastructure.Helpers.Structs;

namespace PeoManageSoft.Business.Infrastructure.RepositoriesNoSql.Databases.Authorization.Role.Models
{
    /// <summary>
    /// Resource
    /// </summary>
    internal sealed class ResourceDocument
    {
        #region Properties

        /// <summary>
        /// Resource name
        /// </summary>
        public string Name { get; private set; }
        /// <summary>
        /// User permissions.
        /// </summary>
        public Grant Permissions { get; private set; }

        #endregion
    }
}
