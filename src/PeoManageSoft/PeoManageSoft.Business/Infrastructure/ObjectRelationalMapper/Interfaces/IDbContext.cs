using System.Data;
using static Dapper.SqlMapper;

namespace PeoManageSoft.Business.Infrastructure.ObjectRelationalMapper.Interfaces
{
    /// <summary>
    /// Represents a session with the underlying database using which you can perform CRUD (Create, Read, Update, Delete) operations.
    /// </summary>
    public interface IDbContext
    {
        #region Methods

        /// <summary>
        /// Execute parameterized SQL.
        /// </summary>
        /// <typeparam name="T">The type of the entity.</typeparam>
        /// <param name="connection">The connection to query on.</param>
        /// <param name="sqlStatement">The SQL to execute for this query.</param>
        /// <param name="entity">The entity to use for this query.</param>
        /// <param name="transaction">The transaction to use for this query.</param>
        /// <param name="commandType">Is it a stored proc or a batch?</param>
        /// <returns>The number of rows affected.</returns>
        int Execute<T>(IDbConnection connection, string sqlStatement, T entity, IDbTransaction transaction = null, CommandType? commandType = null);

        /// <summary>
        /// Execute parameterized SQL and asynchronously using Task.
        /// </summary>
        /// <typeparam name="T">The type of the entity.</typeparam>
        /// <param name="connection">The connection to query on.</param>
        /// <param name="sqlStatement">The SQL to execute for this query.</param>
        /// <param name="entity">The entity to use for this query.</param>
        /// <param name="transaction">The transaction to use for this query.</param>
        /// <param name="commandType">Is it a stored proc or a batch?</param>
        /// <returns>
        /// Task: Represents an asynchronous operation.
        /// The number of rows affected.
        /// </returns>
        Task<int> ExecuteAsync<T>(IDbConnection connection, string sqlStatement, T entity, IDbTransaction transaction = null, CommandType? commandType = null);

        /// <summary>
        /// Execute parameterized SQL that selects a single value.
        /// </summary>
        /// <typeparam name="T">The type of the entity.</typeparam>
        /// <typeparam name="TReturn">The type of the return.</typeparam>
        /// <param name="connection">The connection to query on.</param>
        /// <param name="sqlStatement">The SQL to execute for this query.</param>
        /// <param name="entity">The entity to use for this query.</param>
        /// <param name="transaction">The transaction to use for this query.</param>
        /// <param name="commandType">Is it a stored proc or a batch?</param>
        /// <returns>The first cell selected as TReturn.</returns>
        TReturn ExecuteScalar<T, TReturn>(IDbConnection connection, string sqlStatement, T entity, IDbTransaction transaction = null, CommandType? commandType = null);

        /// <summary>
        /// Execute parameterized SQL that selects a single value and asynchronously using Task.
        /// </summary>
        /// <typeparam name="T">The type of the entity.</typeparam>
        /// <typeparam name="TReturn">The type of the return.</typeparam>
        /// <param name="connection">The connection to query on.</param>
        /// <param name="sqlStatement">The SQL to execute for this query.</param>
        /// <param name="entity">The entity to use for this query.</param>
        /// <param name="transaction">The transaction to use for this query.</param>
        /// <param name="commandType">Is it a stored proc or a batch?</param>
        /// <returns>
        /// Task: Represents an asynchronous operation.
        /// The first cell selected as TReturn.
        /// </returns>
        Task<TReturn> ExecuteScalarAsync<T, TReturn>(IDbConnection connection, string sqlStatement, T entity, IDbTransaction transaction = null, CommandType? commandType = null);

        /// <summary>
        /// Return a dynamic object with properties matching the columns.
        /// </summary>
        /// <typeparam name="TResult">The type of the entity.</typeparam>
        /// <param name="connection">The connection to query on.</param>
        /// <param name="sqlStatement">The SQL to execute for this query.</param>
        /// <param name="id">The id of the entity.</param>
        /// <param name="transaction">The transaction to use for this query.</param>
        /// <param name="commandType">Is it a stored proc or a batch?</param>
        /// <returns>The first cell selected as TReturn.</returns>
        TResult QueryFirstOrDefault<TResult>(IDbConnection connection, string sqlStatement, object id, IDbTransaction transaction = null, CommandType? commandType = null);

        /// <summary>
        /// Return a dynamic object with properties matching the columns and asynchronously using Task.
        /// </summary>
        /// <typeparam name="TResult">The type of the entity.</typeparam>
        /// <param name="connection">The connection to query on.</param>
        /// <param name="sqlStatement">The SQL to execute for this query.</param>
        /// <param name="id">The id of the entity.</param>
        /// <param name="transaction">The transaction to use for this query.</param>
        /// <param name="commandType">Is it a stored proc or a batch?</param>
        /// <returns>
        /// Task: Represents an asynchronous operation.
        /// The first cell selected as TReturn.
        /// </returns>
        Task<TResult> QueryFirstOrDefaultAsync<TResult>(IDbConnection connection, string sqlStatement, object id, IDbTransaction transaction = null, CommandType? commandType = null);

        /// <summary>
        /// Executes a query, returning the data typed as TResult.
        /// </summary>
        /// <typeparam name="TResult">The type of the entity.</typeparam>
        /// <param name="connection">The connection to query on.</param>
        /// <param name="sqlStatement">The SQL to execute for this query.</param>
        /// <param name="parameters">The parameters to pass, if any.</param>
        /// <param name="transaction">The transaction to use for this query.</param>
        /// <param name="commandType">Is it a stored proc or a batch?</param>
        /// <returns>A sequence of data of the TResult type</returns>
        IEnumerable<TResult> Query<TResult>(IDbConnection connection, string sqlStatement, object parameters, IDbTransaction transaction = null, CommandType? commandType = null);

        /// <summary>
        /// Executes a query, returning the data typed as TResult and asynchronously using Task.
        /// </summary>
        /// <typeparam name="TResult">The type of the entity.</typeparam>
        /// <param name="connection">The connection to query on.</param>
        /// <param name="sqlStatement">The SQL to execute for this query.</param>
        /// <param name="parameters">The parameters to pass, if any.</param>
        /// <param name="transaction">The transaction to use for this query.</param>
        /// <param name="commandType">Is it a stored proc or a batch?</param>
        /// <returns>
        /// Task: Represents an asynchronous operation.
        /// A sequence of data of the TResult type.
        /// </returns>
        Task<IEnumerable<TResult>> QueryAsync<TResult>(IDbConnection connection, string sqlStatement, object parameters, IDbTransaction transaction = null, CommandType? commandType = null);

        /// <summary>
        /// Perform a multi-mapping query with 2 input types.
        /// Executes a query, returning the data typed as TResult.
        /// </summary>
        /// <typeparam name="TFirst">The first type in the recordset.</typeparam>
        /// <typeparam name="TSecond">The second type in the recordset.</typeparam>
        /// <typeparam name="TResult">The combined type to return.</typeparam>
        /// <param name="connection">The connection to query on.</param>
        /// <param name="map">The function to map row types to the return type.</param>
        /// <param name="sqlStatement">The SQL to execute for this query.</param>
        /// <param name="parameters">The parameters to pass, if any.</param>
        /// <param name="splitOn">The field we should split and read the second object from (default: "Id").</param>
        /// <param name="transaction">The transaction to use for this query.</param>
        /// <param name="commandType">Is it a stored proc or a batch?</param>
        /// <returns>A sequence of data of the TResult type</returns>
        public IEnumerable<TResult> Query<TFirst, TSecond, TResult>(IDbConnection connection, Func<TFirst, TSecond, TResult> map, string sqlStatement, object parameters, string splitOn, IDbTransaction transaction = null, CommandType? commandType = null);

        /// <summary>
        /// Perform a multi-mapping query with 2 input types.
        /// Executes a query, returning the data typed as TResult and asynchronously using Task.
        /// </summary>
        /// <typeparam name="TFirst">The first type in the recordset.</typeparam>
        /// <typeparam name="TSecond">The second type in the recordset.</typeparam>
        /// <typeparam name="TResult">The combined type to return.</typeparam>
        /// <param name="connection">The connection to query on.</param>
        /// <param name="map">The function to map row types to the return type.</param>
        /// <param name="sqlStatement">The SQL to execute for this query.</param>
        /// <param name="parameters">The parameters to pass, if any.</param>
        /// <param name="splitOn">The field we should split and read the second object from (default: "Id").</param>
        /// <param name="transaction">The transaction to use for this query.</param>
        /// <param name="commandType">Is it a stored proc or a batch?</param>
        /// <returns>
        /// Task: Represents an asynchronous operation.
        /// A sequence of data of the TResult type.
        /// </returns>
        Task<IEnumerable<TResult>> QueryAsync<TFirst, TSecond, TResult>(IDbConnection connection, Func<TFirst, TSecond, TResult> map, string sqlStatement, object parameters, string splitOn, IDbTransaction transaction = null, CommandType? commandType = null);

        /// <summary>
        /// Perform a multi-mapping query with 3 input types.
        /// Executes a query, returning the data typed as TResult.
        /// </summary>
        /// <typeparam name="TFirst">The first type in the recordset.</typeparam>
        /// <typeparam name="TSecond">The second type in the recordset.</typeparam>
        /// <typeparam name="TThird">The third type in the recordset.</typeparam>
        /// <typeparam name="TResult">The combined type to return.</typeparam>
        /// <param name="connection">The connection to query on.</param>
        /// <param name="map">The function to map row types to the return type.</param>
        /// <param name="sqlStatement">The SQL to execute for this query.</param>
        /// <param name="parameters">The parameters to pass, if any.</param>
        /// <param name="splitOn">The field we should split and read the second object from (default: "Id").</param>
        /// <param name="transaction">The transaction to use for this query.</param>
        /// <param name="commandType">Is it a stored proc or a batch?</param>
        /// <returns>A sequence of data of the TResult type</returns>
        IEnumerable<TResult> Query<TFirst, TSecond, TThird, TResult>(IDbConnection connection, Func<TFirst, TSecond, TThird, TResult> map, string sqlStatement, object parameters, string splitOn, IDbTransaction transaction = null, CommandType? commandType = null);

        /// <summary>
        /// Perform a multi-mapping query with 3 input types.
        /// Executes a query, returning the data typed as TResult and asynchronously using Task.
        /// </summary>
        /// <typeparam name="TFirst">The first type in the recordset.</typeparam>
        /// <typeparam name="TSecond">The second type in the recordset.</typeparam>
        /// <typeparam name="TThird">The third type in the recordset.</typeparam>
        /// <typeparam name="TResult">The combined type to return.</typeparam>
        /// <param name="connection">The connection to query on.</param>
        /// <param name="map">The function to map row types to the return type.</param>
        /// <param name="sqlStatement">The SQL to execute for this query.</param>
        /// <param name="parameters">The parameters to pass, if any.</param>
        /// <param name="splitOn">The field we should split and read the second object from (default: "Id").</param>
        /// <param name="transaction">The transaction to use for this query.</param>
        /// <param name="commandType">Is it a stored proc or a batch?</param>
        /// <returns>A sequence of data of the TResult type</returns>
        Task<IEnumerable<TResult>> QueryAsync<TFirst, TSecond, TThird, TResult>(IDbConnection connection, Func<TFirst, TSecond, TThird, TResult> map, string sqlStatement, object parameters, string splitOn, IDbTransaction transaction = null, CommandType? commandType = null);

        /// <summary>
        /// Perform a multi-mapping query with 4 input types.
        /// Executes a query, returning the data typed as TResult.
        /// </summary>
        /// <typeparam name="TFirst">The first type in the recordset.</typeparam>
        /// <typeparam name="TSecond">The second type in the recordset.</typeparam>
        /// <typeparam name="TThird">The third type in the recordset.</typeparam>
        /// <typeparam name="TFourth">The fourth type in the recordset.</typeparam>
        /// <typeparam name="TResult">The combined type to return.</typeparam>
        /// <param name="connection">The connection to query on.</param>
        /// <param name="map">The function to map row types to the return type.</param>
        /// <param name="sqlStatement">The SQL to execute for this query.</param>
        /// <param name="parameters">The parameters to pass, if any.</param>
        /// <param name="splitOn">The field we should split and read the second object from (default: "Id").</param>
        /// <param name="transaction">The transaction to use for this query.</param>
        /// <param name="commandType">Is it a stored proc or a batch?</param>
        /// <returns>A sequence of data of the TResult type</returns>
        IEnumerable<TResult> Query<TFirst, TSecond, TThird, TFourth, TResult>(IDbConnection connection, Func<TFirst, TSecond, TThird, TFourth, TResult> map, string sqlStatement, object parameters, string splitOn, IDbTransaction transaction = null, CommandType? commandType = null);

        /// <summary>
        /// Perform a multi-mapping query with 4 input types.
        /// Executes a query, returning the data typed as TResult and asynchronously using Task.
        /// </summary>
        /// <typeparam name="TFirst">The first type in the recordset.</typeparam>
        /// <typeparam name="TSecond">The second type in the recordset.</typeparam>
        /// <typeparam name="TThird">The third type in the recordset.</typeparam>
		/// <typeparam name="TFourth">The fourth type in the recordset.</typeparam>
        /// <typeparam name="TResult">The combined type to return.</typeparam>
        /// <param name="connection">The connection to query on.</param>
        /// <param name="map">The function to map row types to the return type.</param>
        /// <param name="sqlStatement">The SQL to execute for this query.</param>
        /// <param name="parameters">The parameters to pass, if any.</param>
        /// <param name="splitOn">The field we should split and read the second object from (default: "Id").</param>
        /// <param name="transaction">The transaction to use for this query.</param>
        /// <param name="commandType">Is it a stored proc or a batch?</param>
        /// <returns>A sequence of data of the TResult type</returns>
        Task<IEnumerable<TResult>> QueryAsync<TFirst, TSecond, TThird, TFourth, TResult>(IDbConnection connection, Func<TFirst, TSecond, TThird, TFourth, TResult> map, string sqlStatement, object parameters, string splitOn, IDbTransaction transaction = null, CommandType? commandType = null);

        /// <summary>
        /// Perform a multi-mapping query with 5 input types.
        /// Executes a query, returning the data typed as TResult.
        /// </summary>
        /// <typeparam name="TFirst">The first type in the recordset.</typeparam>
        /// <typeparam name="TSecond">The second type in the recordset.</typeparam>
        /// <typeparam name="TThird">The third type in the recordset.</typeparam>
        /// <typeparam name="TFourth">The fourth type in the recordset.</typeparam>
        /// <typeparam name="TFifth">The fifth type in the recordset.</typeparam>
        /// <typeparam name="TResult">The combined type to return.</typeparam>
        /// <param name="connection">The connection to query on.</param>
        /// <param name="map">The function to map row types to the return type.</param>
        /// <param name="sqlStatement">The SQL to execute for this query.</param>
        /// <param name="parameters">The parameters to pass, if any.</param>
        /// <param name="splitOn">The field we should split and read the second object from (default: "Id").</param>
        /// <param name="transaction">The transaction to use for this query.</param>
        /// <param name="commandType">Is it a stored proc or a batch?</param>
        /// <returns>A sequence of data of the TResult type</returns>
        IEnumerable<TResult> Query<TFirst, TSecond, TThird, TFourth, TFifth, TResult>(IDbConnection connection, Func<TFirst, TSecond, TThird, TFourth, TFifth, TResult> map, string sqlStatement, object parameters, string splitOn, IDbTransaction transaction = null, CommandType? commandType = null);

        /// <summary>
        /// Perform a multi-mapping query with 5 input types.
        /// Executes a query, returning the data typed as TResult and asynchronously using Task.
        /// </summary>
        /// <typeparam name="TFirst">The first type in the recordset.</typeparam>
        /// <typeparam name="TSecond">The second type in the recordset.</typeparam>
        /// <typeparam name="TThird">The third type in the recordset.</typeparam>
		/// <typeparam name="TFourth">The fourth type in the recordset.</typeparam>
		/// <typeparam name="TFifth">The fifth type in the recordset.</typeparam>
        /// <typeparam name="TResult">The combined type to return.</typeparam>
        /// <param name="connection">The connection to query on.</param>
        /// <param name="map">The function to map row types to the return type.</param>
        /// <param name="sqlStatement">The SQL to execute for this query.</param>
        /// <param name="parameters">The parameters to pass, if any.</param>
        /// <param name="splitOn">The field we should split and read the second object from (default: "Id").</param>
        /// <param name="transaction">The transaction to use for this query.</param>
        /// <param name="commandType">Is it a stored proc or a batch?</param>
        /// <returns>A sequence of data of the TResult type</returns>
        Task<IEnumerable<TResult>> QueryAsync<TFirst, TSecond, TThird, TFourth, TFifth, TResult>(IDbConnection connection, Func<TFirst, TSecond, TThird, TFourth, TFifth, TResult> map, string sqlStatement, object parameters, string splitOn, IDbTransaction transaction = null, CommandType? commandType = null);

        /// <summary>
        /// Perform a multi-mapping query with 6 input types.
        /// Executes a query, returning the data typed as TResult.
        /// </summary>
        /// <typeparam name="TFirst">The first type in the recordset.</typeparam>
        /// <typeparam name="TSecond">The second type in the recordset.</typeparam>
        /// <typeparam name="TThird">The third type in the recordset.</typeparam>
        /// <typeparam name="TFourth">The fourth type in the recordset.</typeparam>
        /// <typeparam name="TFifth">The fifth type in the recordset.</typeparam>
        /// <typeparam name="TSixth">The sixth type in the recordset.</typeparam>
        /// <typeparam name="TResult">The combined type to return.</typeparam>
        /// <param name="connection">The connection to query on.</param>
        /// <param name="map">The function to map row types to the return type.</param>
        /// <param name="sqlStatement">The SQL to execute for this query.</param>
        /// <param name="parameters">The parameters to pass, if any.</param>
        /// <param name="splitOn">The field we should split and read the second object from (default: "Id").</param>
        /// <param name="transaction">The transaction to use for this query.</param>
        /// <param name="commandType">Is it a stored proc or a batch?</param>
        /// <returns>A sequence of data of the TResult type</returns>
        IEnumerable<TResult> Query<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TResult>(IDbConnection connection, Func<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TResult> map, string sqlStatement, object parameters, string splitOn, IDbTransaction transaction = null, CommandType? commandType = null);

        /// <summary>
        /// Perform a multi-mapping query with 6 input types.
        /// Executes a query, returning the data typed as TResult and asynchronously using Task.
        /// </summary>
        /// <typeparam name="TFirst">The first type in the recordset.</typeparam>
        /// <typeparam name="TSecond">The second type in the recordset.</typeparam>
        /// <typeparam name="TThird">The third type in the recordset.</typeparam>
		/// <typeparam name="TFourth">The fourth type in the recordset.</typeparam>
		/// <typeparam name="TFifth">The fifth type in the recordset.</typeparam>
		/// <typeparam name="TSixth">The sixth type in the recordset.</typeparam>
        /// <typeparam name="TResult">The combined type to return.</typeparam>
        /// <param name="connection">The connection to query on.</param>
        /// <param name="map">The function to map row types to the return type.</param>
        /// <param name="sqlStatement">The SQL to execute for this query.</param>
        /// <param name="parameters">The parameters to pass, if any.</param>
        /// <param name="splitOn">The field we should split and read the second object from (default: "Id").</param>
        /// <param name="transaction">The transaction to use for this query.</param>
        /// <param name="commandType">Is it a stored proc or a batch?</param>
        /// <returns>A sequence of data of the TResult type</returns>
        Task<IEnumerable<TResult>> QueryAsync<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TResult>(IDbConnection connection, Func<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TResult> map, string sqlStatement, object parameters, string splitOn, IDbTransaction transaction = null, CommandType? commandType = null);

        /// <summary>
        /// Perform a multi-mapping query with 7 input types.
        /// Executes a query, returning the data typed as TResult.
        /// </summary>
        /// <typeparam name="TFirst">The first type in the recordset.</typeparam>
        /// <typeparam name="TSecond">The second type in the recordset.</typeparam>
        /// <typeparam name="TThird">The third type in the recordset.</typeparam>
        /// <typeparam name="TFourth">The fourth type in the recordset.</typeparam>
        /// <typeparam name="TFifth">The fifth type in the recordset.</typeparam>
        /// <typeparam name="TSixth">The sixth type in the recordset.</typeparam>
        /// <typeparam name="TSeventh">The seventh type in the recordset.</typeparam>
        /// <typeparam name="TResult">The combined type to return.</typeparam>
        /// <param name="connection">The connection to query on.</param>
        /// <param name="map">The function to map row types to the return type.</param>
        /// <param name="sqlStatement">The SQL to execute for this query.</param>
        /// <param name="parameters">The parameters to pass, if any.</param>
        /// <param name="splitOn">The field we should split and read the second object from (default: "Id").</param>
        /// <param name="transaction">The transaction to use for this query.</param>
        /// <param name="commandType">Is it a stored proc or a batch?</param>
        /// <returns>A sequence of data of the TResult type</returns>
        IEnumerable<TResult> Query<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TResult>(IDbConnection connection, Func<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TResult> map, string sqlStatement, object parameters, string splitOn, IDbTransaction transaction = null, CommandType? commandType = null);

        /// <summary>
        /// Perform a multi-mapping query with 7 input types.
        /// Executes a query, returning the data typed as TResult and asynchronously using Task.
        /// </summary>
        /// <typeparam name="TFirst">The first type in the recordset.</typeparam>
        /// <typeparam name="TSecond">The second type in the recordset.</typeparam>
        /// <typeparam name="TThird">The third type in the recordset.</typeparam>
		/// <typeparam name="TFourth">The fourth type in the recordset.</typeparam>
		/// <typeparam name="TFifth">The fifth type in the recordset.</typeparam>
		/// <typeparam name="TSixth">The sixth type in the recordset.</typeparam>
		/// <typeparam name="TSeventh">The seventh type in the recordset.</typeparam>
        /// <typeparam name="TResult">The combined type to return.</typeparam>
        /// <param name="connection">The connection to query on.</param>
        /// <param name="map">The function to map row types to the return type.</param>
        /// <param name="sqlStatement">The SQL to execute for this query.</param>
        /// <param name="parameters">The parameters to pass, if any.</param>
        /// <param name="splitOn">The field we should split and read the second object from (default: "Id").</param>
        /// <param name="transaction">The transaction to use for this query.</param>
        /// <param name="commandType">Is it a stored proc or a batch?</param>
        /// <returns>A sequence of data of the TResult type</returns>
        Task<IEnumerable<TResult>> QueryAsync<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TResult>(IDbConnection connection, Func<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TResult> map, string sqlStatement, object parameters, string splitOn, IDbTransaction transaction = null, CommandType? commandType = null);

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
        void QueryMultiple(IDbConnection connection, string sqlStatement, object parameters, Action<GridReader> result, IDbTransaction transaction = null, CommandType? commandType = null);

        /// <summary>
        /// Execute a command that returns multiple result sets, and access each in turn and asynchronously using Task.
        /// </summary>
        /// <param name="connection">The connection to query on.</param>
        /// <param name="sqlStatement">The SQL to execute for this query.</param>
        /// <param name="parameters">The parameters to pass, if any.</param>
        /// <param name="result">
        /// Encapsulates a method that has one parameter and returns a value of the type specified by the TResult parameter.
        /// Parameter: The parameter of the method that this delegate encapsulates.
        /// GridReader: The grid reader provides interfaces for reading multiple result sets from a Dapper query
        /// TResult: Represents an asynchronous operation.
        /// </param>
        /// <param name="transaction">The transaction to use for this query.</param>
        /// <param name="commandType">Is it a stored proc or a batch?</param>
        /// <returns>Represents an asynchronous operation.</returns>
        Task QueryMultipleAsync(IDbConnection connection, string sqlStatement, object parameters, Func<GridReader, Task> result, IDbTransaction transaction = null, CommandType? commandType = null);

        #endregion
    }
}
