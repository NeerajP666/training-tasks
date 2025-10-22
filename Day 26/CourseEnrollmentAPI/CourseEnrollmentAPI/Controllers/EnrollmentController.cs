using CourseEnrollmentAPI.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;

namespace CourseEnrollmentAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class EnrollmentController : ControllerBase
    {
        private readonly AppDbContext _context;

        public EnrollmentController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost("{courseId}")]
        public IActionResult Enroll(int courseId)
        {
            int userId = int.Parse(User.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value);
            _context.Database.ExecuteSqlRaw(
                "EXEC sp_AddEnrollment @UserId={0}, @CourseId={1}", userId, courseId
            );
            return Ok("Enrolled successfully");
        }

        [HttpGet]
        public IActionResult GetEnrollments()
        {
            int userId = int.Parse(User.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value);
            var enrollments = _context.Enrollments
                .FromSqlRaw("EXEC sp_GetEnrollmentsByUserId @UserId={0}", userId)
                .ToList();
            return Ok(enrollments);
        }

        [HttpDelete("{courseId}")]
        public IActionResult Unenroll(int courseId)
        {
            int userId = int.Parse(User.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value);
            _context.Database.ExecuteSqlRaw(
                "EXEC sp_RemoveEnrollment @UserId={0}, @CourseId={1}", userId, courseId
            );
            return Ok("Unenrolled successfully");
        }
    }
}
