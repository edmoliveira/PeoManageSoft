using PeoManageSoft.Business.Application.Department.Change;
using PeoManageSoft.Business.Application.Department.Delete;
using PeoManageSoft.Business.Application.Department.New;
using PeoManageSoft.Business.Application.Department.Read;
using PeoManageSoft.Business.Application.Department.Read.Response;
using PeoManageSoft.Business.Application.Department.ReadAllWithPagination;
using PeoManageSoft.Business.Application.Department.SearchWithPagination;

namespace PeoManageSoft.Business.Application.Department
{
    /// <summary>
    /// Department Facade that provides a simplified interface.
    /// </summary>
    public interface IDepartmentApplicationFacade
    {
        #region Methods

        /// <summary>
        /// Registers an new department and asynchronously using Task.
        /// </summary>
        /// <param name="request">Request data</param>
        /// <returns>
        /// Task: Represents an asynchronous operation. 
        /// Response data.
        /// </returns>
        Task<NewResponse> AddAsync(NewRequest request);
        /// <summary>
        /// Updates an department data and asynchronously using Task.
        /// </summary>
        /// <param name="request">Request data</param>
        /// <returns>Represents an asynchronous operation.</returns>
        Task UpdateAsync(ChangeRequest request);
        /// <summary>
        /// Removes an department and asynchronously using Task.
        /// </summary>
        /// <param name="request">Request data</param>
        /// <returns>Represents an asynchronous operation.</returns>
        Task RemoveAsync(DeleteRequest request);
        /// <summary>
        /// Gets the department and asynchronously using Task.
        /// </summary>
        /// <param name="request">Request data</param>
        /// <returns>
        /// Task: Represents an asynchronous operation. 
        /// Response data.
        /// </returns>
        Task<ReadResponse> GetAsync(ReadRequest request);
        /// <summary>
        /// Gets all registered departments and asynchronously using Task.
        /// </summary>
        /// <param name="request">Request data</param>
        /// <returns>
        /// Task: Represents an asynchronous operation. 
        /// Response data.
        /// </returns>
        Task<IEnumerable<ReadResponse>> GetAllAsync();
        /// <summary>
        /// Gets all registered departments with pagination and asynchronously using Task.
        /// </summary>
        /// <param name="request">Request data</param>
        /// <returns>
        /// Task: Represents an asynchronous operation. 
        /// Response data.
        /// </returns>
        Task<IEnumerable<ReadResponse>> GetAllWithPaginationAsync(ReadAllWithPaginationRequest request);
        /// <summary>
        /// Search departments with pagination and asynchronously using Task.
        /// </summary>
        /// <param name="request">Request data</param>
        /// <returns>
        /// Task: Represents an asynchronous operation. 
        /// Response data.
        /// </returns>
        Task<IEnumerable<ReadResponse>> SearchWithPaginationAsync(SearchWithPaginationRequest request);

        #endregion
    }
}
