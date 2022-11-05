namespace PeoManageSoft.Business.Domain.Services.Queries.User.Get.Response
{
    /// <summary>
    /// Response for the title.
    /// </summary>
    internal sealed class GetTitleResponse
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

