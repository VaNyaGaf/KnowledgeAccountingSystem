using System.Collections.Generic;
using System.Threading.Tasks;

namespace KnowledgeSystem.DAL.Abstractions
{
    public interface IRepository<TEntity> where TEntity : class
    {
        void Add(TEntity entity);

        Task<TEntity> GetByIdAsync<T>(T id);
        Task<IEnumerable<TEntity>> GetAllAsync();

        void Remove(TEntity entity);
    }
}
