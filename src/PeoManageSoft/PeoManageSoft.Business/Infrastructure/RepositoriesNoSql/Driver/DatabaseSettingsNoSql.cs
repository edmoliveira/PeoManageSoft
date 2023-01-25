using MongoDB.Driver;

namespace PeoManageSoft.Business.Infrastructure.RepositoriesNoSql.Driver
{
    /// <summary>
    /// The settings used to access a database.
    /// </summary>
    internal sealed class DatabaseSettingsNoSql : IDatabaseSettingsNoSql
    {
        MongoDatabaseSettings IDatabaseSettingsNoSql.MongoDatabaseSettings => throw new NotImplementedException();

        public DatabaseSettingsNoSql()
        {

        }


    }
}
