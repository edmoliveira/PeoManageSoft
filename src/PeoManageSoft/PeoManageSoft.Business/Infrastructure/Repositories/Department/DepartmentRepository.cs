using Microsoft.Extensions.Logging;
using PeoManageSoft.Business.Infrastructure.Helpers.Extensions;
using PeoManageSoft.Business.Infrastructure.Helpers.Interfaces;
using PeoManageSoft.Business.Infrastructure.ObjectRelationalMapper;
using PeoManageSoft.Business.Infrastructure.Repositories.Interfaces;
using System.Data;

namespace PeoManageSoft.Business.Infrastructure.Repositories.Department
{
    /// <summary>
    /// Department encapsulation of logic to access data sources.
    /// </summary>
    internal sealed class DepartmentRepository : IDepartmentRepository
    {
        #region Fields

        /// <summary>
        /// Represents a session with the underlying database using which you can perform CRUD (Create, Read, Update, Delete) operations.
        /// </summary>
        private readonly IDbContext _dbContext;
        /// <summary>
        /// Class to be used on one instance throughout the application per request
        /// </summary>
        private readonly IApplicationContext _applicationContext;
        /// <summary>
        /// Log
        /// </summary>
        private readonly ILogger<DepartmentRepository> _logger;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the PeoManageSoft.Business.Infrastructure.Repositories.Department.DepartmentRepository class.
        /// </summary>
        /// <param name="dbContext">Represents a session with the underlying database using which you can perform CRUD (Create, Read, Update, Delete) operations.</param>
        /// <param name="applicationContext">Class to be used on one instance throughout the application per request</param>
        /// <param name="logger">Log</param>
        public DepartmentRepository(IDbContext dbContext, IApplicationContext applicationContext, ILogger<DepartmentRepository> logger)
        {
            _dbContext = dbContext;
            _applicationContext = applicationContext;
            _logger = logger;
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

        #endregion

        #endregion
    }
}
