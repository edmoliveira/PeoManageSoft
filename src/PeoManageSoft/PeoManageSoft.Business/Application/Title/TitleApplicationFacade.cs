using PeoManageSoft.Business.Application.Title.Change;
using PeoManageSoft.Business.Application.Title.Delete;
using PeoManageSoft.Business.Application.Title.New;
using PeoManageSoft.Business.Application.Title.Read;
using PeoManageSoft.Business.Application.Title.Read.Response;
using PeoManageSoft.Business.Application.Title.ReadAll;
using PeoManageSoft.Business.Application.Title.ReadAllWithPagination;
using PeoManageSoft.Business.Application.Title.SearchWithPagination;
using PeoManageSoft.Business.Infrastructure.Helpers.Exceptions;

namespace PeoManageSoft.Business.Application.Title
{
    /// <summary>
    /// Title Facade that provides a simplified interface.
    /// </summary>
    internal sealed class TitleApplicationFacade : ITitleApplicationFacade
    {
        #region Fields

        /// <summary>
        /// Defines a mechanism for retrieving a service object; that is, an object that provides custom support to other objects.
        /// </summary>
        private readonly IServiceProvider _provider;
        /// <summary>
        /// New title application layer.
        /// </summary>
        private readonly Lazy<INewApplication> _newApplication;
        /// <summary>
        /// Change title application layer.
        /// </summary>
        private readonly Lazy<IChangeApplication> _changeApplication;
        /// <summary>
        /// Delete title application layer.
        /// </summary>
        private readonly Lazy<IDeleteApplication> _deleteApplication;
        /// <summary>
        /// Read title application layer.
        /// </summary>
        private readonly Lazy<IReadApplication> _readApplication;
        /// <summary>
        /// Read all title application layer.
        /// </summary>
        private readonly Lazy<IReadAllApplication> _readAllApplication;
        /// <summary>
        /// Read all titles with pagination application layer.
        /// </summary>
        private readonly Lazy<IReadAllWithPaginationApplication> _readAllWithPaginationApplication;
        /// <summary>
        /// Search titles with pagination application layer.
        /// </summary>
        private readonly Lazy<ISearchWithPaginationApplication> _searchWithPaginationApplication;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the PeoManageSoft.Business.Application.Title.TitleApplicationFacade class.
        /// </summary>
        /// <param name="provider">Defines a mechanism for retrieving a service object; that is, an object that provides custom support to other objects.</param>
        public TitleApplicationFacade(IServiceProvider provider)
        {
            _provider = provider;

            _newApplication = new Lazy<INewApplication>(() => GetService<INewApplication>());
            _changeApplication = new Lazy<IChangeApplication>(() => GetService<IChangeApplication>());
            _deleteApplication = new Lazy<IDeleteApplication>(() => GetService<IDeleteApplication>());
            _readApplication = new Lazy<IReadApplication>(() => GetService<IReadApplication>());
            _readAllApplication = new Lazy<IReadAllApplication>(() => GetService<IReadAllApplication>());
            _readAllWithPaginationApplication = new Lazy<IReadAllWithPaginationApplication>(() => GetService<IReadAllWithPaginationApplication>());
            _searchWithPaginationApplication = new Lazy<ISearchWithPaginationApplication>(() => GetService<ISearchWithPaginationApplication>());
        }

        #endregion

        #region Methods

        #region public

        /// <summary>
        /// Registers an new title and asynchronously using Task.
        /// </summary>
        /// <param name="request">Request data</param>
        /// <returns>
        /// Task: Represents an asynchronous operation. 
        /// Response data.
        /// </returns>
        public async Task<NewResponse> AddAsync(NewRequest request)
        {
            return await _newApplication.Value.HandleAsync(request).ConfigureAwait(false);
        }

        /// <summary>
        /// Updates an title data and asynchronously using Task.
        /// </summary>
        /// <param name="request">Request data</param>
        /// <returns>Represents an asynchronous operation.</returns>
        public async Task UpdateAsync(ChangeRequest request)
        {
            await _changeApplication.Value.HandleAsync(request).ConfigureAwait(false);
        }

        /// <summary>
        /// Removes an title and asynchronously using Task.
        /// </summary>
        /// <param name="request">Request data</param>
        /// <returns>Represents an asynchronous operation.</returns>
        public async Task RemoveAsync(DeleteRequest request)
        {
            await _deleteApplication.Value.HandleAsync(request).ConfigureAwait(false);
        }

        /// <summary>
        /// Gets the title and asynchronously using Task.
        /// </summary>
        /// <param name="request">Request data</param>
        /// <returns>
        /// Task: Represents an asynchronous operation. 
        /// Response data.
        /// </returns>
        public async Task<ReadResponse> GetAsync(ReadRequest request)
        {
            return await _readApplication.Value.HandleAsync(request).ConfigureAwait(false);
        }

        /// <summary>
        /// Gets all registered titles and asynchronously using Task.
        /// </summary>
        /// <returns>
        /// Task: Represents an asynchronous operation. 
        /// Response data.
        /// </returns>
        public async Task<IEnumerable<ReadResponse>> GetAllAsync()
        {
            return await _readAllApplication.Value.HandleAsync().ConfigureAwait(false);
        }

        /// <summary>
        /// Gets all registered titles with pagination and asynchronously using Task.
        /// </summary>
        /// <param name="request">Request data</param>
        /// <returns>
        /// Task: Represents an asynchronous operation. 
        /// Response data.
        /// </returns>
        public async Task<IEnumerable<ReadResponse>> GetAllWithPaginationAsync(ReadAllWithPaginationRequest request)
        {
            return await _readAllWithPaginationApplication.Value.HandleAsync(request).ConfigureAwait(false);
        }

        /// <summary>
        /// Search titles with pagination and asynchronously using Task.
        /// </summary>
        /// <param name="request">Request data</param>
        /// <returns>
        /// Task: Represents an asynchronous operation. 
        /// Response data.
        /// </returns>
        public async Task<IEnumerable<ReadResponse>> SearchWithPaginationAsync(SearchWithPaginationRequest request)
        {
            return await _searchWithPaginationApplication.Value.HandleAsync(request).ConfigureAwait(false);
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