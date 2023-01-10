namespace PeoManageSoft.Business.Infrastructure.RepositoriesNoSql.Databases.Authorization.Policy
{
    /// <summary>
    /// Cross-platform NoSQL collection.
    /// </summary>
    internal sealed class PolicyCollection : IPolicyCollection
    {
        #region Constants

        /// <summary>
        /// Database name.
        /// </summary>
        private const string CollectionName = "policies";

        #endregion

        #region Fields

        /// <summary>
        /// Cross-platform NoSQL collection.
        /// </summary>
        private readonly ICollectionNoSql<PolicyEnity> _collection;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the PeoManageSoft.Business.Infrastructure.RepositoriesNoSql.Databases.Authorization.Policy.PolicyCollection class.
        /// </summary>
        /// <param name="client">Cross-platform NoSQL database.</param>
        public PolicyCollection(IDatabaseNoSql _database)
        {
            _collection = _database.GetCollection<PolicyEnity>(CollectionName);
        }

        #endregion
    }
}