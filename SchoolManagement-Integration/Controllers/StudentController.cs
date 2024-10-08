using DataAccessLayer;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace SchoolManagement_Integration.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly UserManager<User> userManager;
        private readonly DataLayer db;
        private readonly IConfiguration configuration;

        public StudentController(UserManager<User> userManager, DataLayer db, IConfiguration configuration)
        {
            this.userManager = userManager;
            this.db = db;
            this.configuration = configuration;
        }

        [HttpGet(Name = "GetStudents")]
        [ProducesResponseType(200, Type = typeof(List<Student>))]
        [ProducesResponseType(400, Type = typeof(List<Student>))]
        [ProducesResponseType(500, Type = typeof(List<Student>))]
        [Authorize]
        public async Task<IActionResult> Get()
        {
            var students = await db.Students.ToListAsync();

            return Ok(students);
        }

        [HttpGet("StudentId")]
        [ProducesResponseType(200, Type = typeof(Student))]
        [ProducesResponseType(400, Type = typeof(Student))]
        [ProducesResponseType(404, Type = typeof(Student))]
        [Authorize]
        public async Task<IActionResult> GetById(int StudentId)
        {
            var student = await db.Students
                        .Where(u => u.Id == StudentId)
                        .FirstOrDefaultAsync();
            if (student == null)
            {
                return NotFound();
            }

            return Ok(student);
        }
    }
}
