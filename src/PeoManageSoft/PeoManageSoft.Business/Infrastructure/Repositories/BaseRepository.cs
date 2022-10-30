using AutoMapper;
using Microsoft.Extensions.Logging;
using PeoManageSoft.Business.Infrastructure.Helpers.Extensions;
using PeoManageSoft.Business.Infrastructure.Helpers.Interfaces;
using PeoManageSoft.Business.Infrastructure.ObjectRelationalMapper;
using PeoManageSoft.Business.Infrastructure.ObjectRelationalMapper.Interfaces;
using PeoManageSoft.Business.Infrastructure.Repositories.Interfaces;
using System.Data;

namespace PeoManageSoft.Business.Infrastructure.Repositories
{
    /// <summary>
    /// Base encapsulation of logic to access data sources.
    /// </summary>
    /// <typeparam name="TEntity">Mapping to a database table</typeparam>
    /// <typeparam name="TEntityField">Entity fields types</typeparam>
    internal abstract class BaseRepository<TEntity, TEntityField> : IBaseRepository<TEntity, TEntityField>
    {
        #region Properties

        /// <summary>
        /// Entity configuration class.
        /// </summary>
        private IBaseEntityConfig<TEntity, TEntityField> EntityConfig { get; }
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
        protected IMapper oMapper { get; }
        /// <summary>
        /// Log
        /// </summary>
        protected ILogger Logger { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the PeoManageSoft.Business.Infrastructure.Repositories.BaseRepository class.
        /// </summary>
        /// <param name="entityConfig">Entity configuration class.</param>
        /// <param name="dbContext">Represents a session with the underlying database using which you can perform CRUD (Create, Read, Update, Delete) operations.</param>
        /// <param name="applicationContext">Class to be used on one instance throughout the application per request</param>
        /// <param name="provider">Defines a mechanism for retrieving a service object; that is, an object that provides custom support to other objects.</param>
        /// <param name="mapper">Data Mapper</param>
        /// <param name="logger">Log</param>
        public BaseRepository(
            IBaseEntityConfig<TEntity, TEntityField> entityConfig,
            IDbContext dbContext,
            IApplicationContext applicationContext,
            IServiceProvider provider,
            IMapper mapper,
            ILogger logger)
        {
            EntityConfig = entityConfig;
            DbContext = dbContext;
            ApplicationContext = applicationContext;
            Provider = provider;
            oMapper = mapper;
            Logger = logger;
        }

        #endregion

        #region Methods 

        #region public

        /// <summary>
        /// Deteles the record from the entiy table and asynchronously using Task.
        /// </summary>
        /// <param name="scope">Transactional scope</param>
        /// <param name="id">Entity identifier</param>
        /// <returns>Task: Represents an asynchronous operation.</returns>
        public async Task DeleteAsync(IScope scope, long id)
        {
            string methodName = nameof(DeleteAsync);

            Logger.LogBeginInformation(methodName);

            _ = await ExecuteAsync(
                scope, () =>
                EntityConfig.GetDeleteSqlStatement(id)
            ).ConfigureAwait(false);

            Logger.LogEndInformation(methodName);
        }

        /// Determines whether the specified entiy table contains the record that match the id
        /// </summary>
        /// <param name="scope">Transactional scope</param>
        /// <param name="id">Entity identifier</param>
        /// <returns>
        /// Task: Represents an asynchronous operation.
        /// Returns true if the record exists in the table
        /// </returns>
        public async Task<bool> ExistsAsync(IScope scope, long id)
        {
            string methodName = nameof(ExistsAsync);

            Logger.LogBeginInformation(methodName);

            bool result = await ExecuteScalarAsync<bool>(
                scope, () =>
                EntityConfig.GetExistsByIdSqlStatement(id)
            ).ConfigureAwait(false);

            Logger.LogEndInformation(methodName);

            return result;
        }

        /// <summary>
        /// Creates the record in the entiy table and asynchronously using Task.
        /// </summary>
        /// <param name="scope">Transactional scope</param>
        /// <param name="entity">Entity entity</param>
        /// <returns>Task: Represents an asynchronous operation.</returns>
        public async Task InsertAsync(IScope scope, TEntity entity)
        {
            string methodName = nameof(InsertAsync);

            Logger.LogBeginInformation(methodName);

            long id = await ExecuteScalarAsync<long>(
                scope, () =>
                EntityConfig.GetInsertSqlStatement(entity)
            ).ConfigureAwait(false);

            SetId(entity, id);

            Logger.LogEndInformation(methodName);
        }

        /// <summary>
        /// Query records in the entiy table and asynchronously using Task.
        /// </summary>
        /// <param name="scope">Transactional scope</param>
        /// <returns>
        /// Task: Represents an asynchronous operation. 
        /// Returns an enumerator that iterates through the user entity collection.
        /// </returns>
        public async Task<IEnumerable<TEntity>> SelectAllAsync(IScope scope)
        {
            string methodName = nameof(SelectAllAsync);

            Logger.LogBeginInformation(methodName);

            var collection = new List<TEntity>();

            await ExecuteReaderAsync(dataReader =>
            {
                collection.Add(SetEntity(new DataReaderGetValue<TEntity, TEntityField>(EntityConfig, dataReader)));
            }, scope, () => EntityConfig.GetSelectAllSqlStatement()).ConfigureAwait(false);

            Logger.LogEndInformation(methodName);

            return collection;
        }

        /// <summary>
        /// Query the record in the entiy table and asynchronously using Task.
        /// </summary>
        /// <param name="scope">Transactional scope</param>
        /// <param name="id">User identifier</param>
        /// <returns>
        /// Task: Represents an asynchronous operation. 
        /// Returns the entity.
        /// </returns>
        public async Task<TEntity> SelectByIdAsync(IScope scope, long id)
        {
            string methodName = nameof(SelectByIdAsync);

            Logger.LogBeginInformation(methodName);

            TEntity entity = default;

            await ExecuteReaderAsync(dataReader =>
            {
                entity = SetEntity(new DataReaderGetValue<TEntity, TEntityField>(EntityConfig, dataReader));
            }, scope, () => EntityConfig.GetSelectByIdSqlStatement(id)).ConfigureAwait(false);

            Logger.LogEndInformation(methodName);

            return entity;
        }

        /// <summary>
        /// Query the record in the entity table by rules and asynchronously using Task.
        /// </summary>
        /// <param name="scope">Transactional scope</param>
        /// <param name="rule">Rules to filter the data.</param>
        /// <returns>IEnumerable[TEntity]</returns>
        public async Task<IEnumerable<TEntity>> SelectByRulesAsync(IScope scope, IRule<TEntityField> rule)
        {
            string methodName = nameof(SelectByRulesAsync);

            Logger.LogBeginInformation(methodName);

            var collection = new List<TEntity>();

            await ExecuteReaderAsync(dataReader =>
            {
                collection.Add(SetEntity(new DataReaderGetValue<TEntity, TEntityField>(EntityConfig, dataReader)));
            }, scope, () => EntityConfig.GetSelectByRulesSqlStatement(rule)).ConfigureAwait(false);

            Logger.LogEndInformation(methodName);

            return collection;
        }

        /// <summary>
        /// Updates the record from the entity table and asynchronously using Task.
        /// </summary>
        /// <param name="scope">Transactional scope</param>
        /// <param name="entity">User entity</param>
        /// <returns>Task: Represents an asynchronous operation.</returns>
        public async Task UpdateAsync(IScope scope, TEntity entity)
        {
            string methodName = nameof(UpdateAsync);

            Logger.LogBeginInformation(methodName);

            _ = await ExecuteAsync(
                scope, () =>
                EntityConfig.GetUpdateSqlStatement(entity)
            ).ConfigureAwait(false);

            Logger.LogEndInformation(methodName);
        }

        /// <summary>
        /// Modifies partial data that must be updated without modifying the entire data and asynchronously using Task.
        /// </summary>
        /// <param name="scope">Transactional scope</param>
        /// <param name="fields">Fields that will be updated</param>
        /// <param name="id">Identifier value</param>
        /// <returns>Task: Represents an asynchronous operation.</returns>
        public async Task PatchAsync(IScope scope, IEnumerable<Field<TEntityField>> fields, long id)
        {
            string methodName = nameof(PatchAsync);

            Logger.LogBeginInformation(methodName);

            _ = await ExecuteAsync(
                scope, () =>
                EntityConfig.GetPatchSqlStatement(fields, id)
            ).ConfigureAwait(false);

            Logger.LogEndInformation(methodName);
        }

        #endregion

        #region protected

        /// <summary>
        /// Sets the unique identifier
        /// </summary>
        /// <param name="entity">Mapping to a database table</param>
        /// <param name="id">The unique identifier</param>
        protected abstract void SetId(TEntity entity, long id);

        /// <summary>
        /// Sets the entity
        /// </summary>
        /// <param name="dataReaderGetValue">Functionality to fetch data from datareader based on entity settings.</param>
        /// <returns>Entity</returns>
        protected abstract TEntity SetEntity(IDataReaderGetValue dataReaderGetValue);

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
        protected async Task ExecuteReaderAsync(Action<IDataReader> action, IScope scope, Func<(string sqlStatement, IEnumerable<IParameter> parameters, CommandType commandType)> getSqlStatementFunc)
        {
            string methodName = nameof(ExecuteReaderAsync);

            Logger.LogBeginInformation(methodName);

            IContentScope contentScope = (IContentScope)scope;

            (string sqlStatement,
             IEnumerable<IParameter> parameters,
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
        protected async Task<TReturn> QueryFirstOrDefaultAsync<TReturn>(IScope scope, Func<(string sqlStatement, IEnumerable<IParameter> parameters, CommandType commandType)> getSqlStatementFunc)
        {
            string methodName = nameof(QueryAsync);

            Logger.LogBeginInformation(methodName);

            IContentScope contentScope = (IContentScope)scope;

            (string sqlStatement,
             IEnumerable<IParameter> parameters,
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
        protected async Task<IEnumerable<TReturn>> QueryAsync<TReturn>(IScope scope, Func<(string sqlStatement, IEnumerable<IParameter> parameters, CommandType commandType)> getSqlStatementFunc)
        {
            string methodName = nameof(QueryAsync);

            Logger.LogBeginInformation(methodName);

            IContentScope contentScope = (IContentScope)scope;

            (string sqlStatement,
             IEnumerable<IParameter> parameters,
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
        protected async Task<TReturn> ExecuteScalarAsync<TReturn>(IScope scope, Func<(string sqlStatement, IEnumerable<IParameter> parameters, CommandType commandType)> getSqlStatementFunc)
        {
            string methodName = nameof(ExecuteScalarAsync);

            Logger.LogBeginInformation(methodName);

            IContentScope contentScope = (IContentScope)scope;

            (string sqlStatement,
             IEnumerable<IParameter> parameters,
             CommandType commandType) = getSqlStatementFunc();

            var result = await DbContext.ExecuteScalarAsync<TReturn>(
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
        protected async Task<int> ExecuteAsync(IScope scope, Func<(string sqlStatement, IEnumerable<IParameter> parameters, CommandType commandType)> getSqlStatementFunc)
        {
            string methodName = nameof(ExecuteAsync);

            Logger.LogBeginInformation(methodName);

            IContentScope contentScope = (IContentScope)scope;

            (string sqlStatement,
             IEnumerable<IParameter> parameters,
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
