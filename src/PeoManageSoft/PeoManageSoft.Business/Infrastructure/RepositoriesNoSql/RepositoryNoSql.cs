using PeoManageSoft.Business.Infrastructure.RepositoriesNoSql.Databases.Authorization;

namespace PeoManageSoft.Business.Infrastructure.RepositoriesNoSql
{
    /// <summary>
    /// Non-SQL repositories
    /// </summary>
    internal sealed class RepositoryNoSql : IRepositoryNoSql
    {
        #region Fields

        /// <summary>
        /// Cross-platform NoSQL database "Authorization". 
        /// </summary>
        private readonly Lazy<IAuthorizationDatabase> _authorization;

        #endregion

        #region Properties

        /// <summary>
        /// Cross-platform NoSQL database "Authorization". 
        /// </summary>
        public IAuthorizationDatabase Authorization => _authorization.Value;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the PeoManageSoft.Business.Infrastructure.RepositoriesNoSql.RepositoryNoSql class.
        /// </summary>
        /// <param name="client">Cross-platform NoSQL document-oriented database client.</param>
        public RepositoryNoSql(IClientNoSql client)
        {
            _authorization = new Lazy<IAuthorizationDatabase>(() => new AuthorizationDatabase(client));
        }

        #endregion

        #region Methods

        #region public

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            
        }

        #endregion

        #endregion
    }
}
