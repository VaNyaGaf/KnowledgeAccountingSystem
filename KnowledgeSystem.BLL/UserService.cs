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

        public void AddAsync(UserDTO entity)
        {
            //var user = new User()
            //{
            //    FirstName = entity.FirstName,
            //    LastName = entity.LastName
            //};
            //_unitOfWork.Users.AddAsync(user);
            //return Task.Run(() => _unitOfWork.Users.AddAsync(user));
            throw new System.NotImplementedException();
        }

        public async Task<List<User>> GetAllAsync()
        {
            return await _unitOfWork.Users.GetAllAsync();
        }

        public Task<UserDTO> GetByIdAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public void RemoveAsync(UserDTO entity)
        {
            throw new System.NotImplementedException();
        }

        public void RemoveAsync(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
