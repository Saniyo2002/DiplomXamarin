using Microsoft.AspNetCore.Mvc;

namespace diplomApiV4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideocardController : ControllerBase
    {
        private DATABASE_1Context _context;

        public VideocardController(DATABASE_1Context context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Videocard>>> Get()
        {

            return _context.Videocards.ToList();

        }
    }
}
