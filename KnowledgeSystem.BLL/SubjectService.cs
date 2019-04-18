using AutoMapper;
using KnowledgeSystem.BLL.Abstractions;
using KnowledgeSystem.BLL.Abstractions.EntitiesDTO;
using KnowledgeSystem.DAL.Abstractions;
using KnowledgeSystem.DAL.Abstractions.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KnowledgeSystem.BLL
{
    public class SubjectService : ISubjectService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public SubjectService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<SubjectDTO> AddAsync(SubjectDTO subjectEntity)
        {
            var subject = _mapper.Map<Subject>(subjectEntity);
            _unitOfWork.Subjects.Add(subject);
            await _unitOfWork.SaveAsync();
            return _mapper.Map<SubjectDTO>(subject);
        }

        public async Task<IList<SubjectDTO>> GetAllAsync()
        {
            var subjects = await _unitOfWork.Subjects.GetAllAsync();
            IList<SubjectDTO> subjectDTOs = _mapper.Map<IList<Subject>, IList<SubjectDTO>>(subjects);
            return subjectDTOs;
        }
        
        public async Task<SubjectDTO> GetByIdAsync(int id)
        {
            var subject = await _unitOfWork.Subjects.GetByIdAsync(id);
            var subjectDto = _mapper.Map<SubjectDTO>(subject);
            return subjectDto;
        }

        public async Task UpdateAsync(SubjectDTO subjectEntity)
        {
            var subject = _mapper.Map<Subject>(subjectEntity);
            _unitOfWork.Subjects.Update(subject);
            await _unitOfWork.SaveAsync();
        }

        public async Task RemoveAsync(int id)
        {
            //var subjectDto = GetByIdAsync(id);
            //var subject = _mapper.Map<Subject>(subjectDto);
            var subject = await GetSubjectByIdAsync(id);
            _unitOfWork.Subjects.Remove(subject);
            await _unitOfWork.SaveAsync();
        }

        private async Task<Subject> GetSubjectByIdAsync(int id)
        {
            return await _unitOfWork.Subjects.GetByIdAsync(id);
        }
    }
}
