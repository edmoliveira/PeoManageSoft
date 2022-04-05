using MySql.Data.MySqlClient;
using Npgsql;
using PeoManageSoft.Business.Infrastructure.Helpers.Interfaces;
using System.Data.Common;
using System.Data.SqlClient;

namespace PeoManageSoft.Business.Infrastructure.ObjectRelationalMapper
{
    /// <summary>
    /// Represents a connection to a database.
    /// </summary>
    public sealed class Connection : IConnection
    {
        #region Fields private

        /// <summary>
        /// Application Configuration
        /// </summary>
        private readonly IAppConfig _appConfig;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the PeoManageSoft.Business.Infrastructure.ObjectRelationalMapper.Connection class.
        /// </summary>
        /// <param name="appConfig">Application Configuration</param>
        public Connection(IAppConfig appConfig)
        {
            _appConfig = appConfig;
        }

        #endregion

        #region Methods

        #region public

        /// <summary>
        /// Creates a connection to a database.
        /// </summary>
        /// <returns>Defines the core behavior of database connections and provides a base class for database-specific connections.</returns>
        public DbConnection CreateConnection()
        {
            return _appConfig.DatabaseType switch
            {
                DatabaseType.SqlServer => new SqlConnection(_appConfig.ConnectionString),
                DatabaseType.PostgreSQL => new NpgsqlConnection(_appConfig.ConnectionString),
                _ => new MySqlConnection(_appConfig.ConnectionString)
            };
        }

        #endregion

        #endregion
    }
}
