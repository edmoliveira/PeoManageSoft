namespace PeoManageSoft.Business.Infrastructure.RepositoriesNoSql.Driver
{
    /// <summary>
    /// The document NoSql.
    /// </summary>
    internal interface IDocumentNoSql
    {
        #region Properties

        /// <summary>
        /// Document identifier
        /// </summary>
        string DocumentId { get; }
        /// <summary>
        /// Entity identifier
        /// </summary>
        Guid Id { get; }

        #endregion
    }
}
