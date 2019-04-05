using KnowledgeSystem.DAL.Abstractions;
using System.Threading.Tasks;

namespace KnowledgeSystem.DAL
{
    class KnowledgeUnitOfWork : IUnitOfWork
    {
        private readonly KnowledgeContext _db;
        public IUserRepository Users { get; private set; }
        public ISubjectRepository Subjects { get; private set; }

        public KnowledgeUnitOfWork(KnowledgeContext context, IUserRepository userRepositroy, ISubjectRepository subjectRepository)
        {
            _db = context;
            Users = userRepositroy;
            Subjects = subjectRepository;
        }

        public async Task<int> SaveAsync()
        {
            return await _db.SaveChangesAsync();
        }
    }
}
