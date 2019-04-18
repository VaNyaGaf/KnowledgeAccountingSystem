using AutoMapper;
using KnowledgeSystem.BLL.Abstractions;
using KnowledgeSystem.BLL.Abstractions.EntitiesDTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KnowledgeSystem.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
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
        public async Task<IActionResult> AddSubject([FromBody] SubjectDTO subjectDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            subjectDto = await _subjectService.AddAsync(subjectDto);
            return Ok(subjectDto);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateSubject([FromBody] SubjectDTO subjectDto)
        {
            await _subjectService.UpdateAsync(subjectDto);
            return Ok(subjectDto);
        }

        [HttpGet]
        public async Task<ActionResult<IList<SubjectDTO>>> GetAllSubjects()
        {
            return Ok(await _subjectService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SubjectDTO>> GetSubjectById(int id)
        {
            return Ok(await _subjectService.GetByIdAsync(id));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSubjectById(int id)
        {
            await _subjectService.RemoveAsync(id);
            return Ok();
        }
    }
}