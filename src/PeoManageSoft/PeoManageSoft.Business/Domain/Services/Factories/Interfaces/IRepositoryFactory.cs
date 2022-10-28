using PeoManageSoft.Business.Infrastructure;
using PeoManageSoft.Business.Infrastructure.ObjectRelationalMapper.Interfaces;

namespace PeoManageSoft.Business.Domain.Services.Factories.Interfaces
{
    /// <summary>
    /// Create objects from repositories
    /// </summary>
    internal interface IRepositoryFactory
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
        IRule<TEntityField> CreateRule<TEntityField>(
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
        IRule<TEntityField> CreateRule<TEntityField>(params IRule<TEntityField>[] rules);

        /// <summary>
        /// Create a rule to filter the data.
        /// </summary>
        /// <typeparam name="TEntityField">Entity fields types</typeparam>
        /// <param name="sqlOperator">Operator of the sql </param>
        /// <param name="rules">Rules to filter the data.</param>
        /// <returns>Returns the rule object.</returns>
        IRule<TEntityField> CreateRule<TEntityField>(SqlOperator sqlOperator, params IRule<TEntityField>[] rules);

        #endregion
    }
}
