using System.Data;

namespace Repository.Interfaces
{
    public interface IRepositoryContext
    {
        public Task<T> WithConnection<T>(Func<IDbConnection, Task<T>> getData);

        public Task WithConnection(Func<IDbConnection, Task> getData);

        public Task<TResult> WithConnection<TRead, TResult>(Func<IDbConnection, Task<TRead>> getData, Func<TRead, Task<TResult>> process);
    }
}
