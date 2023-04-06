using PeoManageSoft.Business.Infrastructure.Helpers.Structs;

namespace PeoManageSoft.Business.Domain.Services.Queries.User.GetPolicies
{
    /// <summary>
    /// Response for the get policies query.
    /// </summary>
    internal sealed class GetPoliciesResponse
    {
        #region Properties

        /// <summary>
        /// Resource name
        /// </summary>
        public string ResourceName { get; private set; }

        /// <summary>
        /// User permissions.
        /// </summary>
        public Grant Permissions { get; private set; }

        #endregion
    }
}
