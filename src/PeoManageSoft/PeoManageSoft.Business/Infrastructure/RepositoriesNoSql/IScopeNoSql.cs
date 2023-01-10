namespace PeoManageSoft.Business.Infrastructure.RepositoriesNoSql
{
    /// <summary>
    /// Makes a code block. 
    /// </summary>
    internal interface IScopeNoSql
    {
        #region Methods

        /// <summary>
        /// The statement defines a boundary for the object outside of which, the connection is automatically destroyed.
        /// </summary>
        /// <param name="action">Delegate that has the method that receives the IRepositoryNoSql parameter and does not return a value.</param>
        public void Using(Action<IRepositoryNoSql> action);
        /// <summary>
        /// The statement defines a boundary for the object outside of which, the connection is automatically destroyed and asynchronously using Task.
        /// </summary>
        /// <param name="func">Function that has the method that receives the IRepositoryNoSql parameter and returns the asynchronous operation.</param>
        /// <returns>Returns the asynchronous operation.</returns>
        Task UsingAsync(Func<IRepositoryNoSql, Task> func);
        /// <summary>
        /// The statement defines a boundary for the object outside of which, the connection is automatically destroyed and that returns the type "T".
        /// </summary>
        /// <typeparam name="T">The type of the return</typeparam>
        /// <param name="func">Function that has the method that receives the IRepositoryNoSql parameter and returns the type "T".</param>
        /// <returns>Returns the type "T"</returns>
        T Using<T>(Func<IRepositoryNoSql, T> func);
        /// <summary>
        /// The statement defines a boundary for the object outside of which, the connection is automatically destroyed and that returns the type "T" and asynchronously using Task.
        /// </summary>
        /// <typeparam name="T">The type of the return</typeparam>
        /// <param name="func">Function that has the method that receives the IRepositoryNoSql parameter and the asynchronous operation that returns the type "T"</param>
        /// <returns>Returns the asynchronous operation that returns the type "T"</returns>
        Task<T> UsingAsync<T>(Func<IRepositoryNoSql, Task<T>> func);

        #endregion
    }
}
