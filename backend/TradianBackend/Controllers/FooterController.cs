using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TradianBackend.Database;

namespace TradianBackend.Controllers {
    [ApiController]
    [Route("api/[controller]")]
    public class FooterController : ControllerBase {

        DatabaseContext _context;
        public FooterController(DatabaseContext context) {
            _context = context;

        }

        [HttpGet("GetFooterData")] 
        public IActionResult GetFooterLinks() {
            var results = _context
                .FooterSections
                .Include(x => x.Links)
                .ToList();

            return Ok(results);
        }

    }
}
