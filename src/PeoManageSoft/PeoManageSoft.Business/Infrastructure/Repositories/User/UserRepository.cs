using Microsoft.Extensions.Logging;
using PeoManageSoft.Business.Infrastructure.Helpers.Extensions;
using PeoManageSoft.Business.Infrastructure.Helpers.Interfaces;
using PeoManageSoft.Business.Infrastructure.ObjectRelationalMapper.Interfaces;
using PeoManageSoft.Business.Infrastructure.Repositories.Department;
using PeoManageSoft.Business.Infrastructure.Repositories.Interfaces;
using PeoManageSoft.Business.Infrastructure.Repositories.Title;
using System.Data;

namespace PeoManageSoft.Business.Infrastructure.Repositories.User
{
    /// <summary>
    /// User encapsulation of logic to access data sources.
    /// </summary>
    internal sealed class UserRepository : BaseRepository, IUserRepository
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the PeoManageSoft.Business.Infrastructure.Repositories.User.UserRepository class.
        /// </summary>
        /// <param name="dbContext">Represents a session with the underlying database using which you can perform CRUD (Create, Read, Update, Delete) operations.</param>
        /// <param name="applicationContext">Class to be used on one instance throughout the application per request</param>
        /// <param name="provider">Defines a mechanism for retrieving a service object; that is, an object that provides custom support to other objects.</param>
        /// <param name="logger">Log</param>
        public UserRepository(
            IDbContext dbContext, 
            IApplicationContext applicationContext,
            IServiceProvider provider,
            ILogger<UserRepository> logger)
            :base(dbContext, applicationContext, provider, logger)
        {
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

            Logger.LogBeginInformation(methodName);

            IContentScope contentScope = (IContentScope)scope;
            (string sqlStatement,
             object parameterId,
             CommandType commandType) = UserEntityConfig.GetDeleteSqlStatement(id);

            _ = await DbContext.ExecuteAsync(
                contentScope.Connection,
                sqlStatement,
                parameterId,
                contentScope.DbTransaction,
                commandType
            ).ConfigureAwait(false);

            Logger.LogEndInformation(methodName);
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

            Logger.LogBeginInformation(methodName);

            IContentScope contentScope = (IContentScope)scope;
            (string sqlStatement,
             object parameterId,
             CommandType commandType) = UserEntityConfig.GetExistsByIdSqlStatement(id);

            bool result = await DbContext.ExecuteScalarAsync<object, bool>(
                contentScope.Connection,
                sqlStatement,
                parameterId,
                contentScope.DbTransaction,
                commandType
            ).ConfigureAwait(false);

            Logger.LogEndInformation(methodName);

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

            Logger.LogBeginInformation(methodName);

            IContentScope contentScope = (IContentScope)scope;
            (string sqlStatement,
             object parameters,
             CommandType commandType) = UserEntityConfig.GetInsertSqlStatement(
                 Provider,
                 entity,
                 ApplicationContext);

            IEntity ientity = entity;

            long id = await DbContext.ExecuteScalarAsync<object, long>(
                contentScope.Connection,
                sqlStatement,
                parameters,
                contentScope.DbTransaction,
                commandType
            ).ConfigureAwait(false);

            ientity.SetId(id);

            Logger.LogEndInformation(methodName);
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

            Logger.LogBeginInformation(methodName);

            IContentScope contentScope = (IContentScope)scope;
            (string sqlStatement,
             string splitOn,
             CommandType commandType) = UserEntityConfig.GetSelectSqlStatement();

            IEnumerable<UserEntity> result = await DbContext.QueryAsync<UserEntity, TitleEntity, DepartmentEntity, UserEntity>(
                contentScope.Connection,
                SetRelationships,
                sqlStatement,
                null,
                splitOn,
                contentScope.DbTransaction,
                commandType
            ).ConfigureAwait(false);

            Logger.LogEndInformation(methodName);

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

            Logger.LogBeginInformation(methodName);

            IContentScope contentScope = (IContentScope)scope;
            (string sqlStatement,
             object parameterId,
             string splitOn,
             CommandType commandType) = UserEntityConfig.GetSelectByIdSqlStatement(id);

            IEnumerable<UserEntity> result = await DbContext.QueryAsync<UserEntity, TitleEntity, DepartmentEntity, UserEntity>(
                contentScope.Connection,
                SetRelationships,
                sqlStatement,
                parameterId,
                splitOn,
                contentScope.DbTransaction,
                commandType
            ).ConfigureAwait(false);

            Logger.LogEndInformation(methodName);

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

            Logger.LogBeginInformation(methodName);

            IContentScope contentScope = (IContentScope)scope;
            (string sqlStatement,
             object parameterId,
             string splitOn,
             CommandType commandType) = UserEntityConfig.GetSelectUserSqlStatement(username, password);

            IEnumerable<UserEntity> result = await DbContext.QueryAsync<UserEntity, TitleEntity, DepartmentEntity, UserEntity>(
                contentScope.Connection,
                SetRelationships,
                sqlStatement,
                parameterId,
                splitOn,
                contentScope.DbTransaction,
                commandType
            ).ConfigureAwait(false);

            Logger.LogEndInformation(methodName);

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

            Logger.LogBeginInformation(methodName);

            IContentScope contentScope = (IContentScope)scope;
            (string sqlStatement,
             object parameters,
             CommandType commandType) = UserEntityConfig.GetUpdateSqlStatement(
                 Provider,
                 entity,
                 ApplicationContext);

            IEntity ientity = entity;

            _ = await DbContext.ExecuteAsync(
                contentScope.Connection,
                sqlStatement,
                parameters,
                contentScope.DbTransaction,
                commandType
            ).ConfigureAwait(false);

            Logger.LogEndInformation(methodName);
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

            Logger.LogBeginInformation(methodName);

            IContentScope contentScope = (IContentScope)scope;
            (string sqlStatement,
             object parameters,
             CommandType commandType) = UserEntityConfig.GetUpdateChangePassSqlStatement(
                 Provider, username, oldPassword, newPassword, ApplicationContext
             );

            bool wasChanged = await DbContext.ExecuteScalarAsync<object, bool>(
                contentScope.Connection,
                sqlStatement,
                parameters,
                contentScope.DbTransaction,
                commandType
            ).ConfigureAwait(false);

            Logger.LogEndInformation(methodName);

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

            Logger.LogBeginInformation(methodName);

            IContentScope contentScope = (IContentScope)scope;
            (string sqlStatement,
             object parameters,
             CommandType commandType) = UserEntityConfig.GetValidateInsertSqlStatement(
                 Provider,
                 entity);

            IEntity ientity = entity;

            IEnumerable<string> result = await DbContext.QueryAsync<string>(
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

            Logger.LogBeginInformation(methodName);

            IContentScope contentScope = (IContentScope)scope;
            (string sqlStatement,
             object parameters,
             CommandType commandType) = UserEntityConfig.GetValidateUpdateSqlStatement(
                Provider,
                entity);

            IEntity ientity = entity;

            IEnumerable<string> result = await DbContext.QueryAsync<string>(
                contentScope.Connection,
                sqlStatement,
                parameters,
                contentScope.DbTransaction,
                commandType
            ).ConfigureAwait(false);

            Logger.LogEndInformation(methodName);

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
