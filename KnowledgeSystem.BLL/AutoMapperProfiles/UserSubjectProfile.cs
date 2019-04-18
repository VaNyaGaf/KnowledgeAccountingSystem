using AutoMapper;
using KnowledgeSystem.BLL.Abstractions.EntitiesDTO;
using KnowledgeSystem.DAL.Abstractions.Entities;

namespace KnowledgeSystem.BLL.AutoMapperProfiles
{
    class UserSubjectProfile : Profile
    {
        public UserSubjectProfile()
        {
            CreateMap<UserSubject, UserSubjectDTO>().ReverseMap();
        }
    }
}
