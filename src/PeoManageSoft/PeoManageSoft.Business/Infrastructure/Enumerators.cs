using System.ComponentModel;

namespace PeoManageSoft.Business.Infrastructure
{
    #region Enumerators

    /// <summary>
    /// Roles
    /// </summary>
    public enum UserRole
    {
        /// <summary>
        /// Administrator
        /// </summary>
        [Description("Administrator")]
        Admin = 1,
        /// <summary>
        /// Standard user
        /// </summary>
        [Description("Standard user")]
        User = 2
    }

    /// <summary>
    /// Relational Database Type
    /// </summary>
    public enum DatabaseType
    {
        /// <summary>
        /// Sql Server
        /// </summary>
        [Description("SqlServer")]
        SqlServer = 0,
        /// <summary>
        /// PostgreSQL 
        /// </summary>
        [Description("PostgreSQL")]
        PostgreSQL = 1,
        /// <summary>
        /// MySql 
        /// </summary>
        [Description("MySql")]
        MySql = 2,
    }

    /// <summary>
    /// Transaction status
    /// </summary>ype
    public enum TransactionStatus
    {
        /// <summary>
        /// Indicates that the transaction was not initialized.
        /// </summary>
        [Description("None")]
        None = 0,
        /// <summary>
        /// Indicates that the transaction was initialized.
        /// </summary>
        [Description("Initialized")]
        Initialized = 1,
        /// <summary>
        /// Indicates that the transaction was committed. 
        /// </summary>
        [Description("Committed")]
        Committed = 2,
        /// <summary>
        /// Indicates that the transaction was rolled back. 
        /// </summary>
        [Description("Committed")]
        RolledBack = 3,
    }

    /// <summary>
    /// Operator of the sql.
    /// </summary>
    public enum SqlOperator
    {
        /// <summary>
        /// And
        /// </summary>
        [Description("And")]
        And = 0,
        /// <summary>
        /// Or 
        /// </summary>
        [Description("Or")]
        Or = 1,
        /// <summary>
        /// Not 
        /// </summary>
        [Description("Not")]
        Not = 2,
    }

    /// <summary>
    /// Comparison operator of SQL
    /// </summary>
    public enum SqlComparisonOperator
    {
        /// <summary>
        /// = 
        /// </summary>
        [Description("EqualTo")]
        EqualTo = 0,
        /// <summary>
        /// > 
        /// </summary>
        [Description("GreaterThan")]
        GreaterThan = 1,
        /// <summary>
        /// < 
        /// </summary>
        [Description("LessThan")]
        LessThan = 2,
        /// <summary>
        /// >=	 
        /// </summary>
        [Description("GreaterThanOrEqualTo")]
        GreaterThanOrEqualTo = 3,
        /// <summary>
        /// <=	 
        /// </summary>
        [Description("LessThanOrEqualTo")]
        LessThanOrEqualTo = 4,
        /// <summary>
        /// <> 
        /// </summary>
        [Description("NotEqualTo")]
        NotEqualTo = 5,
        /// <summary>
        /// In 
        /// </summary>
        [Description("In")]
        In = 6,
    }

    #endregion
}
