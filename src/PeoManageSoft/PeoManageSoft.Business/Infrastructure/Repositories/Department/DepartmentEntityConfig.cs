using System.Data;

namespace PeoManageSoft.Business.Infrastructure.Repositories.Department
{
    /// <summary>
    /// Department entity stored procedures
    /// </summary>
    static class DepartmentEntityConfig
    {
        #region Methods

        #region public

        /// <summary>
        /// Stored procedures "DELETE"
        /// </summary>
        /// <param name="id">Department identifier value</param>
        /// <returns>
        /// Returns the sql statement, the parameter id and the command type.
        /// </returns>
        public static (string sqlStatement, object parameterId, CommandType commandType) GetDeleteSqlStatement(long id)
        {
            return (sqlStatement: "[SP_DELETE_Department]", parameterId: new { Id = id }, CommandType.StoredProcedure);
        }

        /// <summary>
        /// Stored procedures "EXISTS BY ID"
        /// </summary>
        /// <param name="id">Department identifier value</param>
        /// <returns>
        /// Returns the sql statement and the command type.
        /// </returns>
        public static (string sqlStatement, object parameterId, CommandType commandType) GetExistsByIdSqlStatement(long id)
        {
            return (sqlStatement: "[SP_EXISTS_BY_ID_Department]", parameterId: new { Id = id }, CommandType.StoredProcedure);
        }

        /// <summary>
        /// Stored procedures "INSERT"
        /// </summary>
        /// <returns>
        /// Returns the sql statement and the command type.
        /// </returns>
        public static (string sqlStatement, CommandType commandType) GetInsertSqlStatement()
        {
            return (sqlStatement: "[SP_INSERT_Department]", CommandType.StoredProcedure);
        }

        /// <summary>
        /// Stored procedures "SELECT BY ID"
        /// </summary>
        /// <param name="id">Department identifier value</param>
        /// <returns>
        /// Returns the sql statement and the command type.
        /// </returns>
        public static (string sqlStatement, object parameterId, CommandType commandType) GetSelectByIdSqlStatement(long id)
        {
            return (sqlStatement: "[SP_SELECT_BY_ID_Department]", parameterId: new { Id = id }, CommandType.StoredProcedure);
        }

        /// <summary>
        /// Stored procedures "SELECT"
        /// </summary>
        /// <returns>Returns the sql statement and the command type.</returns>
        public static (string sqlStatement, CommandType commandType) GetSelectSqlStatement()
        {
            return (sqlStatement: "[SP_SELECT_Department]", CommandType.StoredProcedure);
        }

        /// <summary>
        /// Stored procedures "UPDATE"
        /// </summary>
        /// <returns>Returns the sql statement and the command type.</returns>
        public static (string sqlStatement, CommandType commandType) GetUpdateSqlStatement()
        {
            return (sqlStatement: "[SP_UPDATE_Department]", CommandType.StoredProcedure);
        }

        #endregion

        #endregion
    }
}
