using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QuizMaster.Data;
using QuizMaster.Models;

namespace QuizMaster.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class QuestionController : Controller
    {
        private readonly AppDbContext _context;

        public QuestionController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult AddQuestion([FromBody] Question question)
        {
            _context.Questions.Add(question);
            _context.SaveChanges();
            return Ok("Question added successfully.");
        }

        [HttpGet("{quizId}")]
        public IActionResult GetQuestions(int quizId)
        {
            var questions = _context.Questions.Where(q => q.QuizId == quizId).ToList();
            return Ok(questions);
        }
    }
}
