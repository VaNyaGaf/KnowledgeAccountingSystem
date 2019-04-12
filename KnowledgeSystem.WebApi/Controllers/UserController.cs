using AutoMapper;
using KnowledgeSystem.BLL.Abstractions;
using KnowledgeSystem.DAL.Abstractions.Entities;
using KnowledgeSystem.WebApi.Auth;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KnowledgeSystem.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserManager<AuthUser> _userManager;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserController(UserManager<AuthUser> userManager, IUserService userService, IMapper mapper)
        {
            _userManager = userManager;
            _userService = userService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetAllUsers()
        {
            return Ok(await _userService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetById(string id)
        {
            return Ok(await _userService.GetByIdAsync(id));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(string id)
        {
            var user = await _userService.GetByIdAsync(id);
            var authUser = await _userManager.FindByIdAsync(id);
            
            if (user == null || authUser == null)
                return BadRequest();

            await _userService.RemoveAsync(user);
            await _userManager.DeleteAsync(authUser);

            return Ok(user);
        }
    }
}