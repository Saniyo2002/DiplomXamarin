using diplomApiV4.Security;
using Microsoft.AspNetCore.Mvc;

namespace diplomApiV4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PasswordRecoveryController : ControllerBase
    {
        private DATABASE_1Context _context;
        private readonly IPasswordHasher passwordHasher;

        public class ApiResult
        {
            public bool IsSuccess { get; set; }
            public string Message { get; set; }
        }
        public PasswordRecoveryController(DATABASE_1Context context, IPasswordHasher passwordHasher)
        {
            _context = context;
            this.passwordHasher = passwordHasher;
        }
        [HttpPost]

        public IActionResult Authorization(string login, string email, string dateTime)
        {

            var user = _context.Clients.ToList().FirstOrDefault(x => x.ClientNick == login && x.ClientMail == email && ((DateTime)x.ClientBirthday).ToString("dd.MM.yyyy") == dateTime);

            if (user == null) return BadRequest("Такого пользователя не существует");

           
            return Ok(new
            {
                
                User = user
            }) ;

        }
        [HttpGet("newPassword")]
        public async Task<IActionResult> NewPassword(string login, string oldPassword, string newPassword)
        {
            var user = _context.Clients.ToList().FirstOrDefault(x => x.ClientNick == login && x.ClientPassword == oldPassword);
            if(user == null) return BadRequest("Такого пользователя не существует");
            user.ClientPassword = passwordHasher.CalculateHash(newPassword);
            await _context.SaveChangesAsync();
            return Ok(new
            {

                User = user
            });
        }

        ////(string login, string email, DateTime dateTime, string pass)
    }
}
