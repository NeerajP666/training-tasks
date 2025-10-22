using CourseEnrollmentAPI.Data;
using CourseEnrollmentAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace CourseEnrollmentAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class CourseController:Controller
    {
        private readonly AppDbContext _context;

        public CourseController(AppDbContext context)
        {
            _context = context;
        }
        [HttpPost("add")]
        public IActionResult AddCourse([FromBody] Course dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var course = new Course
            {
                Title = dto.Title,
                Description = dto.Description,
                Duration = dto.Duration
            };

           
            _context.Courses.Add(course);
            _context.SaveChanges(); 

            return Ok(course);
        }


        [HttpGet]
        public IActionResult GetCourses()
        {
            var courses = _context.Courses
                .FromSqlRaw("EXEC sp_GetCourses")
                .ToList();
            return Ok(courses);
        }
    }
}
