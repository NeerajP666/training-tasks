
using LibraryManagementApi.Data;
using LibraryManagementApi.DTOs;
using LibraryManagementApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly AppDbContext _context;

        public BooksController(AppDbContext context)
        {
            _context = context;
        }

    
        [HttpGet]
        public IActionResult GetAllBooks()
        {
            var books = _context.Books
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

            return Ok(books);
        }

      
        [HttpGet("{id}")]
        public IActionResult GetBookById(int id)
        {
            var book = _context.Books
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
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var author = _context.Authors.Find(bookDto.AuthorId);
            if (author == null)
                return BadRequest("Invalid AuthorId.");

            var book = new Book
            {
                BookName = bookDto.BookName,
                Genre = bookDto.Genre,
                AuthorId = bookDto.AuthorId
            };

            _context.Books.Add(book);
            _context.SaveChanges();

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
            var book = _context.Books.Find(bookId);
            if (book == null)
                return NotFound("Book not found.");

            if (book.MemberId != null)
                return BadRequest("Book already borrowed by another member.");

            var member = _context.Members.Find(memberId);
            if (member == null)
                return BadRequest("Invalid MemberId.");

            book.MemberId = memberId;
            _context.SaveChanges();

            return Ok("Book borrowed successfully.");
        }

        [HttpPut("return/{bookId}")]
        public IActionResult ReturnBook(int bookId)
        {
            var book = _context.Books.Find(bookId);
            if (book == null)
                return NotFound("Book not found.");

            book.MemberId = null;
            _context.SaveChanges();

            return Ok("Book returned successfully.");
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id, [FromBody] BookDTO bookDto)
        {
         
            var book = _context.Books.Find(id);
            if (book == null)
                return NotFound("Book not found.");

            var author = _context.Authors.Find(bookDto.AuthorId);
            if (author == null)
                return BadRequest("Invalid AuthorId.");

           
            if (bookDto.MemberId != null)
            {
                var member = _context.Members.Find(bookDto.MemberId);
                if (member == null)
                    return BadRequest("Invalid MemberId.");
                book.MemberId = bookDto.MemberId;
            }
            else
            {
                book.MemberId = null; 
            }

            book.BookName = bookDto.BookName;
            book.Genre = bookDto.Genre;
            book.AuthorId = bookDto.AuthorId;

            _context.SaveChanges();

            return Ok("Book updated successfully.");
        }

      
        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            var book = _context.Books.Find(id);
            if (book == null)
                return NotFound("Book not found.");

            _context.Books.Remove(book);
            _context.SaveChanges();

            return Ok("Book deleted successfully.");
        }
    }
}
