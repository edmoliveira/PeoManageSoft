namespace PeoManageSoft.Business.Application.User.Read.Response
{
    /// <summary>
    /// Response for the read title query.
    /// </summary>
    public sealed class ReadTitleResponse
    {
        #region Properties

        /// <summary>
        /// Title identifier
        /// </summary>
        public long Id { get; set; }
        /// <summary>
        /// Indicates whether the user is active
        /// </summary>
        public bool IsActive { get; set; }
        /// <summary>
        /// Title name
        /// </summary>
        public string Name { get; set; }

        #endregion
    }
}

