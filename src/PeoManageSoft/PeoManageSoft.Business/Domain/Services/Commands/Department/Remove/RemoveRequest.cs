namespace PeoManageSoft.Business.Domain.Services.Commands.Department.Remove
{
    /// <summary>
    /// Request for the remove department command.
    /// </summary>
    internal sealed class RemoveRequest
    {
        #region Properties

        /// <summary>
        /// Department identifier
        /// </summary>
        public long Id { get; set; }

        #endregion
    }
}
