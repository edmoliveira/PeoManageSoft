using Microsoft.Extensions.Logging;
using PeoManageSoft.Business.Infrastructure.Helpers.Extensions;
using PeoManageSoft.Business.Infrastructure.ObjectRelationalMapper;
using System.Data;

namespace PeoManageSoft.Business.Infrastructure.Repositories.User
{
    /// <summary>
    /// User encapsulation of logic to access data sources.
    /// </summary>
    public sealed class UserRepository : IUserRepository
    {
        #region Fields

        /// <summary>
        /// Represents a session with the underlying database using which you can perform CRUD (Create, Read, Update, Delete) operations.
        /// </summary>
        private readonly IDbContext _dbContext;
        /// <summary>
        /// Log
        /// </summary>
        private readonly ILogger<UserRepository> _logger;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the PeoManageSoft.Business.Infrastructure.Repositories.User.UserRepository class.
        /// </summary>
        /// <param name="dbContext">Represents a session with the underlying database using which you can perform CRUD (Create, Read, Update, Delete) operations.</param>
        /// <param name="logger">Log</param>
        public UserRepository(IDbContext dbContext, ILogger<UserRepository> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        #endregion

        #region Methods

        #region public

        /// <summary>
        /// Deteles the record from the user table and asynchronously using Task.
        /// </summary>
        /// <param name="scope">Transactional scope</param>
        /// <param name="id">User identifier</param>
        /// <returns>Task: Represents an asynchronous operation.</returns>
        public async Task DeleteAsync(IScope scope, long id)
        {
            string methodName = nameof(DeleteAsync);

            _logger.LogBeginInformation(methodName);

            IContentScope contentScope = (IContentScope)scope;
            (string sqlStatement,
             object parameterId,
             CommandType commandType) = UserEntityConfig.GetDeleteSqlStatement(id);

            _ = await _dbContext.ExecuteAsync(
                contentScope.Connection,
                sqlStatement,
                parameterId,
                contentScope.DbTransaction,
                commandType
            ).ConfigureAwait(false);

            _logger.LogEndInformation(methodName);
        }

        /// <summary>
        /// Creates the record in the user table and asynchronously using Task.
        /// </summary>
        /// <param name="scope">Transactional scope</param>
        /// <param name="entity">User entity</param>
        /// <returns>Task: Represents an asynchronous operation.</returns>
        public async Task InsertAsync(IScope scope, UserEntity entity)
        {
            string methodName = nameof(InsertAsync);

            _logger.LogBeginInformation(methodName);

            IContentScope contentScope = (IContentScope)scope;
            (string sqlStatement,
             CommandType commandType) = UserEntityConfig.GetInsertSqlStatement();

            entity.Id = await _dbContext.ExecuteScalarAsync<object, long>(
                contentScope.Connection,
                sqlStatement,
                entity.GetInsertParameters(),
                contentScope.DbTransaction,
                commandType
            ).ConfigureAwait(false);

            _logger.LogEndInformation(methodName);
        }

        /// <summary>
        /// Query records in the user table and asynchronously using Task.
        /// </summary>
        /// <param name="scope">Transactional scope</param>
        /// <returns>
        /// Task: Represents an asynchronous operation. 
        /// Returns an enumerator that iterates through the user entity collection.
        /// </returns>
        public async Task<IEnumerable<UserEntity>> SelectAllAsync(IScope scope)
        {
            string methodName = nameof(SelectAllAsync);

            _logger.LogBeginInformation(methodName);

            IContentScope contentScope = (IContentScope)scope;
            (string sqlStatement,
             CommandType commandType) = UserEntityConfig.GetSelectSqlStatement();

            IEnumerable<UserEntity> result = await _dbContext.QueryAsync<UserEntity>(
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
        /// Query the record in the user table and asynchronously using Task.
        /// </summary>
        /// <param name="scope">Transactional scope</param>
        /// <param name="id">User identifier</param>
        /// <returns>
        /// Task: Represents an asynchronous operation. 
        /// Returns the user entity.
        /// </returns>
        public async Task<UserEntity> SelectByIdAsync(IScope scope, long id)
        {
            string methodName = nameof(SelectByIdAsync);

            _logger.LogBeginInformation(methodName);

            IContentScope contentScope = (IContentScope)scope;
            (string sqlStatement,
             object parameterId,
             CommandType commandType) = UserEntityConfig.GetSelectByIdSqlStatement(id);

            UserEntity result = await _dbContext.QueryFirstOrDefaultAsync<UserEntity>(
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
        /// Query the record in the user table by username/password and asynchronously using Task.
        /// </summary>
        /// <param name="scope">Transactional scope</param>
        /// <param name="username">Username</param>
        /// <param name="password">User password</param>
        /// <returns>
        /// Task: Represents an asynchronous operation. 
        /// Returns the user entity.
        /// </returns>
        public async Task<UserEntity> SelectUserAsync(IScope scope, string username, string password)
        {
            string methodName = nameof(SelectUserAsync);

            _logger.LogBeginInformation(methodName);

            IContentScope contentScope = (IContentScope)scope;
            (string sqlStatement,
             object parameters,
             CommandType commandType) = UserEntityConfig.GetSelectUserSqlStatement(username, password);

            UserEntity result = await _dbContext.QueryFirstOrDefaultAsync<UserEntity>(
                contentScope.Connection,
                sqlStatement,
                parameters,
                contentScope.DbTransaction,
                commandType
            ).ConfigureAwait(false);

            _logger.LogEndInformation(methodName);

            return result;
        }

        /// <summary>
        /// Updates the record from the user table and asynchronously using Task.
        /// </summary>
        /// <param name="scope">Transactional scope</param>
        /// <param name="entity">User entity</param>
        /// <returns>Task: Represents an asynchronous operation.</returns>
        public async Task UpdateAsync(IScope scope, UserEntity entity)
        {
            string methodName = nameof(UpdateAsync);

            _logger.LogBeginInformation(methodName);

            IContentScope contentScope = (IContentScope)scope;
            (string sqlStatement,
             CommandType commandType) = UserEntityConfig.GetUpdateSqlStatement();

            _ = await _dbContext.ExecuteAsync(
                contentScope.Connection,
                sqlStatement,
                entity.GetUpdateParameters(),
                contentScope.DbTransaction,
                commandType
            ).ConfigureAwait(false);

            _logger.LogEndInformation(methodName);
        }

        /// <summary>
        /// Change the user password in the user table and asynchronously using Task.
        /// </summary>
        /// <param name="scope">Transactional scope</param>
        /// <param name="username">Username</param>
        /// <param name="oldPassword">User old password</param>
        /// <param name="newPassword">User new password</param>
        /// <returns>Returns true if the password has been changed.</returns>
        public async Task<bool> ChangePasswordAsync(IScope scope, string username, string oldPassword, string newPassword)
        {
            string methodName = nameof(ChangePasswordAsync);

            _logger.LogBeginInformation(methodName);

            IContentScope contentScope = (IContentScope)scope;
            (string sqlStatement,
             object parameters,
             CommandType commandType) = UserEntityConfig.GetUpdateChangePassSqlStatement(username, oldPassword, newPassword);

            bool wasChanged = await _dbContext.ExecuteScalarAsync<object, bool>(
                contentScope.Connection,
                sqlStatement,
                parameters,
                contentScope.DbTransaction,
                commandType
            ).ConfigureAwait(false);

            _logger.LogEndInformation(methodName);

            return wasChanged;
        }

        #endregion

        #endregion
    }
}
