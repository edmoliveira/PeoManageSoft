using PeoManageSoft.Business.Infrastructure.ObjectRelationalMapper;
using PeoManageSoft.Business.Infrastructure.ObjectRelationalMapper.Interfaces;
using System.Data;

namespace PeoManageSoft.Business.Infrastructure.Repositories.Interfaces
{
    /// <summary>
    /// Entity configuration base class
    /// </summary>
    /// <typeparam name="TEntity">Mapping to a database table</typeparam>
    /// <typeparam name="TEntityField">Entity fields types</typeparam>
    internal interface IBaseEntityConfig<TEntity, TEntityField>
    {
        #region Methods

        /// <summary>
        /// Gets a function to look up the entity property value.
        /// </summary>
        /// <returns>Func<object, IDataReader, object></returns>
        Func<object, IDataReader, object> GetFuncSearchValue();

        /// <summary>
        /// Stored procedures "DELETE"
        /// </summary>
        /// <param name="id">User identifier value</param>
        /// <returns>
        /// Returns the sql statement, parameters and the command type.
        /// </returns>
        (string sqlStatement, IEnumerable<IParameter> parameters, CommandType commandType) GetDeleteSqlStatement(long id);

        /// <summary>
        /// Stored procedures "INSERT"
        /// </summary>
        /// <param name="entity">Entity user.</param>
        /// <returns>Returns the sql statement, parameters and the command type.</returns>
        (string sqlStatement, IEnumerable<IParameter> parameters, CommandType commandType) GetInsertSqlStatement(TEntity entity);

        /// <summary>
        /// Gets select exists command of the entity by id.
        /// </summary>
        /// <param name="id">User identifier value</param>
        /// <returns>
        /// Returns the sql statement, parameters and the command type.
        /// </returns>
        (string sqlStatement, IEnumerable<IParameter> parameters, CommandType commandType) GetExistsByIdSqlStatement(long id);
        /// <summary>
        /// Gets select exists command of the entity by rules.
        /// </summary>
        /// <param name="rule"></param>
        /// <returns>
        /// Returns the sql statement, parameters and the command type.
        /// </returns>
        (string sqlStatement, IEnumerable<IParameter> parameters, CommandType commandType) GetSelectExistsByRulesSqlStatement(IRule<TEntityField> rule);

        /// <summary>
        /// Gets select command of the entity by id.
        /// </summary>
        /// <param name="id">User identifier value</param>
        /// <returns>
        /// Returns the sql statement, parameters and the command type.
        /// </returns>
        (string sqlStatement, IEnumerable<IParameter> parameters, CommandType commandType) GetSelectByIdSqlStatement(long id);

        /// <summary>
        /// Gets select command of the entity by rules.
        /// </summary>
        /// <param name="rule"></param>
        /// <returns>
        /// Returns the sql statement, parameters and the command type.
        /// </returns>
        (string sqlStatement, IEnumerable<IParameter> parameters, CommandType commandType) GetSelectByRulesSqlStatement(IRule<TEntityField> rule);

        /// <summary>
        /// Gets select all command of the entity.
        /// </summary>
        /// <returns>Returns the sql statement, parameters and the command type.</returns>
        (string sqlStatement, IEnumerable<IParameter> parameters, CommandType commandType) GetSelectAllSqlStatement();

        /// <summary>
        /// Gets select command of the entity with pagination by rules
        /// </summary>
        /// <param name="page">Current page</param>
        /// <param name="quantityPerPage">Quantity per page</param>
        /// <param name="orderBy">OrderBy sql command</param>
        /// <param name="rule">Rules to filter the data</param>
        /// <returns>Returns the sql statement, parameters and the command type.</returns>
        (string sqlStatement, IEnumerable<IParameter> parameters, CommandType commandType) GetSelectByRulesSqlStatementWithPagination(int page, int quantityPerPage, OrderBy<TEntityField> orderBy, IRule<TEntityField> rule);

        /// <summary>
        /// Stored procedures "UPDATE"
        /// </summary>
        /// <param name="entity">Entity user.</param>
        /// <returns>Returns the sql statement,parameters and the command type.</returns>
        (string sqlStatement, IEnumerable<IParameter> parameters, CommandType commandType) GetUpdateSqlStatement(TEntity entity);

        /// <summary>
        /// The sql statement to update the fields
        /// </summary>
        /// <param name="fields">Fields that will be updated</param>
        /// <param name="id">Identifier value</param>
        /// <returns>Returns the sql statement, the parameters and the command type</returns>
        (string sqlStatement, IEnumerable<IParameter> parameters, CommandType commandType) GetPatchSqlStatement(IEnumerable<Field<TEntityField>> fields, long id);

        /// <summary>
        /// Gets select all command of the entity with pagination.
        /// </summary>
        /// <param name="page">Current page</param>
        /// <param name="quantityPerPage">Quantity per page</param>
        /// <param name="orderBy">OrderBy sql command</param>
        /// <returns>Returns the sql statement, parameters and the command type.</returns>
        (string sqlStatement, IEnumerable<IParameter> parameters, CommandType commandType) GetSelectAllSqlStatementWithPagination(int page, int quantityPerPage, OrderBy<TEntityField> orderBy);

        #endregion
    }
}
