﻿using KnowledgeSystem.DAL.Abstractions.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KnowledgeSystem.BLL.Abstractions
{
    //Is Should be DTO's models or usual model
    public interface IUserService
    {
        void AddAsync(User entity);

        Task<IEnumerable<User>> GetAllAsync();

        Task<User> GetByIdAsync(int id);

        void RemoveAsync(User entity);
    }
}
