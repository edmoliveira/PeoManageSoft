using PeoManageSoft.Business.Application.User.New;

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

        #endregion
    }
}
