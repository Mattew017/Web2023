using EntityFrameworkConsole;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DepartmentsController : ControllerBase
    {

        private readonly ILogger<DepartmentsController> _logger;

        public DepartmentsController(ILogger<DepartmentsController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetDepartments")]
        public IEnumerable<Department> Get()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var departments = db.Departments.ToList();
                return departments;
            }


        }

        [HttpGet("{id}")]
        public Department GetById(long id)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var department = db.Departments.FirstOrDefault(x => x.Id == id);
                return department;
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                Department department = db.Departments.FirstOrDefault(x => x.Id == id);
                if (department != null)
                {
                    db.Departments.Remove(department);
                    db.SaveChanges();
                }
                return Ok(department);
            }

        }

        [HttpPost]
        public IActionResult Post(Department department)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                if (ModelState.IsValid)
                {
                    db.Departments.Add(department);
                    db.SaveChanges();
                    return Ok(department);
                }
                return BadRequest(ModelState);
            }
            
        }

        [HttpPut]
        public IActionResult Put(Department department)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                if (ModelState.IsValid)
                {
                    db.Update(department);
                    db.SaveChanges();
                    return Ok(department);
                }
                return BadRequest(ModelState);
            }

        }
    }
}