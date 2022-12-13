
using diplomApiV4.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace diplomApiV4.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        private DATABASE_1Context _context;
        private readonly IPasswordHasher _hasher;
        private readonly ITokenService _token;
        private readonly IConfiguration configuration;
        public LoginController(DATABASE_1Context context, IPasswordHasher hasher, ITokenService token, IConfiguration configuration)
        {
            _context = context;
            _hasher = hasher;
            _token = token;
            this.configuration = configuration;
        }   
        [HttpPost("Authorization")]
        public IActionResult Authorization(string login, string password)
        {

            var user = _context.Clients.FirstOrDefault(x => x.ClientNick == login);

            if (user == null) return BadRequest("Неверный логин или пароль");

            if (!_hasher.CheckPassword(password, user.ClientPassword))
            {
                return BadRequest("Неверный логин или пароль");
            }

            return Ok(new
            {
                Token = _token.BuildToken(configuration["Jwt:Key"], configuration["Jwt:Issuer"], user),
                User = user
            });

        }
        
      
    }
}
