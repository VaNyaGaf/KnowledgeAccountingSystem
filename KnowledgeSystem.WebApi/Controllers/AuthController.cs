using KnowledgeSystem.DAL.Abstractions.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using KnowledgeSystem.BLL.Abstractions.EntitiesDTO;
using AutoMapper;
using System.Threading.Tasks;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System;
using System.Collections.Generic;
using System.Linq;

namespace KnowledgeSystem.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;

        public AuthController(UserManager<User> userManager, SignInManager<User> signInManager, IConfiguration configuration, IMapper mapper)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("sign-up")]
        public async Task<IActionResult> SignUp([FromBody] UserDTO userDto)
        {
            var user = _mapper.Map<User>(userDto);
            var result = await _userManager.CreateAsync(user, userDto.Password);
            //await _userManager.UpdateSecurityStampAsync(user);
            await _signInManager.SignInAsync(user, isPersistent: false);
            var registeredUser = _userManager.Users.FirstOrDefault(u => user.FirstName == u.FirstName);

            var token = GeneraeToken(user);

            return Ok(new { user, token, result });
        }

        [HttpPost]
        [Route("sign-in")]
        public async Task<IActionResult> SignIn([FromBody] UserDTO userDto)
        {
            var user = _mapper.Map<User>(userDto);
            var result = await _signInManager.PasswordSignInAsync(user.UserName, userDto.Password, false, false);
            if (result.Succeeded)
            {
                user = _userManager.Users.FirstOrDefault(u => u.UserName == user.UserName);

                var token = GeneraeToken(user);

                return Ok(new { user, token });
            }
            return BadRequest();
        }

        private string GeneraeToken(User user)
        {
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:SecretKey"]));
            var signInCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

            var tokeOptions = new JwtSecurityToken(
                issuer: _configuration["JWT:Issuer"],
                audience: _configuration["JWT:Audience"],
                claims: new List<Claim>(),
                //{
                //    new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                //    new Claim("DateOfJoing", DateTime.Now.ToString())
                //},
                expires: DateTime.Now.AddMinutes(10),
                signingCredentials: signInCredentials
            );

            var token = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
            return token;
        }
    }
}
