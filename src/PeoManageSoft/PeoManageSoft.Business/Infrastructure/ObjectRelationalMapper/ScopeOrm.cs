using System.Data;

namespace PeoManageSoft.Business.Infrastructure.ObjectRelationalMapper
{
    /// <summary>
    /// Transactional scope
    /// </summary>
    public sealed class ScopeOrm : IContentScope
    {
        public IDbConnection Connection { get; set; }

        public IDbTransaction DbTransaction { get; private set; }

        public void BeginTransaction()
        {
            DbTransaction = this.Connection.BeginTransaction();
        }

        public void CommitTransaction()
        {
            if (DbTransaction != null)
            {
                DbTransaction.Commit();
            }
        }

        public void RollBackTransaction()
        {
            if (DbTransaction != null)
            {
                DbTransaction.Rollback();
            }
        }
    }
}
