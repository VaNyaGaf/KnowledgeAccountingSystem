using KnowledgeSystem.DAL.Abstractions;
using KnowledgeSystem.DAL.Abstractions.Entities;

namespace KnowledgeSystem.DAL.Repositories
{
    class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(KnowledgeContext context)
            : base(context)
        {
        }
    }
}
 