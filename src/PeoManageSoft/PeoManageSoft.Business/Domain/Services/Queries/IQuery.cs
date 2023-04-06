using PeoManageSoft.Business.Infrastructure.ObjectRelationalMapper.Interfaces;

namespace PeoManageSoft.Business.Domain.Services.Queries
{
    /// <summary>
    /// The Query interface declares a method for executing a query.
    /// </summary>
    /// <typeparam name="TRequest">The type of request value</typeparam>
    /// <typeparam name="TResponse">The type of response value</typeparam>
    internal interface IQueryScope<TRequest, TResponse> where TRequest : class where TResponse : class
    {
        #region Methods

        /// <summary>
        /// Executes the query.
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
    /// The Query interface declares a method for executing a query and asynchronously using Task.
    /// </summary>
    /// <typeparam name="TRequest">The type of request value</typeparam>
    /// <typeparam name="TResponse">The type of response value</typeparam>
    internal interface IQueryScopeAsync<TRequest, TResponse> where TRequest : class where TResponse : class
    {
        #region Methods

        /// <summary>
        /// Executes the query and asynchronously using Task.
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
    /// The Query interface declares a method for executing a query.
    /// </summary>
    /// <typeparam name="TResponse">The type of response value</typeparam>
    internal interface IQueryScope<TResponse> where TResponse : class
    {
        #region Methods

        /// <summary>
        /// Executes the query.
        /// </summary>
        /// <param name="scope">Transactional scope</param>
        /// <returns>
        /// The return value
        /// </returns>
        TResponse Execute(IScope scope);

        #endregion
    }

    /// <summary>
    /// The Query interface declares a method for executing a query and asynchronously using Task.
    /// </summary>
    /// <typeparam name="TResponse">The type of response value</typeparam>
    internal interface IQueryScopeAsync<TResponse> where TResponse : class
    {
        #region Methods

        /// <summary>
        /// Executes the query and asynchronously using Task.
        /// </summary>
        /// <param name="scope">Transactional scope</param>
        /// <returns>
        /// Task: Represents an asynchronous operation. 
        /// The return value
        /// </returns>
        Task<TResponse> ExecuteAsync(IScope scope);

        #endregion
    }

    /// <summary>
    /// The Query interface declares a method for executing a query.
    /// </summary>
	/// <typeparam name="TCollection">The type of the cross-platform NoSQL collection.</typeparam>
    /// <typeparam name="TRequest">The type of request value</typeparam>
    /// <typeparam name="TResponse">The type of response value</typeparam>
    internal interface IQueryNoSql<TCollection, TRequest, TResponse> where TRequest : class where TResponse : class
    {
        #region Methods

        /// <summary>
        /// Executes the query.
        /// </summary>
        /// <param name="collection">Cross-platform NoSQL collection</param>
        /// <param name="request">Request</param>
        /// <returns>
        /// The return value
        /// </returns>
        TResponse Execute(TCollection collection, TRequest request);

        #endregion
    }

    /// <summary>
    /// The Query interface declares a method for executing a query and asynchronously using Task.
    /// </summary>
	/// <typeparam name="TCollection">The type of the cross-platform NoSQL collection.</typeparam>
    /// <typeparam name="TRequest">The type of request value</typeparam>
    /// <typeparam name="TResponse">The type of response value</typeparam>
    internal interface IQueryNoSqlAsync<TCollection, TRequest, TResponse> where TRequest : class where TResponse : class
    {
        #region Methods

        /// <summary>
        /// Executes the query and asynchronously using Task.
        /// </summary>
        /// <param name="collection">Cross-platform NoSQL collection</param>
        /// <param name="request">Request</param>
        /// <returns>
        /// Task: Represents an asynchronous operation. 
        /// The return value
        /// </returns>
        Task<TResponse> ExecuteAsync(TCollection collection, TRequest request);

        #endregion
    }

    /// <summary>
    /// The Query interface declares a method for executing a query.
    /// </summary>
	/// <typeparam name="TCollection">The type of the cross-platform NoSQL collection.</typeparam>
    /// <typeparam name="TRequest">The type of request value</typeparam>
    internal interface IQueryNoSql<TCollection, TRequest> where TRequest : class
    {
        #region Methods

        /// <summary>
        /// Executes the query.
        /// </summary>
        /// <param name="collection">Cross-platform NoSQL collection</param>
        /// <param name="request">Request</param>
        void Execute(TCollection collection, TRequest request);

        #endregion
    }

    /// <summary>
    /// The Query interface declares a method for executing a query and asynchronously using Task.
    /// </summary>
	/// <typeparam name="TCollection">The type of the cross-platform NoSQL collection.</typeparam>
    /// <typeparam name="TRequest">The type of request value</typeparam>
    internal interface IQueryNoSqlAsync<TCollection, TRequest> where TRequest : class
    {
        #region Methods

        /// <summary>
        /// Executes the query and asynchronously using Task.
        /// </summary>
        /// <param name="collection">Cross-platform NoSQL collection</param>
        /// <param name="request">Request</param>
        /// <returns>Represents an asynchronous operation. </returns>
        Task ExecuteAsync(TCollection collection, TRequest request);

        #endregion
    }
}
