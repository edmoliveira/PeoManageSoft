using PeoManageSoft.Business.Infrastructure.RepositoriesNoSql.Databases.Authorization.Policy;
using PeoManageSoft.Business.Infrastructure.RepositoriesNoSql.Databases.Authorization.Role;
using PeoManageSoft.Business.Infrastructure.RepositoriesNoSql.Databases.Authorization.Schema;
using PeoManageSoft.Business.Infrastructure.RepositoriesNoSql.Driver;

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
        /// Cross-platform NoSQL collection. "Role". 
        /// </summary>
        private readonly Lazy<IRoleCollection> _role;
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
        /// Cross-platform NoSQL collection. "Role". 
        /// </summary>
        public IRoleCollection Role => _role.Value;
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

            _role = new Lazy<IRoleCollection>(() => new RoleCollection(database));
            _schema = new Lazy<ISchemaCollection>(() => new SchemaCollection(database));
            _policy = new Lazy<IPolicyCollection>(() => new PolicyCollection(database));
        }

        #endregion
    }
}
