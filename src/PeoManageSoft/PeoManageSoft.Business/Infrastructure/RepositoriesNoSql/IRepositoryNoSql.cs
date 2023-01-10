using PeoManageSoft.Business.Infrastructure.RepositoriesNoSql.Databases.Authorization;

namespace PeoManageSoft.Business.Infrastructure.RepositoriesNoSql
{
    /// <summary>
    /// Non-SQL repositories
    /// </summary>
    internal interface IRepositoryNoSql: IDisposable
    {
        #region Properties

        /// <summary>
        /// Cross-platform NoSQL database "Authorization". 
        /// </summary>
        IAuthorizationDatabase Authorization { get; }

        #endregion
    }
}
