using System.Collections.Generic;
using System.Threading.Tasks;
using KnowledgeSystem.BLL.Abstractions;
using KnowledgeSystem.BLL.Abstractions.EntitiesDTO;
using KnowledgeSystem.DAL.Abstractions;
using KnowledgeSystem.DAL.Abstractions.Entities;

namespace KnowledgeSystem.BLL
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void AddAsync(User entity)
        {
            _unitOfWork.Users.AddAsync(entity);
            _unitOfWork.SaveAsync();

            //throw new System.NotImplementedException();
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _unitOfWork.Users.GetAllAsync();
        }

        public async Task<User> GetByIdAsync(int id)
        {
            return await _unitOfWork.Users.GetByIdAsync(id);

            //throw new System.NotImplementedException();
        }

        public void RemoveAsync(User entity)
        {
            _unitOfWork.Users.RemoveAsync(entity);
            _unitOfWork.SaveAsync();

            //throw new System.NotImplementedException();
        }
    }
}
