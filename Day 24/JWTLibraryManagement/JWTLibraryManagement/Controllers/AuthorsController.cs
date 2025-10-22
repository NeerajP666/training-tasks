using JWTLibraryManagement.Data;
using JWTLibraryManagement.DTOs;
using JWTLibraryManagement.Models;
using Microsoft.AspNetCore.Mvc;

namespace JWTLibraryManagement.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : Controller
    {
        private readonly AppDbContext _context;
        public AuthorsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAllAuthors()
        {
            var authors = _context.Author
                .Select(a => new AuthorDTO
                {
                    AuthorId = a.AuthorId,
                    AuthorName = a.AuthorName,
                    Books = a.Books.Select(b => b.BookName).ToList()
                }).ToList();

            return Ok(authors);
        }

        [HttpGet("{id}")]
        public IActionResult GetAuthorById(int id)
        {
            var author = _context.Author
                .Where(a => a.AuthorId == id)
                .Select(a => new AuthorDTO
                {
                    AuthorId = a.AuthorId,
                    AuthorName = a.AuthorName,
                    Books = a.Books.Select(b => b.BookName).ToList()
                })
                .FirstOrDefault();

            if (author == null)
                return NotFound();

            return Ok(author);
        }

        [HttpPost]
        public IActionResult AddAuthor([FromBody] AuthorDTO authorDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var author = new Author
            {
                AuthorName = authorDto.AuthorName
            };

            _context.Author.Add(author);
            _context.SaveChanges();

            authorDto.AuthorId = author.AuthorId;
            return CreatedAtAction(nameof(GetAuthorById), new { id = author.AuthorId }, authorDto);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateAuthor(int id, [FromBody] AuthorDTO authorDto)
        {
            var author = _context.Author.Find(id);
            if (author == null)
                return NotFound();

            author.AuthorName = authorDto.AuthorName;
            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAuthor(int id)
        {
            var author = _context.Author.Find(id);
            if (author == null)
                return NotFound();

            _context.Author.Remove(author);
            _context.SaveChanges();

            return NoContent();
        }
    }

}
