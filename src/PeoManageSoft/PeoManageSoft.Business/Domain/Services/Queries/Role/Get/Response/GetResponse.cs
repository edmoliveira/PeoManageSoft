namespace PeoManageSoft.Business.Domain.Services.Queries.Role.Get.Response
{
    /// <summary>
    /// Response for the role.
    /// </summary>
    internal sealed class GetResponse
    {
        #region Properties

        /// <summary>
        /// Role identifier
        /// </summary>
        public long Id { get; set; }
        /// <summary>
        /// Indicates whether the role is active
        /// </summary>
        public bool IsActive { get; set; }
        /// <summary>
        /// Full rolename
        /// </summary>
        public string Name { get; set; }

        #endregion
    }
}
