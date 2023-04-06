namespace PeoManageSoft.Business.Domain.Services.Queries.User.GetPolicies
{
    /// <summary>
    /// Request for the get policies query.
    /// </summary>
    internal sealed class GetPoliciesRequest
    {
        #region Properties

        /// <summary>
        /// User identifier
        /// </summary>
        public long UserId { get; set; }

        #endregion
    }
}
