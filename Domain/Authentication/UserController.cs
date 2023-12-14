using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Library_System_Application.Domain.Dto;
using Library_System_Application.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Library_System_Application.Domain.Authentication
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly LibrarySystemContext _context;
                private readonly IMapper _mapper;
                private readonly IConfiguration _config;
                
        
                public UserController(LibrarySystemContext context, IMapper mapper, IConfiguration config)
                {
                    _context = context;
                    _mapper = mapper;
                    _config = config;
                }
                
        
        [Authorize]
        [HttpGet("Admins")]
        public IActionResult AdminsEndpoint()
        {
            var currentUser = GetCurrentUser();
            return Ok($"Hi {currentUser.FirstName}, you are an {currentUser.Role}");
        }
        
        [HttpGet("Public")]
        public IActionResult Public()
        {
            return Ok("Hi, you are just a student");
        }

        private StudentInfoDto GetCurrentUser()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;

            if (identity != null)
            {
                var userClaims = identity.Claims;
                return new StudentInfoDto
                {
                    IdCard = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.NameIdentifier)?.Value,
                    Email = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.Email)?.Value,
                    FirstName = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.GivenName)?.Value,
                    LastName = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.Surname)?.Value,
                    Role = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.Role)?.Value,
                };
            }

            return null;
        }
        
    }
}
