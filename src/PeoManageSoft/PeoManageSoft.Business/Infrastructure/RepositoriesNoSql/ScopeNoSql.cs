using PeoManageSoft.Business.Infrastructure.Helpers.Exceptions;
using PeoManageSoft.Business.Infrastructure.RepositoriesNoSql.Driver;

namespace PeoManageSoft.Business.Infrastructure.RepositoriesNoSql
{
    /// <summary>
    /// Makes a code block. 
    /// </summary>
    internal sealed class ScopeNoSql: IScopeNoSql
    {
        #region Fields

        /// <summary>
        /// Defines a mechanism for retrieving a service object; that is, an object that provides custom support to other objects.
        /// </summary>
        private readonly IServiceProvider _provider;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the PeoManageSoft.Business.Infrastructure.RepositoriesNoSql.ScopeNoSql class.
        /// </summary>
        /// <param name="provider">Defines a mechanism for retrieving a service object; that is, an object that provides custom support to other objects.</param>
        public ScopeNoSql(IServiceProvider provider)
        {
            _provider = provider;
        }

        #endregion

        #region Methods

        #region public

        /// <summary>
        /// The statement defines a boundary for the object outside of which, the connection is automatically destroyed.
        /// </summary>
        /// <param name="action">Delegate that has the method that receives the IRepositoryNoSql parameter and does not return a value.</param>
        public void Using(Action<IRepositoryNoSql> action)
        {
            using var client = GetClientNoSql();
            using var repository = CreateRepositoryNoSql(client);

            action(repository);
        }

        /// <summary>
        /// The statement defines a boundary for the object outside of which, the connection is automatically destroyed and asynchronously using Task.
        /// </summary>
        /// <param name="func">Function that has the method that receives the IRepositoryNoSql parameter and returns the asynchronous operation.</param>
        /// <returns>Returns the asynchronous operation.</returns>
        public async Task UsingAsync(Func<IRepositoryNoSql, Task> func)
        {
            using var client = GetClientNoSql();
            using var repository = CreateRepositoryNoSql(client);

            await func(repository).ConfigureAwait(false);
        }

        /// <summary>
        /// The statement defines a boundary for the object outside of which, the connection is automatically destroyed and that returns the type "T".
        /// </summary>
        /// <typeparam name="T">The type of the return</typeparam>
        /// <param name="func">Function that has the method that receives the IRepositoryNoSql parameter and returns the type "T".</param>
        /// <returns>Returns the type "T"</returns>
        public T Using<T>(Func<IRepositoryNoSql, T> func)
        {
            using var client = GetClientNoSql(); 
            using var repository = CreateRepositoryNoSql(client);

            return func(repository);
        }

        /// <summary>
        /// The statement defines a boundary for the object outside of which, the connection is automatically destroyed and that returns the type "T" and asynchronously using Task.
        /// </summary>
        /// <typeparam name="T">The type of the return</typeparam>
        /// <param name="func">Function that has the method that receives the IRepositoryNoSql parameter and the asynchronous operation that returns the type "T"</param>
        /// <returns>Returns the asynchronous operation that returns the type "T"</returns>
        public async Task<T> UsingAsync<T>(Func<IRepositoryNoSql, Task<T>> func)
        {
            using var client = GetClientNoSql();
            using var repository = CreateRepositoryNoSql(client);

            return await func(repository).ConfigureAwait(false);
        }

        #endregion

        #region private

        /// <summary>
        /// Gets the IClientNoSql instance.
        /// </summary>
        /// <returns>Returns the cross-platform NoSQL document-oriented database client.</returns>
        /// <exception cref="ProviderServiceNotFoundException">Represents errors that occur when service provider tries to get a service.</exception>
        private IClientNoSql GetClientNoSql()
        {
            if (_provider.GetService(typeof(IClientNoSql)) is not IClientNoSql client)
            {
                throw new ProviderServiceNotFoundException(nameof(IClientNoSql));
            }

            return client;
        }

        /// <summary>
        /// Creates a new IRepositoryNoSql instance.
        /// </summary>
        /// <param name="client">Cross-platform NoSQL document-oriented database client.</param>
        /// <returns>Returns the Non-SQL repositories.</returns>
        /// <exception cref="ProviderServiceNotFoundException">Represents errors that occur when service provider tries to get a service.</exception>
        private static IRepositoryNoSql CreateRepositoryNoSql(IClientNoSql client)
        {
            return new RepositoryNoSql(client);
        }

        #endregion

        #endregion
    }
}
