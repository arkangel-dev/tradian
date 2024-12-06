using Microsoft.AspNetCore.Mvc;
using TradianBackend.Services;
using TradianBackend.DtoModels;
using TradianBackend.Database;

namespace TradianBackend.Controllers {


    [ApiController]
    [Route("[controller]")]
    public class AuthenticationController : ControllerBase {
        private readonly JwtHelper _jwtHelper;
        private readonly DatabaseContext _dbcontext;

        public AuthenticationController(JwtHelper jwtHelper, DatabaseContext dbcontext) {
            _jwtHelper = jwtHelper;
            _dbcontext = dbcontext;
        }

        [HttpPost("Login")]
        public IActionResult Login(LoginRequestModel loginModel) {

            var user = _dbcontext.Logins.SingleOrDefault(x =>
                x.Username == loginModel.Username &&
                x.Password == loginModel.Password
            );

            if (user is null)
                return Unauthorized(new { Message = "Invalid credentials" });


            // Replace this with actual user validation
            var token = _jwtHelper.GenerateToken(loginModel.Username);

            // Set token in a HttpOnly cookie
            Response.Cookies.Append("AuthToken", token, new CookieOptions {
                HttpOnly = true,
                Secure = true,
                SameSite = SameSiteMode.Strict,
                Expires = DateTime.UtcNow.AddMinutes(60)
            });

            return Ok(new { Message = "Login successful" });
        }
    }

}
