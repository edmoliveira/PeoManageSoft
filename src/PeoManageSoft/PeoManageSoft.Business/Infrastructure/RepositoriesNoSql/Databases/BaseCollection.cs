using PeoManageSoft.Business.Infrastructure.RepositoriesNoSql.Driver;
using System.Linq.Expressions;

namespace PeoManageSoft.Business.Infrastructure.RepositoriesNoSql.Databases
{
    /// <summary>
    /// Cross-platform NoSQL collection base class.
    /// </summary>
    /// <typeparam name="TDocument">The type of the documents stored in the collection.</typeparam>
    internal abstract class BaseCollection<TDocument> : IBaseCollection<TDocument> where TDocument : IDocumentNoSql
    {
        #region Properties

        /// <summary>
        /// Cross-platform NoSQL collection.
        /// </summary>
        protected ICollectionNoSql<TDocument> Collection { get; private set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the PeoManageSoft.Business.Infrastructure.RepositoriesNoSql.Databases.BaseCollection class.
        /// </summary>
        /// <param name="collection">Cross-platform NoSQL collection.</param>
        public BaseCollection(ICollectionNoSql<TDocument> collection)
        {
            Collection = collection;
        }

        #endregion

        #region Methods

        #region public

        /// <summary>
        /// Find the documents matching the filter and asynchronously using Task.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <returns>
        /// Task: Represents an asynchronous operation. 
        /// Returns the list of documents.
        /// </returns>
        public async Task<IEnumerable<TDocument>> FindAsync(Expression<Func<TDocument, bool>> filter)
        {
            return await Collection.FindAsync(filter).ConfigureAwait(false);
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
            return await Collection.SelectAllAsync().ConfigureAwait(false);
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
            return await Collection.SelectByIdAsync(id).ConfigureAwait(false);
        }

        /// <summary>
        /// Inserts many documents and asynchronously using Task.
        /// </summary>
        /// <param name="documents">The documents.</param>
        /// <returns>Task: Represents an asynchronous operation.</returns>
        public async Task InsertManyAsync(IEnumerable<TDocument> documents)
        {
            await Collection.InsertManyAsync(documents).ConfigureAwait(false);
        }

        /// <summary>
        /// Inserts the document and asynchronously using Task.
        /// </summary>
        /// <param name="document">The document.</param>
        /// <returns>Task: Represents an asynchronous operation.</returns>
        public async Task InsertAsync(TDocument document)
        {
            await Collection.InsertAsync(document).ConfigureAwait(false);
        }

        /// <summary>
        /// Updates the document and asynchronously using Task.
        /// </summary>
        /// <param name="document">The document.</param>
        /// <returns>Task: Represents an asynchronous operation.</returns>
        public async Task UpdateAsync(TDocument document)
        {
            await Collection.UpdateAsync(document).ConfigureAwait(false);
        }

        /// <summary>
        /// Deletes the document and asynchronously using Task.
        /// </summary>
        /// <param name="id">Entity identifier</param>
        /// <returns>Task: Represents an asynchronous operation.</returns>
        public async Task DeleteAsync(Guid id)
        {
            await Collection.DeleteAsync(id).ConfigureAwait(false);
        }

        #endregion

        #endregion
    }
}
