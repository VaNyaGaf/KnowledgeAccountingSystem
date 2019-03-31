using System.Collections.Generic;
using System.Threading.Tasks;

namespace KnowledgeSystem.DAL.Abstractions
{
    public interface IRepository<TEntity> where TEntity : class
    {
        void AddAsync(TEntity entity);

        Task<TEntity> GetByIdAsync(int id);
        Task<List<TEntity>> GetAllAsync();

        //IAsyncEnumerable FindAsync(Func<TEntity, bool> predicate);

        void RemoveAsync(TEntity entity);
        void RemoveAsync(int id);
    }
}
