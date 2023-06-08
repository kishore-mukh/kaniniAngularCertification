using Microsoft.AspNetCore.Mvc;
using StudentCRUDProjectAPI.Entity;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StudentCRUDProjectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        StudentManagementContext dbContext;

        public StudentController(StudentManagementContext dbContext)
        {
            this.dbContext = dbContext;
        }

        // GET: api/<StudentController>
        [HttpGet]
        public IEnumerable<Student> Get()
        {
            return dbContext.Students.ToList();
        }

        // GET api/<StudentController>/5
        [HttpGet("{id}")]
        public Student Get(int id)
        {
            return dbContext.Students.Where(x => x.Id == id).FirstOrDefault();
        }

        // POST api/<StudentController>
        [HttpPost]
        public void Post([FromBody] Student student)
        {
            dbContext.Students.Add(student);
            dbContext.SaveChanges();
        }

        // PUT api/<StudentController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Student value)
        {
            Student student = dbContext.Students.Where(x => x.Id == id).FirstOrDefault();
            if (student == null)
            {
                return;
            }
            student.Name = value.Name;
            student.Course = value.Course;
            student.Phone = value.Phone;
            dbContext.Students.Update(student);
            dbContext.SaveChanges();
        }

        // DELETE api/<StudentController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Student student = dbContext.Students.Where(x => x.Id == id).FirstOrDefault();
            if (student == null)
            {
                return;
            }
            dbContext.Students.Remove(student);
            dbContext.SaveChanges();
        }
    }
}
