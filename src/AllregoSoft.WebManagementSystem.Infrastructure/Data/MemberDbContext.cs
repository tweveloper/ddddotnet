using AllregoSoft.WebManagementSystem.ApplicationCore.Interfaces;
using AllregoSoft.WebManagementSystem.Domain.Common;
using AllregoSoft.WebManagementSystem.Domain.Entities;
using AllregoSoft.WebManagementSystem.Infrastructure.Data.Configuration;
using MediatR;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AllregoSoft.WebManagementSystem.Infrastructure.Data
{
    public class MemberDbContext : DbContext, IMemberDbContext
    {
        public MemberDbContext(DbContextOptions<MemberDbContext> options) : base(options) { }
        public DbSet<tbl_ScmMember> tbl_ScmMember { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            //builder.Entity<DomainEvent>().HasNoKey();
            builder.ApplyConfiguration(new ScmMemberConfiguration());
            builder.ApplyConfiguration(new RoleConfiguration());

            base.OnModelCreating(builder);
        }
    }
}
