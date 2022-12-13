using Microsoft.AspNetCore.Mvc;

namespace diplomApiV4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManufactureController : ControllerBase
    {
        private DATABASE_1Context _context;

        public ManufactureController(DATABASE_1Context context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Manufacturer>>> Get()
        {

            return _context.Manufacturers.ToList();

        }
    }
}
