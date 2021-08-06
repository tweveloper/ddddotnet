using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AllregoSoft.WebManagementSystem.ApplicationCore.Interfaces
{
    public interface IRepository<T> where T : class, IAggregateRoot
    {
        T GetById(object id);
        IEnumerable<T> GetAll();
        IEnumerable<T> Find(Expression<Func<T, bool>> expression);
        void Add(T entity);
        void AddRange(IEnumerable<T> entities);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);
        void Update(T Entity);
        void SaveChanges();

        public void Commit();
        public void Rollback();

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
        public Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default(CancellationToken));

        public void BeginTransaction();
    }
}
