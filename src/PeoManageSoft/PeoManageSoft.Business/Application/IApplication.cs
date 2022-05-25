namespace PeoManageSoft.Business.Application
{
    /// <summary>
    /// Handles the application layer.
    /// </summary>
    /// <typeparam name="TRequest">Request for the application layer</typeparam>
    /// <typeparam name="TResponse">Response for the application layer.</typeparam>
    public interface IApplication<TRequest, TResponse> where TRequest : class where TResponse : class
    {
        #region Methods

        /// <summary>
        /// Handles the application layer
        /// </summary>
        /// <param name="request">Request for the application layer.</param>
        /// <returns>Response for the application layer.</returns>
        TResponse Handle(TRequest request);

        #endregion
    }

    /// <summary>
    /// Handles the application layer and asynchronously using Task.
    /// </summary>
    /// <typeparam name="TRequest">Request for the application layer</typeparam>
    /// <typeparam name="TResponse">Response for the application layer.</typeparam>
    public interface IApplicationAsync<TRequest, TResponse> where TRequest : class where TResponse : class
    {
        #region Methods

        /// <summary>
        /// Handles the application layer
        /// </summary>
        /// <param name="request">Request for the application layer.</param>
        /// <returns>
        /// Task: Represents an asynchronous operation. 
        /// Response for the application layer.
        /// </returns>
        Task<TResponse> HandleAsync(TRequest request);

        #endregion
    }
}
