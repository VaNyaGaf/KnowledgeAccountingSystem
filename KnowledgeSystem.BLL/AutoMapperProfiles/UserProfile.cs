using AutoMapper;
using KnowledgeSystem.BLL.Abstractions.EntitiesDTO;
using KnowledgeSystem.DAL.Abstractions.Entities;

namespace KnowledgeSystem.BLL.AutoMapperProfiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserDTO, User>()
                .ForMember(u => u.UserName, opt => opt.MapFrom(dto => $"{dto.FirstName}.{dto.LastName}"));
            CreateMap<User, UserDTO>()
                .ForMember(dto => dto.Password, opt => opt.Ignore());
        }
    }
}
