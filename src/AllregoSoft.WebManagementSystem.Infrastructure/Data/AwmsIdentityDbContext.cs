using AllregoSoft.WebManagementSystem.ApplicationCore.Interfaces;
using AllregoSoft.WebManagementSystem.Domain.Common;
using AllregoSoft.WebManagementSystem.Domain.Entities;
using AllregoSoft.WebManagementSystem.Infrastructure.Data.Configuration;
using MediatR;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AllregoSoft.WebManagementSystem.Infrastructure.Data
{
    public class AwmsIdentityDbContext : DbContext, IIdentityDbContext
    {
        public AwmsIdentityDbContext(DbContextOptions<AwmsIdentityDbContext> options) : base(options) { }

        public DbSet<tbl_ScmMember> tbl_ScmMember { get; set; }
        public DbSet<tbl_Member> tbl_Member { get; set; }
        public DbSet<tbl_Role> tbl_Role { get; set; }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.RegId = 0;
                        entry.Entity.RegDt = DateTime.Now;
                        break;

                    case EntityState.Modified:
                        entry.Entity.ModId = 0;
                        entry.Entity.ModDt = DateTime.Now;
                        break;
                }
            }

            var result = await base.SaveChangesAsync(cancellationToken);

            return result;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new ScmMemberConfiguration());
            builder.ApplyConfiguration(new MemberConfiguration());
            builder.ApplyConfiguration(new RoleConfiguration());

            base.OnModelCreating(builder);
        }
    }
}
