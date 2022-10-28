using AutoMapper;
using Microsoft.Extensions.Logging;
using PeoManageSoft.Business.Infrastructure.Helpers.Extensions;
using PeoManageSoft.Business.Infrastructure.Helpers.Interfaces;
using PeoManageSoft.Business.Infrastructure.ObjectRelationalMapper.Interfaces;
using System.Data;

namespace PeoManageSoft.Business.Infrastructure.Repositories
{
    /// <summary>
    /// Base encapsulation of logic to access data sources.
    /// </summary>
    internal abstract class BaseRepository
    {
        #region Properties

        /// <summary>
        /// Represents a session with the underlying database using which you can perform CRUD (Create, Read, Update, Delete) operations.
        /// </summary>
        protected IDbContext DbContext { get; }
        /// <summary>
        /// Class to be used on one instance throughout the application per request
        /// </summary>
        protected IApplicationContext ApplicationContext { get; }
        /// <summary>
        /// Defines a mechanism for retrieving a service object; that is, an object that provides custom support to other objects.
        /// </summary>
        protected IServiceProvider Provider { get; }
        /// <summary>
        /// Data Mapper 
        /// </summary>
        protected IMapper Mapper { get; }
        /// <summary>
        /// Log
        /// </summary>
        protected ILogger Logger { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the PeoManageSoft.Business.Infrastructure.Repositories.BaseRepository class.
        /// </summary>
        /// <param name="dbContext">Represents a session with the underlying database using which you can perform CRUD (Create, Read, Update, Delete) operations.</param>
        /// <param name="applicationContext">Class to be used on one instance throughout the application per request</param>
        /// <param name="provider">Defines a mechanism for retrieving a service object; that is, an object that provides custom support to other objects.</param>
        /// <param name="mapper">Data Mapper</param>
        /// <param name="logger">Log</param>
        public BaseRepository(
            IDbContext dbContext,
            IApplicationContext applicationContext,
            IServiceProvider provider,
            IMapper mapper,
            ILogger logger)
        {
            DbContext = dbContext;
            ApplicationContext = applicationContext;
            Provider = provider;
            Mapper = mapper;
            Logger = logger;
        }

        #endregion

        #region Methods 

        #region protected

        /// <summary>
        /// Execute parameterized SQL and return an data reader and asynchronously using Task.
        /// </summary>
        /// <param name="action">An data reader that can be used to iterate over the results of the SQL query.</param>
        /// <param name="scope">Transactional scope</param>
        /// <param name="getSqlStatementFunc">
        /// Function to get:
        /// sqlStatement: The SQL to execute for this query.
        /// parameters: The parameter to sql command.
        /// commandType: Is it a stored proc or a batch?.
        /// </param>
        /// <returns>Represents an asynchronous operation.</returns>
        protected async Task ExecuteReaderAsync(Action<IDataReader> action, IScope scope, Func<(string sqlStatement, object parameters, CommandType commandType)> getSqlStatementFunc)
        {
            string methodName = nameof(ExecuteReaderAsync);

            Logger.LogBeginInformation(methodName);

            IContentScope contentScope = (IContentScope)scope;

            (string sqlStatement,
             object parameters,
             CommandType commandType) = getSqlStatementFunc();

            await DbContext.ExecuteReaderAsync(
                action,
                contentScope.Connection,
                sqlStatement,
                parameters,
                contentScope.DbTransaction,
                commandType
            ).ConfigureAwait(false);

            Logger.LogEndInformation(methodName);
        }

        /// <summary>
        /// Return a dynamic object with properties matching the columns and asynchronously using Task.
        /// </summary>
        /// <typeparam name="TReturn">The type of the return.</typeparam>
        /// <param name="scope">Transactional scope</param>
        /// <param name="getSqlStatementFunc">
        /// Function to get:
        /// sqlStatement: The SQL to execute for this query.
        /// parameters: The parameter to sql command.
        /// commandType: Is it a stored proc or a batch?.
        /// </param>
        /// <returns>
        /// Task: Represents an asynchronous operation.
        /// The first cell selected as TReturn.
        /// </returns>
        protected async Task<TReturn> QueryFirstOrDefaultAsync<TReturn>(IScope scope, Func<(string sqlStatement, object parameters, CommandType commandType)> getSqlStatementFunc)
        {
            string methodName = nameof(QueryAsync);

            Logger.LogBeginInformation(methodName);

            IContentScope contentScope = (IContentScope)scope;

            (string sqlStatement,
             object parameters,
             CommandType commandType) = getSqlStatementFunc();

            var result = await DbContext.QueryFirstOrDefaultAsync<TReturn>(
                contentScope.Connection,
                sqlStatement,
                parameters,
                contentScope.DbTransaction,
                commandType
            ).ConfigureAwait(false);

            Logger.LogEndInformation(methodName);

            return result;
        }

        /// <summary>
        /// Executes a query, returning the data typed as TResult and asynchronously using Task.
        /// </summary>
        /// <typeparam name="TReturn">The type of the return.</typeparam>
        /// <param name="scope">Transactional scope</param>
        /// <param name="getSqlStatementFunc">
        /// Function to get:
        /// sqlStatement: The SQL to execute for this query.
        /// parameters: The parameter to sql command.
        /// commandType: Is it a stored proc or a batch?.
        /// </param>
        /// <returns>
        /// Task: Represents an asynchronous operation.
        /// A sequence of data of the TResult type.
        /// </returns>
        protected async Task<IEnumerable<TReturn>> QueryAsync<TReturn>(IScope scope, Func<(string sqlStatement, object parameters, CommandType commandType)> getSqlStatementFunc)
        {
            string methodName = nameof(QueryAsync);

            Logger.LogBeginInformation(methodName);

            IContentScope contentScope = (IContentScope)scope;

            (string sqlStatement,
             object parameters,
             CommandType commandType) = getSqlStatementFunc();

            var result = await DbContext.QueryAsync<TReturn>(
                contentScope.Connection,
                sqlStatement,
                parameters,
                contentScope.DbTransaction,
                commandType
            ).ConfigureAwait(false);

            Logger.LogEndInformation(methodName);

            return result;
        }

        /// <summary>
        /// Execute parameterized SQL that selects a single value and asynchronously using Task.
        /// </summary>
        /// <typeparam name="TReturn">The type of the return.</typeparam>
        /// <param name="scope">Transactional scope</param>
        /// <param name="getSqlStatementFunc">
        /// Function to get:
        /// sqlStatement: The SQL to execute for this query.
        /// parameters: The parameter to sql command.
        /// commandType: Is it a stored proc or a batch?.
        /// </param>
        /// <returns>
        /// Task: Represents an asynchronous operation.
        /// The first cell selected as TReturn.
        /// </returns>
        protected async Task<TReturn> ExecuteScalarAsync<TReturn>(IScope scope, Func<(string sqlStatement, object parameters, CommandType commandType)> getSqlStatementFunc)
        {
            string methodName = nameof(ExecuteScalarAsync);

            Logger.LogBeginInformation(methodName);

            IContentScope contentScope = (IContentScope)scope;

            (string sqlStatement,
             object parameters,
             CommandType commandType) = getSqlStatementFunc();

            var result = await DbContext.ExecuteScalarAsync<object, TReturn>(
                contentScope.Connection,
                sqlStatement,
                parameters,
                contentScope.DbTransaction,
                commandType
            ).ConfigureAwait(false);

            Logger.LogEndInformation(methodName);

            return result;
        }

        /// <summary>
        /// Execute parameterized SQL and asynchronously using Task.
        /// </summary>
        /// <param name="scope">Transactional scope</param>
        /// <param name="getSqlStatementFunc">
        /// Function to get:
        /// sqlStatement: The SQL to execute for this query.
        /// parameters: The parameter to sql command.
        /// commandType: Is it a stored proc or a batch?.
        /// </param>
        /// <returns>
        /// Task: Represents an asynchronous operation.
        /// The number of rows affected.
        /// </returns>
        protected async Task<int> ExecuteAsync(IScope scope, Func<(string sqlStatement, object parameters, CommandType commandType)> getSqlStatementFunc)
        {
            string methodName = nameof(ExecuteAsync);

            Logger.LogBeginInformation(methodName);

            IContentScope contentScope = (IContentScope)scope;

            (string sqlStatement,
             object parameters,
             CommandType commandType) = getSqlStatementFunc();

            int rows = await DbContext.ExecuteAsync(
                contentScope.Connection,
                sqlStatement,
                parameters,
                contentScope.DbTransaction,
                commandType
            ).ConfigureAwait(false);

            Logger.LogEndInformation(methodName);

            return rows;
        }

        #endregion

        #endregion
    }
}
