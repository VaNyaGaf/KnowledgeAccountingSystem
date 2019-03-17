using KnowledgeSystem.DAL.Abstractions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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

        public void Add(TEntity entity)
        {
            _db.Set<TEntity>().Add(entity);
        }

        public void AddAsync(TEntity entity)
        {
            _db.Set<TEntity>().AddAsync(entity);
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return _db.Set<TEntity>().Where(predicate);
        }

        //public IAsyncEnumerable<TEntity> FindAsync(Func<TEntity, bool> predicate)
        //{
        //    return _db.Set<TEntity>().Where(predicate).ToAsyncEnumerable();
        //}

        public IEnumerable<TEntity> GetAll()
        {
            return _db.Set<TEntity>().ToList();
        }

        public Task<List<TEntity>> GetAllAsync()
        {
            return _db.Set<TEntity>().ToListAsync();
        }

        public TEntity GetById(int id)
        {
            return _db.Set<TEntity>().Find(id);
        }

        public Task<TEntity> GetByIdAsync(int id)
        {
            return _db.Set<TEntity>().FindAsync(id);
        }

        public void Remove(TEntity entity)
        {
            _db.Set<TEntity>().Remove(entity);
        }

        public void Remove(int id)
        {
            TEntity entityToRemove = GetById(id);
            Remove(entityToRemove);
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
