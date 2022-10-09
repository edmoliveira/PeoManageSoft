using PeoManageSoft.Business.Application.User.Change;
using PeoManageSoft.Business.Application.User.Delete;
using PeoManageSoft.Business.Application.User.New;
using PeoManageSoft.Business.Application.User.Read;
using PeoManageSoft.Business.Application.User.Read.Response;
using PeoManageSoft.Business.Application.User.ReadAll;
using PeoManageSoft.Business.Application.User.ReadAll.Response;
using PeoManageSoft.Business.Application.User.SignIn;
using PeoManageSoft.Business.Infrastructure.Helpers.Exceptions;

namespace PeoManageSoft.Business.Application.User
{
    /// <summary>
    /// User Facade that provides a simplified interface.
    /// </summary>
    internal class UserApplicationFacade : IUserApplicationFacade
    {
        #region Fields

        /// <summary>
        /// Defines a mechanism for retrieving a service object; that is, an object that provides custom support to other objects.
        /// </summary>
        private readonly IServiceProvider _provider;
        /// <summary>
        /// New user application layer.
        /// </summary>
        private readonly Lazy<INewApplication> _newApplication;
        /// <summary>
        /// Change user application layer.
        /// </summary>
        private readonly Lazy<IChangeApplication> _changeApplication;
        /// <summary>
        /// Delete user application layer.
        /// </summary>
        private readonly Lazy<IDeleteApplication> _deleteApplication;
        /// <summary>
        /// Read user application layer.
        /// </summary>
        private readonly Lazy<IReadApplication> _readApplication;
        /// <summary>
        /// Read all user application layer.
        /// </summary>
        private readonly Lazy<IReadAllApplication> _readAllApplication;
        /// <summary>
        /// Sign in application layer.
        /// </summary>
        private readonly Lazy<ISignInApplication> _signInApplication;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the PeoManageSoft.Business.Application.User.UserApplicationFacade class.
        /// </summary>
        /// <param name="provider">Defines a mechanism for retrieving a service object; that is, an object that provides custom support to other objects.</param>
        public UserApplicationFacade(IServiceProvider provider)
        {
            _provider = provider;

            _newApplication = new Lazy<INewApplication>(() => GetService<INewApplication>());
            _changeApplication = new Lazy<IChangeApplication>(() => GetService<IChangeApplication>());
            _deleteApplication = new Lazy<IDeleteApplication>(() => GetService<IDeleteApplication>());
            _readApplication = new Lazy<IReadApplication>(() => GetService<IReadApplication>());
            _readAllApplication = new Lazy<IReadAllApplication>(() => GetService<IReadAllApplication>());
            _signInApplication = new Lazy<ISignInApplication>(() => GetService<ISignInApplication>());
        }

        #endregion

        #region Methods

        #region public

        /// <summary>
        /// Registers an new user and asynchronously using Task.
        /// </summary>
        /// <param name="request">Request data</param>
        /// <returns>
        /// Task: Represents an asynchronous operation. 
        /// Response data.
        /// </returns>
        public async Task<NewResponse> AddAsync(NewRequest request)
        {
            return await _newApplication.Value.HandleAsync(request);
        }

        /// <summary>
        /// Updates an user data and asynchronously using Task.
        /// </summary>
        /// <param name="request">Request data</param>
        /// <returns>Represents an asynchronous operation.</returns>
        public async Task UpdateAsync(ChangeRequest request)
        {
            await _changeApplication.Value.HandleAsync(request);
        }

        /// <summary>
        /// Removes an user and asynchronously using Task.
        /// </summary>
        /// <param name="request">Request data</param>
        /// <returns>Represents an asynchronous operation.</returns>
        public async Task RemoveAsync(DeleteRequest request)
        {
            await _deleteApplication.Value.HandleAsync(request);
        }

        /// <summary>
        /// Gets the user and asynchronously using Task.
        /// </summary>
        /// <param name="request">Request data</param>
        /// <returns>
        /// Task: Represents an asynchronous operation. 
        /// Response data.
        /// </returns>
        public async Task<ReadResponse> GetAsync(ReadRequest request)
        {
            return await _readApplication.Value.HandleAsync(request);
        }

        /// <summary>
        /// Gets all registered users and asynchronously using Task.
        /// </summary>
        /// <returns>
        /// Task: Represents an asynchronous operation. 
        /// Response data.
        /// </returns>
        public async Task<IEnumerable<ReadAllResponse>> GetAllAsync()
        {
            return await _readAllApplication.Value.HandleAsync();
        }

        /// <summary>
        /// Accesses the system through authentication and asynchronously using Task.
        /// </summary>
        /// <param name="request">Request data</param>
        /// <returns>
        /// Task: Represents an asynchronous operation. 
        /// Response data.
        /// </returns>
        public async Task<SignInResponse> SignInAsync(SignInRequest request)
        {
            return await _signInApplication.Value.HandleAsync(request);
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