using PeoManageSoft.Business.Infrastructure.Helpers.Interfaces;
using System.Data;

namespace PeoManageSoft.Business.Infrastructure.Repositories.User
{
    /// <summary>
    /// User entity stored procedures
    /// </summary>
    static class UserEntityConfig
    {
        #region Methods

        #region public

        /// <summary>
        /// Stored procedures "DELETE"
        /// </summary>
        /// <param name="id">User identifier value</param>
        /// <returns>
        /// Returns the sql statement, the parameter id and the command type.
        /// </returns>
        public static (string sqlStatement, object parameterId, CommandType commandType) GetDeleteSqlStatement(long id)
        {
            return (sqlStatement: "[SP_DELETE_User]", parameterId: new { Id = id }, CommandType.StoredProcedure);
        }

        /// <summary>
        /// Stored procedures "INSERT"
        /// </summary>
        /// <returns>
        /// Returns the sql statement and the command type.
        /// </returns>
        public static (string sqlStatement, CommandType commandType) GetInsertSqlStatement()
        {
            return (sqlStatement: "[SP_INSERT_User]", CommandType.StoredProcedure);
        }

        /// <summary>
        /// Stored procedures "DELETE"
        /// </summary>
        /// <param name="id">User identifier value</param>
        /// <returns>
        /// Returns the sql statement and the command type.
        /// </returns>
        public static (string sqlStatement, object parameterId, CommandType commandType) GetSelectByIdSqlStatement(long id)
        {
            return (sqlStatement: "[SP_SELECT_BY_ID_User]", parameterId: new { Id = id }, CommandType.StoredProcedure);
        }

        /// <summary>
        /// Stored procedures "SELECT"
        /// </summary>
        /// <returns>Returns the sql statement and the command type.</returns>
        public static (string sqlStatement, CommandType commandType) GetSelectSqlStatement()
        {
            return (sqlStatement: "[SP_SELECT_User]", CommandType.StoredProcedure);
        }

        /// <summary>
        /// Stored procedures "UPDATE"
        /// </summary>
        /// <returns>Returns the sql statement and the command type.</returns>
        public static (string sqlStatement, CommandType commandType) GetUpdateSqlStatement()
        {
            return (sqlStatement: "[SP_UPDATE_User]", CommandType.StoredProcedure);
        }

        /// <summary>
        /// Stored procedures "SP_SELECT_AUTH_User"
        /// </summary>
        /// <param name="username">Username</param>
        /// <param name="password">User password</param>
        /// <returns>Returns the sql statement, the parameters and the command type</returns>
        public static (string sqlStatement, object parameters, CommandType commandType) GetSelectUserSqlStatement(string username, string password)
        {
            return (sqlStatement: "[SP_SELECT_AUTH_User]", parameters: new { Username = username, Password = password }, CommandType.StoredProcedure);
        }

        /// <summary>
        /// Stored procedures "SP_UPDATE_CHANGE_PASS_User"
        /// </summary>
        /// <param name="username">Username</param>
        /// <param name="oldPassword">User old password</param>
        /// <param name="newPassword">User new password</param>
        /// <param name="applicationContext">Class to be used on one instance throughout the application per request</param>
        /// <returns>Returns the sql statement, the parameters and the command type</returns>
        public static (string sqlStatement, object parameters, CommandType commandType) GetUpdateChangePassSqlStatement(string username, string oldPassword, string newPassword, IApplicationContext applicationContext)
        {
            return (sqlStatement: "[SP_UPDATE_CHANGE_PASS_User]", parameters: new
            {
                Username = username,
                Password = oldPassword,
                NewPassword = newPassword,
                applicationContext.RequestId,
                UpdatedUserId = applicationContext.LoggedUser.Id,
                UpdatedDate = DateTime.Now
            }, CommandType.StoredProcedure);
        }

        #endregion

        #endregion
    }
}
