using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Library_System_Application.Model;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using NuGet.Protocol.Plugins;

namespace Library_System_Application.Domain.User
{
   
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly LibrarySystemContext _context;
        private readonly IMapper _mapper;
        private readonly IConfiguration _config;
        

        public LoginController(LibrarySystemContext context, IMapper mapper, IConfiguration config)
        {
            _context = context;
            _mapper = mapper;
            _config = config;
        }
        
        
        
        [HttpPost("Login")]
        public IActionResult Login([FromBody] UserLoginDto userLogin)
        {
            var authenticate = Authenticate(userLogin);
            if (authenticate != null)
            {
                var token = Generate(authenticate);
                // return Ok(token);
                return Ok(new {token=token, user =authenticate});
            }   

            return NotFound("User not found");
        }
        
        
        private string Generate(Model.Student student)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, student.IdCard),
                new Claim(ClaimTypes.Email, student.Email),
                new Claim(ClaimTypes.GivenName, student.FirstName ),
                new Claim(ClaimTypes.Surname, student.LastName),
                new Claim(ClaimTypes.Role, student.Role)
            };

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
                _config["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddMinutes(60),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
     

        private Model.Student? Authenticate(UserLoginDto userLoginDto)
        {
            var currentStudent = _context.Users.FirstOrDefault(o => String.Equals(o.Email.ToLower(), userLoginDto.Email.ToLower()) 
                                                                       && o.Passport == userLoginDto.Passport);
            if (currentStudent != null)
            {
                return currentStudent;
            }
            return null;
        }
        
        
        private bool StudentExists(int id)
        {
            return (_context.Users?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
 
