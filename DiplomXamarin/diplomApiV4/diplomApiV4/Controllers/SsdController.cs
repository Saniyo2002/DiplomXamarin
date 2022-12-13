using Microsoft.AspNetCore.Mvc;

namespace diplomApiV4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SsdController : ControllerBase
    {
        private DATABASE_1Context _context;

        public SsdController(DATABASE_1Context context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SolidStateDrife>>> Get()
        {

            return _context.SolidStateDrives.ToList();

        }
    }
}
