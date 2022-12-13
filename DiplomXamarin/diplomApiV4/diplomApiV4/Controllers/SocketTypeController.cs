using Microsoft.AspNetCore.Mvc;

namespace diplomApiV4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocketTypeController : ControllerBase
    {
        private DATABASE_1Context _context;

        public SocketTypeController(DATABASE_1Context context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SocketType>>> Get()
        {

            return _context.SocketTypes.ToList();

        }
    }
}
