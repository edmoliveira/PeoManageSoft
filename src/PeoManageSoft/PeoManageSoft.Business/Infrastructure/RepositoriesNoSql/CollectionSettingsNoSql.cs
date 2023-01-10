using MongoDB.Driver;

namespace PeoManageSoft.Business.Infrastructure.RepositoriesNoSql
{
    /// <summary>
    /// The settings used to access a database.
    /// </summary>
    internal sealed class CollectionSettingsNoSql : ICollectionSettingsNoSql
    {
        /// <summary>
        ///  The settings used to access a collection.
        /// </summary>
        MongoCollectionSettings ICollectionSettingsNoSql.MongoCollectionSettings => throw new NotImplementedException();

        public CollectionSettingsNoSql()
        {

        }


    }
}
