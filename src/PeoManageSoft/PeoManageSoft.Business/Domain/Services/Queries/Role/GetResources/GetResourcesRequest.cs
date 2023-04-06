namespace PeoManageSoft.Business.Domain.Services.Queries.Role.GetResources
{
    /// <summary>
    /// Request for the get resources query.
    /// </summary>
    internal sealed class GetResourcesRequest
    {
        #region Properties

        /// <summary>
        /// Role identifier
        /// </summary>
        public long RoleId { get; set; }

        #endregion
    }
}
