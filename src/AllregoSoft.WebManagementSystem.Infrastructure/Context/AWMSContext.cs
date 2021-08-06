using AllregoSoft.WebManagementSystem.ApplicationCore.Entities;
using AllregoSoft.WebManagementSystem.ApplicationCore.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace AllregoSoft.WebManagementSystem.Infrastructure.Context
{
    public partial class AWMSContext : DbContext
    {
        public readonly DbContextOptions<AWMSContext> _options;

        public AWMSContext(DbContextOptions<AWMSContext> options) : base(options)
        {
            _options = options;
        }

        public virtual DbSet<tbl_Member> tbl_Member { get; set; }
        public virtual DbSet<tbl_Role> tbl_Role { get; set; }
        public virtual DbSet<tbl_SiteMap> tbl_SiteMap { get; set; }
        public virtual DbSet<tbl_Role_Mapping> tbl_Role_Mapping { get; set; }
        public virtual DbSet<tbl_MemberToken> tbl_MemberToken { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var foreignKey in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                foreignKey.DeleteBehavior = DeleteBehavior.Restrict;
            }

            //OnModelCreatingPartial(modelBuilder);
            base.OnModelCreating(modelBuilder);
            //modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        //partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
