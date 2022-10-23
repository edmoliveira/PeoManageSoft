using System.Data.Common;

namespace PeoManageSoft.Business.Infrastructure.ObjectRelationalMapper.Interfaces
{
    /// <summary>
    /// Represents a connection to a database.
    /// </summary>
    public interface IConnection
    {
        #region Methods

        /// <summary>
        /// Creates a connection to a database.
        /// </summary>
        /// <returns>Defines the core behavior of database connections and provides a base class for database-specific connections.</returns>
        DbConnection CreateConnection();

        #endregion
    }
}
