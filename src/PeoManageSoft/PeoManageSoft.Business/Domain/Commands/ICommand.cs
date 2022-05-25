using PeoManageSoft.Business.Infrastructure.ObjectRelationalMapper;

namespace PeoManageSoft.Business.Domain.Commands
{
    /// <summary>
    /// The Command interface declares a method for executing a command.
    /// </summary>
    /// <typeparam name="TRequest">The type of request value</typeparam>
    /// <typeparam name="TResponse">The type of response value</typeparam>
    internal interface ICommandScope<TRequest, TResponse> where TRequest : class where TResponse : class
    {
        #region Methods

        /// <summary>
        /// Executes the command.
        /// </summary>
        /// <param name="scope">Transactional scope</param>
        /// <param name="request">Request</param>
        /// <returns>
        /// The return value
        /// </returns>
        TResponse Execute(IScope scope, TRequest request);

        #endregion
    }

    /// <summary>
    /// The Command interface declares a method for executing a command and asynchronously using Task.
    /// </summary>
    /// <typeparam name="TRequest">The type of request value</typeparam>
    /// <typeparam name="TResponse">The type of response value</typeparam>
    internal interface ICommandScopeAsync<TRequest, TResponse> where TRequest : class where TResponse : class
    {
        #region Methods

        /// <summary>
        /// Executes the command and asynchronously using Task.
        /// </summary>
        /// <param name="scope">Transactional scope</param>
        /// <param name="request">Request</param>
        /// <returns>
        /// Task: Represents an asynchronous operation. 
        /// The return value
        /// </returns>
        Task<TResponse> ExecuteAsync(IScope scope, TRequest request);

        #endregion
    }

    /// <summary>
    /// The Command interface declares a method for executing a command.
    /// </summary>
    /// <typeparam name="TRequest">The type of request value</typeparam>
    internal interface ICommandScope<TRequest> where TRequest : class
    {
        #region Methods

        /// <summary>
        /// Executes the command.
        /// </summary>
        /// <param name="scope">Transactional scope</param>
        /// <param name="request">Request</param>
        void Execute(IScope scope, TRequest request);

        #endregion
    }

    /// <summary>
    /// The Command interface declares a method for executing a command and asynchronously using Task.
    /// </summary>
    /// <typeparam name="TRequest">The type of request value</typeparam>
    internal interface ICommandScopeAsync<TRequest> where TRequest : class
    {
        #region Methods

        /// <summary>
        /// Executes the command and asynchronously using Task.
        /// </summary>
        /// <param name="scope">Transactional scope</param>
        /// <param name="request">Request</param>
        /// <returns>Represents an asynchronous operation. </returns>
        Task ExecuteAsync(IScope scope, TRequest request);

        #endregion
    }
}