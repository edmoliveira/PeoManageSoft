using PeoManageSoft.Business.Application.Role.Change;
using PeoManageSoft.Business.Application.Role.Delete;
using PeoManageSoft.Business.Application.Role.New;
using PeoManageSoft.Business.Application.Role.Read;
using PeoManageSoft.Business.Application.Role.Read.Response;
using PeoManageSoft.Business.Application.Role.ReadAllWithPagination;
using PeoManageSoft.Business.Application.Role.SearchWithPagination;

namespace PeoManageSoft.Business.Application.Role
{
    /// <summary>
    /// Role Facade that provides a simplified interface.
    /// </summary>
    public interface IRoleApplicationFacade
    {
        #region Methods

        /// <summary>
        /// Registers an new role and asynchronously using Task.
        /// </summary>
        /// <param name="request">Request data</param>
        /// <returns>
        /// Task: Represents an asynchronous operation. 
        /// Response data.
        /// </returns>
        Task<NewResponse> AddAsync(NewRequest request);
        /// <summary>
        /// Updates an role data and asynchronously using Task.
        /// </summary>
        /// <param name="request">Request data</param>
        /// <returns>Represents an asynchronous operation.</returns>
        Task UpdateAsync(ChangeRequest request);
        /// <summary>
        /// Removes an role and asynchronously using Task.
        /// </summary>
        /// <param name="request">Request data</param>
        /// <returns>Represents an asynchronous operation.</returns>
        Task RemoveAsync(DeleteRequest request);
        /// <summary>
        /// Gets the role and asynchronously using Task.
        /// </summary>
        /// <param name="request">Request data</param>
        /// <returns>
        /// Task: Represents an asynchronous operation. 
        /// Response data.
        /// </returns>
        Task<ReadResponse> GetAsync(ReadRequest request);
        /// <summary>
        /// Gets all registered roles and asynchronously using Task.
        /// </summary>
        /// <param name="request">Request data</param>
        /// <returns>
        /// Task: Represents an asynchronous operation. 
        /// Response data.
        /// </returns>
        Task<IEnumerable<ReadResponse>> GetAllAsync();
        /// <summary>
        /// Gets all registered roles with pagination and asynchronously using Task.
        /// </summary>
        /// <param name="request">Request data</param>
        /// <returns>
        /// Task: Represents an asynchronous operation. 
        /// Response data.
        /// </returns>
        Task<IEnumerable<ReadResponse>> GetAllWithPaginationAsync(ReadAllWithPaginationRequest request);
        /// <summary>
        /// Search roles with pagination and asynchronously using Task.
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
