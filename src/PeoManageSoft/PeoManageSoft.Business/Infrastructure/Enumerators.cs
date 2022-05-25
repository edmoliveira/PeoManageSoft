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

    #endregion
}
