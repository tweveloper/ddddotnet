using System;
using System.Threading;
using System.Threading.Tasks;

namespace AllregoSoft.WebManagementSystem.ApplicationCore.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
        public Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}
