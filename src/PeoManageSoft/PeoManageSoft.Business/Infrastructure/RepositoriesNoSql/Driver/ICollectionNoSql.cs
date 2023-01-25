namespace PeoManageSoft.Business.Infrastructure.RepositoriesNoSql.Driver
{
    /// <summary>
    /// Cross-platform NoSQL collection.
    /// </summary>
    /// <typeparam name="TDocument">The type of the documents stored in the collection.</typeparam>
    internal interface ICollectionNoSql<TDocument>
    {
        #region Methods

        /// <summary>
        /// Returns a list containing all the documents returned by the cursor returned by a cursor source.
        /// </summary>
        /// <returns>Returns the list of documents.</returns>
        IEnumerable<TDocument> SelectAll();
        /// <summary>
        /// Returns a list containing all the documents returned by the cursor returned by a cursor source and asynchronously using Task.
        /// </summary>
        /// <returns>
        /// Task: Represents an asynchronous operation. 
        /// Returns the list of documents.
        /// </returns>
        Task<IEnumerable<TDocument>> SelectAllAsync();
        /// <summary>
        /// Query the document by id.
        /// </summary>
        /// <param name="id">Entity identifier</param>
        /// <returns>Returns the document.</returns>
        TDocument SelectById(Guid id);
        /// <summary>
        /// Query the document by id and asynchronously using Task.
        /// </summary>
        /// <param name="id">Entity identifier</param>
        /// <returns>
        /// Task: Represents an asynchronous operation. 
        /// Returns the document.
        /// </returns>
        Task<TDocument> SelectByIdAsync(Guid id);
        /// <summary>
        /// Inserts many documents.
        /// </summary>
        /// <param name="document">The documents.</param>
        void InsertMany(IEnumerable<TDocument> documents);
        /// <summary>
        /// Inserts many documents and asynchronously using Task.
        /// </summary>
        /// <param name="documents">The documents.</param>
        /// <returns>Task: Represents an asynchronous operation.</returns>
        Task InsertManyAsync(IEnumerable<TDocument> documents);
        /// <summary>
        /// Inserts a single document.
        /// </summary>
        /// <param name="document">The document.</param>
        void Insert(TDocument document);
        /// <summary>
        /// Inserts a single document and asynchronously using Task.
        /// </summary>
        /// <param name="document">The document.</param>
        /// <returns>Task: Represents an asynchronous operation.</returns>
        Task InsertAsync(TDocument document);
        /// <summary>
        /// Updates a single document.
        /// </summary>
        /// <param name="document">The document.</param>
        void Update(TDocument document);
        /// <summary>
        /// Updates a single document and asynchronously using Task.
        /// </summary>
        /// <param name="document">The document.</param>
        /// <returns>Task: Represents an asynchronous operation.</returns>
        Task UpdateAsync(TDocument document);
        /// <summary>
        /// Deletes a single document.
        /// </summary>
        /// <param name="id">Entity identifier</param>
        void Delete(Guid id);
        /// <summary>
        /// Deletes a single document and asynchronously using Task.
        /// </summary>
        /// <param name="id">Entity identifier</param>
        /// <returns>Task: Represents an asynchronous operation.</returns>
        Task DeleteAsync(Guid id);

        #endregion
    }
}
