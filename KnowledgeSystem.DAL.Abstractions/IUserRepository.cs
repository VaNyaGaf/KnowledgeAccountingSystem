using KnowledgeSystem.DAL.Abstractions.Entities;
using System.Threading.Tasks;

namespace KnowledgeSystem.DAL.Abstractions
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> GetByIdAsync(string id);

        Task RateTheSubject(UserSubject ratedSubject);
    }
}
