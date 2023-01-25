namespace PeoManageSoft.Business.Infrastructure.RepositoriesNoSql.Driver
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
        /// <typeparam name="IDocumentNoSql">The document type.</typeparam>
        /// <param name="name">Collection name</param>
        /// <param name="settings">Collection settings</param>
        /// <returns>Returns the collection object.</returns>
        ICollectionNoSql<T> GetCollection<T>
            (string name, CollectionSettingsNoSql settings = default)
            where T : IDocumentNoSql;

        #endregion
    }
}
