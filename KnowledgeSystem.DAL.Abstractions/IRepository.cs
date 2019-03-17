using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace KnowledgeSystem.DAL.Abstractions
{
    public interface IRepository<TEntity> where TEntity : class
    {
        void Add(TEntity entity);
        void AddAsync(TEntity entity);

        TEntity GetById(int id);
        Task<TEntity> GetByIdAsync(int id);
        IEnumerable<TEntity> GetAll();
        Task<List<TEntity>> GetAllAsync();
            
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
        //IAsyncEnumerable FindAsync(Func<TEntity, bool> predicate);

        void Remove(TEntity entity);
        void RemoveAsync(TEntity entity);
        void Remove(int id);
        void RemoveAsync(int id);
    }
}
