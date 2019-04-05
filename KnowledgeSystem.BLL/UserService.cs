using KnowledgeSystem.BLL.Abstractions;
using KnowledgeSystem.DAL.Abstractions;
using KnowledgeSystem.DAL.Abstractions.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KnowledgeSystem.BLL
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task AddAsync(User entity)
        {
            _unitOfWork.Users.Add(entity);
            await _unitOfWork.SaveAsync();
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _unitOfWork.Users.GetAllAsync();
        }

        public async Task<User> GetByIdAsync(string id)
        {
            return await _unitOfWork.Users.GetByIdAsync(id);
        }

        public async Task RemoveAsync(User entity)
        {
            _unitOfWork.Users.Remove(entity);
            await _unitOfWork.SaveAsync();
        }
    }
}
