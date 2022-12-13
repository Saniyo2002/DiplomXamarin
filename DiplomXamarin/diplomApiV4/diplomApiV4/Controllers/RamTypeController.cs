using Microsoft.AspNetCore.Mvc;

namespace diplomApiV4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RamTypeController : ControllerBase
    {
        private DATABASE_1Context _context;

        public RamTypeController(DATABASE_1Context context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RamType>>> Get()
        {

            return _context.RamTypes.ToList();

        }
    }
}
