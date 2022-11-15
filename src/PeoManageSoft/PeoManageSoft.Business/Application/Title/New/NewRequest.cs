namespace PeoManageSoft.Business.Application.Title.New
{
    /// <summary>
    /// Request data.
    /// </summary>
    public sealed class NewRequest
    {
        #region Properties

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
