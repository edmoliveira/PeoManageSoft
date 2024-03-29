﻿using System.Data;

namespace PeoManageSoft.Business.Infrastructure.ObjectRelationalMapper
{
    /// <summary>
    /// The Parameter configuration.
    /// </summary>
    internal sealed class ParameterConfig
    {
        #region Properties

        /// <summary>
        /// Gets the table object
        /// </summary>
        public Table Table { get; }
        /// <summary>
        /// Gets the value that indicates whether the parameter is a unique identifier
        /// </summary>
        public bool IsUniqueIdentifier { get; }
        /// <summary>
        /// Gets a value indicating whether the parameter is input-only, output-only, bidirectional, or a stored procedure return value parameter.
        /// </summary>
        public ParameterDirection Direction { get; set; }
        /// <summary>
        /// Gets the type of the parameter.
        /// </summary>
        public DbType DbType { get; }
        /// <summary>
        /// Gets the value that indicates whether the parameter accepts null values.
        /// </summary>
        public bool IsNullable { get; }
        /// <summary>
        /// Gets the maximum number of digits used to represent the Value  property.
        /// </summary>
        public byte Precision { get; }
        /// <summary>
        /// Gets the number of decimal places to which Value is resolved.
        /// </summary>
        public byte Scale { get; }
        /// <summary>
        /// Gets the maximum size, in bytes, of the data within the column.
        /// </summary>
        public int Size { get; }
        /// <summary>
        /// Gets the name of the parameter.
        /// </summary>
        public string ParameterName { get; }
        /// <summary>
        /// The name of the source column mapped to the database.
        /// </summary>
        public string SourceColumn { get; }
        /// <summary>
        /// The name of the source column mapped to the database with alias.
        /// </summary>
        public string SourceColumnAlias
        {
            get
            {
                return $"{Table.Name}_{SourceColumn}";
            }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the PeoManageSoft.Business.Infrastructure.ObjectRelationalMapper.ParameterConfig class.
        /// </summary>
        /// <param name="sourceColumn">The name of the source column mapped to the database.</param>
        /// <param name="type">Type of the parameter</param>
        /// <param name="size">The maximum size, in bytes, of the data within the column</param>
        /// <param name="isNullable">The value that indicates whether the parameter accepts null values.</param>
        /// <param name="isUniqueIdentifier">The value that indicates whether the parameter is a unique identifier</param>
        /// <param name="precision">The maximum number of digits used to represent the Value  property.</param>
        /// <param name="scale">The number of decimal places to which Value is resolved.</param>
        /// <param name="table">The table object</param>
        /// <param name="direction">A value indicating whether the parameter is input-only, output-only, bidirectional, or a stored procedure return value parameter.</param>
        public ParameterConfig(
            string sourceColumn,
            DbType type,
            int size = 0,
            bool isNullable = false,
            bool isUniqueIdentifier = false,
            byte precision = 0,
            byte scale = 0,
            Table table = default,
            ParameterDirection direction = ParameterDirection.Input)
        {
            ParameterName = string.Concat("@", sourceColumn);
            SourceColumn = sourceColumn;
            DbType = type;
            Size = size;
            IsNullable = isNullable;
            IsUniqueIdentifier = isUniqueIdentifier;
            Precision = precision;
            Scale = scale;
            Table = table;
            Direction = direction;
        }

        #endregion
    }
}
