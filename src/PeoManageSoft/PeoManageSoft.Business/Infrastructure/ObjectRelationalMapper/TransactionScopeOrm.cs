using PeoManageSoft.Business.Infrastructure.Helpers.Exceptions;
using System.Data;
using System.Data.Common;

namespace PeoManageSoft.Business.Infrastructure.ObjectRelationalMapper
{
    /// <summary>
    /// Makes a code block transactional. 
    /// </summary>
    public sealed class TransactionScopeOrm : ITransactionScope
    {
        private readonly IServiceProvider _provider;
        private readonly IConnection _connection;

        public TransactionScopeOrm(IServiceProvider provider, IConnection connection)
        {
            _provider = provider;
            _connection = connection;
        }

        public void Using(Action<IScope> action)
        {
            using DbConnection connection = _connection.CreateConnection();
            connection.Open();

            action(GetScope(connection));
        }

        public async Task UsingAsync(Func<IScope, Task> func)
        {
            using DbConnection connection = _connection.CreateConnection();
            await connection.OpenAsync();

            await func(GetScope(connection)).ConfigureAwait(false);
        }

        public T Using<T>(Func<IScope, T> func)
        {
            using DbConnection connection = _connection.CreateConnection();
            connection.Open();

            return func(GetScope(connection));
        }

        public async Task<T> UsingAsync<T>(Func<IScope, Task<T>> func)
        {
            using DbConnection connection = _connection.CreateConnection();
            await connection.OpenAsync();

            return await func(GetScope(connection)).ConfigureAwait(false);
        }

        private IContentScope GetScope(IDbConnection connection)
        {
            if (_provider.GetService(typeof(IContentScope)) is not IContentScope scope)
            {
                throw new ProviderServiceNotFoundException(nameof(IContentScope));
            }

            scope.Connection = connection;

            return scope;
        }
    }
}
