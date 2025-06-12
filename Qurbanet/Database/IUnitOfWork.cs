using Qurbanet.Database.Repositories;

namespace Qurbanet.Database
{
    public interface IUnitOfWork : IDisposable
    {
        BaseRepository<T> Repository<T>() where T : class;
        Task<int> SaveChangesAsync();
        // Transaction Methods
        Task BeginTransactionAsync();
        Task CommitTransactionAsync();
        Task RollbackTransactionAsync();
    }
}
