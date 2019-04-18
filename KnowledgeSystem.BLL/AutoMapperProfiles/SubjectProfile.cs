using AutoMapper;
using KnowledgeSystem.BLL.Abstractions.EntitiesDTO;
using KnowledgeSystem.DAL.Abstractions.Entities;

namespace KnowledgeSystem.BLL.AutoMapperProfiles
{
    public class SubjectProfile : Profile
    {
        public SubjectProfile()
        {
            CreateMap<SubjectDTO, Subject>().MaxDepth(3)
                .ForMember(subject => subject.UserSubjects,
                opt => opt.MapFrom(subjectDto => subjectDto.RatedByUsers));

            CreateMap<Subject, SubjectDTO>().MaxDepth(3)
                .ForMember(subjectDto => subjectDto.RatedByUsers,
                opt => opt.MapFrom(subject => subject.UserSubjects));
        }
    }
}
