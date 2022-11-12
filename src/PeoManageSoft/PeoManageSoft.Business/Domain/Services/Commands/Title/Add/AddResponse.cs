namespace PeoManageSoft.Business.Domain.Services.Commands.Title.Add
{
    /// <summary>
    /// Response for the add title command.
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
