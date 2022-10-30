using Dapper;
using PeoManageSoft.Business.Infrastructure.Helpers.Interfaces;
using PeoManageSoft.Business.Infrastructure.ObjectRelationalMapper.Interfaces;
using System.Data;
using static Dapper.SqlMapper;

namespace PeoManageSoft.Business.Infrastructure.ObjectRelationalMapper
{
    /// <summary>
    /// Represents a session with the underlying database using which you can perform CRUD (Create, Read, Update, Delete) operations.
    /// </summary>
    internal sealed class DbContext : IDbContext
    {
        #region Fields

        /// <summary>
        /// Application Configuration
        /// </summary>
        private readonly IAppConfig _appConfig;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the PeoManageSoft.Business.Infrastructure.ObjectRelationalMapper.DbContext class.
        /// </summary>
        /// <param name="appConfig">Application Configuration</param>
        public DbContext(IAppConfig appConfig)
        {
            _appConfig = appConfig;
        }

        #endregion

        #region Methods 

        #region public

        /// <summary>
        /// Execute parameterized SQL.
        /// </summary>
        /// <param name="connection">The connection to query on.</param>
        /// <param name="sqlStatement">The SQL to execute for this query.</param>
        /// <param name="parameters">The parameters to pass, if any.</param>
        /// <param name="transaction">The transaction to use for this query.</param>
        /// <param name="commandType">Is it a stored proc or a batch?</param>
        /// <returns>The number of rows affected.</returns>
        public int Execute(IDbConnection connection, string sqlStatement, IEnumerable<IParameter> parameters, IDbTransaction transaction = null, CommandType? commandType = null)
        {
            return connection.Execute(sqlStatement, ConvertIParameterToDynamicParameters(parameters), transaction, _appConfig.SqlCommandTimeout, commandType);
        }

        /// <summary>
        /// Execute parameterized SQL and asynchronously using Task.
        /// </summary>
        /// <param name="connection">The connection to query on.</param>
        /// <param name="sqlStatement">The SQL to execute for this query.</param>
        /// <param name="parameters">The parameters to pass, if any.</param>
        /// <param name="transaction">The transaction to use for this query.</param>
        /// <param name="commandType">Is it a stored proc or a batch?</param>
        /// <returns>
        /// Task: Represents an asynchronous operation.
        /// The number of rows affected.
        /// </returns>
        public async Task<int> ExecuteAsync(IDbConnection connection, string sqlStatement, IEnumerable<IParameter> parameters, IDbTransaction transaction = null, CommandType? commandType = null)
        {
            return await connection.ExecuteAsync(sqlStatement, ConvertIParameterToDynamicParameters(parameters), transaction, _appConfig.SqlCommandTimeout, commandType).ConfigureAwait(false);
        }

        /// <summary>
        /// Execute parameterized SQL that selects a single value.
        /// </summary>
        /// <typeparam name="T">The type of the entity.</typeparam>
        /// <typeparam name="TReturn">The type of the return.</typeparam>
        /// <param name="connection">The connection to query on.</param>
        /// <param name="sqlStatement">The SQL to execute for this query.</param>
        /// <param name="parameters">The parameters to pass, if any.</param>
        /// <param name="transaction">The transaction to use for this query.</param>
        /// <param name="commandType">Is it a stored proc or a batch?</param>
        /// <returns>The first cell selected as TReturn.</returns>
        public TReturn ExecuteScalar<TReturn>(IDbConnection connection, string sqlStatement, IEnumerable<IParameter> parameters, IDbTransaction transaction = null, CommandType? commandType = null)
        {
            return connection.ExecuteScalar<TReturn>(sqlStatement, ConvertIParameterToDynamicParameters(parameters), transaction, _appConfig.SqlCommandTimeout, commandType);
        }

        /// <summary>
        /// Execute parameterized SQL that selects a single value and asynchronously using Task.
        /// </summary>
        /// <typeparam name="T">The type of the entity.</typeparam>
        /// <typeparam name="TReturn">The type of the return.</typeparam>
        /// <param name="connection">The connection to query on.</param>
        /// <param name="sqlStatement">The SQL to execute for this query.</param>
        /// <param name="parameters">The parameters to pass, if any.</param>
        /// <param name="transaction">The transaction to use for this query.</param>
        /// <param name="commandType">Is it a stored proc or a batch?</param>
        /// <returns>
        /// Task: Represents an asynchronous operation.
        /// The first cell selected as TReturn.
        /// </returns>
        public async Task<TReturn> ExecuteScalarAsync<TReturn>(IDbConnection connection, string sqlStatement, IEnumerable<IParameter> parameters, IDbTransaction transaction = null, CommandType? commandType = null)
        {
            return await connection.ExecuteScalarAsync<TReturn>(sqlStatement, ConvertIParameterToDynamicParameters(parameters), transaction, _appConfig.SqlCommandTimeout, commandType).ConfigureAwait(false);
        }

        /// <summary>
        /// Return a dynamic object with properties matching the columns.
        /// </summary>
        /// <typeparam name="TReturn">The type of the entity.</typeparam>
        /// <param name="connection">The connection to query on.</param>
        /// <param name="sqlStatement">The SQL to execute for this query.</param>
        /// <param name="parameters">The parameters to pass, if any.</param>
        /// <param name="transaction">The transaction to use for this query.</param>
        /// <param name="commandType">Is it a stored proc or a batch?</param>
        /// <returns>The first cell selected as TReturn.</returns>
        public TReturn QueryFirstOrDefault<TReturn>(IDbConnection connection, string sqlStatement, IEnumerable<IParameter> parameters, IDbTransaction transaction = null, CommandType? commandType = null)
        {
            return connection.QueryFirstOrDefault<TReturn>(sqlStatement, ConvertIParameterToDynamicParameters(parameters), transaction, _appConfig.SqlCommandTimeout, commandType);
        }

        /// <summary>
        /// Return a dynamic object with properties matching the columns and asynchronously using Task.
        /// </summary>
        /// <typeparam name="TReturn">The type of the entity.</typeparam>
        /// <param name="connection">The connection to query on.</param>
        /// <param name="sqlStatement">The SQL to execute for this query.</param>
        /// <param name="parameters">The parameters to pass, if any.</param>
        /// <param name="transaction">The transaction to use for this query.</param>
        /// <param name="commandType">Is it a stored proc or a batch?</param>
        /// <returns>
        /// Task: Represents an asynchronous operation.
        /// The first cell selected as TReturn.
        /// </returns>
        public async Task<TReturn> QueryFirstOrDefaultAsync<TReturn>(IDbConnection connection, string sqlStatement, IEnumerable<IParameter> parameters, IDbTransaction transaction = null, CommandType? commandType = null)
        {
            return await connection.QueryFirstOrDefaultAsync<TReturn>(sqlStatement, ConvertIParameterToDynamicParameters(parameters), transaction, _appConfig.SqlCommandTimeout, commandType).ConfigureAwait(false);
        }

        /// <summary>
        /// Executes a query, returning the data typed as TReturn.
        /// </summary>
        /// <typeparam name="TReturn">The type of the entity.</typeparam>
        /// <param name="connection">The connection to query on.</param>
        /// <param name="sqlStatement">The SQL to execute for this query.</param>
        /// <param name="parameters">The parameters to pass, if any.</param>
        /// <param name="transaction">The transaction to use for this query.</param>
        /// <param name="commandType">Is it a stored proc or a batch?</param>
        /// <returns>A sequence of data of the TReturn type</returns>
        public IEnumerable<TReturn> Query<TReturn>(IDbConnection connection, string sqlStatement, IEnumerable<IParameter> parameters, IDbTransaction transaction = null, CommandType? commandType = null)
        {
            return connection.Query<TReturn>(sqlStatement, ConvertIParameterToDynamicParameters(parameters), transaction, true, _appConfig.SqlCommandTimeout, commandType);
        }

        /// <summary>
        /// Executes a query, returning the data typed as TReturn and asynchronously using Task.
        /// </summary>
        /// <typeparam name="TReturn">The type of the entity.</typeparam>
        /// <param name="connection">The connection to query on.</param>
        /// <param name="sqlStatement">The SQL to execute for this query.</param>
        /// <param name="parameters">The parameters to pass, if any.</param>
        /// <param name="transaction">The transaction to use for this query.</param>
        /// <param name="commandType">Is it a stored proc or a batch?</param>
        /// <returns>
        /// Task: Represents an asynchronous operation.
        /// A sequence of data of the TReturn type.
        /// </returns>
        public async Task<IEnumerable<TReturn>> QueryAsync<TReturn>(IDbConnection connection, string sqlStatement, IEnumerable<IParameter> parameters, IDbTransaction transaction = null, CommandType? commandType = null)
        {
            return await connection.QueryAsync<TReturn>(sqlStatement, ConvertIParameterToDynamicParameters(parameters), transaction, _appConfig.SqlCommandTimeout, commandType).ConfigureAwait(false);
        }

        /// <summary>
        /// Execute parameterized SQL and return an <see cref="IDataReader"/>.
        /// </summary>
        /// <param name="action">An <see cref="IDataReader"/> that can be used to iterate over the results of the SQL query.</param>
        /// <param name="connection">The connection to query on.</param>
        /// <param name="sqlStatement">The SQL to execute for this query.</param>
        /// <param name="parameters">The parameters to pass, if any.</param>
        /// <param name="transaction">The transaction to use for this query.</param>
        /// <param name="commandType">Is it a stored proc or a batch?</param>
        public void ExecuteReader(Action<IDataReader> action, IDbConnection connection, string sqlStatement, IEnumerable<IParameter> parameters, IDbTransaction transaction = null, CommandType? commandType = null)
        {
            using var reader = connection.ExecuteReader(sqlStatement, ConvertIParameterToDynamicParameters(parameters), transaction, _appConfig.SqlCommandTimeout, commandType);

            while (reader.Read())
            {
                action(reader);
            }
        }

        /// <summary>
        /// Execute parameterized SQL and return an <see cref="IDataReader"/>  and asynchronously using Task.
        /// </summary>
        /// <param name="action">An <see cref="IDataReader"/> that can be used to iterate over the results of the SQL query.</param>
        /// <param name="connection">The connection to query on.</param>
        /// <param name="sqlStatement">The SQL to execute for this query.</param>
        /// <param name="parameters">The parameters to pass, if any.</param>
        /// <param name="transaction">The transaction to use for this query.</param>
        /// <param name="commandType">Is it a stored proc or a batch?</param>
        /// <returns>Represents an asynchronous operation.</returns>
        public async Task ExecuteReaderAsync(Action<IDataReader> action, IDbConnection connection, string sqlStatement, IEnumerable<IParameter> parameters, IDbTransaction transaction = null, CommandType? commandType = null)
        {
            using var reader = await connection.ExecuteReaderAsync(sqlStatement, ConvertIParameterToDynamicParameters(parameters), transaction, _appConfig.SqlCommandTimeout, commandType).ConfigureAwait(false);

            while (reader.Read())
            {
                action(reader);
            }
        }

        /// <summary>
        /// Perform a multi-mapping query with 2 input types.
        /// Executes a query, returning the data typed as TReturn.
        /// </summary>
        /// <typeparam name="TFirst">The first type in the recordset.</typeparam>
        /// <typeparam name="TSecond">The second type in the recordset.</typeparam>
        /// <typeparam name="TReturn">The combined type to return.</typeparam>
        /// <param name="connection">The connection to query on.</param>
        /// <param name="map">The function to map row types to the return type.</param>
        /// <param name="sqlStatement">The SQL to execute for this query.</param>
        /// <param name="parameters">The parameters to pass, if any.</param>
        /// <param name="splitOn">The field we should split and read the second object from (default: "Id").</param>
        /// <param name="transaction">The transaction to use for this query.</param>
        /// <param name="commandType">Is it a stored proc or a batch?</param>
        /// <returns>A sequence of data of the TReturn type</returns>
        public IEnumerable<TReturn> Query<TFirst, TSecond, TReturn>(IDbConnection connection, Func<TFirst, TSecond, TReturn> map, string sqlStatement, IEnumerable<IParameter> parameters, string splitOn, IDbTransaction transaction = null, CommandType? commandType = null)
        {
            return connection.Query(sqlStatement, map, ConvertIParameterToDynamicParameters(parameters), transaction, true, splitOn, _appConfig.SqlCommandTimeout, commandType);
        }

        /// <summary>
        /// Perform a multi-mapping query with 2 input types.
        /// Executes a query, returning the data typed as TReturn and asynchronously using Task.
        /// </summary>
        /// <typeparam name="TFirst">The first type in the recordset.</typeparam>
        /// <typeparam name="TSecond">The second type in the recordset.</typeparam>
        /// <typeparam name="TReturn">The combined type to return.</typeparam>
        /// <param name="connection">The connection to query on.</param>
        /// <param name="map">The function to map row types to the return type.</param>
        /// <param name="sqlStatement">The SQL to execute for this query.</param>
        /// <param name="parameters">The parameters to pass, if any.</param>
        /// <param name="splitOn">The field we should split and read the second object from (default: "Id").</param>
        /// <param name="transaction">The transaction to use for this query.</param>
        /// <param name="commandType">Is it a stored proc or a batch?</param>
        /// <returns>
        /// Task: Represents an asynchronous operation.
        /// A sequence of data of the TReturn type.
        /// </returns>
        public async Task<IEnumerable<TReturn>> QueryAsync<TFirst, TSecond, TReturn>(IDbConnection connection, Func<TFirst, TSecond, TReturn> map, string sqlStatement, IEnumerable<IParameter> parameters, string splitOn, IDbTransaction transaction = null, CommandType? commandType = null)
        {
            return await connection.QueryAsync(sqlStatement, map, ConvertIParameterToDynamicParameters(parameters), transaction, true, splitOn, _appConfig.SqlCommandTimeout, commandType);
        }

        /// <summary>
        /// Perform a multi-mapping query with 3 input types.
        /// Executes a query, returning the data typed as TReturn.
        /// </summary>
        /// <typeparam name="TFirst">The first type in the recordset.</typeparam>
        /// <typeparam name="TSecond">The second type in the recordset.</typeparam>
        /// <typeparam name="TThird">The third type in the recordset.</typeparam>
        /// <typeparam name="TReturn">The combined type to return.</typeparam>
        /// <param name="connection">The connection to query on.</param>
        /// <param name="map">The function to map row types to the return type.</param>
        /// <param name="sqlStatement">The SQL to execute for this query.</param>
        /// <param name="parameters">The parameters to pass, if any.</param>
        /// <param name="splitOn">The field we should split and read the second object from (default: "Id").</param>
        /// <param name="transaction">The transaction to use for this query.</param>
        /// <param name="commandType">Is it a stored proc or a batch?</param>
        /// <returns>A sequence of data of the TReturn type</returns>
        public IEnumerable<TReturn> Query<TFirst, TSecond, TThird, TReturn>(IDbConnection connection, Func<TFirst, TSecond, TThird, TReturn> map, string sqlStatement, IEnumerable<IParameter> parameters, string splitOn, IDbTransaction transaction = null, CommandType? commandType = null)
        {
            return connection.Query(sqlStatement, map, ConvertIParameterToDynamicParameters(parameters), transaction, true, splitOn, _appConfig.SqlCommandTimeout, commandType);
        }

        /// <summary>
        /// Perform a multi-mapping query with 3 input types.
        /// Executes a query, returning the data typed as TReturn and asynchronously using Task.
        /// </summary>
        /// <typeparam name="TFirst">The first type in the recordset.</typeparam>
        /// <typeparam name="TSecond">The second type in the recordset.</typeparam>
        /// <typeparam name="TThird">The third type in the recordset.</typeparam>
        /// <typeparam name="TReturn">The combined type to return.</typeparam>
        /// <param name="connection">The connection to query on.</param>
        /// <param name="map">The function to map row types to the return type.</param>
        /// <param name="sqlStatement">The SQL to execute for this query.</param>
        /// <param name="parameters">The parameters to pass, if any.</param>
        /// <param name="splitOn">The field we should split and read the second object from (default: "Id").</param>
        /// <param name="transaction">The transaction to use for this query.</param>
        /// <param name="commandType">Is it a stored proc or a batch?</param>
        /// <returns>A sequence of data of the TReturn type</returns>
        public async Task<IEnumerable<TReturn>> QueryAsync<TFirst, TSecond, TThird, TReturn>(IDbConnection connection, Func<TFirst, TSecond, TThird, TReturn> map, string sqlStatement, IEnumerable<IParameter> parameters, string splitOn, IDbTransaction transaction = null, CommandType? commandType = null)
        {
            return await connection.QueryAsync(sqlStatement, map, ConvertIParameterToDynamicParameters(parameters), transaction, true, splitOn, _appConfig.SqlCommandTimeout, commandType);
        }

        /// <summary>
        /// Perform a multi-mapping query with 4 input types.
        /// Executes a query, returning the data typed as TReturn.
        /// </summary>
        /// <typeparam name="TFirst">The first type in the recordset.</typeparam>
        /// <typeparam name="TSecond">The second type in the recordset.</typeparam>
        /// <typeparam name="TThird">The third type in the recordset.</typeparam>
		/// <typeparam name="TFourth">The fourth type in the recordset.</typeparam>
        /// <typeparam name="TReturn">The combined type to return.</typeparam>
        /// <param name="connection">The connection to query on.</param>
        /// <param name="map">The function to map row types to the return type.</param>
        /// <param name="sqlStatement">The SQL to execute for this query.</param>
        /// <param name="parameters">The parameters to pass, if any.</param>
        /// <param name="splitOn">The field we should split and read the second object from (default: "Id").</param>
        /// <param name="transaction">The transaction to use for this query.</param>
        /// <param name="commandType">Is it a stored proc or a batch?</param>
        /// <returns>A sequence of data of the TReturn type</returns>
        public IEnumerable<TReturn> Query<TFirst, TSecond, TThird, TFourth, TReturn>(IDbConnection connection, Func<TFirst, TSecond, TThird, TFourth, TReturn> map, string sqlStatement, IEnumerable<IParameter> parameters, string splitOn, IDbTransaction transaction = null, CommandType? commandType = null)
        {
            return connection.Query(sqlStatement, map, ConvertIParameterToDynamicParameters(parameters), transaction, true, splitOn, _appConfig.SqlCommandTimeout, commandType);
        }

        /// <summary>
        /// Perform a multi-mapping query with 4 input types.
        /// Executes a query, returning the data typed as TReturn and asynchronously using Task.
        /// </summary>
        /// <typeparam name="TFirst">The first type in the recordset.</typeparam>
        /// <typeparam name="TSecond">The second type in the recordset.</typeparam>
        /// <typeparam name="TThird">The third type in the recordset.</typeparam>
		/// <typeparam name="TFourth">The fourth type in the recordset.</typeparam>
        /// <typeparam name="TReturn">The combined type to return.</typeparam>
        /// <param name="connection">The connection to query on.</param>
        /// <param name="map">The function to map row types to the return type.</param>
        /// <param name="sqlStatement">The SQL to execute for this query.</param>
        /// <param name="parameters">The parameters to pass, if any.</param>
        /// <param name="splitOn">The field we should split and read the second object from (default: "Id").</param>
        /// <param name="transaction">The transaction to use for this query.</param>
        /// <param name="commandType">Is it a stored proc or a batch?</param>
        /// <returns>A sequence of data of the TReturn type</returns>
        public async Task<IEnumerable<TReturn>> QueryAsync<TFirst, TSecond, TThird, TFourth, TReturn>(IDbConnection connection, Func<TFirst, TSecond, TThird, TFourth, TReturn> map, string sqlStatement, IEnumerable<IParameter> parameters, string splitOn, IDbTransaction transaction = null, CommandType? commandType = null)
        {
            return await connection.QueryAsync(sqlStatement, map, ConvertIParameterToDynamicParameters(parameters), transaction, true, splitOn, _appConfig.SqlCommandTimeout, commandType);
        }

        /// <summary>
        /// Perform a multi-mapping query with 5 input types.
        /// Executes a query, returning the data typed as TReturn.
        /// </summary>
        /// <typeparam name="TFirst">The first type in the recordset.</typeparam>
        /// <typeparam name="TSecond">The second type in the recordset.</typeparam>
        /// <typeparam name="TThird">The third type in the recordset.</typeparam>
        /// <typeparam name="TFourth">The fourth type in the recordset.</typeparam>
        /// <typeparam name="TFifth">The fifth type in the recordset.</typeparam>
        /// <typeparam name="TReturn">The combined type to return.</typeparam>
        /// <param name="connection">The connection to query on.</param>
        /// <param name="map">The function to map row types to the return type.</param>
        /// <param name="sqlStatement">The SQL to execute for this query.</param>
        /// <param name="parameters">The parameters to pass, if any.</param>
        /// <param name="splitOn">The field we should split and read the second object from (default: "Id").</param>
        /// <param name="transaction">The transaction to use for this query.</param>
        /// <param name="commandType">Is it a stored proc or a batch?</param>
        /// <returns>A sequence of data of the TReturn type</returns>
        public IEnumerable<TReturn> Query<TFirst, TSecond, TThird, TFourth, TFifth, TReturn>(IDbConnection connection, Func<TFirst, TSecond, TThird, TFourth, TFifth, TReturn> map, string sqlStatement, IEnumerable<IParameter> parameters, string splitOn, IDbTransaction transaction = null, CommandType? commandType = null)
        {
            return connection.Query(sqlStatement, map, ConvertIParameterToDynamicParameters(parameters), transaction, true, splitOn, _appConfig.SqlCommandTimeout, commandType);
        }

        /// <summary>
        /// Perform a multi-mapping query with 5 input types.
        /// Executes a query, returning the data typed as TReturn and asynchronously using Task.
        /// </summary>
        /// <typeparam name="TFirst">The first type in the recordset.</typeparam>
        /// <typeparam name="TSecond">The second type in the recordset.</typeparam>
        /// <typeparam name="TThird">The third type in the recordset.</typeparam>
		/// <typeparam name="TFourth">The fourth type in the recordset.</typeparam>
		/// <typeparam name="TFifth">The fifth type in the recordset.</typeparam>
        /// <typeparam name="TReturn">The combined type to return.</typeparam>
        /// <param name="connection">The connection to query on.</param>
        /// <param name="map">The function to map row types to the return type.</param>
        /// <param name="sqlStatement">The SQL to execute for this query.</param>
        /// <param name="parameters">The parameters to pass, if any.</param>
        /// <param name="splitOn">The field we should split and read the second object from (default: "Id").</param>
        /// <param name="transaction">The transaction to use for this query.</param>
        /// <param name="commandType">Is it a stored proc or a batch?</param>
        /// <returns>A sequence of data of the TReturn type</returns>
        public async Task<IEnumerable<TReturn>> QueryAsync<TFirst, TSecond, TThird, TFourth, TFifth, TReturn>(IDbConnection connection, Func<TFirst, TSecond, TThird, TFourth, TFifth, TReturn> map, string sqlStatement, IEnumerable<IParameter> parameters, string splitOn, IDbTransaction transaction = null, CommandType? commandType = null)
        {
            return await connection.QueryAsync(sqlStatement, map, ConvertIParameterToDynamicParameters(parameters), transaction, true, splitOn, _appConfig.SqlCommandTimeout, commandType);
        }

        /// <summary>
        /// Perform a multi-mapping query with 6 input types.
        /// Executes a query, returning the data typed as TReturn.
        /// </summary>
        /// <typeparam name="TFirst">The first type in the recordset.</typeparam>
        /// <typeparam name="TSecond">The second type in the recordset.</typeparam>
        /// <typeparam name="TThird">The third type in the recordset.</typeparam>
        /// <typeparam name="TFourth">The fourth type in the recordset.</typeparam>
        /// <typeparam name="TFifth">The fifth type in the recordset.</typeparam>
        /// <typeparam name="TSixth">The sixth type in the recordset.</typeparam>
        /// <typeparam name="TReturn">The combined type to return.</typeparam>
        /// <param name="connection">The connection to query on.</param>
        /// <param name="map">The function to map row types to the return type.</param>
        /// <param name="sqlStatement">The SQL to execute for this query.</param>
        /// <param name="parameters">The parameters to pass, if any.</param>
        /// <param name="splitOn">The field we should split and read the second object from (default: "Id").</param>
        /// <param name="transaction">The transaction to use for this query.</param>
        /// <param name="commandType">Is it a stored proc or a batch?</param>
        /// <returns>A sequence of data of the TReturn type</returns>
        public IEnumerable<TReturn> Query<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TReturn>(IDbConnection connection, Func<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TReturn> map, string sqlStatement, IEnumerable<IParameter> parameters, string splitOn, IDbTransaction transaction = null, CommandType? commandType = null)
        {
            return connection.Query(sqlStatement, map, ConvertIParameterToDynamicParameters(parameters), transaction, true, splitOn, _appConfig.SqlCommandTimeout, commandType);
        }

        /// <summary>
        /// Perform a multi-mapping query with 6 input types.
        /// Executes a query, returning the data typed as TReturn and asynchronously using Task.
        /// </summary>
        /// <typeparam name="TFirst">The first type in the recordset.</typeparam>
        /// <typeparam name="TSecond">The second type in the recordset.</typeparam>
        /// <typeparam name="TThird">The third type in the recordset.</typeparam>
		/// <typeparam name="TFourth">The fourth type in the recordset.</typeparam>
		/// <typeparam name="TFifth">The fifth type in the recordset.</typeparam>
		/// <typeparam name="TSixth">The sixth type in the recordset.</typeparam>
        /// <typeparam name="TReturn">The combined type to return.</typeparam>
        /// <param name="connection">The connection to query on.</param>
        /// <param name="map">The function to map row types to the return type.</param>
        /// <param name="sqlStatement">The SQL to execute for this query.</param>
        /// <param name="parameters">The parameters to pass, if any.</param>
        /// <param name="splitOn">The field we should split and read the second object from (default: "Id").</param>
        /// <param name="transaction">The transaction to use for this query.</param>
        /// <param name="commandType">Is it a stored proc or a batch?</param>
        /// <returns>A sequence of data of the TReturn type</returns>
        public async Task<IEnumerable<TReturn>> QueryAsync<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TReturn>(IDbConnection connection, Func<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TReturn> map, string sqlStatement, IEnumerable<IParameter> parameters, string splitOn, IDbTransaction transaction = null, CommandType? commandType = null)
        {
            return await connection.QueryAsync(sqlStatement, map, ConvertIParameterToDynamicParameters(parameters), transaction, true, splitOn, _appConfig.SqlCommandTimeout, commandType);
        }

        /// <summary>
        /// Perform a multi-mapping query with 7 input types.
        /// Executes a query, returning the data typed as TReturn.
        /// </summary>
        /// <typeparam name="TFirst">The first type in the recordset.</typeparam>
        /// <typeparam name="TSecond">The second type in the recordset.</typeparam>
        /// <typeparam name="TThird">The third type in the recordset.</typeparam>
        /// <typeparam name="TFourth">The fourth type in the recordset.</typeparam>
        /// <typeparam name="TFifth">The fifth type in the recordset.</typeparam>
        /// <typeparam name="TSixth">The sixth type in the recordset.</typeparam>
        /// <typeparam name="TSeventh">The seventh type in the recordset.</typeparam>
        /// <typeparam name="TReturn">The combined type to return.</typeparam>
        /// <param name="connection">The connection to query on.</param>
        /// <param name="map">The function to map row types to the return type.</param>
        /// <param name="sqlStatement">The SQL to execute for this query.</param>
        /// <param name="parameters">The parameters to pass, if any.</param>
        /// <param name="splitOn">The field we should split and read the second object from (default: "Id").</param>
        /// <param name="transaction">The transaction to use for this query.</param>
        /// <param name="commandType">Is it a stored proc or a batch?</param>
        /// <returns>A sequence of data of the TReturn type</returns>
        public IEnumerable<TReturn> Query<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TReturn>(IDbConnection connection, Func<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TReturn> map, string sqlStatement, IEnumerable<IParameter> parameters, string splitOn, IDbTransaction transaction = null, CommandType? commandType = null)
        {
            return connection.Query(sqlStatement, map, ConvertIParameterToDynamicParameters(parameters), transaction, true, splitOn, _appConfig.SqlCommandTimeout, commandType);
        }

        /// <summary>
        /// Perform a multi-mapping query with 7 input types.
        /// Executes a query, returning the data typed as TReturn and asynchronously using Task.
        /// </summary>
        /// <typeparam name="TFirst">The first type in the recordset.</typeparam>
        /// <typeparam name="TSecond">The second type in the recordset.</typeparam>
        /// <typeparam name="TThird">The third type in the recordset.</typeparam>
		/// <typeparam name="TFourth">The fourth type in the recordset.</typeparam>
		/// <typeparam name="TFifth">The fifth type in the recordset.</typeparam>
		/// <typeparam name="TSixth">The sixth type in the recordset.</typeparam>
		/// <typeparam name="TSeventh">The seventh type in the recordset.</typeparam>
        /// <typeparam name="TReturn">The combined type to return.</typeparam>
        /// <param name="connection">The connection to query on.</param>
        /// <param name="map">The function to map row types to the return type.</param>
        /// <param name="sqlStatement">The SQL to execute for this query.</param>
        /// <param name="parameters">The parameters to pass, if any.</param>
        /// <param name="splitOn">The field we should split and read the second object from (default: "Id").</param>
        /// <param name="transaction">The transaction to use for this query.</param>
        /// <param name="commandType">Is it a stored proc or a batch?</param>
        /// <returns>A sequence of data of the TReturn type</returns>
        public async Task<IEnumerable<TReturn>> QueryAsync<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TReturn>(IDbConnection connection, Func<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TReturn> map, string sqlStatement, IEnumerable<IParameter> parameters, string splitOn, IDbTransaction transaction = null, CommandType? commandType = null)
        {
            return await connection.QueryAsync(sqlStatement, map, ConvertIParameterToDynamicParameters(parameters), transaction, true, splitOn, _appConfig.SqlCommandTimeout, commandType);
        }

        /// <summary>
        /// Execute a command that returns multiple result sets, and access each in turn.
        /// </summary>
        /// <param name="connection">The connection to query on.</param>
        /// <param name="sqlStatement">The SQL to execute for this query.</param>
        /// <param name="parameters">The parameters to pass, if any.</param>
        /// <param name="result">
        /// Encapsulates a method that has a single parameter and does not return a value.
        /// Parameter: The parameter of the method that this delegate encapsulates.
        /// GridReader: The grid reader provides interfaces for reading multiple result sets from a Dapper query
        /// </param>
        /// <param name="transaction">The transaction to use for this query.</param>
        /// <param name="commandType">Is it a stored proc or a batch?</param>
        public void QueryMultiple(IDbConnection connection, string sqlStatement, IEnumerable<IParameter> parameters, Action<GridReader> result, IDbTransaction transaction = null, CommandType? commandType = null)
        {
            using GridReader gridReader = connection.QueryMultiple(sqlStatement, ConvertIParameterToDynamicParameters(parameters), transaction, _appConfig.SqlCommandTimeout, commandType);
            result(gridReader);
        }

        /// <summary>
        /// Execute a command that returns multiple result sets, and access each in turn and asynchronously using Task.
        /// </summary>
        /// <param name="connection">The connection to query on.</param>
        /// <param name="sqlStatement">The SQL to execute for this query.</param>
        /// <param name="parameters">The parameters to pass, if any.</param>
        /// <param name="result">
        /// Encapsulates a method that has one parameter and returns a value of the type specified by the TReturn parameter.
        /// Parameter: The parameter of the method that this delegate encapsulates.
        /// GridReader: The grid reader provides interfaces for reading multiple result sets from a Dapper query
        /// TReturn: Represents an asynchronous operation.
        /// </param>
        /// <param name="transaction">The transaction to use for this query.</param>
        /// <param name="commandType">Is it a stored proc or a batch?</param>
        /// <returns>Represents an asynchronous operation.</returns>
        public async Task QueryMultipleAsync(IDbConnection connection, string sqlStatement, IEnumerable<IParameter> parameters, Func<GridReader, Task> result, IDbTransaction transaction = null, CommandType? commandType = null)
        {
            using GridReader gridReader = connection.QueryMultiple(sqlStatement, ConvertIParameterToDynamicParameters(parameters), transaction, _appConfig.SqlCommandTimeout, commandType);
            await result(gridReader).ConfigureAwait(false);
        }

        #endregion

        #region private

        /// <summary>
        /// Converts the parameter object list to a DynamicParameters object.
        /// </summary>
        /// <param name="parameters">Parameter list to a command object.</param>
        /// <returns>Returns a bag of parameters that can be passed to the Dapper Query and Execute methods</returns>
        private static DynamicParameters ConvertIParameterToDynamicParameters(IEnumerable<IParameter> parameters)
        {
            if (parameters is null) { return null; }

            var dynamicParameters = new DynamicParameters();

            foreach (var parameter in parameters)
            {
                dynamicParameters.Add(parameter.ParameterName, parameter.Value);
            }

            return dynamicParameters;
        }

        #endregion

        #endregion
    }
}
