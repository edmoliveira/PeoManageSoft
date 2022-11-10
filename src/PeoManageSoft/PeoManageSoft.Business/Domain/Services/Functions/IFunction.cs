namespace PeoManageSoft.Business.Domain.Services.Functions
{
    /// <summary>
    /// The Function interface declares a method for executing a function.
    /// </summary>
    /// <typeparam name="TRequest">The type of request value</typeparam>
    /// <typeparam name="TResponse">The type of response value</typeparam>
    internal interface IFunctionScope<TRequest, TResponse>
    {
        #region Methods

        /// <summary>
        /// Executes the function.
        /// </summary>
        /// <param name="request">Request</param>
        /// <returns>
        /// The return value
        /// </returns>
        TResponse Execute(TRequest request);

        #endregion
    }

    /// <summary>
    /// The Function interface declares a method for executing a function and asynchronously using Task.
    /// </summary>
    /// <typeparam name="TRequest">The type of request value</typeparam>
    /// <typeparam name="TResponse">The type of response value</typeparam>
    internal interface IFunctionAsync<TRequest, TResponse>
    {
        #region Methods

        /// <summary>
        /// Executes the function and asynchronously using Task.
        /// </summary>
        /// <param name="request">Request</param>
        /// <returns>
        /// Task: Represents an asynchronous operation. 
        /// The return value
        /// </returns>
        Task<TResponse> ExecuteAsync(TRequest request);

        #endregion
    }

    /// <summary>
    /// The Function interface declares a method for executing a function.
    /// </summary>
    /// <typeparam name="TRequest">The type of request value</typeparam>
    internal interface IFunctionScope<TRequest>
    {
        #region Methods

        /// <summary>
        /// Executes the function.
        /// </summary>
        /// <param name="request">Request</param>
        void Execute(TRequest request);

        #endregion
    }

    /// <summary>
    /// The Function interface declares a method for executing a function and asynchronously using Task.
    /// </summary>
    /// <typeparam name="TRequest">The type of request value</typeparam>
    internal interface IFunctionAsync<TRequest>
    {
        #region Methods

        /// <summary>
        /// Executes the function and asynchronously using Task.
        /// </summary>
        /// <param name="request">Request</param>
        /// <returns>Represents an asynchronous operation.</returns>
        Task ExecuteAsync(TRequest request);

        #endregion
    }

    /// <summary>
    /// The Function interface declares a method for executing a function.
    /// </summary>
    /// <typeparam name="TResponse">The type of response value</typeparam>
    internal interface IResponseFunctionScope<TResponse>
    {
        #region Methods

        /// <summary>
        /// Executes the function.
        /// </summary>
        /// <returns>
        /// The return value
        /// </returns>
        TResponse Execute();

        #endregion
    }

    /// <summary>
    /// The Function interface declares a method for executing a function and asynchronously using Task.
    /// </summary>
    /// <typeparam name="TResponse">The type of response value</typeparam>
    internal interface IResponseFunctionScopeAsync<TResponse>
    {
        #region Methods

        /// <summary>
        /// Executes the function and asynchronously using Task.
        /// </summary>
        /// <returns>
        /// Task: Represents an asynchronous operation. 
        /// The return value
        /// </returns>
        Task<TResponse> ExecuteAsync();

        #endregion
    }
}
