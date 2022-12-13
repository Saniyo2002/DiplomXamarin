using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace diplomApiV4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChipsetTypeController : ControllerBase
    {
        private DATABASE_1Context _context;

        public ChipsetTypeController(DATABASE_1Context context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ChipsetTypeMatheboard>>> Get()
        {

            return _context.ChipsetTypeMatheboards.ToList();

        }
    }
}
