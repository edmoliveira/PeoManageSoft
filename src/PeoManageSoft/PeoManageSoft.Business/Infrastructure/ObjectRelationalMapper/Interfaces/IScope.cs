using System.Data;

namespace PeoManageSoft.Business.Infrastructure.ObjectRelationalMapper.Interfaces
{
    /// <summary>
    /// Transactional scope
    /// </summary>
    public interface IScope
    {
        #region Methods

        /// <summary>
        /// Begins a database transaction.
        /// </summary>
        void BeginTransaction();

        #endregion
    }

    /// <summary>
    /// Transactional scope
    /// </summary>
    public interface IIScope : IScope
    {
        #region Properties

        /// <summary>
        /// Indicates the transaction status.
        /// </summary>
        TransactionStatus TransactionStatus { get; }

        #endregion

        #region Methods

        /// <summary>
        /// Commits the database transaction.
        /// </summary>
        void CommitTransaction();
        /// <summary>
        /// Rolls back a transaction from a pending state.
        /// </summary>
        void RollBackTransaction();

        #endregion
    }

    /// <summary>
    /// Transactional scope with the connection.
    /// </summary>
    public interface IContentScope : IScope
    {
        #region Properties

        /// <summary>
        /// Represents an open connection to a data source, and is implemented by .NET data providers that access relational databases.
        /// </summary>
        IDbConnection Connection { get; set; }
        /// <summary>
        /// Represents a transaction to be performed at a data source, and is implemented by .NET data providers that access relational databases.
        /// </summary>
        IDbTransaction DbTransaction { get; }

        #endregion
    }
}
