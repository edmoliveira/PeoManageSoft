using Microsoft.Extensions.Logging;
using PeoManageSoft.Business.Infrastructure.Helpers.Extensions;
using PeoManageSoft.Business.Infrastructure.Helpers.Interfaces;
using PeoManageSoft.Business.Infrastructure.ObjectRelationalMapper.Interfaces;
using PeoManageSoft.Business.Infrastructure.Repositories.Interfaces;
using PeoManageSoft.Business.Infrastructure.Repositories.User;
using System.Data;

namespace PeoManageSoft.Business.Infrastructure.Repositories.Title
{
    /// <summary>
    /// Title encapsulation of logic to access data sources.
    /// </summary>
    internal sealed class TitleRepository : BaseRepository, ITitleRepository
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the PeoManageSoft.Business.Infrastructure.Repositories.Title.TitleRepository class.
        /// </summary>
        /// <param name="dbContext">Represents a session with the underlying database using which you can perform CRUD (Create, Read, Update, Delete) operations.</param>
        /// <param name="applicationContext">Class to be used on one instance throughout the application per request</param>
        /// <param name="provider">Defines a mechanism for retrieving a service object; that is, an object that provides custom support to other objects.</param>
        /// <param name="logger">Log</param>
        public TitleRepository(
            IDbContext dbContext,
            IApplicationContext applicationContext,
            IServiceProvider provider,
            ILogger<UserRepository> logger)
            : base(dbContext, applicationContext, provider, logger)
        {
        }

        #endregion

        #region Methods

        #region public

        /// <summary>
        /// Deteles the record from the Title table and asynchronously using Task.
        /// </summary>
        /// <param name="scope">Transactional scope</param>
        /// <param name="id">Title identifier</param>
        /// <returns>Task: Represents an asynchronous operation.</returns>
        public async Task DeleteAsync(IScope scope, long id)
        {
            string methodName = nameof(DeleteAsync);

            _logger.LogBeginInformation(methodName);

            IContentScope contentScope = (IContentScope)scope;
            (string sqlStatement,
             object parameterId,
             CommandType commandType) = TitleEntityConfig.GetDeleteSqlStatement(id);

            _ = await _dbContext.ExecuteAsync(
                contentScope.Connection,
                sqlStatement,
                parameterId,
                contentScope.DbTransaction,
                commandType
            ).ConfigureAwait(false);

            _logger.LogEndInformation(methodName);
        }

        /// Determines whether the specified title table contains the record that match the id
        /// </summary>
        /// <param name="scope">Transactional scope</param>
        /// <param name="id">Title identifier</param>
        /// <returns>
        /// Task: Represents an asynchronous operation.
        /// Returns true if the record exists in the table
        /// </returns>
        public async Task<bool> ExistsAsync(IScope scope, long id)
        {
            string methodName = nameof(SelectByIdAsync);

            _logger.LogBeginInformation(methodName);

            IContentScope contentScope = (IContentScope)scope;
            (string sqlStatement,
             object parameterId,
             CommandType commandType) = TitleEntityConfig.GetExistsByIdSqlStatement(id);

            bool result = await _dbContext.ExecuteScalarAsync<object, bool>(
                contentScope.Connection,
                sqlStatement,
                parameterId,
                contentScope.DbTransaction,
                commandType
            ).ConfigureAwait(false);

            _logger.LogEndInformation(methodName);

            return result;
        }

        /// <summary>
        /// Creates the record in the Title table and asynchronously using Task.
        /// </summary>
        /// <param name="scope">Transactional scope</param>
        /// <param name="entity">Title entity</param>
        /// <returns>Task: Represents an asynchronous operation.</returns>
        public async Task InsertAsync(IScope scope, TitleEntity entity)
        {
            string methodName = nameof(InsertAsync);

            _logger.LogBeginInformation(methodName);

            IContentScope contentScope = (IContentScope)scope;
            (string sqlStatement,
             CommandType commandType) = TitleEntityConfig.GetInsertSqlStatement();

            IEntity ientity = entity;

            long id = await _dbContext.ExecuteScalarAsync<object, long>(
                contentScope.Connection,
                sqlStatement,
                ientity.GetInsertParameters(_applicationContext),
                contentScope.DbTransaction,
                commandType
            ).ConfigureAwait(false);

            ientity.SetId(id);

            _logger.LogEndInformation(methodName);
        }

        /// <summary>
        /// Query records in the Title table and asynchronously using Task.
        /// </summary>
        /// <param name="scope">Transactional scope</param>
        /// <returns>
        /// Task: Represents an asynchronous operation. 
        /// Returns an enumerator that iterates through the Title entity collection.
        /// </returns>
        public async Task<IEnumerable<TitleEntity>> SelectAllAsync(IScope scope)
        {
            string methodName = nameof(SelectAllAsync);

            _logger.LogBeginInformation(methodName);

            IContentScope contentScope = (IContentScope)scope;
            (string sqlStatement,
             CommandType commandType) = TitleEntityConfig.GetSelectSqlStatement();

            IEnumerable<TitleEntity> result = await _dbContext.QueryAsync<TitleEntity>(
                contentScope.Connection,
                sqlStatement,
                null,
                contentScope.DbTransaction,
                commandType
            ).ConfigureAwait(false);

            _logger.LogEndInformation(methodName);

            return result;
        }

        /// <summary>
        /// Query the record in the Title table and asynchronously using Task.
        /// </summary>
        /// <param name="scope">Transactional scope</param>
        /// <param name="id">Title identifier</param>
        /// <returns>
        /// Task: Represents an asynchronous operation. 
        /// Returns the Title entity.
        /// </returns>
        public async Task<TitleEntity> SelectByIdAsync(IScope scope, long id)
        {
            string methodName = nameof(SelectByIdAsync);

            _logger.LogBeginInformation(methodName);

            IContentScope contentScope = (IContentScope)scope;
            (string sqlStatement,
             object parameterId,
             CommandType commandType) = TitleEntityConfig.GetSelectByIdSqlStatement(id);

            TitleEntity result = await _dbContext.QueryFirstOrDefaultAsync<TitleEntity>(
                contentScope.Connection,
                sqlStatement,
                parameterId,
                contentScope.DbTransaction,
                commandType
            ).ConfigureAwait(false);

            _logger.LogEndInformation(methodName);

            return result;
        }

        /// <summary>
        /// Updates the record from the Title table and asynchronously using Task.
        /// </summary>
        /// <param name="scope">Transactional scope</param>
        /// <param name="entity">Title entity</param>
        /// <returns>Task: Represents an asynchronous operation.</returns>
        public async Task UpdateAsync(IScope scope, TitleEntity entity)
        {
            string methodName = nameof(UpdateAsync);

            _logger.LogBeginInformation(methodName);

            IContentScope contentScope = (IContentScope)scope;
            (string sqlStatement,
             CommandType commandType) = TitleEntityConfig.GetUpdateSqlStatement();

            IEntity ientity = entity;

            _ = await _dbContext.ExecuteAsync(
                contentScope.Connection,
                sqlStatement,
                ientity.GetUpdateParameters(_applicationContext),
                contentScope.DbTransaction,
                commandType
            ).ConfigureAwait(false);

            _logger.LogEndInformation(methodName);
        }

        /// <summary>
        /// Validates whether inserting into the title table is allowed and asynchronously using Task.
        /// </summary>
        /// <param name="scope">Transactional scope</param>
        ///  <param name="entity">Title Entity</param>
        /// <returns>
        /// Task: Represents an asynchronous operation. 
        /// Returns an enumerator that iterates through the validation collection.
        /// </returns>
        public async Task<IEnumerable<string>> ValidateInsertAsync(IScope scope, TitleEntity entity)
        {
            string methodName = nameof(ValidateInsertAsync);

            _logger.LogBeginInformation(methodName);

            IContentScope contentScope = (IContentScope)scope;
            (string sqlStatement,
             CommandType commandType) = TitleEntityConfig.GetValidateInsertSqlStatement();

            IEntity ientity = entity;

            IEnumerable<string> result = await _dbContext.QueryAsync<string>(
                contentScope.Connection,
                sqlStatement,
                ientity.GetValidateInsertParameters(),
                contentScope.DbTransaction,
                commandType
            ).ConfigureAwait(false);

            _logger.LogEndInformation(methodName);

            return result;
        }

        /// <summary>
        /// Validates whether updating into the title table is allowed and asynchronously using Task.
        /// </summary>
        /// <param name="scope">Transactional scope</param>
        ///  <param name="entity">Title entity</param>
        /// <returns>
        /// Task: Represents an asynchronous operation. 
        /// Returns an enumerator that iterates through the validation collection.
        /// </returns>
        public async Task<IEnumerable<string>> ValidateUpdateAsync(IScope scope, TitleEntity entity)
        {
            string methodName = nameof(ValidateUpdateAsync);

            _logger.LogBeginInformation(methodName);

            IContentScope contentScope = (IContentScope)scope;
            (string sqlStatement,
             CommandType commandType) = TitleEntityConfig.GetValidateUpdateSqlStatement();

            IEntity ientity = entity;

            IEnumerable<string> result = await _dbContext.QueryAsync<string>(
                contentScope.Connection,
                sqlStatement,
                ientity.GetValidateUpdateParameters(),
                contentScope.DbTransaction,
                commandType
            ).ConfigureAwait(false);

            _logger.LogEndInformation(methodName);

            return result;
        }

        #endregion

        #endregion
    }
}
