using KnowledgeSystem.DAL.Abstractions.Entities;
using System.Threading.Tasks;

namespace KnowledgeSystem.DAL.Abstractions
{
    public interface ISubjectRepository : IRepository<Subject>
    {
        // Some unique methods only for SubjectRepository
        void Update(Subject subject);
    }
}
