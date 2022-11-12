namespace PeoManageSoft.Business.Domain.Services.Commands.Department.Add
{
    /// <summary>
    /// Response for the add department command.
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
