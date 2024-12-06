using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TradianBackend.Controllers {
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class SecureContentController : ControllerBase {
        [HttpGet]
        public IActionResult GetSecret() {
            return Ok("This is a top secret file!");
        }
    }
}

