using System.Data;

namespace PeoManageSoft.Business.Infrastructure.ObjectRelationalMapper
{
    /// <summary>
    /// Transactional scope
    /// </summary>
    public interface IScope
    {
        void BeginTransaction();
        void CommitTransaction();
        void RollBackTransaction();
    }

    /// <summary>
    /// Transactional scope with the connection.
    /// </summary>
    public interface IContentScope : IScope
    {
        IDbConnection Connection { get; set; }
        IDbTransaction DbTransaction { get; }
    }
}
