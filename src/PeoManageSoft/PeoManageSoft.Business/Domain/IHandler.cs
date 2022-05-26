namespace PeoManageSoft.Business.Domain
{
    /// <summary>
    /// Handles the commands and queries created in the application.
    /// </summary>
    /// <typeparam name="TRequest">Request for the commands</typeparam>
    /// <typeparam name="TResponse">Response for the commands.</typeparam>
    internal interface IHandler<TRequest, TResponse> where TRequest : class where TResponse : class
    {
        #region Methods

        /// <summary>
        /// Handles the commands
        /// </summary>
        /// <param name="request">Request for the commands.</param>
        /// <returns>Response for the commands.</returns>
        TResponse Handle(TRequest request);

        #endregion
    }

    /// <summary>
    /// Handles the commands and queries created in the application and asynchronously using Task.
    /// </summary>
    /// <typeparam name="TRequest">Request for the commands</typeparam>
    /// <typeparam name="TResponse">Response for the commands.</typeparam>
    internal interface IHandlerAsync<TRequest, TResponse> where TRequest : class where TResponse : class
    {
        #region Methods

        /// <summary>
        /// Handles the commands
        /// </summary>
        /// <param name="request">Request for the commands.</param>
        /// <returns>
        /// Task: Represents an asynchronous operation. 
        /// Response for the commands.
        /// </returns>
        Task<TResponse> HandleAsync(TRequest request);

        #endregion
    }

    /// <summary>
    /// Handles the commands and queries created in the application.
    /// </summary>
    /// <typeparam name="TRequest">Request for the commands</typeparam>
    internal interface IHandler<TRequest> where TRequest : class
    {
        #region Methods

        /// <summary>
        /// Handles the commands
        /// </summary>
        /// <param name="request">Request for the commands.</param>
        void Handle(TRequest request);

        #endregion
    }

    /// <summary>
    /// Handles the commands and queries created in the application and asynchronously using Task.
    /// </summary>
    /// <typeparam name="TRequest">Request for the commands</typeparam>
    internal interface IHandlerAsync<TRequest> where TRequest : class
    {
        #region Methods

        /// <summary>
        /// Handles the commands
        /// </summary>
        /// <param name="request">Request for the commands.</param>
        /// <returns>Represents an asynchronous operation.</returns>
        Task HandleAsync(TRequest request);

        #endregion
    }

    /// <summary>
    /// Handles the commands and queries created in the application.
    /// </summary>
    /// <typeparam name="TResponse">Response for the commands.</typeparam>
    internal interface IResponseHandler<TResponse> where TResponse : class
    {
        #region Methods

        /// <summary>
        /// Handles the commands
        /// </summary>
        /// <returns>Response for the commands.</returns>
        TResponse Handle();

        #endregion
    }

    /// <summary>
    /// Handles the commands and queries created in the application and asynchronously using Task.
    /// </summary>
    /// <typeparam name="TResponse">Response for the commands.</typeparam>
    internal interface IResponseHandlerAsync<TResponse> where TResponse : class
    {
        #region Methods

        /// <summary>
        /// Handles the commands
        /// </summary>
        /// <returns>
        /// Task: Represents an asynchronous operation. 
        /// Response for the commands.
        /// </returns>
        Task<TResponse> HandleAsync();

        #endregion
    }
}
