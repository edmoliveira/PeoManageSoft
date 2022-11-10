using PeoManageSoft.Business.Domain.Services.Factories.Interfaces;
using PeoManageSoft.Business.Infrastructure;
using PeoManageSoft.Business.Infrastructure.ObjectRelationalMapper.Interfaces;

namespace PeoManageSoft.Business.Domain.Services.Queries
{
    /// <summary>
    /// Base class to handle all queries to get by rules
    /// </summary>
    /// <typeparam name="TEntityField">Entity fields types</typeparam>
    internal abstract class BaseGetByRulesHandler<TEntityField>
    {
        #region Fields

        /// <summary>
        /// Create objects from repositories
        /// </summary>
        private readonly IRepositoryFactory _repositoryFactory;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the PeoManageSoft.Business.Domain.Services.Queries.BaseGetByRulesHandler class.
        /// </summary>
        /// <param name="repositoryFactory">Create objects from repositories.</param>
        public BaseGetByRulesHandler(
                IRepositoryFactory repositoryFactory
            )
        {
            _repositoryFactory = repositoryFactory;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Create a rule to filter the data.
        /// </summary>
        /// <param name="entityField">Entity field.</param>
        /// <param name="comparisonOperator">Comparison operator of SQL</param>
        /// <param name="Value">Parameter value</param>
        /// <param name="SqlOperator">Operator of the sql </param>
        /// <returns>Returns the rule object.</returns>
        public IRule<TEntityField> CreateRule(
            TEntityField entityField,
            SqlComparisonOperator comparisonOperator,
            object value,
            SqlOperator? sqlOperator = null)
        {
            return _repositoryFactory.CreateRule(entityField, comparisonOperator, value, sqlOperator);
        }

        /// <summary>
        /// Create a rule to filter the data.
        /// </summary>
        /// <param name="rules">Rules to filter the data.</param>
        /// <returns>Returns the rule object.</returns>
        public IRule<TEntityField> CreateRule(params IRule<TEntityField>[] rules)
        {
            return _repositoryFactory.CreateRule(rules);
        }

        /// <summary>
        /// Create a rule to filter the data.
        /// </summary>
        /// <typeparam name="TEntityField">Entity fields types</typeparam>
        /// <param name="sqlOperator">Operator of the sql </param>
        /// <param name="rules">Rules to filter the data.</param>
        /// <returns>Returns the rule object.</returns>
        public IRule<TEntityField> CreateRule(SqlOperator sqlOperator, params IRule<TEntityField>[] rules)
        {
            return _repositoryFactory.CreateRule(sqlOperator, rules);
        }

        #endregion
    }
}
