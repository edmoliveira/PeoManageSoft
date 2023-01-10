using MongoDB.Driver;

namespace PeoManageSoft.Business.Infrastructure.RepositoriesNoSql
{
    /// <summary>
    /// Cross-platform NoSQL collection.
    /// </summary>
    /// <typeparam name="TDocument">The document type.</typeparam>
    internal sealed class CollectionNoSql<TDocument> : ICollectionNoSql<TDocument>
    {
        #region Fields

        /// <summary>
        /// Cross-platform NoSQL collection.
        /// </summary>
        private readonly IMongoCollection<TDocument> _collection;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the PeoManageSoft.Business.Infrastructure.RepositoriesNoSql.CollectionNoSql class.
        /// </summary>
        /// <param name="collection">Cross-platform NoSQL collection.</param>
        public CollectionNoSql(IMongoCollection<TDocument> collection)
        {
            _collection = collection;
        }

        #endregion

        #region Methods

        #region public

        #endregion

        #endregion
    }
}
