using EntityFrameworkConsole;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BusinnesTripsController : ControllerBase
    {

        private readonly ILogger<BusinnesTripsController> _logger;

        public BusinnesTripsController(ILogger<BusinnesTripsController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetBusinessTrips")]
        public IEnumerable<BusinessTrip> Get()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var trips = db.BusinessTrips.ToList();
                return trips;
            }


        }

        [HttpGet("{id}")]
        public BusinessTrip GetById(long id)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var trip = db.BusinessTrips.FirstOrDefault(x => x.Id == id);
                return trip;
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                BusinessTrip trip = db.BusinessTrips.FirstOrDefault(x => x.Id == id);
                if (trip != null)
                {
                    db.BusinessTrips.Remove(trip);
                    db.SaveChanges();
                }
                return Ok(trip);
            }

        }

        [HttpPost]
        public IActionResult Post(BusinessTrip trip)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                if (ModelState.IsValid)
                {
                    db.BusinessTrips.Add(trip);
                    db.SaveChanges();
                    return Ok(trip);
                }
                return BadRequest(ModelState);
            }

        }

        [HttpPut]
        public IActionResult Put(BusinessTrip trip)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                if (ModelState.IsValid)
                {
                    db.Update(trip);
                    db.SaveChanges();
                    return Ok(trip);
                }
                return BadRequest(ModelState);
            }

        }
    }
}
