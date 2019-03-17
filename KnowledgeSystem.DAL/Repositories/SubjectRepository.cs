using KnowledgeSystem.DAL.Abstractions;
using KnowledgeSystem.DAL.Abstractions.Entities;

namespace KnowledgeSystem.DAL.Repositories
{
    class SubjectRepository : Repository<Subject>, ISubjectRepository
    {
        public SubjectRepository(KnowledgeContext context)
            : base(context)
        {
        }
    }
}
