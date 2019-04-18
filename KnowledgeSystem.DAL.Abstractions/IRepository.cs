using System.Collections.Generic;
using System.Threading.Tasks;

namespace KnowledgeSystem.DAL.Abstractions
{
    public interface IRepository<TEntity> where TEntity : class
    {
        void Add(TEntity entity);

        Task<IList<TEntity>> GetAllAsync();

        void Remove(TEntity entity);
    }
}
