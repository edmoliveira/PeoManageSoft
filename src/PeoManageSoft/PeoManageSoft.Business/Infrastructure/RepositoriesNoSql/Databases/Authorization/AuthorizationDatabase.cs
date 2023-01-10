using PeoManageSoft.Business.Infrastructure.RepositoriesNoSql.Databases.Authorization.Policy;
using PeoManageSoft.Business.Infrastructure.RepositoriesNoSql.Databases.Authorization.Schema;

namespace PeoManageSoft.Business.Infrastructure.RepositoriesNoSql.Databases.Authorization
{
    /// <summary>
    /// Cross-platform NoSQL database "Authorization"
    /// </summary>
    internal class AuthorizationDatabase : IAuthorizationDatabase
    {
        #region Constants

        /// <summary>
        /// Database name.
        /// </summary>
        private const string DatabaseName = "pmsAuthorization";

        #endregion

        #region Fields

        /// <summary>
        /// Cross-platform NoSQL collection. "Schema". 
        /// </summary>
        private readonly Lazy<ISchemaCollection> _schema;
        /// <summary>
        /// Cross-platform NoSQL collection. "Policy". 
        /// </summary>
        private readonly Lazy<IPolicyCollection> _policy;

        #endregion

        #region Properties

        /// <summary>
        /// Cross-platform NoSQL collection. "Schema". 
        /// </summary>
        public ISchemaCollection Schema => _schema.Value;
        /// <summary>
        /// Cross-platform NoSQL collection. "Policy". 
        /// </summary>
        public IPolicyCollection Policy => _policy.Value;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the PeoManageSoft.Business.Infrastructure.RepositoriesNoSql.Databases.Authorization.AuthorizationDatabase class.
        /// </summary>
        /// <param name="client">Cross-platform NoSQL document-oriented database client.</param>
        public AuthorizationDatabase(IClientNoSql client)
        {
            var database = client.GetDatabase(DatabaseName);

            _schema = new Lazy<ISchemaCollection>(() => new SchemaCollection(database));
            _policy = new Lazy<IPolicyCollection>(() => new PolicyCollection(database));
        }

        #endregion
    }
}
