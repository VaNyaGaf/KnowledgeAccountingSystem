using AutoMapper;
using KnowledgeSystem.BLL.Abstractions;
using KnowledgeSystem.BLL.Abstractions.EntitiesDTO;
using KnowledgeSystem.DAL.Abstractions;
using KnowledgeSystem.DAL.Abstractions.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KnowledgeSystem.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        //***************************************
        //  TO DO:
        //      Add JWT
        //      Add second Db for auth users
        //***************************************
        public ValuesController(IUnitOfWork unitOfWork, IUserService userService, IMapper mapper, UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userService = userService;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _userManager = userManager;
            _signInManager = signInManager;
        }
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public async Task<object> Post([FromBody] UserDTO userDTO)
        {
            var user = new User()
            {
                UserName = userDTO.FirstName,
                FirstName = userDTO.FirstName,
                LastName = userDTO.LastName
            };
            var result = await _userManager.CreateAsync(user, userDTO.Password);
            return Ok(result);
        }

        [HttpPost("RegUser")]
        //[Route("RegUser")]
        public async Task<object> PostRegUser([FromBody] UserDTO userDTO)
        {
            var user = _mapper.Map<User>(userDTO);
            try
            {
                await _userService.AddAsync(user);
                return Ok();
            }
            catch (System.Exception ex)
            {
                return NotFound(ex);
            }
        }
        [HttpDelete("DelUser")]
        public async Task<IActionResult> DeleteUser([FromBody] UserDTO userDTO)
        {
            var user = _mapper.Map<User>(userDTO);
            try
            {
                //var user = await _userService.GetByIdAsync(userDTO.Id);
                await _userService.RemoveAsync(user);
                return Ok(user);
            }
            catch (System.Exception ex)
            {
                return NotFound(ex);
            }
        }

        // GET api/values
        [HttpGet]
        [Route("GetUsers")]
        public async Task<IEnumerable<User>> GetUsers()
        {
            return await _userService.GetAllAsync();
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
