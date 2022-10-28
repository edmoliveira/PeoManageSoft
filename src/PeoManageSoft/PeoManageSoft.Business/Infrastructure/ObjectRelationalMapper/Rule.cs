using PeoManageSoft.Business.Infrastructure.ObjectRelationalMapper.Interfaces;

namespace PeoManageSoft.Business.Infrastructure.ObjectRelationalMapper
{
    /// <summary>
    /// Rule to filter the data.
    /// </summary>
    /// <typeparam name="TEntityField">Entity fields types</typeparam>
    internal sealed class Rule<TEntityField> : IRule<TEntityField>
    {
        #region Fields private

        /// <summary>
        /// Rules to filter the data.
        /// </summary>
        private readonly List<IRule<TEntityField>> _rules;

        #endregion

        #region Properties

        /// <summary>
        /// Operator of the sql 
        /// </summary>
        public SqlOperator? SqlOperator { get; set; }
        /// <summary>
        /// Entity field.
        /// </summary>
        public TEntityField EntityField { get; set; }
        /// <summary>
        /// Comparison operator of SQL
        /// </summary>
        public SqlComparisonOperator ComparisonOperator { get; set; }
        /// <summary>
        /// Parameter value
        /// </summary>
        public object Value { get; set; }
        /// <summary>
        /// Rules to filter the data.
        /// </summary>
        IReadOnlyList<IRule<TEntityField>> IRule<TEntityField>.Rules => _rules;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the  PeoManageSoft.Business.Infrastructure.ObjectRelationalMapper.Rule class.
        /// </summary>
        public Rule()
        {

        }

        /// <summary>
        /// Initializes a new instance of the  PeoManageSoft.Business.Infrastructure.ObjectRelationalMapper.Rule class.
        /// </summary>
        /// <param name="rules">Rules to filter the data.</param>
        public Rule(params IRule<TEntityField>[] rules)
        {
            _rules = rules.ToList();
        }

        /// <summary>
        /// Initializes a new instance of the  PeoManageSoft.Business.Infrastructure.ObjectRelationalMapper.Rule class.
        /// </summary>
        /// <param name="sqlOperator">Operator of the sql </param>
        /// <param name="rules">Rules to filter the data.</param>
        public Rule(SqlOperator sqlOperator, params IRule<TEntityField>[] rules)
        {
            SqlOperator = sqlOperator;
            _rules = rules.ToList();
        }

        #endregion
    }
}
