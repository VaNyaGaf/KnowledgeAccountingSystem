using KnowledgeSystem.DAL.Abstractions;
using KnowledgeSystem.DAL.Abstractions.Entities;
using System.Threading.Tasks;

namespace KnowledgeSystem.DAL.Repositories
{
    class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(KnowledgeContext context)
            : base(context)
        {
        }

        public async Task<User> GetByIdAsync(string id)
        {
            var user = await _db.Set<User>().FindAsync(id);
            await _db.Entry(user).Collection(u => u.UserSubjects).LoadAsync();
            return user;
        }

        public async Task RateTheSubject(UserSubject ratedSubject)
        {
            var user = await GetByIdAsync(ratedSubject.UserId);
            user.UserSubjects.Add(ratedSubject);
        }
    }
}
