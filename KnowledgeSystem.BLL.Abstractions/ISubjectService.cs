using KnowledgeSystem.DAL.Abstractions.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KnowledgeSystem.BLL.Abstractions
{
    //Is Should be DTO's models or usual model
    public interface ISubjectService
    {
        void AddAsync(Subject entity);

        Task<IEnumerable<Subject>> GetAllAsync();

        Task<Subject> GetByIdAsync(int id);

        void RemoveAsync(Subject entity);
    }
}
