using JWTLibraryManagement.Data;
using JWTLibraryManagement.DTOs;
using JWTLibraryManagement.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace JWTLibraryManagement.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IConfiguration _configuration;

        public AuthController(AppDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] Member member)
        {
            if (member == null || string.IsNullOrEmpty(member.Email) || string.IsNullOrEmpty(member.Password))
                return BadRequest("Invalid registration details.");

            var existingMember = _context.Member.FirstOrDefault(m => m.Email == member.Email);
            if (existingMember != null)
                return BadRequest("Email already registered.");

            _context.Member.Add(member);
            _context.SaveChanges();

            return Ok("Registration successful.");
        }

       
        [HttpPost("login")]
        public IActionResult Login([FromBody] MemberLoginDTO loginData)
        {
            if (loginData == null || string.IsNullOrEmpty(loginData.Email) || string.IsNullOrEmpty(loginData.Password))
                return BadRequest("Invalid login details.");

            var member = _context.Member.FirstOrDefault(m => m.Email == loginData.Email && m.Password == loginData.Password);

            if (member == null)
                return Unauthorized("Invalid email or password.");

            var token = GenerateJwtToken(member);

            return Ok(new { Token = token });
        }

        private string GenerateJwtToken(Member member)
        {
            var jwtSettings = _configuration.GetSection("JwtSettings");
            var secretKey = jwtSettings["Secret"];

            var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secretKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, member.MemberId.ToString()),
                new Claim(ClaimTypes.Email, member.Email),
                new Claim(ClaimTypes.Name, member.MemberName)
            };

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddHours(2),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
