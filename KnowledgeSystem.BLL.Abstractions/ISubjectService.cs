using KnowledgeSystem.DAL.Abstractions.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KnowledgeSystem.BLL.Abstractions
{
    public interface ISubjectService
    {
        Task AddAsync(Subject entity);

        Task<IEnumerable<Subject>> GetAllAsync();

        Task<Subject> GetByIdAsync(int id);

        Task Update(Subject subject);

        Task RemoveAsync(Subject entity);
    }
}
