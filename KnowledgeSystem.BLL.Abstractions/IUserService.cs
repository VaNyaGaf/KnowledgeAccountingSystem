using KnowledgeSystem.BLL.Abstractions.EntitiesDTO;
using KnowledgeSystem.DAL.Abstractions.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KnowledgeSystem.BLL.Abstractions
{
    public interface IUserService
    {
        void AddAsync(UserDTO entity);

        Task<List<User>> GetAllAsync();

        Task<UserDTO> GetByIdAsync(int id);

        void RemoveAsync(UserDTO entity);

        void RemoveAsync(int id);
    }
}
