namespace PeoManageSoft.Business.Domain.Services.Functions.Department
{
    /// <summary>
    /// Department Facade that provides a simplified interface.
    /// </summary>
    internal interface IDepartmentFunctionFacade
    {
        #region Methods

        /// <summary>
        /// Determines whether the specified department table contains the record that match the id and asynchronously using Task.
        /// </summary>
        /// <param name="titleId">Department identifier</param>
        /// <returns>
        /// Task: Represents an asynchronous operation. 
        /// Returns true if the department exists.
        /// </returns>
        Task<bool> ExistsAsync(long titleId);
        /// <summary>
        /// Determines if the name already exists in the department table.
        /// </summary>
        /// <param name="name">Department name</param>
        /// <param name="departmentId">Department identifier</param>
        /// <returns>
        /// Task: Represents an asynchronous operation. 
        /// Returns true if the name already exists.
        /// </returns>
        Task<bool> NameExistsAsync(string name, long? departmentId = null);

        #endregion
    }
}
