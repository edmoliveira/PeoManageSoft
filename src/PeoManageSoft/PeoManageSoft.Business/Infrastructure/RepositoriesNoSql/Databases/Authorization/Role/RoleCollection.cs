using PeoManageSoft.Business.Infrastructure.RepositoriesNoSql.Driver;

namespace PeoManageSoft.Business.Infrastructure.RepositoriesNoSql.Databases.Authorization.Role
{
    /// <summary>
    /// Cross-platform NoSQL collection.
    /// </summary>
    internal sealed class RoleCollection : BaseCollection<RoleDocument>, IRoleCollection
    {
        #region Constants

        /// <summary>
        /// Collection name.
        /// </summary>
        private const string CollectionName = "roles";

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the PeoManageSoft.Business.Infrastructure.RepositoriesNoSql.Databases.Authorization.Role.RoleCollection class.
        /// </summary>
        /// <param name="client">Cross-platform NoSQL database.</param>
        public RoleCollection(IDatabaseNoSql _database)
            : base(_database.GetCollection<RoleDocument>(CollectionName))
        {

        }

        #endregion
    }
}
