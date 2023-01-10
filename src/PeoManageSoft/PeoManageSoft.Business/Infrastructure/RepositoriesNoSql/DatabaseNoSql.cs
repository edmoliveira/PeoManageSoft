using MongoDB.Driver;

namespace PeoManageSoft.Business.Infrastructure.RepositoriesNoSql
{
    /// <summary>
    /// Cross-platform NoSQL database.
    /// </summary>
    internal sealed class DatabaseNoSql : IDatabaseNoSql
    {
        #region Fields

        /// <summary>
        /// Cross-platform NoSQL database.
        /// </summary>
        private readonly IMongoDatabase _database;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the PeoManageSoft.Business.Infrastructure.RepositoriesNoSql.DatabaseNoSql class.
        /// </summary>
        /// <param name="database">Cross-platform NoSQL database.</param>
        public DatabaseNoSql(IMongoDatabase database)
        {
            _database = database;
        }

        #endregion

        #region Methods

        #region public

        /// <summary>
        /// Gets the collection object.
        /// </summary>
        /// <typeparam name="TDocument">The document type.</typeparam>
        /// <param name="name">Collection name</param>
        /// <param name="settings">Collection settings</param>
        /// <returns>Returns the collection object.</returns>
        public ICollectionNoSql<TDocument> GetCollection<TDocument>(string name, CollectionSettingsNoSql settings = default)
        {
            MongoCollectionSettings mongoCollectionSettings = default;

            if (settings != null)
            {
                mongoCollectionSettings = ((ICollectionSettingsNoSql)settings).MongoCollectionSettings;
            }

            return new CollectionNoSql<TDocument>(_database.GetCollection<TDocument>(name, mongoCollectionSettings));
        }

        #endregion

        #endregion
    }
}
