namespace PeoManageSoft.Business.Domain.Services.Commands.Role.Add
{
    /// <summary>
    /// Response for the add role command.
    /// </summary>
    internal sealed class AddResponse
    {
        #region Properties

        /// <summary>
        /// The identifier of the new record
        /// </summary>
        public long NewId { get; set; }

        #endregion 
    }
}
