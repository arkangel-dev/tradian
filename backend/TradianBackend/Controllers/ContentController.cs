using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TradianBackend.Database;

namespace TradianBackend.Controllers {
    [ApiController]
    [Route("api/[controller]")]
    public class ContentController : ControllerBase {

        private readonly IConfiguration _configuration;
        private readonly DatabaseContext _dbcontext;
        public ContentController(IConfiguration configuration, DatabaseContext dbcontext) {
            _configuration = configuration;
            _dbcontext = dbcontext;
        }

        [HttpGet("Posts")]
        public IActionResult GetAvailablePosts(
            [FromQuery(Name = "query")]
            string? SearchQuery = null,

            [FromQuery(Name = "count")]
            int count = 3
        ) {
            var content = _dbcontext
                .Posts
                .AsQueryable();

            if (!String.IsNullOrEmpty(SearchQuery)) {
                SearchQuery = SearchQuery.ToLower();
                content = content
                    .Where(x =>
                        x.Title.ToLower().Contains(SearchQuery) ||
                        x.Description.ToLower().Contains(SearchQuery) ||
                        x.Body.ToLower().Contains(SearchQuery)
                );
            }

            if (!HttpContext.User.Identity?.IsAuthenticated ?? false)
                content = content.Where(x => !x.IsSecured);

            var results = content.Select(x => new { x.Id, x.Title, x.Description, x.IsSecured }).Take(count);
            return Ok(new {
                Count = content.Count(),
                Results = results
            });
        }

        [HttpGet("Posts/{PostId}")]
        public IActionResult Post(Guid PostId) {
            var post = _dbcontext.Posts.Find(PostId);
            if (post is null) return NotFound();
            if (post.IsSecured && !(HttpContext.User.Identity?.IsAuthenticated ?? false)) return StatusCode(401);
            return Ok(post);
        }


        [HttpGet("Support")]
        public IActionResult GetAvailableSupportPages(
            [FromQuery(Name = "query")]
            string? SearchQuery = null,

            [FromQuery(Name = "count")]
            int count = 3
        ) {
            var content = _dbcontext
                .Pages
                .Where(x => x.Type == Database.Entities.PageType.SupportPage);

            if (!String.IsNullOrEmpty(SearchQuery)) {
                SearchQuery = SearchQuery.ToLower();
                content = content
                    .Where(x =>
                        x.Title.ToLower().Contains(SearchQuery) ||
                        x.Description.ToLower().Contains(SearchQuery) ||
                        x.Body.ToLower().Contains(SearchQuery)
                );
            }

            var results = content.Select(x => new { x.SlugId, x.Image, x.Title, x.Description, x.PostedDate }).Take(count);
            return Ok(new {
                Count = content.Count(),
                Results = results
            });
        }


        [HttpGet("Support/{supportid}")]
        public IActionResult Support(string supportid) {
            var post = _dbcontext.Pages.Find(supportid);
            if (post is null || post.Type != Database.Entities.PageType.SupportPage) return NotFound();
            return Ok(post);
        }

        [HttpGet("News")]
        public IActionResult GetAvailableNewsPosts(
            [FromQuery(Name = "query")]
            string? SearchQuery = null,

            [FromQuery(Name = "count")]
            int count = 3
        ) {
            var content = _dbcontext
                .Pages
                .Where(x => x.Type == Database.Entities.PageType.NewsPost);

            if (!String.IsNullOrEmpty(SearchQuery)) {
                SearchQuery = SearchQuery.ToLower();
                content = content
                    .Where(x =>
                        x.Title.ToLower().Contains(SearchQuery) ||
                        x.Description.ToLower().Contains(SearchQuery) ||
                        x.Body.ToLower().Contains(SearchQuery)
                );
            }

            var results = content.Select(x => new { x.SlugId, x.Image, x.Title, x.Description, x.PostedDate }).Take(count);
            return Ok(new {
                Count = content.Count(),
                Results = results
            });
        }

        [HttpGet("News/{newsId}")]
        public IActionResult News(string newsId) {
            var post = _dbcontext.Pages.Find(newsId);
            if (post is null || post.Type != Database.Entities.PageType.NewsPost) return NotFound();
            return Ok(post);
        }
    }
}

