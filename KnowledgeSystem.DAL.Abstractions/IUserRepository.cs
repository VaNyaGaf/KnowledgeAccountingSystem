using KnowledgeSystem.DAL.Abstractions.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KnowledgeSystem.DAL.Abstractions
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> GetByIdAsync(string id);
    }
}
