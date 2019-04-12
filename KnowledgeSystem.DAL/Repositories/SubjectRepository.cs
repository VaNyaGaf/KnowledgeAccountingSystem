using KnowledgeSystem.DAL.Abstractions;
using KnowledgeSystem.DAL.Abstractions.Entities;
using Microsoft.EntityFrameworkCore;

namespace KnowledgeSystem.DAL.Repositories
{
    class SubjectRepository : Repository<Subject>, ISubjectRepository
    {
        public SubjectRepository(KnowledgeContext context)
            : base(context)
        {
        }

        public void Update(Subject subject)
        {
            _db.Set<Subject>().Update(subject);
        }
    }
}
