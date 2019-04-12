using AutoMapper;
using KnowledgeSystem.BLL.Abstractions;
using KnowledgeSystem.BLL.Abstractions.EntitiesDTO;
using KnowledgeSystem.DAL.Abstractions.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KnowledgeSystem.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectController : ControllerBase
    {
        private readonly ISubjectService _subjectService;
        private readonly IMapper _mapper;
        public SubjectController(ISubjectService subjectService, IMapper mapper)
        {
            _subjectService = subjectService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> AddTask([FromBody] SubjectDTO subjectDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var subject = _mapper.Map<Subject>(subjectDto);
            await _subjectService.AddAsync(subject);
            return Ok(subject);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateTask([FromBody] SubjectDTO subjectDto)
        {
            var subject = _mapper.Map<Subject>(subjectDto);
            await _subjectService.Update(subject);
            return Ok(subject);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Subject>>> GetAllSubjects()
        {
            return Ok(await _subjectService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Subject>> GetSubjectById(int id)
        {
            return Ok(await _subjectService.GetByIdAsync(id));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSubjectById(int id)
        {
            var subject = await _subjectService.GetByIdAsync(id);
            if (subject is null)
                return BadRequest();
            await _subjectService.RemoveAsync(subject);
            return Ok(subject);
        }
    }
}