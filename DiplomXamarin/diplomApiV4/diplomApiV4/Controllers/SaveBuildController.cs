using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace diplomApiV4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SaveBuildController : ControllerBase
    {
        private DATABASE_1Context _context;

        public SaveBuildController(DATABASE_1Context context)
        {
            _context = context;
        }
        [HttpPost]

        public async Task<ApiResult> PostBuild([FromBody]ClientComponent clientComponent)
        {

             _context.ClientComponents.Add(clientComponent);
            await _context.SaveChangesAsync();
            return new ApiResult
            {
                IsSuccess = true,
                Message = "Сборка добавлена!"
            };
           

        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClientComponent>>> Get()
        {

            return _context.ClientComponents.Include(x=>x.Case1)
                .Include(x=>x.Client)
                .Include(x=>x.Hdd)
                .Include(x=>x.M2)
                .Include(x=>x.Matheboard)
                .Include(x=>x.PowerCase)
                .Include(x=>x.Processor)
                .Include(x=>x.Ram)
                .Include(x=>x.Ssd)
                .Include(x=>x.Videocard).ToList();

        }
    }
}
