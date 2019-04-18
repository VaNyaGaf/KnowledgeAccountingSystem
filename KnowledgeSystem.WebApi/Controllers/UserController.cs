using AutoMapper;
using KnowledgeSystem.BLL.Abstractions;
using KnowledgeSystem.BLL.Abstractions.EntitiesDTO;
using KnowledgeSystem.WebApi.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
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

        [HttpGet("current")]
        [Authorize]
        public async Task<IActionResult> GetCurrentUser()
        {
            var currentUserId = HttpContext.User.FindFirstValue(JwtRegisteredClaimNames.Sub);
            var currentUser = await _userService.GetByIdAsync(currentUserId);

            return Ok(currentUser);
        }

        [HttpGet]
        public async Task<ActionResult<IList<UserDTO>>> GetAllUsers()
        {
            return Ok(await _userService.GetAllAsync());
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetById(string id)
        {
            var userDto = await _userService.GetByIdAsync(id);
            return Ok(userDto);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteUser(string id)
        {
            var authUser = await _userManager.FindByIdAsync(id);
            
            if (authUser == null)
                return BadRequest();

            await _userService.RemoveAsync(id);
            await _userManager.DeleteAsync(authUser);

            return Ok();
        }

        [HttpPut("rateSubject")]
        [Authorize]
        public async Task<IActionResult> RateTheSubject(UserSubjectDTO ratedSubject)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            await _userService.RateTheSubject(ratedSubject);
            return Ok();
        }
    }
}
