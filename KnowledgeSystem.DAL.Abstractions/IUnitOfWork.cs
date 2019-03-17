using System;

namespace KnowledgeSystem.DAL.Abstractions
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository Users { get; }
        ISubjectRepository Subjects { get; }
        void Save();
        void SaveAsync();
    }
}
