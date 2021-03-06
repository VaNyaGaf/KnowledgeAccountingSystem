﻿using KnowledgeSystem.DAL.Abstractions;
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

        public void Add(TEntity entity)
        {
            _db.Set<TEntity>().Add(entity);
        }

        public async Task<IList<TEntity>> GetAllAsync()
        {
            return await _db.Set<TEntity>().ToListAsync();
        }

        public void Remove(TEntity entity)
        {
            _db.Entry(entity).State = EntityState.Deleted;
        }
    }
}
