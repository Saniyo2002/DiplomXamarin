using Microsoft.AspNetCore.Mvc;

namespace diplomApiV4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuildDeleteController : ControllerBase
    {
        private DATABASE_1Context _context;
       

        public BuildDeleteController(DATABASE_1Context context)
        {
            _context = context;
        }
        [HttpPost]
        public async Task<IActionResult> RemoveBuildClient(int idBuild)
        {
            var build = _context.ClientComponents.FirstOrDefault(x => x.ClientComponentId == idBuild);
            _context.ClientComponents.Remove(build);
            await _context.SaveChangesAsync();
            return Ok(new ApiResult
            {
                IsSuccess = true,
                Message = "Сборка удалена!"
            });
        }
    }
}
