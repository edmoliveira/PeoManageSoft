using PeoManageSoft.Business.Infrastructure.Helpers.Structs;

namespace PeoManageSoft.Business.Domain.Services.Queries.Role.GetResources
{
    /// <summary>
    /// Response for the get resources query.
    /// </summary>
    internal sealed class GetResourcesResponse
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
