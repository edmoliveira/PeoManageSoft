namespace PeoManageSoft.Business.Infrastructure.RepositoriesNoSql.Driver
{
    /// <summary>
    /// Cross-platform NoSQL document-oriented database client.
    /// </summary>
    internal interface IClientNoSql : IDisposable
    {
        #region Methods

        /// <summary>
        /// Gets the database object.
        /// </summary>
        /// <param name="name">Database name</param>
        /// <param name="settings">Database settings</param>
        IDatabaseNoSql GetDatabase(string name, DatabaseSettingsNoSql settings = default);

        #endregion
    }
}
