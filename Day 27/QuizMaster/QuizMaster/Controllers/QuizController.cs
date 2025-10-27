using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QuizMaster.Data;
using QuizMaster.Models;

namespace QuizMaster.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class QuizController : Controller
    {
        private readonly AppDbContext _context;

        public QuizController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult AddQuiz([FromBody] Quiz quiz)
        {
            _context.Quizzes.Add(quiz);
            _context.SaveChanges();
            return Ok("Quiz added successfully.");
        }

        [HttpGet]
        public IActionResult GetAllQuizzes()
        {
            var quizzes = _context.Quizzes.ToList();
            return Ok(quizzes);
        }
    }
}
