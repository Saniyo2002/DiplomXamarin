using Microsoft.AspNetCore.Mvc;

namespace diplomApiV4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PowerCaseController : ControllerBase
    {
        private DATABASE_1Context _context;

        public PowerCaseController(DATABASE_1Context context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PowerCase>>> Get()
        {
            return _context.PowerCases.ToList();
        }

    }
}
