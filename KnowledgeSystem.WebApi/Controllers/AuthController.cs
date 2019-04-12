using AutoMapper;
using KnowledgeSystem.BLL.Abstractions;
using KnowledgeSystem.BLL.Abstractions.EntitiesDTO;
using KnowledgeSystem.DAL.Abstractions.Entities;
using KnowledgeSystem.WebApi.Auth;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace KnowledgeSystem.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<AuthUser> _userManager;
        private readonly SignInManager<AuthUser> _signInManager;
        private readonly IUserService _userService;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;

        public AuthController(
            UserManager<AuthUser> userManager
            , SignInManager<AuthUser> signInManager
            , IUserService userService
            , IConfiguration configuration
            , IMapper mapper)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _userService = userService;
            _configuration = configuration;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("sign-up")]
        public async Task<IActionResult> SignUp([FromBody] UserDTO userDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var authUser = new AuthUser(userDto.Email);
            var result = await _userManager.CreateAsync(authUser, userDto.Password);

            if (!result.Succeeded)
                return BadRequest(result.Errors);

            //await _signInManager.SignInAsync(authUser, false);        // Do we need this line??
            var user = _mapper.Map<User>(userDto);
            user.Id = authUser.Id;          // Is there exists another way of creating user, exmp. new User()

            await _userService.AddAsync(user);
            var token = GeneraeToken(user);

            return Ok(new { user, token });
        }

        [HttpPost]
        [Route("sign-in")]
        public async Task<IActionResult> SignIn([FromBody] SignInModel signInModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _signInManager.PasswordSignInAsync(signInModel.Email, signInModel.Password, false, false);

            if (!result.Succeeded)
                return BadRequest();

            AuthUser authUser = _userManager.Users.FirstOrDefault(u => u.UserName == signInModel.Email);
            User user = await _userService.GetByIdAsync(authUser.Id);
            var token = GeneraeToken(user);

            return Ok(new { user, token });
        }

        private string GeneraeToken(User user)
        {
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:SecretKey"]));
            var signInCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

            List<Claim> claims = new List<Claim>()
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id),
                new Claim(JwtRegisteredClaimNames.Iat, DateTimeOffset.Now.ToUnixTimeSeconds().ToString())
            };

            if (user.FirstName.Contains("admin"))
                claims.Add(new Claim(ClaimTypes.Role, "admin"));

            var tokeOptions = new JwtSecurityToken(
                issuer: _configuration["JWT:Issuer"],
                audience: _configuration["JWT:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(10),
                signingCredentials: signInCredentials
            );

            var token = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
            return token;
        }
    }
}
