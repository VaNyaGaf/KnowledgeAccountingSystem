using KnowledgeSystem.BLL.Abstractions.EntitiesDTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KnowledgeSystem.BLL.Abstractions
{
    public interface ISubjectService
    {
        Task<SubjectDTO> AddAsync(SubjectDTO subjectEntity);

        Task<IList<SubjectDTO>> GetAllAsync();

        Task<SubjectDTO> GetByIdAsync(int id);

        Task UpdateAsync(SubjectDTO subjectEntity);

        Task RemoveAsync(int id);
    }
}
