namespace PeoManageSoft.Business.Application.Title.Change
{
    /// <summary>
    /// Request data.
    /// </summary>
    public sealed class ChangeRequest
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
