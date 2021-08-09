using AllregoSoft.WebManagementSystem.ApplicationCore.Common;
using AllregoSoft.WebManagementSystem.ApplicationCore.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AllregoSoft.WebManagementSystem.Infrastructure.Repositories
{
    public abstract class GenericRepository<TEntity, TContext> : Disposable, IGenericRepository<TEntity>
        where TEntity : class
        where TContext : DbContext
    {
        private readonly TContext _context;
        public GenericRepository(TContext context)
        {
            _context = context;
        }

        public DbContext UnitOfWork => _context;

        public DbSet<TEntity> Entity { get
            {
                return _context.Set<TEntity>();
            } 
        }
        protected override void DisposeCore()
        {
            if (_context != null)
            {
                _context.Dispose();
            }
        }
    }
}
