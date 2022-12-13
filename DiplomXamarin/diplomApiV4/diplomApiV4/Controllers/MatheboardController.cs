using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace diplomApiV4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatheboardsController : ControllerBase
    {
        private DATABASE_1Context _context;

        public MatheboardsController(DATABASE_1Context context)
        {
            _context = context;
        }
        [HttpGet]
        
        public async Task<ActionResult<IEnumerable<Matheboard>>> Get()
        {
            return _context.Matheboards.Include(z => z.MatheboardSocket).Include(x=>x.MatheboardChipset).Include(c=>c.MatheboardManufacturer).Include(v=>v.ComponentType).ToList();
        }


    }
}
