using PeoManageSoft.Business.Infrastructure.RepositoriesNoSql.Driver;

namespace PeoManageSoft.Business.Infrastructure.RepositoriesNoSql.Databases.Authorization.Schema
{
    /// <summary>
    /// Cross-platform NoSQL collection.
    /// </summary>
    internal sealed class SchemaCollection : BaseCollection<SchemaDocument>, ISchemaCollection
    {
        #region Constants

        /// <summary>
        /// Collection name.
        /// </summary>
        private const string CollectionName = "schemas";

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the PeoManageSoft.Business.Infrastructure.RepositoriesNoSql.Databases.Authorization.Schema.SchemaCollection class.
        /// </summary>
        /// <param name="client">Cross-platform NoSQL database.</param>
        public SchemaCollection(IDatabaseNoSql _database)
            : base(_database.GetCollection<SchemaDocument>(CollectionName))
        {

        }

        #endregion
    }
}
