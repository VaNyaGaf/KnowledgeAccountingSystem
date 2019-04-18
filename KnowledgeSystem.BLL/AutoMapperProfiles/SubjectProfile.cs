using AutoMapper;
using KnowledgeSystem.BLL.Abstractions.EntitiesDTO;
using KnowledgeSystem.DAL.Abstractions.Entities;

namespace KnowledgeSystem.BLL.AutoMapperProfiles
{
    public class SubjectProfile : Profile
    {
        public SubjectProfile()
        {
            CreateMap<SubjectDTO, Subject>()
                .ForMember(subject => subject.UserSubjects,
                opt => opt.MapFrom(subjectDto => subjectDto.RatedByUsers));

            CreateMap<Subject, SubjectDTO>()
                .ForMember(subjectDto => subjectDto.RatedByUsers,
                opt => opt.MapFrom(subject => subject.UserSubjects));
        }
    }
}
