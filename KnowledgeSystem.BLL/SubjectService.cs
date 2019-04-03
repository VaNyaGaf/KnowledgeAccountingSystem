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

        public void AddAsync(Subject entity)
        {
            _unitOfWork.Subjects.AddAsync(entity);
            _unitOfWork.SaveAsync();

            //throw new System.NotImplementedException();
        }

        public async Task<IEnumerable<Subject>> GetAllAsync()
        {
            return await _unitOfWork.Subjects.GetAllAsync();

            //throw new System.NotImplementedException();
        }

        public async Task<Subject> GetByIdAsync(int id)
        {
            return await _unitOfWork.Subjects.GetByIdAsync(id);

            //throw new System.NotImplementedException();
        }

        public void RemoveAsync(Subject entity)
        {
            _unitOfWork.Subjects.RemoveAsync(entity);
            _unitOfWork.SaveAsync();

            //throw new System.NotImplementedException();
        }
    }
}
