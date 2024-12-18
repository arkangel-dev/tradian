﻿using Microsoft.AspNetCore.Mvc;
using TradianBackend.Services;
using TradianBackend.DtoModels;
using TradianBackend.Database;
using Microsoft.AspNetCore.Authorization;

namespace TradianBackend.Controllers {


    [ApiController]
    [Route("api/[controller]")]
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

            var token = _jwtHelper.GenerateToken(loginModel.Username);



            

            Response.Cookies.Append("AuthToken", token, new CookieOptions {
                //HttpOnly = true,
                //Secure   = true,
                SameSite = SameSiteMode.Strict,
                Expires  = DateTime.Now.AddMinutes(120)
            });

            return Ok(new { Message = "Login successful" });
        }

        [HttpGet("AmILoggedIn")]
        [Authorize]
        public IActionResult AmILoggedIn() {
            return Ok();
        }
    }

}
