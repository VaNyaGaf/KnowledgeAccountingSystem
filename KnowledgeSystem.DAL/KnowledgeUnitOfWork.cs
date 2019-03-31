using KnowledgeSystem.DAL.Abstractions;

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

        public void Dispose()
        {
            _db.Dispose();
        }

        public void SaveAsync()
        {
            _db.SaveChangesAsync();
        }
    }
}
