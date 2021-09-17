using AllregoSoft.WebManagementSystem.ApplicationCore.Interfaces;
using AllregoSoft.WebManagementSystem.Domain.Common;
using AllregoSoft.WebManagementSystem.Domain.Entities;
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
    public class AwmsDbContext : DbContext, IApplicationDbContext
    {
        private readonly ICurrentUserService _currentUserService;
        private readonly IDomainEventService _domainEventService;
        public AwmsDbContext(
            DbContextOptions options, 
            ICurrentUserService currentUserService,
            IDomainEventService domainEventService) : base(options)
        {
            _currentUserService = currentUserService;
            _domainEventService = domainEventService;
        }

        public DbSet<tbl_ScmMember> tbl_ScmMember { get; set; }
        public DbSet<tbl_Member> tbl_Member { get; set; }
        public DbSet<tbl_Role> tbl_Role { get; set; }
        public DbSet<tbl_SiteMap> tbl_SiteMap { get; set; }
        public DbSet<tbl_Role_Mapping> tbl_Role_Mapping { get; set; }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.RegId = _currentUserService == null ? 0 : _currentUserService.UserId;
                        entry.Entity.RegDt = DateTime.Now;
                        break;

                    case EntityState.Modified:
                        entry.Entity.ModId = _currentUserService == null ? 0 : _currentUserService.UserId;
                        entry.Entity.ModDt = DateTime.Now;
                        break;
                }
            }

            var result = await base.SaveChangesAsync(cancellationToken);

            await DispatchEvents();

            return result;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }

        private async Task DispatchEvents()
        {
            while (true)
            {
                var domainEventEntity = ChangeTracker.Entries<IHasDomainEvent>()
                    .Select(x => x.Entity.DomainEvents)
                    .SelectMany(x => x)
                    .Where(domainEvent => !domainEvent.IsPublished)
                    .FirstOrDefault();
                if (domainEventEntity == null) break;

                domainEventEntity.IsPublished = true;
                await _domainEventService.Publish(domainEventEntity);
            }
        }
    }

    public class AwmsDbContextDesignFactory : IDesignTimeDbContextFactory<AwmsDbContext>
    {
        public AwmsDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AwmsDbContext>()
                    .UseSqlServer(
                        "data source=localhost;initial catalog=AWMS;persist security info=True;user id=sa;password=Pa$$w0rd",
                        b => b.MigrationsAssembly(typeof(AwmsDbContext).Assembly.FullName));

            return new AwmsDbContext(optionsBuilder.Options, null, null);
        }
    }
}
