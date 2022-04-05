using Dapper;
using PeoManageSoft.Business.Infrastructure.Helpers.Interfaces;
using System.Data;
using static Dapper.SqlMapper;

namespace PeoManageSoft.Business.Infrastructure.ObjectRelationalMapper
{
    /// <summary>
    /// Represents a session with the underlying database using which you can perform CRUD (Create, Read, Update, Delete) operations.
    /// </summary>
    public sealed class DbContext : IDbContext
    {
        private readonly IAppConfig _appConfig;

        public DbContext(IAppConfig appConfig)
        {
            _appConfig = appConfig;
        }

        public int Execute<T>(IDbConnection connection, string sqlStatement, T entity, IDbTransaction transaction = null, CommandType? commandType = null)
        {
            return connection.Execute(sqlStatement, entity, transaction, _appConfig.SqlCommandTimeout, commandType);
        }

        public async Task<int> ExecuteAsync<T>(IDbConnection connection, string sqlStatement, T entity, IDbTransaction transaction = null, CommandType? commandType = null)
        {
            return await connection.ExecuteAsync(sqlStatement, entity, transaction, _appConfig.SqlCommandTimeout, commandType).ConfigureAwait(false);
        }

        public TReturn ExecuteScalar<T, TReturn>(IDbConnection connection, string sqlStatement, T entity, IDbTransaction transaction = null, CommandType? commandType = null)
        {
            return connection.ExecuteScalar<TReturn>(sqlStatement, entity, transaction, _appConfig.SqlCommandTimeout, commandType);
        }

        public async Task<TReturn> ExecuteScalarAsync<T, TReturn>(IDbConnection connection, string sqlStatement, T entity, IDbTransaction transaction = null, CommandType? commandType = null)
        {
            return await connection.ExecuteScalarAsync<TReturn>(sqlStatement, entity, transaction, _appConfig.SqlCommandTimeout, commandType).ConfigureAwait(false);
        }

        public TResult QueryFirstOrDefault<TResult, TId>(IDbConnection connection, string sqlStatement, TId id, IDbTransaction transaction = null, CommandType? commandType = null)
        {
            return connection.QueryFirstOrDefault<TResult>(sqlStatement, id, transaction, _appConfig.SqlCommandTimeout, commandType);
        }

        public async Task<TResult> QueryFirstOrDefaultAsync<TResult>(IDbConnection connection, string sqlStatement, object id, IDbTransaction transaction = null, CommandType? commandType = null)
        {
            return await connection.QueryFirstOrDefaultAsync<TResult>(sqlStatement, id, transaction, _appConfig.SqlCommandTimeout, commandType).ConfigureAwait(false);
        }

        public IEnumerable<TResult> Query<TResult>(IDbConnection connection, string sqlStatement, object parameters, IDbTransaction transaction = null, CommandType? commandType = null)
        {
            return connection.Query<TResult>(sqlStatement, parameters, transaction, true, _appConfig.SqlCommandTimeout, commandType);
        }

        public async Task<IEnumerable<TResult>> QueryAsync<TResult>(IDbConnection connection, string sqlStatement, object parameters, IDbTransaction transaction = null, CommandType? commandType = null)
        {
            return await connection.QueryAsync<TResult>(sqlStatement, parameters, transaction, _appConfig.SqlCommandTimeout, commandType).ConfigureAwait(false);
        }

        public void QueryMultiple(IDbConnection connection, string sqlStatement, object parameters, Action<GridReader> result, IDbTransaction transaction = null, CommandType? commandType = null)
        {
            using GridReader gridReader = connection.QueryMultiple(sqlStatement, parameters, transaction, _appConfig.SqlCommandTimeout, commandType);
            result(gridReader);
        }

        public async Task QueryMultipleAsync(IDbConnection connection, string sqlStatement, object parameters, Func<GridReader, Task> result, IDbTransaction transaction = null, CommandType? commandType = null)
        {
            using GridReader gridReader = connection.QueryMultiple(sqlStatement, parameters, transaction, _appConfig.SqlCommandTimeout, commandType);
            await result(gridReader).ConfigureAwait(false);
        }
    }
}
