using KnowledgeSystem.BLL.Abstractions;
using KnowledgeSystem.DAL.Abstractions;
using KnowledgeSystem.DAL.Abstractions.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KnowledgeSystem.BLL
{
    public class SubjectService : ISubjectService
    {
        private readonly IUnitOfWork _unitOfWork;

        public SubjectService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task AddAsync(Subject entity)
        {
            _unitOfWork.Subjects.Add(entity);
            await _unitOfWork.SaveAsync();
        }

        public async Task<IEnumerable<Subject>> GetAllAsync()
        {
            return await _unitOfWork.Subjects.GetAllAsync();
        }

        public async Task<Subject> GetByIdAsync(int id)
        {
            return await _unitOfWork.Subjects.GetByIdAsync(id);
        }

        public async Task Update(Subject subject)
        {
            var existingSubject = await GetByIdAsync(subject.Id);
            if (existingSubject is null)
                throw new System.NullReferenceException("There are no subject with such id");

            _unitOfWork.Subjects.Update(subject);
            await _unitOfWork.SaveAsync();
        }

        public async Task RemoveAsync(Subject entity)
        {
            _unitOfWork.Subjects.Remove(entity);
            await _unitOfWork.SaveAsync();
        }
    }
}
