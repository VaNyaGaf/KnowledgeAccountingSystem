using KnowledgeSystem.DAL.Abstractions;
using KnowledgeSystem.DAL.Abstractions.Entities;
using System.Threading.Tasks;

namespace KnowledgeSystem.DAL.Repositories
{
    class SubjectRepository : Repository<Subject>, ISubjectRepository
    {
        public SubjectRepository(KnowledgeContext context)
            : base(context)
        {
        }

        public async Task<Subject> GetByIdAsync(int id)
        {
            var subject = await _db.Set<Subject>().FindAsync(id);
            await _db.Entry(subject).Collection(s => s.UserSubjects).LoadAsync();
            return subject;
        }

        public void Update(Subject subject)
        {
            _db.Set<Subject>().Update(subject);
        }
    }
}
