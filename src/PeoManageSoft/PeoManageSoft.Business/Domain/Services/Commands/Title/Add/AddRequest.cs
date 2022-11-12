namespace PeoManageSoft.Business.Domain.Services.Commands.Title.Add
{
    /// <summary>
    /// Request for the add title command.
    /// </summary>
    internal sealed class AddRequest
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
