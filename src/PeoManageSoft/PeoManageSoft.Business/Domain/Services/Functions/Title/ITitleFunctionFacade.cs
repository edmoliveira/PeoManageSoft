namespace PeoManageSoft.Business.Domain.Services.Functions.Title
{
    /// <summary>
    /// Title Facade that provides a simplified interface.
    /// </summary>
    internal interface ITitleFunctionFacade
    {
        #region Methods

        /// <summary>
        /// Determines whether the specified title table contains the record that match the id and asynchronously using Task.
        /// </summary>
        /// <param name="titleId">Title identifier</param>
        /// <returns>
        /// Task: Represents an asynchronous operation. 
        /// Returns true if the title exists.
        /// </returns>
        Task<bool> ExistsAsync(long titleId);
        /// <summary>
        /// Determines if the name already exists in the title table.
        /// </summary>
        /// <param name="name">Title name</param>
        /// <param name="titleId">Title identifier</param>
        /// <returns>
        /// Task: Represents an asynchronous operation. 
        /// Returns true if the name already exists.
        /// </returns>
        Task<bool> NameExistsAsync(string name, long? titleId = null);

        #endregion
    }
}
