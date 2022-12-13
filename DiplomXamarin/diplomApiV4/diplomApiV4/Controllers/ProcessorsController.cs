using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace diplomApiV4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProcessorsController : ControllerBase
    {
        private DATABASE_1Context _context;

        public ProcessorsController(DATABASE_1Context context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Processor>>> Get()
        {

            return _context.Processors.Include(x=>x.ProcessorSocket).ToList();
           

        }
    }
}
