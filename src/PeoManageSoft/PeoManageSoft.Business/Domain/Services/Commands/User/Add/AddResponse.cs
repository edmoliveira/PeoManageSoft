namespace PeoManageSoft.Business.Domain.Services.Commands.User.Add
{
    /// <summary>
    /// Response for the add user command.
    /// </summary>
    internal class AddResponse
    {
        #region Properties

        /// <summary>
        /// The identifier of the new record
        /// </summary>
        public long NewId { get; set; }

        #endregion 
    }
}
