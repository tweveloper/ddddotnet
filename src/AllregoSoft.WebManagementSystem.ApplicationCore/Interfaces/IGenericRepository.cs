using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace AllregoSoft.WebManagementSystem.ApplicationCore.Interfaces
{
    public interface IGenericRepository<TEntity> 
        where TEntity : class
    {
        DbSet<TEntity> Entity { get; }
        DbContext UnitOfWork { get; }
        //public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
        //public Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}
