using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TradianBackend.Database;

namespace TradianBackend.Controllers {
    [ApiController]
    [Route("[controller]")]
    public class FooterController : ControllerBase {

        DatabaseContext _context;
        public FooterController(DatabaseContext context) {
            _context = context;

        }

        [HttpGet] 
        public IActionResult GetFooterLinks() {
            var results = _context
                .FooterSections
                .Include(x => x.Links)
                .ToList();

            return Ok(results);
        }

    }
}
