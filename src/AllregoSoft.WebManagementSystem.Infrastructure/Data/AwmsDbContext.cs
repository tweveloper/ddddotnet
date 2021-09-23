using AllregoSoft.WebManagementSystem.ApplicationCore.Interfaces;
using AllregoSoft.WebManagementSystem.Domain.Common;
using AllregoSoft.WebManagementSystem.Domain.Entities;
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
    public class AwmsDbContext : DbContext, IApplicationDbContext
    {
        private readonly IIdentityService _identityService;
        private readonly IDomainEventService _domainEventService;
        
        private IDbContextTransaction _currentTransaction;
        public AwmsDbContext(
            DbContextOptions options,
            IIdentityService identityService,
            IDomainEventService domainEventService) : base(options)
        {
            _identityService = identityService;
            _domainEventService = domainEventService;
        }

        public IDbContextTransaction GetCurrentTransaction() => _currentTransaction;

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
                        entry.Entity.RegId = _identityService == null ? 0 : _identityService.GetUserId();
                        entry.Entity.RegDt = DateTime.Now;
                        break;

                    case EntityState.Modified:
                        entry.Entity.ModId = _identityService == null ? 0 : _identityService.GetUserId();
                        entry.Entity.ModDt = DateTime.Now;
                        break;
                }
            }

            var result = await base.SaveChangesAsync(cancellationToken);

            await DispatchEvents();

            return result;
        }

        public async Task<IDbContextTransaction> BeginTransactionAsync()
        {
            if (_currentTransaction != null) return null;

            _currentTransaction = await Database.BeginTransactionAsync(IsolationLevel.ReadUncommitted);

            return _currentTransaction;
        }

        public async Task CommitTransactionAsync(IDbContextTransaction transaction)
        {
            if (transaction == null) throw new ArgumentNullException(nameof(transaction));
            if (transaction != _currentTransaction) throw new InvalidOperationException($"Transaction {transaction.TransactionId} is not current");

            try
            {
                await SaveChangesAsync();
                transaction.Commit();
            }
            catch
            {
                RollbackTransaction();
                throw;
            }
            finally
            {
                if (_currentTransaction != null)
                {
                    _currentTransaction.Dispose();
                    _currentTransaction = null;
                }
            }
        }

        public void RollbackTransaction()
        {
            try
            {
                _currentTransaction?.Rollback();
            }
            finally
            {
                if (_currentTransaction != null)
                {
                    _currentTransaction.Dispose();
                    _currentTransaction = null;
                }
            }
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
