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
            return (sqlStatement: "sp_delete_user", parameterId: new { Id = id }, CommandType.StoredProcedure);
        }

        /// <summary>
        /// Stored procedures "EXISTS BY ID"
        /// </summary>
        /// <param name="id">User identifier value</param>
        /// <returns>
        /// Returns the sql statement and the command type.
        /// </returns>
        public static (string sqlStatement, object parameterId, CommandType commandType) GetExistsByIdSqlStatement(long id)
        {
            return (sqlStatement: "sp_exists_by_id_user", parameterId: new { Id = id }, CommandType.StoredProcedure);
        }

        /// <summary>
        /// Stored procedures "INSERT"
        /// </summary>
        /// <returns>
        /// Returns the sql statement and the command type.
        /// </returns>
        public static (string sqlStatement, CommandType commandType) GetInsertSqlStatement()
        {
            return (sqlStatement: "sp_insert_user", CommandType.StoredProcedure);
        }

        /// <summary>
        /// Stored procedures "SELECT BY ID"
        /// </summary>
        /// <param name="id">User identifier value</param>
        /// <returns>
        /// Returns the sql statement and the command type.
        /// </returns>
        public static (string sqlStatement, object parameterId, string splitOn, CommandType commandType) GetSelectByIdSqlStatement(long id)
        {
            return (sqlStatement: "sp_select_by_id_user", parameterId: new { Id = id }, splitOn: "TitleId,DepartmentId", CommandType.StoredProcedure);
        }

        /// <summary>
        /// Stored procedures "SELECT"
        /// </summary>
        /// <returns>Returns the sql statement, splitOn and the command type.</returns>
        public static (string sqlStatement, string splitOn, CommandType commandType) GetSelectSqlStatement()
        {
            return (sqlStatement: "sp_select_user", splitOn: "TitleId,DepartmentId", CommandType.StoredProcedure);
        }

        /// <summary>
        /// Stored procedures "UPDATE"
        /// </summary>
        /// <returns>Returns the sql statement and the command type.</returns>
        public static (string sqlStatement, CommandType commandType) GetUpdateSqlStatement()
        {
            return (sqlStatement: "sp_update_user", CommandType.StoredProcedure);
        }

        /// <summary>
        /// Stored procedures "SP_SELECT_AUTH_User"
        /// </summary>
        /// <param name="username">Username</param>
        /// <param name="password">User password</param>
        /// <returns>Returns the sql statement, the parameters and the command type</returns>
        public static (string sqlStatement, object parameters, CommandType commandType) GetSelectUserSqlStatement(string username, string password)
        {
            return (sqlStatement: "sp_select_auth_user", parameters: new { Username = username, Password = password }, CommandType.StoredProcedure);
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
            return (sqlStatement: "sp_update_change_pass_user", parameters: new
            {
                username,
                password = oldPassword,
                newpassword = newPassword,
                requestid = applicationContext.RequestId,
                updateduser = applicationContext.LoggedUser.User,
                updateddate = DateTime.Now
            }, CommandType.StoredProcedure);
        }

        #endregion

        #endregion
    }
}
