namespace PeoManageSoft.Business.Infrastructure.ObjectRelationalMapper.Interfaces
{
    /// <summary>
    /// Rule to filter the data.
    /// </summary>
    /// <typeparam name="TEntityField">Entity fields types</typeparam>
    public interface IRule<TEntityField>
    {
        #region Properties

        /// <summary>
        /// Operator of the sql 
        /// </summary>
        SqlOperator? SqlOperator { get; }
        /// <summary>
        /// Entity field.
        /// </summary>
        TEntityField EntityField { get; }
        /// <summary>
        /// Comparison operator of SQL
        /// </summary>
        SqlComparisonOperator ComparisonOperator { get; }
        /// <summary>
        /// Parameter value
        /// </summary>
        object Value { get; set; }
        /// <summary>
        /// Rules to filter the data.
        /// </summary>
        IReadOnlyList<IRule<TEntityField>> Rules { get; }

        #endregion
    }
}
