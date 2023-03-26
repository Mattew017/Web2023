using EntityFrameworkConsole;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VacationsController : ControllerBase
    {

        private readonly ILogger<VacationsController> _logger;

        public VacationsController(ILogger<VacationsController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetVacations")]
        public IEnumerable<Vacation> Get()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var vacations = db.Vacations.ToList();
                return vacations;
            }


        }
        [HttpGet("{id}")]
        public Vacation GetById(long id)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var vacation = db.Vacations.FirstOrDefault(x => x.Id == id);
                return vacation;
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                Vacation vacation = db.Vacations.FirstOrDefault(x => x.Id == id);
                if (vacation != null)
                {
                    db.Vacations.Remove(vacation);
                    db.SaveChanges();
                }
                return Ok(vacation);
            }

        }

        [HttpPost]
        public IActionResult Post(Vacation vacation)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                if (ModelState.IsValid)
                {
                    db.Vacations.Add(vacation);
                    db.SaveChanges();
                    return Ok(vacation);
                }
                return BadRequest(ModelState);
            }

        }

        [HttpPut]
        public IActionResult Put(Vacation vacation)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                if (ModelState.IsValid)
                {
                    db.Update(vacation);
                    db.SaveChanges();
                    return Ok(vacation);
                }
                return BadRequest(ModelState);
            }

        }
    }
}
