using LibraryManagementApi.Data;
using LibraryManagementApi.DTOs;
using LibraryManagementApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementApi.Controllers
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
            var authors = _context.Authors
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
            var author = _context.Authors
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

            _context.Authors.Add(author);
            _context.SaveChanges();

            authorDto.AuthorId = author.AuthorId;
            return CreatedAtAction(nameof(GetAuthorById), new { id = author.AuthorId }, authorDto);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateAuthor(int id, [FromBody] AuthorDTO authorDto)
        {
            var author = _context.Authors.Find(id);
            if (author == null)
                return NotFound();

            author.AuthorName = authorDto.AuthorName;
            _context.SaveChanges();

            return NoContent();
        }

       
        [HttpDelete("{id}")]
        public IActionResult DeleteAuthor(int id)
        {
            var author = _context.Authors.Find(id);
            if (author == null)
                return NotFound();

            _context.Authors.Remove(author);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
