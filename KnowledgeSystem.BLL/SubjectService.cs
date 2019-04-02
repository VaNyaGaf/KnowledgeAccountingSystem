using System.Collections.Generic;
using System.Threading.Tasks;
using KnowledgeSystem.BLL.Abstractions;
using KnowledgeSystem.BLL.Abstractions.EntitiesDTO;

namespace KnowledgeSystem.BLL
{
    public class SubjectService : ISubjectService
    {
        public void AddAsync(SubjectDTO entity)
        {
            throw new System.NotImplementedException();
        }

        public Task<List<SubjectDTO>> GetAllAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<SubjectDTO> GetByIdAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public void RemoveAsync(SubjectDTO entity)
        {
            throw new System.NotImplementedException();
        }

        public void RemoveAsync(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
