namespace PeoManageSoft.Business.Domain.Services.Commands.Title.Update
{
    /// <summary>
    /// Request for the update title command.
    /// </summary>
    internal sealed class UpdateRequest
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
