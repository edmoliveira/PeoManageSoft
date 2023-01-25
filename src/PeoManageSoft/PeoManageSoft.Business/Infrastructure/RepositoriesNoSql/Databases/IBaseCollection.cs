using PeoManageSoft.Business.Infrastructure.RepositoriesNoSql.Driver;

namespace PeoManageSoft.Business.Infrastructure.RepositoriesNoSql.Databases
{
    /// <summary>
    /// Cross-platform NoSQL collection base class.
    /// </summary>
    internal interface IBaseCollection<TDocument> where TDocument : IDocumentNoSql
    {
        #region Methods

        /// <summary>
        /// Returns a list containing all the documents returned by the cursor returned by a cursor source and asynchronously using Task.
        /// </summary>
        /// <returns>
        /// Task: Represents an asynchronous operation. 
        /// Returns the list of documents.
        /// </returns>
        Task<IEnumerable<TDocument>> SelectAllAsync();
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
        /// Inserts many documents and asynchronously using Task.
        /// </summary>
        /// <param name="documents">The documents.</param>
        /// <returns>Task: Represents an asynchronous operation.</returns>
        Task InsertManyAsync(IEnumerable<TDocument> documents);
        /// <summary>
        /// Inserts the document and asynchronously using Task.
        /// </summary>
        /// <param name="document">The document.</param>
        /// <returns>Task: Represents an asynchronous operation.</returns>
        Task InsertAsync(TDocument document);
        /// <summary>
        /// Updates the document and asynchronously using Task.
        /// </summary>
        /// <param name="document">The document.</param>
        /// <returns>Task: Represents an asynchronous operation.</returns>
        Task UpdateAsync(TDocument document);
        /// <summary>
        /// Deletes the document and asynchronously using Task.
        /// </summary>
        /// <param name="id">Entity identifier</param>
        /// <returns>Task: Represents an asynchronous operation.</returns>
        Task DeleteAsync(Guid id);

        #endregion
    }
}
