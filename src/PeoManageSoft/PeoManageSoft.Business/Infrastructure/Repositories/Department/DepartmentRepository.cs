using Microsoft.Extensions.Logging;
using PeoManageSoft.Business.Infrastructure.Helpers.Extensions;
using PeoManageSoft.Business.Infrastructure.Helpers.Interfaces;
using PeoManageSoft.Business.Infrastructure.ObjectRelationalMapper.Interfaces;
using PeoManageSoft.Business.Infrastructure.Repositories.Interfaces;
using PeoManageSoft.Business.Infrastructure.Repositories.User;
using System.Data;

namespace PeoManageSoft.Business.Infrastructure.Repositories.Department
{
    /// <summary>
    /// Department encapsulation of logic to access data sources.
    /// </summary>
    internal sealed class DepartmentRepository : BaseRepository, IDepartmentRepository
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the PeoManageSoft.Business.Infrastructure.Repositories.Department.DepartmentRepository class.
        /// </summary>
        /// <param name="dbContext">Represents a session with the underlying database using which you can perform CRUD (Create, Read, Update, Delete) operations.</param>
        /// <param name="applicationContext">Class to be used on one instance throughout the application per request</param>
        /// <param name="provider">Defines a mechanism for retrieving a service object; that is, an object that provides custom support to other objects.</param>
        /// <param name="logger">Log</param>
        public DepartmentRepository(
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
        /// Deteles the record from the Department table and asynchronously using Task.
        /// </summary>
        /// <param name="scope">Transactional scope</param>
        /// <param name="id">Department identifier</param>
        /// <returns>Task: Represents an asynchronous operation.</returns>
        public async Task DeleteAsync(IScope scope, long id)
        {
            string methodName = nameof(DeleteAsync);

            _logger.LogBeginInformation(methodName);

            IContentScope contentScope = (IContentScope)scope;
            (string sqlStatement,
             object parameterId,
             CommandType commandType) = DepartmentEntityConfig.GetDeleteSqlStatement(id);

            _ = await _dbContext.ExecuteAsync(
                contentScope.Connection,
                sqlStatement,
                parameterId,
                contentScope.DbTransaction,
                commandType
            ).ConfigureAwait(false);

            _logger.LogEndInformation(methodName);
        }

        /// Determines whether the specified Department table contains the record that match the id
        /// </summary>
        /// <param name="scope">Transactional scope</param>
        /// <param name="id">Department identifier</param>
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
             CommandType commandType) = DepartmentEntityConfig.GetExistsByIdSqlStatement(id);

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
        /// Creates the record in the Department table and asynchronously using Task.
        /// </summary>
        /// <param name="scope">Transactional scope</param>
        /// <param name="entity">Department entity</param>
        /// <returns>Task: Represents an asynchronous operation.</returns>
        public async Task InsertAsync(IScope scope, DepartmentEntity entity)
        {
            string methodName = nameof(InsertAsync);

            _logger.LogBeginInformation(methodName);

            IContentScope contentScope = (IContentScope)scope;
            (string sqlStatement,
             CommandType commandType) = DepartmentEntityConfig.GetInsertSqlStatement();

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
        /// Query records in the Department table and asynchronously using Task.
        /// </summary>
        /// <param name="scope">Transactional scope</param>
        /// <returns>
        /// Task: Represents an asynchronous operation. 
        /// Returns an enumerator that iterates through the Department entity collection.
        /// </returns>
        public async Task<IEnumerable<DepartmentEntity>> SelectAllAsync(IScope scope)
        {
            string methodName = nameof(SelectAllAsync);

            _logger.LogBeginInformation(methodName);

            IContentScope contentScope = (IContentScope)scope;
            (string sqlStatement,
             CommandType commandType) = DepartmentEntityConfig.GetSelectSqlStatement();

            IEnumerable<DepartmentEntity> result = await _dbContext.QueryAsync<DepartmentEntity>(
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
        /// Query the record in the Department table and asynchronously using Task.
        /// </summary>
        /// <param name="scope">Transactional scope</param>
        /// <param name="id">Department identifier</param>
        /// <returns>
        /// Task: Represents an asynchronous operation. 
        /// Returns the Department entity.
        /// </returns>
        public async Task<DepartmentEntity> SelectByIdAsync(IScope scope, long id)
        {
            string methodName = nameof(SelectByIdAsync);

            _logger.LogBeginInformation(methodName);

            IContentScope contentScope = (IContentScope)scope;
            (string sqlStatement,
             object parameterId,
             CommandType commandType) = DepartmentEntityConfig.GetSelectByIdSqlStatement(id);

            DepartmentEntity result = await _dbContext.QueryFirstOrDefaultAsync<DepartmentEntity>(
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
        /// Updates the record from the Department table and asynchronously using Task.
        /// </summary>
        /// <param name="scope">Transactional scope</param>
        /// <param name="entity">Department entity</param>
        /// <returns>Task: Represents an asynchronous operation.</returns>
        public async Task UpdateAsync(IScope scope, DepartmentEntity entity)
        {
            string methodName = nameof(UpdateAsync);

            _logger.LogBeginInformation(methodName);

            IContentScope contentScope = (IContentScope)scope;
            (string sqlStatement,
             CommandType commandType) = DepartmentEntityConfig.GetUpdateSqlStatement();

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
        /// Validates whether inserting into the department table is allowed and asynchronously using Task.
        /// </summary>
        /// <param name="scope">Transactional scope</param>
        ///  <param name="entity">Department Entity</param>
        /// <returns>
        /// Task: Represents an asynchronous operation. 
        /// Returns an enumerator that iterates through the validation collection.
        /// </returns>
        public async Task<IEnumerable<string>> ValidateInsertAsync(IScope scope, DepartmentEntity entity)
        {
            string methodName = nameof(ValidateInsertAsync);

            _logger.LogBeginInformation(methodName);

            IContentScope contentScope = (IContentScope)scope;
            (string sqlStatement,
             CommandType commandType) = DepartmentEntityConfig.GetValidateInsertSqlStatement();

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
        /// Validates whether updating into the department table is allowed and asynchronously using Task.
        /// </summary>
        /// <param name="scope">Transactional scope</param>
        ///  <param name="entity">Department entity</param>
        /// <returns>
        /// Task: Represents an asynchronous operation. 
        /// Returns an enumerator that iterates through the validation collection.
        /// </returns>
        public async Task<IEnumerable<string>> ValidateUpdateAsync(IScope scope, DepartmentEntity entity)
        {
            string methodName = nameof(ValidateUpdateAsync);

            _logger.LogBeginInformation(methodName);

            IContentScope contentScope = (IContentScope)scope;
            (string sqlStatement,
             CommandType commandType) = DepartmentEntityConfig.GetValidateUpdateSqlStatement();

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
