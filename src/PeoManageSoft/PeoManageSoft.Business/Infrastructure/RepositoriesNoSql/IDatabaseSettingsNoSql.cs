using MongoDB.Driver;

namespace PeoManageSoft.Business.Infrastructure.RepositoriesNoSql
{
    /// <summary>
    /// The settings used to access a database.
    /// </summary>
    internal interface IDatabaseSettingsNoSql
    {
        #region Properties

        /// <summary>
        /// The settings used to access a database.
        /// </summary>
        MongoDatabaseSettings MongoDatabaseSettings { get; }

        #endregion
    }
}
