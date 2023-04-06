namespace PeoManageSoft.Business.Application.User.Read.Response
{
    /// <summary>
    /// Response for the read role query.
    /// </summary>
    public sealed class ReadRoleResponse
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
        /// Role name
        /// </summary>
        public string Name { get; set; }

        #endregion
    }
}
