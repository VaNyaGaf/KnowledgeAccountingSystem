using AutoMapper;
using KnowledgeSystem.BLL.Abstractions;
using KnowledgeSystem.BLL.Abstractions.EntitiesDTO;
using KnowledgeSystem.DAL.Abstractions;
using KnowledgeSystem.DAL.Abstractions.Entities;
using KnowledgeSystem.WebApi.Auth;
using Microsoft.AspNetCore.Authorization;
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
        private readonly UserManager<AuthUser> _userManager;
        private readonly SignInManager<AuthUser> _signInManager;
        //***************************************
        //  TO DO:
        //      Add JWT
        //      Add second Db for auth users
        //***************************************
        public ValuesController(IUnitOfWork unitOfWork, IUserService userService, IMapper mapper, UserManager<AuthUser> userManager, SignInManager<AuthUser> signInManager)
        {
            _userService = userService;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _userManager = userManager;
            _signInManager = signInManager;
        }
        // GET api/values
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "Hello", "from", "Authorize", "Admin Method" };
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
                //UserName = userDTO.FirstName,
                FirstName = userDTO.FirstName,
                LastName = userDTO.LastName
            };
            //var result = await _userManager.CreateAsync(user, userDTO.Password);
            return Ok();
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
