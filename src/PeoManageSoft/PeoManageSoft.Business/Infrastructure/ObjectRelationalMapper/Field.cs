namespace PeoManageSoft.Business.Infrastructure.ObjectRelationalMapper
{
    /// <summary>
    /// Field to be updated
    /// </summary>
    /// <typeparam name="TEntityField">Entity fields types</typeparam>
    internal sealed class Field<TEntityField>
    {
        #region Properties

        /// <summary>
        /// Field type.
        /// </summary>
        public TEntityField Type { get; set; }
        /// <summary>
        /// Field value.
        /// </summary>
        public object Value { get; set; }

        #endregion
    }
}
