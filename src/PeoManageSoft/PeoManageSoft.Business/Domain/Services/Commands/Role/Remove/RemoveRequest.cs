namespace PeoManageSoft.Business.Domain.Services.Commands.Role.Remove
{
    /// <summary>
    /// Request for the remove role command.
    /// </summary>
    internal sealed class RemoveRequest
    {
        #region Properties

        /// <summary>
        /// Role identifier
        /// </summary>
        public long Id { get; set; }

        #endregion
    }
}
