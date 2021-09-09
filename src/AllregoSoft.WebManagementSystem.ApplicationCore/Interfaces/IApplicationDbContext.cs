using AllregoSoft.WebManagementSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace AllregoSoft.WebManagementSystem.ApplicationCore.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<tbl_Member> tbl_Member { get; set; }

        DbSet<tbl_Role> tbl_Role { get; set; }
        DbSet<tbl_SiteMap> tbl_SiteMap { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
