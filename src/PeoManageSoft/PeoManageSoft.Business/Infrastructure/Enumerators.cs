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

    #endregion
}
