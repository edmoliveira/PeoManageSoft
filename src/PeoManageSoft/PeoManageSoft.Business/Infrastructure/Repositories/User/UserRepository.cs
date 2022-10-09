using Microsoft.Extensions.Logging;
using PeoManageSoft.Business.Infrastructure.Helpers.Extensions;
using PeoManageSoft.Business.Infrastructure.Helpers.Interfaces;
using PeoManageSoft.Business.Infrastructure.ObjectRelationalMapper;
using PeoManageSoft.Business.Infrastructure.Repositories.Department;
using PeoManageSoft.Business.Infrastructure.Repositories.Interfaces;
using PeoManageSoft.Business.Infrastructure.Repositories.Title;
using System.Data;

namespace PeoManageSoft.Business.Infrastructure.Repositories.User
{
    /// <summary>
    /// User encapsulation of logic to access data sources.
    /// </summary>
    internal sealed class UserRepository : IUserRepository
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
        private readonly ILogger<UserRepository> _logger;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the PeoManageSoft.Business.Infrastructure.Repositories.User.UserRepository class.
        /// </summary>
        /// <param name="dbContext">Represents a session with the underlying database using which you can perform CRUD (Create, Read, Update, Delete) operations.</param>
        /// <param name="applicationContext">Class to be used on one instance throughout the application per request</param>
        /// <param name="logger">Log</param>
        public UserRepository(IDbContext dbContext, IApplicationContext applicationContext, ILogger<UserRepository> logger)
        {
            _dbContext = dbContext;
            _applicationContext = applicationContext;
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

        /// Determines whether the specified user table contains the record that match the id
        /// </summary>
        /// <param name="scope">Transactional scope</param>
        /// <param name="id">User identifier</param>
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
             CommandType commandType) = UserEntityConfig.GetExistsByIdSqlStatement(id);

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
             string splitOn,
             CommandType commandType) = UserEntityConfig.GetSelectSqlStatement();

            IEnumerable<UserEntity> result = await _dbContext.QueryAsync<UserEntity, TitleEntity, DepartmentEntity, UserEntity>(
                contentScope.Connection,
                SetRelationships,
                sqlStatement,
                null,
                splitOn,
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
             string splitOn,
             CommandType commandType) = UserEntityConfig.GetSelectByIdSqlStatement(id);

            IEnumerable<UserEntity> result = await _dbContext.QueryAsync<UserEntity, TitleEntity, DepartmentEntity, UserEntity>(
                contentScope.Connection,
                SetRelationships,
                sqlStatement,
                parameterId,
                splitOn,
                contentScope.DbTransaction,
                commandType
            ).ConfigureAwait(false);

            _logger.LogEndInformation(methodName);

            return result.FirstOrDefault();
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
             object parameterId,
             string splitOn,
             CommandType commandType) = UserEntityConfig.GetSelectUserSqlStatement(username, password);

            IEnumerable<UserEntity> result = await _dbContext.QueryAsync<UserEntity, TitleEntity, DepartmentEntity, UserEntity>(
                contentScope.Connection,
                SetRelationships,
                sqlStatement,
                parameterId,
                splitOn,
                contentScope.DbTransaction,
                commandType
            ).ConfigureAwait(false);

            _logger.LogEndInformation(methodName);

            return result.FirstOrDefault();
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
             CommandType commandType) = UserEntityConfig.GetUpdateChangePassSqlStatement(username, oldPassword, newPassword, _applicationContext);

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

        /// <summary>
        /// Validates whether inserting into the user table is allowed and asynchronously using Task.
        /// </summary>
        /// <param name="scope">Transactional scope</param>
        ///  <param name="entity">User Entity</param>
        /// <returns>
        /// Task: Represents an asynchronous operation. 
        /// Returns an enumerator that iterates through the validation collection.
        /// </returns>
        public async Task<IEnumerable<string>> ValidateInsertAsync(IScope scope, UserEntity entity)
        {
            string methodName = nameof(ValidateInsertAsync);

            _logger.LogBeginInformation(methodName);

            IContentScope contentScope = (IContentScope)scope;
            (string sqlStatement,
             CommandType commandType) = UserEntityConfig.GetValidateInsertSqlStatement();

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
        /// Validates whether updating into the user table is allowed and asynchronously using Task.
        /// </summary>
        /// <param name="scope">Transactional scope</param>
        ///  <param name="entity">User entity</param>
        /// <returns>
        /// Task: Represents an asynchronous operation. 
        /// Returns an enumerator that iterates through the validation collection.
        /// </returns>
        public async Task<IEnumerable<string>> ValidateUpdateAsync(IScope scope, UserEntity entity)
        {
            string methodName = nameof(ValidateUpdateAsync);

            _logger.LogBeginInformation(methodName);

            IContentScope contentScope = (IContentScope)scope;
            (string sqlStatement,
             CommandType commandType) = UserEntityConfig.GetValidateUpdateSqlStatement();

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

        #region private 

        /// <summary>
        /// Defines user entity relationships
        /// </summary>
        /// <param name="userEntity">User entity</param>
        /// <param name="titleEntity">Title entity</param>
        /// <param name="departmentEntity">Department entity</param>
        /// <returns></returns>
        private static UserEntity SetRelationships(UserEntity userEntity, TitleEntity titleEntity, DepartmentEntity departmentEntity)
        {
            IUser user = userEntity;

            user.SetTitle(titleEntity);
            user.SetDepartment(departmentEntity);

            return userEntity;
        }

        #endregion

        #endregion
    }
}
