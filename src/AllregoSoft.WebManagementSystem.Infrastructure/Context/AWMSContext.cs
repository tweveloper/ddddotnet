using AllregoSoft.WebManagementSystem.ApplicationCore.Entities;
using AllregoSoft.WebManagementSystem.ApplicationCore.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace AllregoSoft.WebManagementSystem.Infrastructure.Context
{
    public partial class AWMSContext : DbContext, IUnitOfWork
    {
        public readonly DbContextOptions<AWMSContext> _options;
        private IDbContextTransaction _currentTransaction;
        public IDbContextTransaction GetCurrentTransaction() => _currentTransaction;

        public AWMSContext(DbContextOptions<AWMSContext> options) : base(options)
        {
            _options = options;
        }

        private DbSet<tbl_Member> tbl_Member { get; set; }
        private DbSet<tbl_Role> tbl_Role { get; set; }
        private DbSet<tbl_SiteMap> tbl_SiteMap { get; set; }
        private DbSet<tbl_Role_Mapping> tbl_Role_Mapping { get; set; }
        private DbSet<tbl_MemberToken> tbl_MemberToken { get; set; }

        public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default)
        {
            var result = await base.SaveChangesAsync(cancellationToken);
            return true;
        }

        public async Task<IDbContextTransaction> BeginTransactionAsync()
        {
            if (_currentTransaction != null) return null;

            _currentTransaction = await Database.BeginTransactionAsync(IsolationLevel.ReadCommitted);

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
