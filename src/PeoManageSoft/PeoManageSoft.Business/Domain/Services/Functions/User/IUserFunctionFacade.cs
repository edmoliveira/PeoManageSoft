using PeoManageSoft.Business.Domain.Services.Functions.User.SendEmailToActiveUser;
using PeoManageSoft.Business.Domain.Services.Queries.User.Get.Response;
using PeoManageSoft.Business.Infrastructure.Helpers.Structs;
using System.Collections.Specialized;

namespace PeoManageSoft.Business.Domain.Services.Functions.User
{
    /// <summary>
    /// User Facade that provides a simplified interface.
    /// </summary>
    internal interface IUserFunctionFacade
    {
        #region Methods

        /// <summary>
        /// Activates the user and asynchronously using Task.
        /// </summary>
        /// <param name="userId">User identifier</param>
        /// <returns>Represents an asynchronous operation.</returns>
        Task ActivateUserAsync(long userId);
        /// <summary>
        /// Determines whether the specified user table contains the record that match the id and asynchronously using Task.
        /// </summary>
        /// <param name="userId">User identifier</param>
        /// <returns>
        /// Task: Represents an asynchronous operation. 
        /// Returns true if the user exists.
        /// </returns>
        Task<bool> ExistsAsync(long userId);
        /// <summary>
        /// Determines if the email already exists in the user table.
        /// </summary>
        /// <param name="email">User email</param>
        /// <param name="userId">User identifier</param>
        /// <returns>
        /// Task: Represents an asynchronous operation. 
        /// Returns true if the email already exists.
        /// </returns>
        Task<bool> EmailExistsAsync(string email, long? userId = null);
        /// <summary>
        /// Determines if the login already exists in the user table.
        /// </summary>
        /// <param name="login">User login</param>
        /// <param name="userId">User identifier</param>
        /// <returns>
        /// Task: Represents an asynchronous operation. 
        /// Returns true if the login already exists.
        /// </returns>
        Task<bool> LoginExistsAsync(string login, long? userId = null);
        /// <summary>
        /// Gets the user by PasswordToken
        /// </summary>
        /// <param name="passwordToken">Token to change the user password.</param>
        /// <returns>
        /// Task: Represents an asynchronous operation. 
        /// Returns the user data.
        /// </returns>
        Task<GetResponse> GetByPasswordTokenAsync(string passwordToken);
        /// <summary>
        /// Gets the user by login and password and asynchronously using Task.
        /// </summary>
        /// <param name="login">User login</param>
        /// <param name="encryptedPassword">User encrypted password</param>
        /// <returns>
        /// Task: Represents an asynchronous operation. 
        /// Returns the user data.
        /// </returns>
        Task<GetResponse> GetByAuthenticationAsync(string login, string encryptedPassword);
        /// <summary>
        /// Updates the user's password and asynchronously using Task.
        /// </summary>
        /// <param name="userId">User identifier</param>
        /// <param name="encryptedPassword">User encrypted password</param>
        /// <returns>Represents an asynchronous operation.</returns>
        Task PutPasswordAsync(long userId, string encryptedPassword);
        /// <summary>
        /// Updates the user's location and asynchronously using Task.
        /// </summary>
        /// <param name="userId">User identifier</param>
        /// <param name="location">User location</param>
        /// <returns>Represents an asynchronous operation.</returns>
        Task PutLocationAsync(long userId, GeoLocation location);
        /// <summary>
        /// Gets the the user by email and asynchronously using Task.
        /// </summary>
        /// <param name="email">User email.</param>
        /// <returns>
        /// Task: Represents an asynchronous operation. 
        /// Returns the user data.
        /// </returns>
        Task<GetResponse> GetByEmailAsync(string email);
        /// <summary>
        /// Updates the user's passwordToken and asynchronously using Task.
        /// </summary>
        /// <param name="userId">User identifier</param>
        /// <param name="passwordToken">Token to change the user password.</param>
        /// <returns>Represents an asynchronous operation.</returns>
        Task PutPasswordTokenAsync(long userId, string passwordToken);
        /// <summary>
        /// Sends an email with token in the url to activate the user and asynchronously using Task.
        /// </summary>
        ///  <param name="request">Request for the function.</param>
        /// <returns>
        /// Task: Represents an asynchronous operation. 
        /// Returns the email headers that are transmitted with this email message.
        /// </returns>
        Task<StringDictionary> SendEmailToActiveUserAsync(SendEmailToActiveUserFunctionRequest request);

        #endregion
    }
}
