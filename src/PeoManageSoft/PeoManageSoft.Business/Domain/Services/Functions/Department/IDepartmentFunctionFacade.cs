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

        #endregion
    }
}
