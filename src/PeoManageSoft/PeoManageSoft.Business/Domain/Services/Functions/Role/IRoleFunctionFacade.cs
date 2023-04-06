namespace PeoManageSoft.Business.Domain.Services.Functions.Role
{
    /// <summary>
    /// Role Facade that provides a simplified interface.
    /// </summary>
    internal interface IRoleFunctionFacade
    {
        #region Methods

        /// <summary>
        /// Determines whether the specified role table contains the record that match the id and asynchronously using Task.
        /// </summary>
        /// <param name="titleId">Role identifier</param>
        /// <returns>
        /// Task: Represents an asynchronous operation. 
        /// Returns true if the role exists.
        /// </returns>
        Task<bool> ExistsAsync(long titleId);
        /// <summary>
        /// Determines if the name already exists in the role table.
        /// </summary>
        /// <param name="name">Role name</param>
        /// <param name="roleId">Role identifier</param>
        /// <returns>
        /// Task: Represents an asynchronous operation. 
        /// Returns true if the name already exists.
        /// </returns>
        Task<bool> NameExistsAsync(string name, long? roleId = null);

        #endregion
    }
}
