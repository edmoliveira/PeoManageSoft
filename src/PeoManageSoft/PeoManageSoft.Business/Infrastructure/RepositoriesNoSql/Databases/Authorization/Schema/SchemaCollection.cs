
namespace PeoManageSoft.Business.Infrastructure.RepositoriesNoSql.Databases.Authorization.Schema
{
    /// <summary>
    /// Cross-platform NoSQL collection.
    /// </summary>
    internal sealed class SchemaCollection : ISchemaCollection
    {
        #region Constants

        /// <summary>
        /// Database name.
        /// </summary>
        private const string CollectionName = "schemas";

        #endregion

        #region Fields

        /// <summary>
        /// Cross-platform NoSQL collection.
        /// </summary>
        private readonly ICollectionNoSql<SchemaEntity> _collection;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the PeoManageSoft.Business.Infrastructure.RepositoriesNoSql.Databases.Authorization.Schema.SchemaCollection class.
        /// </summary>
        /// <param name="client">Cross-platform NoSQL database.</param>
        public SchemaCollection(IDatabaseNoSql _database)
        {
            _collection = _database.GetCollection<SchemaEntity>(CollectionName);
        }

        #endregion
    }
}
