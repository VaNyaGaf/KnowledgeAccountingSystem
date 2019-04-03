using System.Collections.Generic;
using System.Threading.Tasks;

namespace KnowledgeSystem.DAL.Abstractions
{
    public interface IRepository<TEntity> where TEntity : class
    {
        void AddAsync(TEntity entity);

        Task<TEntity> GetByIdAsync(int id);
        Task<IEnumerable<TEntity>> GetAllAsync();

        void RemoveAsync(TEntity entity);
    }
}
