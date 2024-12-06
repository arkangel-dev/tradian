using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TradianBackend.Database;

namespace TradianBackend.Controllers {
    [ApiController]
    [Route("[controller]")]
    public class DevController : ControllerBase {

        private readonly IConfiguration _configuration;
        private readonly DatabaseContext _dbcontext;
        public DevController(IConfiguration configuration, DatabaseContext dbcontext) {
            _configuration = configuration;
            _dbcontext = dbcontext;
        }

        [HttpPost("SeedFooterValues")]
        public IActionResult SeedData() {
            _dbcontext.FooterLinks.ExecuteDelete();
            _dbcontext.FooterSections.ExecuteDelete();
            _dbcontext.SaveChanges();

            _dbcontext.FooterSections.Add(new() {
                Section = "Quick Links",
                Links = [
                    new() { Link = "https://one.gov.mv/",  Value = "oneGov" },
                    new() { Link = "https://www.tradenet.com.mv/",  Value = "Tradenet" }
                ]
            });

            _dbcontext.FooterSections.Add(new() {
                Section = "Logistics",
                Links = [
                    new() { Link = "/articles/vessel-registration-and-eta",  Value = "Vessels" },
                    new() { Link = "/articles/logistics-shipping-agents",  Value = "Shipping Agents" },
                    new() { Link = "/articles/logistics-freight-forwarders",  Value = "Freight Forwarders" },
                    new() { Link = "/articles/logistics-courier-agent",  Value = "Courier Agents" },
                    new() { Link = "/articles/broker-registration-and-accreditation",  Value = "Brokers" },
                ]
            });

            _dbcontext.FooterSections.Add(new() {
                Section = "Terms and Policies",
                Links = [
                    new() { Link = "/terms-and-conditions",  Value = "Terms and Conditions" }
                ]
            });
            _dbcontext.SaveChanges();
            return Ok("Seed data injected");
        }
    }
}
