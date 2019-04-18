using KnowledgeSystem.BLL.Abstractions;
using KnowledgeSystem.DAL.Abstractions;
using KnowledgeSystem.DAL.Abstractions.Entities;
using System.Collections.Generic;
using KnowledgeSystem.BLL.Abstractions.EntitiesDTO;
using System.Threading.Tasks;
using AutoMapper;

namespace KnowledgeSystem.BLL
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UserService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<UserDTO> AddAsync(UserDTO entity)
        {
            var user = _mapper.Map<User>(entity);
            _unitOfWork.Users.Add(user);
            await _unitOfWork.SaveAsync();
            return _mapper.Map<UserDTO>(user);
        }

        public async Task<IList<UserDTO>> GetAllAsync()
        {
            var users = await _unitOfWork.Users.GetAllAsync();
            var userDTOs = _mapper.Map<IList<User>, IList<UserDTO>>(users);
            return userDTOs;
        }

        public async Task<UserDTO> GetByIdAsync(string id)
        {
            var user = await _unitOfWork.Users.GetByIdAsync(id);
            var userDto = _mapper.Map<UserDTO>(user);
            return userDto;
        }

        public async Task RemoveAsync(string id)
        {
            var user = await GetUserByIdAsync(id);
            _unitOfWork.Users.Remove(user);
            await _unitOfWork.SaveAsync();
        }

        private async Task<User> GetUserByIdAsync(string id)
        {
            return await _unitOfWork.Users.GetByIdAsync(id);
        }
    }
}
