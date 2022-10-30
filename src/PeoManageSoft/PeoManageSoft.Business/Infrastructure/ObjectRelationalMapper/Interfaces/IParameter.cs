using System.Data;

namespace PeoManageSoft.Business.Infrastructure.ObjectRelationalMapper.Interfaces
{
    /// <summary>
    /// Represent a parameter to a Command object.
    /// </summary>
    public interface IParameter
    {
        #region Properties

        /// <summary>
        /// Gets or sets the value that indicates whether the parameter is a unique identifier
        /// </summary>
        bool IsUniqueIdentifier { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether the parameter is input-only, output-only, bidirectional, or a stored procedure return value parameter.
        /// </summary>
        public ParameterDirection Direction { get; set; }
        /// <summary>
        /// Gets or sets the type of the parameter.
        /// </summary>
        DbType DbType { get; set; }
        /// <summary>
        /// Gets or sets the value that indicates whether the parameter accepts null values.
        /// </summary>
        bool IsNullable { get; set; }
        /// <summary>
        /// Gets or sets the name of the parameter.
        /// </summary>
        string ParameterName { get; set; }
        /// <summary>
        /// Gets or sets the maximum number of digits used to represent the Value  property.
        /// </summary>
        byte Precision { get; set; }
        /// <summary>
        /// Gets or sets the number of decimal places to which Value is resolved.
        /// </summary>
        byte Scale { get; set; }
        /// <summary>
        /// Gets or sets the maximum size, in bytes, of the data within the column.
        /// </summary>
        int Size { get; set; }
        /// <summary>
        /// The name of the source column mapped to the database. The default is an empty string.
        /// </summary>
        string SourceColumn { get; set; }
        /// <summary>
        /// Gets or sets the value of the parameter.
        /// </summary>
        object Value { get; set; }

        #endregion

        #region Methods public

        /// <summary>
        /// Creates a shallow copy of the current Parameter.
        /// </summary>
        /// <returns> A shallow copy of the current Parameter.</returns>
        IParameter Clone();

        #endregion
    }
}
