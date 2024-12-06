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
        public IActionResult SeetFooterLinks() {
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

        [HttpPost("SeedPostsValues")]
        public IActionResult SeedPosts() {
            _dbcontext.Posts.ExecuteDelete();
            _dbcontext.SaveChanges();

            _dbcontext.Posts.Add(new Database.Entities.Post() {
                Body = System.IO.File.ReadAllText("Posts/post1.md"),
                Title = "Mastering the Art of Trading: A Beginner's Perspective",
                Description = "A beginner-friendly guide to trading, offering essential tips on starting small, managing risk, developing strategies, and maintaining discipline to navigate the market confidently. Perfect for those looking to master the basics and build a solid foundation in trading."
            });

            _dbcontext.Posts.Add(new Database.Entities.Post() {
                Body = System.IO.File.ReadAllText("Posts/post2.md"),
                Title = "Prohibited Items in the Maldives: What You Need to Know",
                Description = "A comprehensive guide to the items prohibited in the Maldives, including alcohol, narcotics, religious materials, and marine resources. Learn what to avoid bringing to ensure a smooth and enjoyable visit to this tropical paradise"
            });

            _dbcontext.Posts.Add(new Database.Entities.Post() {
                Body = System.IO.File.ReadAllText("Posts/post3.md"),
                Title = "The Unspoken Rules: Insider Trading Secrets Revealed",
                Description = "An in-depth guide that explores strategies for navigating the complexities of insider trading while maintaining discretion. This article delves into networking, timing, and maintaining a low profile, offering insights for those intrigued by high-stakes financial maneuvers. (Disclaimer: For entertainment purposes only.)",
                IsSecured = true
            });

            _dbcontext.Posts.Add(new Database.Entities.Post() {
                Body = System.IO.File.ReadAllText("Posts/post4.md"),
                Title = "The Ultimate Guide to Pulling Off a Rug Pull: Mastering the Art of Disappearing",
                Description = "A comprehensive guide exploring the steps and strategies behind executing a rug pull in the cryptocurrency and DeFi space. From building hype and creating a token to managing liquidity and vanishing without a trace, this article delves into the mechanics behind one of the most controversial maneuvers in crypto. (Disclaimer: For informational purposes only.)",
                IsSecured = true
            });

            _dbcontext.Posts.Add(new Database.Entities.Post() {
                Body = System.IO.File.ReadAllText("Posts/post5.md"),
                Title = "The Art of Money Laundering: A \"Hypothetical\" Guide",
                Description = "A detailed exploration of the steps and techniques commonly associated with money laundering, from disguising illicit funds to integrating them into the legitimate economy. This article offers insights into the complexities and risks of navigating financial systems with illicit intentions. (Disclaimer: For informational and entertainment purposes only.)",
                IsSecured = true
            });

            _dbcontext.SaveChanges();
            return Ok("Seed data injected");
        }
    }
}
