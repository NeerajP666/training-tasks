using JWTLibraryManagement.Data;
using JWTLibraryManagement.DTOs;
using JWTLibraryManagement.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;


namespace JWTLibraryManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BooksController : Controller
    {
        private readonly AppDbContext _context;
        private readonly ILogger<BooksController> _logger;

        public BooksController(AppDbContext context, ILogger<BooksController> logger)
        {
            _context = context;
            _logger = logger;
        }
        [HttpGet]
        public IActionResult GetAllBooks()
        {
            _logger.LogInformation("GetAllBooks called"); 

            try
            {
                var books = _context.Book
                    .Include(b => b.Author)
                    .Include(b => b.Member)
                    .Select(b => new BookDTO
                    {
                        BookId = b.BookId,
                        BookName = b.BookName,
                        Genre = b.Genre,
                        AuthorId = b.AuthorId,
                        AuthorName = b.Author.AuthorName,
                        MemberId = b.MemberId,
                        MemberName = b.Member != null ? b.Member.MemberName : null
                    })
                    .ToList();

                _logger.LogInformation("GetAllBooks successful. Total books: {count}", books.Count);

                return Ok(books);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred in GetAllBooks"); 
                return StatusCode(500, "Internal server error");
            }
        }
        [HttpGet("{id}")]
        public IActionResult GetBookById(int id)
        {
            var book = _context.Book
                .Include(b => b.Author)
                .Include(b => b.Member)
                .Where(b => b.BookId == id)
                .Select(b => new BookDTO
                {
                    BookId = b.BookId,
                    BookName = b.BookName,
                    Genre = b.Genre,
                    AuthorId = b.AuthorId,
                    AuthorName = b.Author.AuthorName,
                    MemberId = b.MemberId,
                    MemberName = b.Member != null ? b.Member.MemberName : null
                })
                .FirstOrDefault();

            if (book == null)
                return NotFound("Book not found.");

            return Ok(book);
        }
        [HttpPost]
        public IActionResult AddBook([FromBody] BookDTO bookDto)
        {
            _logger.LogInformation("AddBook called with BookName: {name}", bookDto.BookName);

            if (!ModelState.IsValid)
            {
                _logger.LogWarning("AddBook failed due to invalid model state");
                return BadRequest(ModelState);
            }

            var author = _context.Author.Find(bookDto.AuthorId);
            if (author == null)
            {
                _logger.LogWarning("AddBook failed: Invalid AuthorId {authorId}", bookDto.AuthorId);
                return BadRequest("Invalid AuthorId.");
            }

            var book = new Book
            {
                BookName = bookDto.BookName,
                Genre = bookDto.Genre,
                AuthorId = bookDto.AuthorId
            };

            _context.Book.Add(book);
            _context.SaveChanges();

            _logger.LogInformation("Book added successfully with BookId: {id}", book.BookId);

            var createdBook = new BookDTO
            {
                BookId = book.BookId,
                BookName = book.BookName,
                Genre = book.Genre,
                AuthorId = book.AuthorId,
                AuthorName = author.AuthorName
            };

            return CreatedAtAction(nameof(GetBookById), new { id = book.BookId }, createdBook);

        }
        [HttpPut("borrow/{bookId}/member/{memberId}")]
        public IActionResult BorrowBook(int bookId, int memberId)
        {
            var book = _context.Book.Find(bookId);
            if (book == null)
                return NotFound("Book not found.");

            if (book.MemberId != null)
                return BadRequest("Book already borrowed by another member.");

            var member = _context.Member.Find(memberId);
            if (member == null)
                return BadRequest("Invalid MemberId.");

            book.MemberId = memberId;
            _context.SaveChanges();

            return Ok("Book borrowed successfully.");
        }
        [HttpPut("return/{bookId}")]
        public IActionResult ReturnBook(int bookId)
        {
            var book = _context.Book.Find(bookId);
            if (book == null)
                return NotFound("Book not found.");

            book.MemberId = null;
            _context.SaveChanges();

            return Ok("Book returned successfully.");
        }
        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id, [FromBody] BookDTO bookDto)
        {
            var book = _context.Book.Find(id);
            if (book == null)
                return NotFound("Book not found.");

            var author = _context.Author.Find(bookDto.AuthorId);
            if (author == null)
                return BadRequest("Invalid AuthorId.");

            book.BookName = bookDto.BookName;
            book.Genre = bookDto.Genre;
            book.AuthorId = bookDto.AuthorId;

            _context.SaveChanges();

            return Ok("Book updated successfully.");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            var book = _context.Book.Find(id);
            if (book == null)
                return NotFound("Book not found.");

            _context.Book.Remove(book);
            _context.SaveChanges();

            return Ok("Book deleted successfully.");
        }
        [HttpGet("test-crash")]
        public IActionResult TestCrash()
        {
            throw new Exception("Test crash inside controller");
        }


    }
}
