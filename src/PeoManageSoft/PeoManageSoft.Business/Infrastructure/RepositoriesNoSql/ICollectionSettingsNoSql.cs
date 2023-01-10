using MongoDB.Driver;

namespace PeoManageSoft.Business.Infrastructure.RepositoriesNoSql
{
    /// <summary>
    /// The settings used to access a collection.
    /// </summary>
    internal interface ICollectionSettingsNoSql
    {
        #region Properties

        /// <summary>
        /// The settings used to access a collection.
        /// </summary>
        MongoCollectionSettings MongoCollectionSettings { get; }

        #endregion
    }
}
