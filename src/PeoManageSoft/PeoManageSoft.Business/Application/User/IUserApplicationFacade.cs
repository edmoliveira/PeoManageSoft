using PeoManageSoft.Business.Application.User.Change;
using PeoManageSoft.Business.Application.User.Delete;
using PeoManageSoft.Business.Application.User.New;
using PeoManageSoft.Business.Application.User.Read;
using PeoManageSoft.Business.Application.User.Read.Response;
using PeoManageSoft.Business.Application.User.ReadAll.Response;

namespace PeoManageSoft.Business.Application.User
{
    /// <summary>
    /// User Facade that provides a simplified interface.
    /// </summary>
    public interface IUserApplicationFacade
    {
        #region Methods

        /// <summary>
        /// Registers an new user and asynchronously using Task.
        /// </summary>
        /// <param name="request">Request data</param>
        /// <returns>
        /// Task: Represents an asynchronous operation. 
        /// Response data.
        /// </returns>
        Task<NewResponse> AddAsync(NewRequest request);
        /// <summary>
        /// Updates an user data and asynchronously using Task.
        /// </summary>
        /// <param name="request">Request data</param>
        /// <returns>Represents an asynchronous operation.</returns>
        Task UpdateAsync(ChangeRequest request);
        /// <summary>
        /// Removes an user and asynchronously using Task.
        /// </summary>
        /// <param name="request">Request data</param>
        /// <returns>Represents an asynchronous operation.</returns>
        Task RemoveAsync(DeleteRequest request);
        /// <summary>
        /// Gets the user and asynchronously using Task.
        /// </summary>
        /// <param name="request">Request data</param>
        /// <returns>
        /// Task: Represents an asynchronous operation. 
        /// Response data.
        /// </returns>
        Task<ReadResponse> GetAsync(ReadRequest request);
        /// <summary>
        /// Gets all registered users and asynchronously using Task.
        /// </summary>
        /// <param name="request">Request data</param>
        /// <returns>
        /// Task: Represents an asynchronous operation. 
        /// Response data.
        /// </returns>
        Task<IEnumerable<ReadAllResponse>> GetAllAsync();

        #endregion
    }
}
