namespace PeoManageSoft.Business.Infrastructure.ObjectRelationalMapper
{
    public interface ITransactionScope
    {
        void Using(Action<IScope> action);
        Task UsingAsync(Func<IScope, Task> func);
        public T Using<T>(Func<IScope, T> func);
        Task<T> UsingAsync<T>(Func<IScope, Task<T>> func);
    }
}
