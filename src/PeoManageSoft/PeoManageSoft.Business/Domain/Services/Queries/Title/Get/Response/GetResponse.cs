namespace PeoManageSoft.Business.Domain.Services.Queries.Title.Get.Response
{
    /// <summary>
    /// Response for the title.
    /// </summary>
    internal sealed class GetResponse
    {
        #region Properties

        /// <summary>
        /// Title identifier
        /// </summary>
        public long Id { get; set; }
        /// <summary>
        /// Indicates whether the title is active
        /// </summary>
        public bool IsActive { get; set; }
        /// <summary>
        /// Full titlename
        /// </summary>
        public string Name { get; set; }

        #endregion
    }
}
