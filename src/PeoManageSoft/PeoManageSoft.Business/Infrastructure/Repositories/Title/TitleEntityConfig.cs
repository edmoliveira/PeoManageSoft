using System.Data;

namespace PeoManageSoft.Business.Infrastructure.Repositories.Title
{
    /// <summary>
    /// Title entity stored procedures
    /// </summary>
    static class TitleEntityConfig
    {
        #region Methods

        #region public

        /// <summary>
        /// Stored procedures "DELETE"
        /// </summary>
        /// <param name="id">Title identifier value</param>
        /// <returns>
        /// Returns the sql statement, the parameter id and the command type.
        /// </returns>
        public static (string sqlStatement, object parameterId, CommandType commandType) GetDeleteSqlStatement(long id)
        {
            return (sqlStatement: "sp_delete_title", parameterId: new { Id = id }, CommandType.StoredProcedure);
        }

        /// <summary>
        /// Stored procedures "EXISTS BY ID"
        /// </summary>
        /// <param name="id">Title identifier value</param>
        /// <returns>
        /// Returns the sql statement and the command type.
        /// </returns>
        public static (string sqlStatement, object parameterId, CommandType commandType) GetExistsByIdSqlStatement(long id)
        {
            return (sqlStatement: "sp_exists_by_id_title", parameterId: new { Id = id }, CommandType.StoredProcedure);
        }

        /// <summary>
        /// Stored procedures "INSERT"
        /// </summary>
        /// <returns>
        /// Returns the sql statement and the command type.
        /// </returns>
        public static (string sqlStatement, CommandType commandType) GetInsertSqlStatement()
        {
            return (sqlStatement: "sp_insert_title", CommandType.StoredProcedure);
        }

        /// <summary>
        /// Stored procedures "SELECT BY ID"
        /// </summary>
        /// <param name="id">Title identifier value</param>
        /// <returns>
        /// Returns the sql statement and the command type.
        /// </returns>
        public static (string sqlStatement, object parameterId, CommandType commandType) GetSelectByIdSqlStatement(long id)
        {
            return (sqlStatement: "sp_select_by_id_title", parameterId: new { Id = id }, CommandType.StoredProcedure);
        }

        /// <summary>
        /// Stored procedures "SELECT"
        /// </summary>
        /// <returns>Returns the sql statement and the command type.</returns>
        public static (string sqlStatement, CommandType commandType) GetSelectSqlStatement()
        {
            return (sqlStatement: "sp_select_title", CommandType.StoredProcedure);
        }

        /// <summary>
        /// Stored procedures "UPDATE"
        /// </summary>
        /// <returns>Returns the sql statement and the command type.</returns>
        public static (string sqlStatement, CommandType commandType) GetUpdateSqlStatement()
        {
            return (sqlStatement: "sp_update_title", CommandType.StoredProcedure);
        }

        /// <summary>
        /// Stored procedures "VALIDATE INSERT"
        /// </summary>
        /// <returns>
        /// Returns the sql statement and the command type.
        /// </returns>
        public static (string sqlStatement, CommandType commandType) GetValidateInsertSqlStatement()
        {
            return (sqlStatement: "sp_validate_insert_title", CommandType.StoredProcedure);
        }

        /// <summary>
        /// Stored procedures "VALIDATE UPDATE"
        /// </summary>
        /// <returns>
        /// Returns the sql statement and the command type.
        /// </returns>
        public static (string sqlStatement, CommandType commandType) GetValidateUpdateSqlStatement()
        {
            return (sqlStatement: "sp_validate_update_title", CommandType.StoredProcedure);
        }

        #endregion

        #endregion
    }
}
