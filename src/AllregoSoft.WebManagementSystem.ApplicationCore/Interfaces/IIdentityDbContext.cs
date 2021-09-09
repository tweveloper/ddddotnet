using AllregoSoft.WebManagementSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace AllregoSoft.WebManagementSystem.ApplicationCore.Interfaces
{
    public interface IIdentityDbContext
    {
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
