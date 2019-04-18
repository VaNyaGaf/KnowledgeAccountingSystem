using KnowledgeSystem.BLL.Abstractions.EntitiesDTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KnowledgeSystem.BLL.Abstractions
{
    public interface IUserService
    {
        Task<UserDTO> AddAsync(UserDTO userEntity);

        Task<IList<UserDTO>> GetAllAsync();

        Task<UserDTO> GetByIdAsync(string id);

        Task RemoveAsync(string id);

        Task RateTheSubject(UserSubjectDTO ratedSubject);
    }
}
