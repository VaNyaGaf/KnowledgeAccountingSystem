using KnowledgeSystem.DAL.Abstractions.Entities;
using System.Threading.Tasks;

namespace KnowledgeSystem.DAL.Abstractions
{
    public interface ISubjectRepository : IRepository<Subject>
    {
        void Update(Subject subject);

        Task<Subject> GetByIdAsync(int id);
    }
}
