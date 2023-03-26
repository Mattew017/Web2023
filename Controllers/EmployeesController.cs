using EntityFrameworkConsole;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeesController : ControllerBase
    {
        
        private readonly ILogger<EmployeesController> _logger;

        public EmployeesController(ILogger<EmployeesController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetEmployees")]
        public IEnumerable<Employee> Get()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var employees = db.Employees.ToList();
                return employees;
            }

            
        }

        [HttpGet("{id}")]
        public Employee GetById(long id)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var employee = db.Employees.FirstOrDefault(x => x.Id == id);
                return employee;
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                Employee employee = db.Employees.FirstOrDefault(x => x.Id == id);
                if (employee != null)
                {
                    db.Employees.Remove(employee);
                    db.SaveChanges();
                }
                return Ok(employee);
            }

        }

        [HttpPost]
        public IActionResult Post(Employee employee)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                if (ModelState.IsValid)
                {
                    db.Employees.Add(employee);
                    db.SaveChanges();
                    return Ok(employee);
                }
                return BadRequest(ModelState);
            }

        }

        [HttpPut]
        public IActionResult Put(Employee employee)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                if (ModelState.IsValid)
                {
                    db.Update(employee);
                    db.SaveChanges();
                    return Ok(employee);
                }
                return BadRequest(ModelState);
            }

        }
    }
}