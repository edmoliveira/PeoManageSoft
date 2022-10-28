namespace PeoManageSoft.Business.Domain.Services.Commands.User.Remove
{
    /// <summary>
    /// Request for the remove user command.
    /// </summary>
    internal class RemoveRequest
    {
        #region Properties

        /// <summary>
        /// User identifier
        /// </summary>
        public long Id { get; set; }

        #endregion
    }
}
