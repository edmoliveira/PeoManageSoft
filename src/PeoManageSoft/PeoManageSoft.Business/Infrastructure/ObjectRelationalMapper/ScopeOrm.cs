using System.Data;

namespace PeoManageSoft.Business.Infrastructure.ObjectRelationalMapper
{
    /// <summary>
    /// Transactional scope
    /// </summary>
    public sealed class ScopeOrm : IContentScope, IIScope
    {
        #region Properties

        /// <summary>
        /// Represents an open connection to a data source, and is implemented by .NET data providers that access relational databases.
        /// </summary>
        public IDbConnection Connection { get; set; }
        /// <summary>
        /// Represents a transaction to be performed at a data source, and is implemented by .NET data providers that access relational databases.
        /// </summary>
        public IDbTransaction DbTransaction { get; private set; }
        /// <summary>
        /// Indicates the transaction status.
        /// </summary>
        public TransactionStatus TransactionStatus { get; private set; } = TransactionStatus.None;

        #endregion

        #region Methods

        #region public

        /// <summary>
        /// Begins a database transaction.
        /// </summary>
        public void BeginTransaction()
        {
            DbTransaction = this.Connection.BeginTransaction();

            this.TransactionStatus = TransactionStatus.Initialized;
        }

        /// <summary>
        /// Commits the database transaction.
        /// </summary>
        public void CommitTransaction()
        {
            if (DbTransaction != null)
            {
                DbTransaction.Commit();
                this.TransactionStatus = TransactionStatus.Committed;
            }
        }

        /// <summary>
        /// Rolls back a transaction from a pending state.
        /// </summary>
        public void RollBackTransaction()
        {
            if (DbTransaction != null)
            {
                DbTransaction.Rollback();
                this.TransactionStatus = TransactionStatus.RolledBack;
            }
        }

        #endregion

        #endregion
    }
}
