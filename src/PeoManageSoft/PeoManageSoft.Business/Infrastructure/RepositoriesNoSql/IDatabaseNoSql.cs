namespace PeoManageSoft.Business.Infrastructure.RepositoriesNoSql
{
    /// <summary>
    /// Cross-platform NoSQL database.
    /// </summary>
    internal interface IDatabaseNoSql
    {
        #region Methods

        /// <summary>
        /// Gets the collection object.
        /// </summary>
        /// <typeparam name="TDocument">The document type.</typeparam>
        /// <param name="name">Collection name</param>
        /// <param name="settings">Collection settings</param>
        /// <returns>Returns the collection object.</returns>
        ICollectionNoSql<TDocument> GetCollection<TDocument>(string name, CollectionSettingsNoSql settings = default);

        #endregion
    }
}
