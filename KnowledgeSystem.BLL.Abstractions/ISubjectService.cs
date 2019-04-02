using KnowledgeSystem.BLL.Abstractions.EntitiesDTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KnowledgeSystem.BLL.Abstractions
{
    public interface ISubjectService
    {
        void AddAsync(SubjectDTO entity);

        Task<List<SubjectDTO>> GetAllAsync();

        Task<SubjectDTO> GetByIdAsync(int id);

        void RemoveAsync(SubjectDTO entity);

        void RemoveAsync(int id);
    }
}
