using System;
using System.Threading.Tasks;

namespace KnowledgeSystem.DAL.Abstractions
{
    public interface IUnitOfWork
    {
        IUserRepository Users { get; }
        ISubjectRepository Subjects { get; }
        Task<int> SaveAsync();
    }
}
