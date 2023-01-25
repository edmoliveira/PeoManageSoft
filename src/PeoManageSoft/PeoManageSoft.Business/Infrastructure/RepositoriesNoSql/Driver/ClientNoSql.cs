using MongoDB.Driver;
using PeoManageSoft.Business.Infrastructure.Helpers.Interfaces;

namespace PeoManageSoft.Business.Infrastructure.RepositoriesNoSql.Driver
{
    /// <summary>
    /// Cross-platform NoSQL document-oriented database client.
    /// </summary>
    internal sealed class ClientNoSql : IClientNoSql
    {
        #region Fields

        /// <summary>
        /// Cross-platform NoSQL document-oriented database client.
        /// </summary>
        public readonly MongoClient _client;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the PeoManageSoft.Business.Infrastructure.RepositoriesNoSql.Driver.ClientNoSql class.
        /// </summary>
        /// <param name="appConfig">Application Configuration</param>
        public ClientNoSql(IAppConfig appConfig)
        {
            _client = new MongoClient(appConfig.ConnectionStringNoSql);
        }

        #endregion

        #region Methods

        #region public

        /// <summary>
        /// Gets the database object.
        /// </summary>
        /// <param name="name">Database name</param>
        /// <param name="settings">Database settings</param>
        /// <returns>Returns the database object.</returns>
        public IDatabaseNoSql GetDatabase(string name, DatabaseSettingsNoSql settings = default)
        {
            MongoDatabaseSettings mongoDatabaseSettings = default;

            if (settings != null)
            {
                mongoDatabaseSettings = ((IDatabaseSettingsNoSql)settings).MongoDatabaseSettings;
            }

            return new DatabaseNoSql(_client.GetDatabase(name, mongoDatabaseSettings));
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {

        }

        #endregion

        #endregion
    }
}
