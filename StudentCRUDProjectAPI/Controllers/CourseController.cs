using Microsoft.AspNetCore.Mvc;
using StudentCRUDProjectAPI.Entity;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StudentCRUDProjectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {

        StudentManagementContext dbContext;

        public CourseController(StudentManagementContext dbContext)
        {
            this.dbContext = dbContext;
        }

        // GET: api/<CourseController>
        [HttpGet]
        public IEnumerable<Subject> Get()
        {
            return dbContext.Subjects.ToList();
        }

        // GET api/<CourseController>/5
        [HttpGet("{id}")]
        public Subject Get(int id)
        {
            return dbContext.Subjects.Where(x => x.Id == id).FirstOrDefault();
        }

        // POST api/<CourseController>
        [HttpPost]
        public void Post([FromBody] Subject subject)
        {
            dbContext.Subjects.Add(subject);
            dbContext.SaveChanges();
        }

        // PUT api/<CourseController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Subject value)
        {
            Subject subject = dbContext.Subjects.Where(x => x.Id == id).FirstOrDefault();
            if (subject == null)
            {
                return;
            }
            subject.CourseName = value.CourseName;
            dbContext.Subjects.Update(subject);
            dbContext.SaveChanges();
        }

        // DELETE api/<CourseController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Subject subject = dbContext.Subjects.Where(x => x.Id == id).FirstOrDefault();
            if (subject == null)
            {
                return;
            }
            dbContext.Subjects.Remove(subject);
            dbContext.SaveChanges();
        }
    }
}
