namespace PeoManageSoft.Business.Application.Role.Read.Response
{
    /// <summary>
    /// Response data.
    /// </summary>
    public sealed class ReadResponse
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