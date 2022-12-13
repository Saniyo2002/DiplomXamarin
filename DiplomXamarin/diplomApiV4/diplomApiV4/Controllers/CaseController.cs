
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace diplomApiV4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CaseController : ControllerBase
    {
        private DATABASE_1Context _context;

        public CaseController(DATABASE_1Context context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Case>>> Get()
        {

            return _context.Cases.Include(x=>x.CaseFactory).Include(x=>x.CaseFormFactor).Include(x=>x.ComponentType).ToList();

        }
    }
}
