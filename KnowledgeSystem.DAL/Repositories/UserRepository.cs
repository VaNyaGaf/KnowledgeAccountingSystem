using KnowledgeSystem.DAL.Abstractions;
using KnowledgeSystem.DAL.Abstractions.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
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
            _db.Entry(user).Collection(u => u.UserSubjects).Load();
            return user;
        }
    }
}
