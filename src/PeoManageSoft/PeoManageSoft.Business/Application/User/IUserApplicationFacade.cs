using PeoManageSoft.Business.Application.User.ActivateUser;
using PeoManageSoft.Business.Application.User.Change;
using PeoManageSoft.Business.Application.User.ChangePassword;
using PeoManageSoft.Business.Application.User.CreateNewPassword;
using PeoManageSoft.Business.Application.User.Delete;
using PeoManageSoft.Business.Application.User.New;
using PeoManageSoft.Business.Application.User.Read;
using PeoManageSoft.Business.Application.User.Read.Response;
using PeoManageSoft.Business.Application.User.SendPasswordToken;
using PeoManageSoft.Business.Application.User.SendReminderActivateUser;
using PeoManageSoft.Business.Application.User.SignIn;
using PeoManageSoft.Business.Application.User.ValidatePasswordToken;

namespace PeoManageSoft.Business.Application.User
{
    /// <summary>
    /// User Facade that provides a simplified interface.
    /// </summary>
    public interface IUserApplicationFacade
    {
        #region Methods

        /// <summary>
        /// Activates the user and asynchronously using Task.
        /// </summary>
        /// <param name="request">Request data</param>
        /// <returns>Represents an asynchronous operation.</returns>
        Task ActivateUserAsync(ActivateUserRequest request);
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
        Task<IEnumerable<ReadResponse>> GetAllAsync();
        /// <summary>
        /// Accesses the system through authentication and asynchronously using Task.
        /// </summary>
        /// <param name="request">Request data</param>
        /// <returns>
        /// Task: Represents an asynchronous operation. 
        /// Response data.
        /// </returns>
        Task<SignInResponse> SignInAsync(SignInRequest request);
        /// <summary>
        /// Sends an email to the user to change his password. and asynchronously using Task.
        /// </summary>
        /// <param name="request">Request data</param>
        /// <returns>Represents an asynchronous operation.</returns>
        Task SendPasswordTokenAsync(SendPasswordTokenRequest request);
        /// <summary>
        /// Sends an email with a reminder to activate the user and asynchronously using Task.
        /// </summary>
        /// <param name="request">Request data</param>
        /// <returns>Represents an asynchronous operation.</returns>
        Task SendReminderActivateUserAsync(SendReminderActivateUserRequest request);
        /// <summary>
        /// Validates if the password token is valid.  and asynchronously using Task.
        /// </summary>
        /// <param name="request">Request data</param>
        /// <returns>
        /// Task: Represents an asynchronous operation. 
        /// Response data.
        /// </returns>
        Task<ValidatePasswordTokenResponse> ValidatePasswordTokenAsync(ValidatePasswordTokenRequest request);
        /// <summary>
        /// Creates new password if the user token is valid.
        /// </summary>
        /// <param name="request">Request data</param>
        /// <returns>Represents an asynchronous operation.</returns>
        Task CreateNewPasswordAsync(CreateNewPasswordRequest request);
        /// <summary>
        /// Changes password if the old password is valid. 
        /// </summary>
        /// <param name="request">Request data</param>
        /// <returns>Represents an asynchronous operation.</returns>
        Task ChangePasswordAsync(ChangePasswordRequest request);

        #endregion
    }
}
