using PeoManageSoft.Business.Domain.Services.Functions.Department.Exists;
using PeoManageSoft.Business.Domain.Services.Functions.Department.NameExists;
using PeoManageSoft.Business.Infrastructure.Helpers.Exceptions;

namespace PeoManageSoft.Business.Domain.Services.Functions.Department
{
    /// <summary>
    /// Department Facade that provides a simplified interface.
    /// </summary>
    internal sealed class DepartmentFunctionFacade : IDepartmentFunctionFacade
    {
        #region Fields

        /// <summary>
        /// Defines a mechanism for retrieving a service object; that is, an object that provides custom support to other objects.
        /// </summary>
        private readonly IServiceProvider _provider;
        /// <summary>
        /// Function that determines whether the specified department table contains the record that match the id
        /// </summary>
        private readonly Lazy<IExistsFunction> _existsFunction;
        /// <summary>
        /// Function that determines if the name already exists in the department table.
        /// </summary>
        private readonly Lazy<INameExistsFunction> _nameExistsFunction;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the PeoManageSoft.Business.Domain.Services.Functions.Department.DepartmentFunctionFacade class.
        /// </summary>
        /// <param name="provider">Defines a mechanism for retrieving a service object; that is, an object that provides custom support to other objects.</param>
        public DepartmentFunctionFacade(IServiceProvider provider)
        {
            _provider = provider;

            _existsFunction = new Lazy<IExistsFunction>(() => GetService<IExistsFunction>());
            _nameExistsFunction = new Lazy<INameExistsFunction>(() => GetService<INameExistsFunction>());
        }

        #endregion

        #region Methods

        #region public

        /// <summary>
        /// Determines whether the specified department table contains the record that match the id and asynchronously using Task.
        /// </summary>
        /// <param name="departmentId">Department identifier</param>
        /// <returns>
        /// Task: Represents an asynchronous operation. 
        /// Returns true if the department already exists.
        /// </returns>
        public async Task<bool> ExistsAsync(long departmentId)
        {
            return await _existsFunction.Value.ExecuteAsync(departmentId).ConfigureAwait(false);
        }

        /// <summary>
        /// Determines if the name already exists in the department table.
        /// </summary>
        /// <param name="name">Department name</param>
        /// <param name="departmentId">Department identifier</param>
        /// <returns>
        /// Task: Represents an asynchronous operation. 
        /// Returns true if the name already exists.
        /// </returns>
        public async Task<bool> NameExistsAsync(string name, long? departmentId = null)
        {
            return await _nameExistsFunction.Value
                .ExecuteAsync(new NameExistsFunctionRequest(name, departmentId))
                .ConfigureAwait(false);
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
