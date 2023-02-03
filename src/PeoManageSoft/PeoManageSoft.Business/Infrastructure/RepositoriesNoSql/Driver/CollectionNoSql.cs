using MongoDB.Driver;

namespace PeoManageSoft.Business.Infrastructure.RepositoriesNoSql.Driver
{
    /// <summary>
    /// Cross-platform NoSQL collection.
    /// </summary>
    /// <typeparam name="TDocument">The type of the documents stored in the collection.</typeparam>
    internal sealed class CollectionNoSql<TDocument> : ICollectionNoSql<TDocument> where TDocument : IDocumentNoSql
    {
        #region Fields

        /// <summary>
        /// Cross-platform NoSQL collection.
        /// </summary>
        private readonly IMongoCollection<TDocument> _collection;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the PeoManageSoft.Business.Infrastructure.RepositoriesNoSql.Driver.CollectionNoSql class.
        /// </summary>
        /// <param name="collection">Cross-platform NoSQL collection.</param>
        public CollectionNoSql(IMongoCollection<TDocument> collection)
        {
            _collection = collection;
        }

        #endregion

        #region Methods

        #region public

        /// <summary>
        /// Returns a list containing all the documents returned by the cursor returned by a cursor source.
        /// </summary>
        /// <returns>Returns the list of documents.</returns>
        public IEnumerable<TDocument> SelectAll()
        {
            return _collection.Find(_ => true).ToList();
        }

        /// <summary>
        /// Returns a list containing all the documents returned by the cursor returned by a cursor source and asynchronously using Task.
        /// </summary>
        /// <returns>
        /// Task: Represents an asynchronous operation. 
        /// Returns the list of documents.
        /// </returns>
        public async Task<IEnumerable<TDocument>> SelectAllAsync()
        {
            return (await _collection.FindAsync(_ => true).ConfigureAwait(false)).ToList();
        }

        /// <summary>
        /// Query the document by id.
        /// </summary>
        /// <param name="id">Entity identifier</param>
        /// <returns>Returns the document.</returns>
        public TDocument SelectById(Guid id)
        {
            return _collection.Find(d => d.Id == id).FirstOrDefault();
        }

        /// <summary>
        /// Query the document by id and asynchronously using Task.
        /// </summary>
        /// <param name="id">Entity identifier</param>
        /// <returns>
        /// Task: Represents an asynchronous operation. 
        /// Returns the document.
        /// </returns>
        public async Task<TDocument> SelectByIdAsync(Guid id)
        {
            return (await _collection.FindAsync(d => d.Id == id).ConfigureAwait(false)).FirstOrDefault();
        }

        /// <summary>
        /// Inserts many documents.
        /// </summary>
        /// <param name="document">The documents.</param>
        public void InsertMany(IEnumerable<TDocument> documents)
        {
            _collection.InsertMany(documents);
        }

        /// <summary>
        /// Inserts many documents and asynchronously using Task.
        /// </summary>
        /// <param name="documents">The documents.</param>
        /// <returns>Task: Represents an asynchronous operation.</returns>
        public async Task InsertManyAsync(IEnumerable<TDocument> documents)
        {
            await _collection.InsertManyAsync(documents).ConfigureAwait(false);
        }

        /// <summary>
        /// Inserts a single document.
        /// </summary>
        /// <param name="document">The document.</param>
        public void Insert(TDocument document)
        {
            _collection.InsertOne(document);
        }

        /// <summary>
        /// Inserts a single document and asynchronously using Task.
        /// </summary>
        /// <param name="document">The document.</param>
        /// <returns>Task: Represents an asynchronous operation.</returns>
        public async Task InsertAsync(TDocument document)
        {
            await _collection.InsertOneAsync(document).ConfigureAwait(false);
        }

        /// <summary>
        /// Updates a single document.
        /// </summary>
        /// <param name="document">The document.</param>
        public void Update(TDocument document)
        {
            var filter = Builders<TDocument>.Filter.Eq("GuidId", document.Id.ToString());

            _ = _collection.ReplaceOneAsync(filter, document);
        }

        /// <summary>
        /// Updates a single document and asynchronously using Task.
        /// </summary>
        /// <param name="document">The document.</param>
        /// <returns>Task: Represents an asynchronous operation.</returns>
        public async Task UpdateAsync(TDocument document)
        {
            var filter = Builders<TDocument>.Filter.Eq("GuidId", document.Id.ToString());

            _ = await _collection.ReplaceOneAsync(filter, document).ConfigureAwait(false);
        }

        /// <summary>
        /// Deletes a single document.
        /// </summary>
        /// <param name="id">Entity identifier</param>
        public void Delete(Guid id)
        {
            var filter = Builders<TDocument>.Filter.Eq("GuidId", id.ToString());

            _ = _collection.DeleteOne(filter);
        }

        /// <summary>
        /// Deletes a single document and asynchronously using Task.
        /// </summary>
        /// <param name="id">Entity identifier</param>
        /// <returns>Task: Represents an asynchronous operation.</returns>
        public async Task DeleteAsync(Guid id)
        {
            var filter = Builders<TDocument>.Filter.Eq("GuidId", id.ToString());

            _ = await _collection.DeleteOneAsync(filter).ConfigureAwait(false);
        }

        #endregion

        #endregion
    }
}
