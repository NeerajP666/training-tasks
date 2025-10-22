using JWTLibraryManagement.Data;
using JWTLibraryManagement.DTOs;
using JWTLibraryManagement.Models;
using Microsoft.AspNetCore.Mvc;

namespace JWTLibraryManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MembersController : Controller
    {
        private readonly AppDbContext _context;

        public MembersController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAllMembers()
        {
            var members = _context.Member
                .Select(m => new MemberDTO
                {
                    MemberId = m.MemberId,
                    MemberName = m.MemberName,
                    Email = m.Email,
                    Books = m.Books.Select(b => b.BookName).ToList()
                }).ToList();

            return Ok(members);
        }

        [HttpGet("{id}")]
        public IActionResult GetMemberById(int id)
        {
            var member = _context.Member
                .Where(m => m.MemberId == id)
                .Select(m => new MemberDTO
                {
                    MemberId = m.MemberId,
                    MemberName = m.MemberName,
                    Email = m.Email,
                    Books = m.Books.Select(b => b.BookName).ToList()
                })
                .FirstOrDefault();

            if (member == null)
                return NotFound();

            return Ok(member);
        }

        [HttpPost]
        public IActionResult AddMember([FromBody] MemberDTO memberDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var member = new Member
            {
                MemberName = memberDto.MemberName,
                Email = memberDto.Email
            };

            _context.Member.Add(member);
            _context.SaveChanges();

            memberDto.MemberId = member.MemberId;
            return CreatedAtAction(nameof(GetMemberById), new { id = member.MemberId }, memberDto);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateMember(int id, [FromBody] MemberDTO memberDto)
        {
            var member = _context.Member.Find(id);
            if (member == null)
                return NotFound();

            member.MemberName = memberDto.MemberName;
            member.Email = memberDto.Email;
            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteMember(int id)
        {
            var member = _context.Member.Find(id);
            if (member == null)
                return NotFound();

            _context.Member.Remove(member);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
