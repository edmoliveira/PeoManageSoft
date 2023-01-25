using PeoManageSoft.Business.Infrastructure.RepositoriesNoSql.Driver;

namespace PeoManageSoft.Business.Infrastructure.RepositoriesNoSql.Databases.Authorization.Policy
{
    /// <summary>
    /// Cross-platform NoSQL collection.
    /// </summary>
    internal sealed class PolicyCollection : BaseCollection<PolicyDocument>, IPolicyCollection
    {
        #region Constants

        /// <summary>
        /// Collection name.
        /// </summary>
        public const string CollectionName = "policies";

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the PeoManageSoft.Business.Infrastructure.RepositoriesNoSql.Databases.Authorization.Policy.PolicyCollection class.
        /// </summary>
        /// <param name="client">Cross-platform NoSQL database.</param>
        public PolicyCollection(IDatabaseNoSql _database)
            : base(_database.GetCollection<PolicyDocument>(CollectionName))
        {

        }

        #endregion
    }
}