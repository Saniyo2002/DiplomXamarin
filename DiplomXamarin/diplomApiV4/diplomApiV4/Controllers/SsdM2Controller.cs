using Microsoft.AspNetCore.Mvc;

namespace diplomApiV4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SsdM2Controller : ControllerBase
    {
        private DATABASE_1Context _context;

        public SsdM2Controller(DATABASE_1Context context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<M2>>> Get()
        {

            return _context.M2s.ToList();

        }
    }
}
