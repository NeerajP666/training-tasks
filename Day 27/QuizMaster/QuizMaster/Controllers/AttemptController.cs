using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QuizMaster.Data;
using QuizMaster.DTOs;
using QuizMaster.Models;
using System.Security.Claims;

namespace QuizMaster.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class AttemptController : Controller
    {
        private readonly AppDbContext _context;

        public AttemptController(AppDbContext context)
        {
            _context = context;
        }

        public class AnswerDto
        {
            public int QuestionId { get; set; }
            public string SelectedOption { get; set; }
        }

        [HttpPost("{quizId}")]
        public IActionResult SubmitQuiz(int quizId, [FromBody] AttemptDto attemptDto)
        {
            int userId = int.Parse(User.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value);
            int score = 0;

            foreach (var ans in attemptDto.Answers)
            {
                var question = _context.Questions.FirstOrDefault(q => q.Id == ans.QuestionId && q.QuizId == quizId);
                if (question != null && question.CorrectOption.Equals(ans.SelectedOption, StringComparison.OrdinalIgnoreCase))
                    score++;
            }

            var attempt = new Attempt
            {
                UserId = userId,
                QuizId = quizId,
                Score = score,
                AttemptedOn = DateTime.Now
            };

            _context.Attempts.Add(attempt);
            _context.SaveChanges();

            return Ok(new { Message = "Quiz submitted successfully", Score = score });
        }

        [HttpGet("{quizId}")]
        public IActionResult GetAttempt(int quizId)
        {
            int userId = int.Parse(User.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value);
            var attempt = _context.Attempts.FirstOrDefault(a => a.QuizId == quizId && a.UserId == userId);
            if (attempt == null)
                return NotFound("No attempt found.");
            return Ok(attempt);
        }
    }
}
