using DataAccessLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SchoolManagement_Integration.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        public StudentController()
        {

        }

        [HttpGet(Name = "Get Students")]
        public IEnumerable<Student> Get()
        {
            List<Student> student = new List<Student>();

            return student;
        }
    }
}
