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

        private bool _isDisposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!_isDisposed)
            {
                if (disposing)
                {
                    _db.Dispose();
                }
                _isDisposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            System.GC.SuppressFinalize(this);
            //_db.Dispose();
        }

        public async void SaveAsync()
        {
            await _db.SaveChangesAsync();
        }
    }
}
