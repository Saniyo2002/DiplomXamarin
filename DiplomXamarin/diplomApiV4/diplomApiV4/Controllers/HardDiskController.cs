using Microsoft.AspNetCore.Mvc;

namespace diplomApiV4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HardDiskController : ControllerBase
    {
        private DATABASE_1Context _context;

        public HardDiskController(DATABASE_1Context context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HardDisk>>> Get()
        {

            return _context.HardDisks.ToList();

        }
    }
}
