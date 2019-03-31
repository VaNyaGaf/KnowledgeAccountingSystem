using KnowledgeSystem.DAL.Abstractions;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KnowledgeSystem.DAL.Repositories
{
    class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext _db; 
        public Repository(DbContext context)
        {
            _db = context;
        }

        public void AddAsync(TEntity entity)
        {
            _db.Set<TEntity>().AddAsync(entity);
        }

        public Task<List<TEntity>> GetAllAsync()
        {
            return _db.Set<TEntity>().ToListAsync();
        }

        public Task<TEntity> GetByIdAsync(int id)
        {
            return _db.Set<TEntity>().FindAsync(id);
        }

        public async void RemoveAsync(TEntity entity)
        {
            await Task.Run(() => _db.Set<TEntity>().Remove(entity));
        }

        public async void RemoveAsync(int id)
        {
            TEntity entityToRemove = await GetByIdAsync(id);
            RemoveAsync(entityToRemove);
        }
    }
}
