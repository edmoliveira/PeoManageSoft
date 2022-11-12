namespace PeoManageSoft.Business.Domain.Services.Commands.Title.Remove
{
    /// <summary>
    /// Request for the remove title command.
    /// </summary>
    internal sealed class RemoveRequest
    {
        #region Properties

        /// <summary>
        /// Title identifier
        /// </summary>
        public long Id { get; set; }

        #endregion
    }
}
