using AllregoSoft.WebManagementSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace AllregoSoft.WebManagementSystem.ApplicationCore.Interfaces
{
    public interface IMemberDbContext
    {
        DbSet<tbl_ScmMember> tbl_ScmMember { get; set; }
    }
}
