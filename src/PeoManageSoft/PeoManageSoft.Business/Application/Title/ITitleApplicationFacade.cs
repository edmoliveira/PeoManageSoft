using PeoManageSoft.Business.Application.Title.Change;
using PeoManageSoft.Business.Application.Title.Delete;
using PeoManageSoft.Business.Application.Title.New;
using PeoManageSoft.Business.Application.Title.Read;
using PeoManageSoft.Business.Application.Title.Read.Response;
using PeoManageSoft.Business.Application.Title.ReadAllWithPagination;
using PeoManageSoft.Business.Application.Title.SearchWithPagination;

namespace PeoManageSoft.Business.Application.Title
{
    /// <summary>
    /// Title Facade that provides a simplified interface.
    /// </summary>
    public interface ITitleApplicationFacade
    {
        #region Methods

        /// <summary>
        /// Registers an new title and asynchronously using Task.
        /// </summary>
        /// <param name="request">Request data</param>
        /// <returns>
        /// Task: Represents an asynchronous operation. 
        /// Response data.
        /// </returns>
        Task<NewResponse> AddAsync(NewRequest request);
        /// <summary>
        /// Updates an title data and asynchronously using Task.
        /// </summary>
        /// <param name="request">Request data</param>
        /// <returns>Represents an asynchronous operation.</returns>
        Task UpdateAsync(ChangeRequest request);
        /// <summary>
        /// Removes an title and asynchronously using Task.
        /// </summary>
        /// <param name="request">Request data</param>
        /// <returns>Represents an asynchronous operation.</returns>
        Task RemoveAsync(DeleteRequest request);
        /// <summary>
        /// Gets the title and asynchronously using Task.
        /// </summary>
        /// <param name="request">Request data</param>
        /// <returns>
        /// Task: Represents an asynchronous operation. 
        /// Response data.
        /// </returns>
        Task<ReadResponse> GetAsync(ReadRequest request);
        /// <summary>
        /// Gets all registered titles and asynchronously using Task.
        /// </summary>
        /// <param name="request">Request data</param>
        /// <returns>
        /// Task: Represents an asynchronous operation. 
        /// Response data.
        /// </returns>
        Task<IEnumerable<ReadResponse>> GetAllAsync();
        /// <summary>
        /// Gets all registered titles with pagination and asynchronously using Task.
        /// </summary>
        /// <param name="request">Request data</param>
        /// <returns>
        /// Task: Represents an asynchronous operation. 
        /// Response data.
        /// </returns>
        Task<IEnumerable<ReadResponse>> GetAllWithPaginationAsync(ReadAllWithPaginationRequest request);
        /// <summary>
        /// Search titles with pagination and asynchronously using Task.
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
