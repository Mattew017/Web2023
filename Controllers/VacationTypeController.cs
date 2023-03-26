using EntityFrameworkConsole;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VacationTypeController : ControllerBase
    {

        private readonly ILogger<VacationTypeController> _logger;

        public VacationTypeController(ILogger<VacationTypeController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetVacationTypes")]
        public IEnumerable<VacationType> Get()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var types = db.VacationTypes.ToList();
                return types;
            }


        }







    }
}
