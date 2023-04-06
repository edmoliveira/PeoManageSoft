namespace PeoManageSoft.Business.Domain.Services.Commands.Role.Remove
{
    /// <summary>
    /// Request for the remove role resources command.
    /// </summary>
    internal class DeleteResourceRequest
    {
        #region Properties

        /// <summary>
        /// Role identifier
        /// </summary>
        public long RoleId { get; set; }

        #endregion
    }
}
