using PeoManageSoft.Business.Infrastructure.Helpers.Exceptions;
using PeoManageSoft.Business.Infrastructure.ObjectRelationalMapper.Interfaces;
using System.Data;
using System.Data.Common;

namespace PeoManageSoft.Business.Infrastructure.ObjectRelationalMapper
{
    /// <summary>
    /// Makes a code block transactional. 
    /// </summary>
    internal sealed class TransactionScopeOrm : ITransactionScope
    {
        #region Fields

        /// <summary>
        /// Defines a mechanism for retrieving a service object; that is, an object that provides custom support to other objects.
        /// </summary>
        private readonly IServiceProvider _provider;
        /// <summary>
        /// Represents a connection to a database.
        /// </summary>
        private readonly IConnection _connection;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the PeoManageSoft.Business.Infrastructure.ObjectRelationalMapper.TransactionScopeOrm class.
        /// </summary>
        /// <param name="provider">Defines a mechanism for retrieving a service object; that is, an object that provides custom support to other objects.</param>
        /// <param name="connection">Represents a connection to a database.</param>
        public TransactionScopeOrm(IServiceProvider provider, IConnection connection)
        {
            _provider = provider;
            _connection = connection;
        }

        #endregion

        #region Methods

        #region public

        /// <summary>
        /// The statement defines a boundary for the object outside of which, the connection is automatically destroyed.
        /// </summary>
        /// <param name="action">Delegate that has the method that receives the IScope parameter and does not return a value.</param>
        public void Using(Action<IScope> action)
        {
            using DbConnection connection = _connection.CreateConnection();
            connection.Open();

            IIScope scope = (IIScope)GetScope(connection);

            try
            {
                action(scope);
            }
            catch (Exception)
            {
                if (scope.TransactionStatus == TransactionStatus.Initialized)
                {
                    scope.RollBackTransaction();
                }

                throw;
            }
            finally
            {
                if (scope.TransactionStatus == TransactionStatus.Initialized)
                {
                    scope.CommitTransaction();
                }
            }
        }

        /// <summary>
        /// The statement defines a boundary for the object outside of which, the connection is automatically destroyed and asynchronously using Task.
        /// </summary>
        /// <param name="func">Function that has the method that receives the IScope parameter and returns the asynchronous operation.</param>
        /// <returns>Returns the asynchronous operation.</returns>
        public async Task UsingAsync(Func<IScope, Task> func)
        {
            using DbConnection connection = _connection.CreateConnection();
            await connection.OpenAsync();

            IIScope scope = (IIScope)GetScope(connection);

            try
            {
                await func(scope).ConfigureAwait(false);
            }
            catch (Exception)
            {
                if (scope.TransactionStatus == TransactionStatus.Initialized)
                {
                    scope.RollBackTransaction();
                }

                throw;
            }
            finally
            {
                if (scope.TransactionStatus == TransactionStatus.Initialized)
                {
                    scope.CommitTransaction();
                }
            }
        }

        /// <summary>
        /// The statement defines a boundary for the object outside of which, the connection is automatically destroyed and that returns the type "T".
        /// </summary>
        /// <typeparam name="T">The type of the return</typeparam>
        /// <param name="func">Function that has the method that receives the IScope parameter and returns the type "T".</param>
        /// <returns>Returns the type "T"</returns>
        public T Using<T>(Func<IScope, T> func)
        {
            using DbConnection connection = _connection.CreateConnection();
            connection.Open();

            IIScope scope = (IIScope)GetScope(connection);

            try
            {
                return func(scope);
            }
            catch (Exception)
            {
                if (scope.TransactionStatus == TransactionStatus.Initialized)
                {
                    scope.RollBackTransaction();
                }

                throw;
            }
            finally
            {
                if (scope.TransactionStatus == TransactionStatus.Initialized)
                {
                    scope.CommitTransaction();
                }
            }
        }

        /// <summary>
        /// The statement defines a boundary for the object outside of which, the connection is automatically destroyed and that returns the type "T" and asynchronously using Task.
        /// </summary>
        /// <typeparam name="T">The type of the return</typeparam>
        /// <param name="func">Function that has the method that receives the IScope parameter and the asynchronous operation that returns the type "T"</param>
        /// <returns>Returns the asynchronous operation that returns the type "T"</returns>
        public async Task<T> UsingAsync<T>(Func<IScope, Task<T>> func)
        {
            using DbConnection connection = _connection.CreateConnection();
            await connection.OpenAsync();

            IIScope scope = (IIScope)GetScope(connection);

            try
            {
                return await func(scope).ConfigureAwait(false);
            }
            catch (Exception)
            {
                if (scope.TransactionStatus == TransactionStatus.Initialized)
                {
                    scope.RollBackTransaction();
                }

                throw;
            }
            finally
            {
                if (scope.TransactionStatus == TransactionStatus.Initialized)
                {
                    scope.CommitTransaction();
                }
            }
        }

        #endregion

        #region private

        /// <summary>
        /// Gets the IContentScope instance.
        /// </summary>
        /// <param name="connection">Represents an open connection to a data source, and is implemented by .NET data providers that access relational databases.</param>
        /// <returns>Returns the transactional scope with the connection.</returns>
        /// <exception cref="ProviderServiceNotFoundException">Represents errors that occur when service provider tries to get a service.</exception>
        private IContentScope GetScope(IDbConnection connection)
        {
            if (_provider.GetService(typeof(IContentScope)) is not IContentScope scope)
            {
                throw new ProviderServiceNotFoundException(nameof(IContentScope));
            }

            scope.Connection = connection;

            return scope;
        }

        #endregion

        #endregion
    }
}
