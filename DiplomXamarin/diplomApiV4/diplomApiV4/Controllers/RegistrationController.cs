using diplomApiV4.Security;
using Microsoft.AspNetCore.Mvc;

namespace diplomApiV4.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RegistrationController : ControllerBase
    {
        public readonly DATABASE_1Context _context;
       
        private readonly IPasswordHasher _hasher;
        private readonly ITokenService _token;
        private readonly IConfiguration configuration;
       
        public RegistrationController(DATABASE_1Context context, IPasswordHasher hasher, ITokenService token, IConfiguration configuration)
        {
            _context = context;         
            _hasher = hasher;
            _token = token;
            this.configuration = configuration;

        }
        [HttpPost("Registration")]
        public async Task<ApiResult> Registration([FromBody] Client user)
        {
            if (user == null) return new ApiResult()
            {
                IsSuccess = false,
                Message = "Пользователь не может быть null"
            };
            if (_context.Clients.Any(x => x.ClientMail == user.ClientMail))
            {
                return new ApiResult()
                {
                    IsSuccess = false,
                    Message = "Логин уже зарегистрирован"
                };
            }
            try
            {
                user.ClientId = 0;
                user.ClientPassword = _hasher.CalculateHash(user.ClientPassword);
                await _context.Clients.AddAsync(user);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return new ApiResult()
                {
                    IsSuccess = false,
                    Message = ex.InnerException.Message,
                };
            }
            return new ApiResult()
            {
                IsSuccess = true,
                Message = "Успешная регистрация"
            };
        }
    }
}
