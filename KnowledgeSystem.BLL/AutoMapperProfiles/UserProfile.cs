﻿using AutoMapper;
using KnowledgeSystem.BLL.Abstractions.EntitiesDTO;
using KnowledgeSystem.DAL.Abstractions.Entities;

namespace KnowledgeSystem.BLL.AutoMapperProfiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserDTO, User>().MaxDepth(3)
                .ForMember(user => user.UserSubjects, opt => opt.MapFrom(userDto => userDto.RatedSubjects));

            CreateMap<User, UserDTO>().MaxDepth(3)
                .ForMember(userDto => userDto.RatedSubjects, opt => opt.MapFrom(u => u.UserSubjects));
        }
    }
}
