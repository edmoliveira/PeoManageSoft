using System.Data;
using static Dapper.SqlMapper;

namespace PeoManageSoft.Business.Infrastructure.ObjectRelationalMapper
{
    /// <summary>
    /// Represents a session with the underlying database using which you can perform CRUD (Create, Read, Update, Delete) operations.
    /// </summary>
    public interface IDbContext
    {
        int Execute<T>(IDbConnection connection, string sqlStatement, T entity, IDbTransaction transaction = null, CommandType? commandType = null);

        Task<int> ExecuteAsync<T>(IDbConnection connection, string sqlStatement, T entity, IDbTransaction transaction = null, CommandType? commandType = null);

        TReturn ExecuteScalar<T, TReturn>(IDbConnection connection, string sqlStatement, T entity, IDbTransaction transaction = null, CommandType? commandType = null);

        Task<TReturn> ExecuteScalarAsync<T, TReturn>(IDbConnection connection, string sqlStatement, T entity, IDbTransaction transaction = null, CommandType? commandType = null);

        TResult QueryFirstOrDefault<TResult, TId>(IDbConnection connection, string sqlStatement, TId id, IDbTransaction transaction = null, CommandType? commandType = null);

        Task<TResult> QueryFirstOrDefaultAsync<TResult>(IDbConnection connection, string sqlStatement, object id, IDbTransaction transaction = null, CommandType? commandType = null);

        IEnumerable<TResult> Query<TResult>(IDbConnection connection, string sqlStatement, object parameters, IDbTransaction transaction = null, CommandType? commandType = null);

        Task<IEnumerable<TResult>> QueryAsync<TResult>(IDbConnection connection, string sqlStatement, object parameters, IDbTransaction transaction = null, CommandType? commandType = null);

        void QueryMultiple(IDbConnection connection, string sqlStatement, object parameters, Action<GridReader> result, IDbTransaction transaction = null, CommandType? commandType = null);

        Task QueryMultipleAsync(IDbConnection connection, string sqlStatement, object parameters, Func<GridReader, Task> result, IDbTransaction transaction = null, CommandType? commandType = null);
    }
}
