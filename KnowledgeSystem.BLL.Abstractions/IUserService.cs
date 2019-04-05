using KnowledgeSystem.DAL.Abstractions.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KnowledgeSystem.BLL.Abstractions
{
    public interface IUserService
    {
        Task AddAsync(User entity);

        Task<IEnumerable<User>> GetAllAsync();

        Task<User> GetByIdAsync(string id);

        Task RemoveAsync(User entity);
    }
}
