using PeoManageSoft.Business.Domain.Services.Functions.User.ActivateUser;
using PeoManageSoft.Business.Domain.Services.Functions.User.EmailExists;
using PeoManageSoft.Business.Domain.Services.Functions.User.Exists;
using PeoManageSoft.Business.Domain.Services.Functions.User.GetByAuthentication;
using PeoManageSoft.Business.Domain.Services.Functions.User.GetByEmail;
using PeoManageSoft.Business.Domain.Services.Functions.User.GetByPasswordToken;
using PeoManageSoft.Business.Domain.Services.Functions.User.LoginExists;
using PeoManageSoft.Business.Domain.Services.Functions.User.PutLocation;
using PeoManageSoft.Business.Domain.Services.Functions.User.PutPassword;
using PeoManageSoft.Business.Domain.Services.Functions.User.PutPasswordToken;
using PeoManageSoft.Business.Domain.Services.Functions.User.SendEmailToActiveUser;
using PeoManageSoft.Business.Domain.Services.Queries.User.Get.Response;
using PeoManageSoft.Business.Infrastructure.Helpers.Exceptions;
using PeoManageSoft.Business.Infrastructure.Helpers.Structs;
using System.Collections.Specialized;

namespace PeoManageSoft.Business.Domain.Services.Functions.User
{
    /// <summary>
    /// User Facade that provides a simplified interface.
    /// </summary>
    internal sealed class UserFunctionFacade : IUserFunctionFacade
    {
        #region Fields

        /// <summary>
        /// Defines a mechanism for retrieving a service object; that is, an object that provides custom support to other objects.
        /// </summary>
        private readonly IServiceProvider _provider;
        /// <summary>
        /// Function that activates the user.
        /// </summary>
        private readonly Lazy<IActivateUserFunction> _activateUserFunction;
        /// <summary>
        /// Function that determines whether the specified user table contains the record that match the id
        /// </summary>
        private readonly Lazy<IExistsFunction> _existsFunction;
        /// <summary>
        /// Function to get the user by passwordToken
        /// </summary>
        private readonly Lazy<IGetByPasswordTokenFunction> _getByPasswordTokenFunction;
        /// <summary>
        /// Function to get the user by login and password
        /// </summary>
        private readonly Lazy<IGetByAuthenticationFunction> _getByAuthenticationFunction;
        /// <summary>
        /// Function that updates the user's password.
        /// </summary>
        private readonly Lazy<IPutPasswordFunction> _putPasswordFunction;
        /// <summary>
        /// Function that updates the user's location.
        /// </summary>
        private readonly Lazy<IPutLocationFunction> _putLocationFunction;
        /// <summary>
        /// Function to get the user by email.
        /// </summary>
        private readonly Lazy<IGetByEmailFunction> _getByEmailFunction;
        /// <summary>
        /// Function that updates the user's passwordToken.
        /// </summary>
        private readonly Lazy<IPutPasswordTokenFunction> _putPasswordTokenFunction;
        /// <summary>
        /// Function that determines if the email already exists in the user table.
        /// </summary>
        private readonly Lazy<IEmailExistsFunction> _emailExistsFunction;
        /// <summary>
        /// Function that determines if the login already exists in the user table.
        /// </summary>
        private readonly Lazy<ILoginExistsFunction> _loginExistsFunction;
        /// <summary>
        /// Function to send an email with token in the url to activate the user.
        /// </summary>
        private readonly Lazy<ISendEmailToActiveUserFunction> _sendEmailToActiveUserFunction;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the PeoManageSoft.Business.Domain.Services.Functions.User.UserFunctionFacade class.
        /// </summary>
        /// <param name="provider">Defines a mechanism for retrieving a service object; that is, an object that provides custom support to other objects.</param>
        public UserFunctionFacade(IServiceProvider provider)
        {
            _provider = provider;

            _activateUserFunction = new Lazy<IActivateUserFunction>(() => GetService<IActivateUserFunction>());
            _existsFunction = new Lazy<IExistsFunction>(() => GetService<IExistsFunction>());
            _getByPasswordTokenFunction = new Lazy<IGetByPasswordTokenFunction>(() => GetService<IGetByPasswordTokenFunction>());
            _getByAuthenticationFunction = new Lazy<IGetByAuthenticationFunction>(() => GetService<IGetByAuthenticationFunction>());
            _putPasswordFunction = new Lazy<IPutPasswordFunction>(() => GetService<IPutPasswordFunction>());
            _putLocationFunction = new Lazy<IPutLocationFunction>(() => GetService<IPutLocationFunction>());
            _getByEmailFunction = new Lazy<IGetByEmailFunction>(() => GetService<IGetByEmailFunction>());
            _putPasswordTokenFunction = new Lazy<IPutPasswordTokenFunction>(() => GetService<IPutPasswordTokenFunction>());
            _emailExistsFunction = new Lazy<IEmailExistsFunction>(() => GetService<IEmailExistsFunction>());
            _loginExistsFunction = new Lazy<ILoginExistsFunction>(() => GetService<ILoginExistsFunction>());
            _sendEmailToActiveUserFunction = new Lazy<ISendEmailToActiveUserFunction>(() => GetService<ISendEmailToActiveUserFunction>());
        }

        #endregion

        #region Methods

        #region public

        /// <summary>
        /// Activates the user and asynchronously using Task.
        /// </summary>
        /// <param name="userId">User identifier</param>
        /// <returns>Represents an asynchronous operation.</returns>
        public async Task ActivateUserAsync(long userId)
        {
            await _activateUserFunction.Value.ExecuteAsync(userId).ConfigureAwait(false);
        }

        /// <summary>
        /// Determines whether the specified user table contains the record that match the id and asynchronously using Task.
        /// </summary>
        /// <param name="userId">User identifier</param>
        /// <returns>
        /// Task: Represents an asynchronous operation. 
        /// Returns true if the user already exists.
        /// </returns>
        public async Task<bool> ExistsAsync(long userId)
        {
            return await _existsFunction.Value.ExecuteAsync(userId).ConfigureAwait(false);
        }

        /// <summary>
        /// Determines if the email already exists in the user table.
        /// </summary>
        /// <param name="email">User email</param>
        /// <param name="userId">User identifier</param>
        /// <returns>
        /// Task: Represents an asynchronous operation. 
        /// Returns true if the email already exists.
        /// </returns>
        public async Task<bool> EmailExistsAsync(string email, long? userId = null)
        {
            return await _emailExistsFunction.Value
                .ExecuteAsync(new EmailExistsFunctionRequest(email, userId))
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Determines if the login already exists in the user table.
        /// </summary>
        /// <param name="login">User login</param>
        /// <param name="userId">User identifier</param>
        /// <returns>
        /// Task: Represents an asynchronous operation. 
        /// Returns true if the email already exists.
        /// </returns>
        public async Task<bool> LoginExistsAsync(string login, long? userId = null)
        {
            return await _loginExistsFunction.Value
                .ExecuteAsync(new LoginExistsFunctionRequest(login, userId))
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Gets the user by PasswordToken and asynchronously using Task.
        /// </summary>
        /// <param name="passwordToken">Token to change the user password.</param>
        /// <returns>
        /// Task: Represents an asynchronous operation. 
        /// Returns the user data.
        /// </returns>
        public async Task<GetResponse> GetByPasswordTokenAsync(string passwordToken)
        {
            return await _getByPasswordTokenFunction.Value.ExecuteAsync(passwordToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Gets the user by login and password and asynchronously using Task.
        /// </summary>
        /// <param name="login">User login</param>
        /// <param name="encryptedPassword">User encrypted password</param>
        /// <returns>
        /// Task: Represents an asynchronous operation. 
        /// Returns the user data.
        /// </returns>
        public async Task<GetResponse> GetByAuthenticationAsync(string login, string encryptedPassword)
        {
            return await _getByAuthenticationFunction.Value
                .ExecuteAsync
                (
                    new GetByAuthenticationRequest { Login = login, EncryptedPassword = encryptedPassword }
                ).ConfigureAwait(false);
        }

        /// <summary>
        /// Updates the user's password and asynchronously using Task.
        /// </summary>
        /// <param name="userId">User identifier</param>
        /// <param name="encryptedPassword">User encrypted password</param>
        /// <returns>Represents an asynchronous operation.</returns>
        public async Task PutPasswordAsync(long userId, string encryptedPassword)
        {
            await _putPasswordFunction.Value
                .ExecuteAsync
                (
                    new PutPasswordFunctionRequest { UserId = userId, EncryptedPassword = encryptedPassword }
                ).ConfigureAwait(false);
        }

        /// <summary>
        /// Updates the user's location and asynchronously using Task.
        /// </summary>
        /// <param name="userId">User identifier</param>
        /// <param name="location">User location</param>
        /// <returns>Represents an asynchronous operation.</returns>
        public async Task PutLocationAsync(long userId, GeoLocation location)
        {
            await _putLocationFunction.Value
                .ExecuteAsync
                (
                    new PutLocationFunctionRequest { UserId = userId, Location = location }
                ).ConfigureAwait(false);
        }

        /// <summary>
        /// Gets the the user by email and asynchronously using Task.
        /// </summary>
        /// <param name="email">User email.</param>
        /// <returns>
        /// Task: Represents an asynchronous operation. 
        /// Returns the user data.
        /// </returns>
        public async Task<GetResponse> GetByEmailAsync(string email)
        {
            return await _getByEmailFunction.Value.ExecuteAsync(email).ConfigureAwait(false);
        }

        /// <summary>
        /// Updates the user's passwordToken and asynchronously using Task.
        /// </summary>
        /// <param name="userId">User identifier</param>
        /// <param name="passwordToken">Token to change the user password.</param>
        /// <returns>Represents an asynchronous operation.</returns>
        public async Task PutPasswordTokenAsync(long userId, string passwordToken)
        {
            await _putPasswordTokenFunction.Value
                .ExecuteAsync
                (
                    new PutPasswordTokenFunctionRequest { UserId = userId, PasswordToken = passwordToken }
                ).ConfigureAwait(false);
        }

        /// <summary>
        /// Sends an email with token in the url to activate the user and asynchronously using Task.
        /// </summary>
        ///  <param name="request">Request for the function.</param>
        /// <returns>
        /// Task: Represents an asynchronous operation. 
        /// Returns the email headers that are transmitted with this email message.
        /// </returns>
        public async Task<StringDictionary> SendEmailToActiveUserAsync(SendEmailToActiveUserFunctionRequest request)
        {
            return await _sendEmailToActiveUserFunction.Value.ExecuteAsync(request).ConfigureAwait(false);
        }

        #endregion

        #region private

        /// <summary>
        /// Gets the service object of the specified type.
        /// </summary>
        /// <typeparam name="T">The type of service object to get.</typeparam>
        /// <returns>A service object of type serviceType. -or- null if there is no service object of type serviceType.</returns>
        /// <exception cref="ProviderServiceNotFoundException">Represents errors that occur when service provider tries to get a service.</exception>
        private T GetService<T>()
        {
            if (_provider.GetService(typeof(T)) is not T service)
            {
                throw new ProviderServiceNotFoundException(typeof(T).FullName);
            }

            return service;
        }

        #endregion

        #endregion
    }
}
