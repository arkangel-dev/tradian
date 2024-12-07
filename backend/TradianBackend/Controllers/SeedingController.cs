using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TradianBackend.Database;

namespace TradianBackend.Controllers {
    [ApiController]
    [Route("api/[controller]")]
    public class SeedingController : ControllerBase {

        private readonly IConfiguration _configuration;
        private readonly DatabaseContext _dbcontext;
        public SeedingController(IConfiguration configuration, DatabaseContext dbcontext) {
            _configuration = configuration;
            _dbcontext = dbcontext;
        }

        [HttpGet("SeedFooterValues")]
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

        [HttpGet("SeedPostsValues")]
        public IActionResult SeedPosts() {
            _dbcontext.Posts.ExecuteDelete();
            _dbcontext.SaveChanges();
            var fileReadingEncoding = System.Text.Encoding.ASCII;

            _dbcontext.Posts.Add(new Database.Entities.Post() {
                Body        = System.IO.File.ReadAllText("Posts/post1.md", fileReadingEncoding),
                Title       = "Mastering the Art of Trading: A Beginner's Perspective",
                Description = "A beginner-friendly guide to trading, offering essential tips on starting small, managing risk, developing strategies, and maintaining discipline to navigate the market confidently. Perfect for those looking to master the basics and build a solid foundation in trading."
            });

            _dbcontext.Posts.Add(new Database.Entities.Post() {
                Body        = System.IO.File.ReadAllText("Posts/post2.md", fileReadingEncoding),
                Title       = "Prohibited Items in the Maldives: What You Need to Know",
                Description = "A comprehensive guide to the items prohibited in the Maldives, including alcohol, narcotics, religious materials, and marine resources. Learn what to avoid bringing to ensure a smooth and enjoyable visit to this tropical paradise"
            });

            _dbcontext.Posts.Add(new Database.Entities.Post() {
                Body        = System.IO.File.ReadAllText("Posts/post3.md", fileReadingEncoding),
                Title       = "The Unspoken Rules: Insider Trading Secrets Revealed",
                Description = "An in-depth guide that explores strategies for navigating the complexities of insider trading while maintaining discretion. This article delves into networking, timing, and maintaining a low profile, offering insights for those intrigued by high-stakes financial maneuvers. (Disclaimer: For entertainment purposes only.)",
                IsSecured   = true
            });

            _dbcontext.Posts.Add(new Database.Entities.Post() {
                Body        = System.IO.File.ReadAllText("Posts/post4.md", fileReadingEncoding),
                Title       = "The Ultimate Guide to Pulling Off a Rug Pull: Mastering the Art of Disappearing",
                Description = "A comprehensive guide exploring the steps and strategies behind executing a rug pull in the cryptocurrency and DeFi space. From building hype and creating a token to managing liquidity and vanishing without a trace, this article delves into the mechanics behind one of the most controversial maneuvers in crypto. (Disclaimer: For informational purposes only.)",
                IsSecured   = true
            });

            _dbcontext.Posts.Add(new Database.Entities.Post() {
                Body        = System.IO.File.ReadAllText("Posts/post5.md", fileReadingEncoding),
                Title       = "The Art of Money Laundering: A \"Hypothetical\" Guide",
                Description = "A detailed exploration of the steps and techniques commonly associated with money laundering, from disguising illicit funds to integrating them into the legitimate economy. This article offers insights into the complexities and risks of navigating financial systems with illicit intentions. (Disclaimer: For informational and entertainment purposes only.)",
                IsSecured   = true
            });

            _dbcontext.Posts.Add(new Database.Entities.Post() {
                Body        = System.IO.File.ReadAllText("Posts/post6.md", fileReadingEncoding),
                Title       = "How to Buy Computer Parts Online and Save Money",
                Description = "A comprehensive guide to buying computer parts online, covering everything from understanding your needs and researching components to finding deals and ensuring secure purchases. Learn how to save money and build your ideal PC by shopping smarter online",
                IsSecured   = false
            });

            _dbcontext.Posts.Add(new Database.Entities.Post() {
                Body        = System.IO.File.ReadAllText("Posts/post7.md", fileReadingEncoding),
                Title       = "How to Find Lost Shipping Containers from the Port",
                Description = "A detailed guide on locating lost shipping containers at ports, covering common reasons for misplacement, utilizing tracking systems, coordinating with customs, and conducting physical searches. Includes tips on preventive measures to avoid future losses and streamline container management.",
                IsSecured   = false
            });

            _dbcontext.Posts.Add(new Database.Entities.Post() {
                Body        = System.IO.File.ReadAllText("Posts/post8.md", fileReadingEncoding),
                Title       = "How to Make a Spaghetti Sandwich",
                Description = "A step-by-step guide on making a delicious spaghetti sandwich, perfect for repurposing leftover pasta. This article covers everything from ingredients and assembly to toasting techniques and creative variations, offering a unique twist on a comforting classic.",
                IsSecured   = false
            });

            _dbcontext.SaveChanges();
            return Ok("Seed data injected");
        }
    }
}
