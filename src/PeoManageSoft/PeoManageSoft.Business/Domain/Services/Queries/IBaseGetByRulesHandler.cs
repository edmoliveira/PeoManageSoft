using PeoManageSoft.Business.Infrastructure;
using PeoManageSoft.Business.Infrastructure.ObjectRelationalMapper.Interfaces;

namespace PeoManageSoft.Business.Domain.Services.Queries
{
    /// <summary>
    /// Base class to handle all queries to get by rules
    /// </summary>
    /// <typeparam name="TEntityField">Entity fields types</typeparam>
    internal interface IBaseGetByRulesHandler<TEntityField>
    {
        #region Methods

        /// <summary>
        /// Create a rule to filter the data.
        /// </summary>
        /// <typeparam name="TEntityField">Entity fields types</typeparam>
        /// <param name="entityField">Entity field.</param>
        /// <param name="comparisonOperator">Comparison operator of SQL</param>
        /// <param name="Value">Parameter value</param>
        /// <param name="SqlOperator">Operator of the sql </param>
        /// <returns>Returns the rule object.</returns>
        IRule<TEntityField> CreateRule(
            TEntityField entityField,
            SqlComparisonOperator comparisonOperator,
            object value,
            SqlOperator? sqlOperator = null);

        /// <summary>
        /// Create a rule to filter the data.
        /// </summary>
        /// <typeparam name="TEntityField">Entity fields types</typeparam>
        /// <param name="rules">Rules to filter the data.</param>
        /// <returns>Returns the rule object.</returns>
        IRule<TEntityField> CreateRule(params IRule<TEntityField>[] rules);

        /// <summary>
        /// Create a rule to filter the data.
        /// </summary>
        /// <typeparam name="TEntityField">Entity fields types</typeparam>
        /// <param name="sqlOperator">Operator of the sql </param>
        /// <param name="rules">Rules to filter the data.</param>
        /// <returns>Returns the rule object.</returns>
        IRule<TEntityField> CreateRule(SqlOperator sqlOperator, params IRule<TEntityField>[] rules);

        #endregion
    }
}
