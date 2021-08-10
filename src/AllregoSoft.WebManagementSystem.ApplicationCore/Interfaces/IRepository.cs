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
        #region | 동기 |
        T GetById(object id);
        IEnumerable<T> GetAll();
        //IQueryable<T> AsQueryable();
        IEnumerable<T> Find(Expression<Func<T, bool>> expression);
        void Add(T entity);
        void AddRange(IEnumerable<T> entities);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);
        void Update(T Entity);
        void SaveChanges();
        #endregion

        #region | 비동기 |
        //Task<T> GetByIdAsync(object id);
        //Task<IEnumerable<T>> GetAllAsync();
        //Task AddAsync(T entity, CancellationToken cancellationToken = default(CancellationToken));
        //Task AddRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default(CancellationToken));

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
        public Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default(CancellationToken));
        #endregion
        public void Commit();
        public void Rollback();
        public void BeginTransaction();
    }
}
